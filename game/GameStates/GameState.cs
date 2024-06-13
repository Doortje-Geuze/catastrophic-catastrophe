using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;
using Blok3Game.Engine.GameObjects;
using Blok3Game.Engine.Helpers;
using Blok3Game.Engine.JSON;
using Blok3Game.Engine.SocketIOClient;
using Blok3Game.GameObjects;
using Blok3Game.SpriteGameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Blok3Game.GameStates
{
    public class GameState : GameObjectList
    {
        //all lists, objects and variables at the start of the game for the gamestate are created here
        private List<PlayerBullet> playerBulletList;
        private List<EnemyBullet> enemyBulletList;
        private List<Grenade> grenadeList;
        private List<GrenadeCollisionBox> grenadeCollisionsList;
        public BossKanarien bossKanarie;
        private List<Enemy> enemyList;
        private List<Currency> currencyList;
        public List<GameObject> toRemoveList;
        private List<Box> boxList;
        public static GameState Instance { get; private set; }
        public Player player;
        public Crosshair crosshair;
        public CatGun catGun;
        public Box box;
        public YellowBox yellowBox;
        public GrenadeCollisionBox grenadeCollisionBox;
        public PurpleBox purpleBox;
        public ShootingEnemy shootingEnemy;
        public FastEnemy fastEnemy;
        public DashIndicator dashIndicator;
        public WaveIndicator waveIndicator;
        public TextGameObject playerHealth;
        public TextGameObject playerCurrency;
        public Shopkeeper shopkeeper;
        public int WaveCounter = 0;
        public int ChosenEnemy = 0;
        public int FramesPerSecond = 60;
        private int WaveIndicatorShowTime = -20;
        private bool NewWave = true;
        private SpriteGameObject background;
        public TextGameObject chooseUpgrade;
        public int PlayerShootCooldown = 0;
        public int PlayerAttackTimes = 0;
        public int PlayerBulletSpeed = 18;
        private bool pickedUpPurple = false;
        private bool pickedUpYellow = false;
        private bool waveRemoved = false;
        private int BossCooldown = 120;
        public bool grenadeKaboom = false;
        private bool bossWave = false;
        private int BossWalking = 0;
        private bool bossSchoot = false;
        private int BossShowAnimation = 60;
        private bool playerWin = false;
        public Door Door;
        public bool EnteredDoor = false;
        public bool DoorSpawned = false;
        private int DoorCounter = 0;

        public GameState() : base()
        {
            if (Instance != null)
            {
                throw new Exception("Only one instance of GameState is allowed");
            }

            Instance = this;
            CreateBackground();

            //List creator
            enemyList = new List<Enemy>();
            playerBulletList = new List<PlayerBullet>();
            enemyBulletList = new List<EnemyBullet>();
            grenadeList = new List<Grenade>();
            currencyList = new List<Currency>();
            boxList = new List<Box>();
            toRemoveList = new List<GameObject>();
            grenadeCollisionsList = new List<GrenadeCollisionBox>();

            player = new Player(3, 5, new Vector2((GameEnvironment.Screen.X / 2) - (90 / 2), (GameEnvironment.Screen.Y / 2) - (90 / 2)));
            Add(player);

            crosshair = new Crosshair(new Vector2(Mouse.GetState().X, Mouse.GetState().Y));
            Add(crosshair);

            Door = new OpenDoor(new Vector2(1113, 200));

            shopkeeper = new Shopkeeper(new Vector2(50, GameEnvironment.Screen.Y / 2));

            catGun = new CatGun(player, crosshair, new Vector2(10, 10));
            Add(catGun);

            playerHealth = new TextGameObject("Fonts/SpriteFont@20px", 1);
            Add(playerHealth);
            playerHealth.Text = $"{player.HitPoints}";
            playerHealth.Color = new(255, 255, 255);
            playerHealth.Parent = player;

            playerCurrency = new TextGameObject("Fonts/SpriteFont@20px", 1);
            Add(playerCurrency);
            playerCurrency.Text = $"you collected {player.currencyCounter} currency";
            playerHealth.Color = new(255, 255, 255);
            playerCurrency.Position = new Vector2(5, 5);

            dashIndicator = new DashIndicator(Vector2.Zero);
            Add(dashIndicator);
            dashIndicator.Parent = player;

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            // The Waves controller
            switch (WaveCounter)
            {
                case 0: //Wave 1
                    if (enemyList.Count == 0)
                    {
                        WaveCounter++;
                        NewWave = true;
                        WaveIndicatorShowTime = 0;
                        ResetBullets();
                        SpawnStandardEnemies();
                    }
                    break;
                case 1: //Wave 2
                    if (enemyList.Count == 0)
                    {
                        if (boxList.Count == 0 && !pickedUpPurple)
                        {
                            //Shotgun upgrade
                            purpleBox = new PurpleBox(new Vector2(GameEnvironment.Screen.X / 2, 150));
                            boxList.Add(purpleBox);

                            Add(purpleBox);

                            chooseUpgrade = new TextGameObject("Fonts/SpriteFont@20px", 1);
                            Add(chooseUpgrade);
                            chooseUpgrade.Text = $"The bird is coming... Take this!";
                            chooseUpgrade.Color = new(255, 255, 255);
                            chooseUpgrade.Position = new Vector2(GameEnvironment.Screen.X / 2 - chooseUpgrade.Size.X / 2, 200);
                        }
                        else if (pickedUpPurple && !DoorSpawned && !shopkeeper.Exists)
                        {
                            Add(Door);
                            Add(shopkeeper);
                            shopkeeper.Exists = true;
                            DoorSpawned = true;
                        }

                        boxCollision();

                        if (DoorSpawned)
                        {
                            DoorCollision();
                            if (shopkeeper.Exists && shopkeeper.HandleCollision(player))
                            {
                                player.Position = new Vector2((GameEnvironment.Screen.X / 2) - (player.Width / 2), (GameEnvironment.Screen.Y / 2) - (player.Height / 2));
                                GameEnvironment.GameStateManager.SwitchToState("SHOP_STATE");
                            }
                        }

                        if (EnteredDoor == true)
                        {
                            Remove(Door);
                            WaveCounter++;
                            NewWave = true;
                            WaveIndicatorShowTime = 0;
                            ResetBullets();
                            SpawnFastEnemies();
                            EnteredDoor = false;
                            DoorSpawned = false;
                            shopkeeper.Exists = false;
                            Remove(shopkeeper);
                        }
                    }
                    break;
                case 2: //Boss wave
                    if (enemyList.Count == 0)
                    {
                        if (!DoorSpawned && !shopkeeper.Exists)
                        {
                            Add(Door);
                            Add(shopkeeper);
                            shopkeeper.Exists = true;
                            DoorSpawned = true;
                        }

                        boxCollision();

                        if (DoorSpawned)
                        {
                            DoorCollision();
                            if (shopkeeper.Exists && shopkeeper.HandleCollision(player))
                            {
                                player.Position = new Vector2((GameEnvironment.Screen.X / 2) - (player.Width / 2), (GameEnvironment.Screen.Y / 2) - (player.Height / 2));
                                GameEnvironment.GameStateManager.SwitchToState("SHOP_STATE");
                            }
                        }

                        if (EnteredDoor == true)
                        {
                            Remove(Door);
                            WaveCounter++;
                            NewWave = true;
                            WaveIndicatorShowTime = 0;
                            ResetBullets();
                            EnteredDoor = false;
                            DoorSpawned = false;
                            shopkeeper.Exists = false;
                            Remove(shopkeeper);

                            bossKanarie = new BossKanarien(50, 1, new Vector2(-15, GameEnvironment.Screen.Y / 2));
                            Add(bossKanarie);
                            bossWave = true;
                        }
                    }
                    break;
                case 3: //Player Wins
                    if (playerWin)
                    {
                        if (DoorCounter < 1)
                        {
                            Add(Door);
                            DoorSpawned = true;
                            DoorCounter++;
                        }

                        if (DoorSpawned)
                        {
                            DoorCollision();
                        }

                        if (EnteredDoor == true)
                        {
                            GameEnvironment.GameStateManager.SwitchToState("WIN_SCREEN_STATE");
                            toRemoveList.Add(Door);
                            DoorCounter = 0;
                            ResetBullets();
                            EnteredDoor = false;
                            DoorSpawned = false;
                        }
                    }
                    break;
            }

            //Shows to the player which wave it is
            ShowWaveIndicator();

            //switches to lose screen if player's HP falls below 0
            if (player.HitPoints <= 0)
            {
                Retry();
                GameEnvironment.GameStateManager.SwitchToState("LOSE_SCREEN_STATE");
                SocketClient.Instance.SendDataPacket(new MatchData
                {
                    TotalWavesSurvived = WaveCounter,
                    KilledBy = "rat",
                    Kills = player.currencyCounter,
                    HealthLeft = player.HitPoints
                });
            }

            foreach (Grenade grenade in grenadeList)
            {
                grenade.HandleCollision(grenadeCollisionBox);
            }

            foreach (GrenadeCollisionBox collisionBox in grenadeCollisionsList)
            {
                if (collisionBox.hit)
                {
                    toRemoveList.Add(collisionBox);
                }
            }

            if (PlayerShootCooldown != 0)
            {
                PlayerShootCooldown--;
            }

            foreach (var enemyBullet in enemyBulletList)
            {
                player.HandleCollision(enemyBullet);
            }

            foreach (var currency in currencyList)
            {
                player.HandleCollision(currency);
            }
            foreach (var grenade in grenadeList)
            {
                if (grenadeKaboom)
                {
                    BirdGrenadeExplode(grenade);
                }
            }

            if (bossWave)
            {
                foreach (var playerBullet in playerBulletList)
                {
                    if (playerBullet.HandleCollision(bossKanarie))
                    {
                        if (bossKanarie.HitPoints > 0)
                        {
                            bossKanarie.HitPoints--;
                            bossKanarie.InvulnerabilityCooldown = 10;
                        }
                        if (bossKanarie.HitPoints <= 0)
                        {
                            Currency currency = new(bossKanarie.Position + new Vector2(bossKanarie.Width / 2, bossKanarie.Height / 2))
                            {
                                Scale = 2
                            };
                            currencyList.Add(currency);
                            Add(currency);

                            toRemoveList.Add(bossKanarie);
                            bossWave = false;
                            playerWin = true;
                        }
                        toRemoveList.Add(playerBullet);
                    }
                }

                //if-statement that flashes red colouring over the boss to indicate that they have been hit
                if (bossKanarie.InvulnerabilityCooldown >= 0)
                {
                    if (bossKanarie.InvulnerabilityCooldown > 1)
                    {
                        bossKanarie.Shade = new Color(255, 0, 0);
                    }
                    else bossKanarie.Shade = new Color(255, 255, 255);

                    bossKanarie.InvulnerabilityCooldown--;
                }

                if (BossWalking != 0)
                {
                    bossKanarie.Velocity = new Vector2(0, 0);
                    bossKanarie.Sprite.SheetIndex = 0;
                    BossWalking--;
                }
                else if (BossWalking <= 0 && !bossSchoot)
                {
                    bossKanarie.EnemySeeking(player.Position);
                    bossKanarie.DoWalking();
                }

                if (bossSchoot)
                {
                    if (BossShowAnimation > 0)
                    {
                        bossKanarie.DoShooting();
                        BossShowAnimation--;
                    }
                    else if (BossShowAnimation <= 0)
                    {
                        EnemyShoots(bossKanarie);
                        BossCooldown = 120;
                        bossKanarie.Sprite.SheetIndex = 0;
                        bossSchoot = false;
                        BossShowAnimation = 60;
                    }
                }

                if (BossCooldown >= 0)
                {
                    if (BossCooldown == 10 && BossWalking <= 0)
                    {
                        BossWalking = 20;
                    }
                    BossCooldown--;
                }
                else if (BossCooldown <= 0 && !bossSchoot)
                {
                    Random random = new Random();
                    int attack = random.Next(0, 2);
                    Debug.WriteLine(attack);

                    switch (attack)
                    {
                        case 0: //SCHIET
                            bossSchoot = true;
                            break;
                        case 1:
                            BirdGrenade(bossKanarie);
                            BossCooldown = 120;
                            break;
                    }
                }
            }
            else
            {
                foreach (Enemy enemy in enemyList) // Tells every enemy where to go, when to shoot and what to do when it collides with the player. Does the same for the PlayerBullets
                {
                    enemy.EnemySeeking(player.Position);

                    if (enemy.EnemyShootCooldown >= 120 && enemy is not FastEnemy fastEnemy)
                    {
                        EnemyShoots(enemy);
                        enemy.EnemyShootCooldown = 0;
                    }
                    enemy.EnemyShootCooldown++;

                    player.HandleCollision(enemy);
                    foreach (var playerBullet in playerBulletList)
                    {
                        if (playerBullet.HandleCollision(enemy))
                        {
                            if (enemy.HitPoints > 0)
                            {
                                enemy.HitPoints--;
                            }
                            if (enemy.HitPoints <= 0)
                            {
                                Currency currency = new(enemy.Position + new Vector2(enemy.Width / 2, enemy.Height / 2))
                                {
                                    Scale = 2
                                };
                                currencyList.Add(currency);
                                Add(currency);

                                toRemoveList.Add(enemy);
                            }

                            toRemoveList.Add(playerBullet);
                        }

                    }
                }
            }

            //switches to lose screen if player's HP falls below 0
            if (player.HitPoints <= 0)
            {
                GameEnvironment.GameStateManager.SwitchToState("LOSE_SCREEN_STATE");
                player.HitPoints = player.BaseHitPoints;
                playerHealth.Text = $"{player.HitPoints}";
                ResetBullets();
            }
            //if-statement that flashes red colouring over the player to indicate that they have been hit, and are currently invulnerable
            if (player.InvulnerabilityCooldown >= 0)
            {
                if (player.InvulnerabilityCooldown % (FramesPerSecond / 2) > (FramesPerSecond / 4))
                {
                    player.Shade = new Color(255, 0, 0);
                }
                if (player.InvulnerabilityCooldown % (FramesPerSecond / 2) < (FramesPerSecond / 4))
                {
                    player.Shade = new Color(255, 255, 255);
                }
            }
            //removes all objects that are put in the toRemoveList. We use this because we can't remove items from a list while using a foreach-loop on it
            foreach (var gameObject in toRemoveList)
            {
                if (gameObject is PlayerBullet playerBullet)
                {
                    playerBulletList.Remove(playerBullet);
                }
                if (gameObject is Enemy enemy)
                {
                    enemyList.Remove(enemy);
                }
                if (gameObject is EnemyBullet enemyBullet)
                {
                    enemyBulletList.Remove(enemyBullet);
                }
                if (gameObject is Currency currency)
                {
                    currencyList.Remove(currency);
                    player.currencyCounter += 1;
                }
                if (gameObject is PurpleBox box)
                {
                    boxList.Remove(box);
                }
                if (gameObject is GrenadeCollisionBox grenadeCollisionBox)
                {
                    grenadeCollisionsList.Remove(grenadeCollisionBox);
                }
                if (gameObject is Grenade grenade)
                {
                    grenadeList.Remove(grenade);
                }
                Remove(gameObject);
            }
            toRemoveList.Clear();

            //switches to lose screen if player's HP falls below 0
            if (player.HitPoints <= 0)
            {
                Retry();
                GameEnvironment.GameStateManager.SwitchToState("SHOP_STATE");
            }
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);

            if (inputHelper.MouseLeftButtonPressed && PlayerShootCooldown == 0)
            {
                PlayerShoot(inputHelper.MousePosition.X, inputHelper.MousePosition.Y);
            }
        }

        private void SpawnStandardEnemies()
        {
            Random random = new Random();

            int swap = 0;
            //For-loop om meerdere enemies aan te maken
            for (int i = 0; i < 10 * WaveCounter; i++)
            {
                int XPosition, YPosition;

                //Willekeurige posities waar de enemies spawnen
                XPosition = random.Next(0 - 250, GameEnvironment.Screen.X + 650);
                YPosition = random.Next(0 - 250, GameEnvironment.Screen.Y + 650);

                //Do-While loop die ervoor zorgt dat de enemies aan de buiten randen spawnen 
                //De swap variabele zorgt ervoor dat de enemies evenredig worden verdeel aan alle kanten
                do
                {
                    if (swap % 2 == 0)
                    {
                        XPosition = random.Next(0 - 250, GameEnvironment.Screen.X + 650);
                        swap++;
                    }
                    else
                    {
                        YPosition = random.Next(0 - 250, GameEnvironment.Screen.Y + 650);
                        swap++;
                    }
                } while (XPosition >= 0 - 150 && XPosition <= GameEnvironment.Screen.X + 150 &&
                         YPosition >= 0 - 150 && YPosition <= GameEnvironment.Screen.Y + 150);

                //Aanmaken van de enemies
                shootingEnemy = new ShootingEnemy(1, 1, new Vector2(XPosition, YPosition));
                enemyList.Add(shootingEnemy);

                Add(shootingEnemy);
            }
        }

        private void SpawnFastEnemies()
        {
            Random random = new Random();

            int swap = 0;
            //For-loop om meerdere enemies aan te maken
            for (int i = 0; i < 10 * WaveCounter; i++)
            {
                int XPosition, YPosition;

                //Willekeurige posities waar de enemies spawnen
                XPosition = random.Next(0 - 300, GameEnvironment.Screen.X + 700);
                YPosition = random.Next(0 - 300, GameEnvironment.Screen.Y + 700);


                //Do-While loop die ervoor zorgt dat de enemies aan de buiten randen spawnen 
                //De swap variabele zorgt ervoor dat de enemies evenredig worden verdeel aan alle kanten
                do
                {
                    if (swap % 2 == 0)
                    {
                        XPosition = random.Next(0 - 300, GameEnvironment.Screen.X + 700);
                        swap++;
                    }
                    else
                    {
                        YPosition = random.Next(0 - 300, GameEnvironment.Screen.Y + 700);
                        swap++;
                    }

                } while (XPosition >= 0 - 200 && XPosition <= GameEnvironment.Screen.X + 200 &&
                         YPosition >= 0 - 200 && YPosition <= GameEnvironment.Screen.Y + 200);

                //Aanmaken van de enemies
                fastEnemy = new FastEnemy(1, 4, new Vector2(XPosition, YPosition));

                enemyList.Add(fastEnemy);
                Add(fastEnemy);
            }
        }

        private void PlayerShoot(float MousePositionX, float MousePositionY)
        {
            float ShootPositionX = player.Position.X + player.Width / 2;
            float ShootPositionY = player.Position.Y + player.Height / 2;
            double bulletAngle = Math.Atan2(MousePositionY - ShootPositionY, MousePositionX - ShootPositionX);

            //Shotgun Upgrade
            if (pickedUpPurple)
            {
                for (int i = -1; i < 2; i++)
                {
                    PlayerBullet playerBullet = new(new Vector2(ShootPositionX, ShootPositionY), bulletAngle - 0.3f * i, PlayerBulletSpeed);
                    playerBulletList.Add(playerBullet);
                    Add(playerBullet);
                }
            }
            else
            {
                PlayerBullet playerBullet = new(new Vector2(ShootPositionX, ShootPositionY), bulletAngle, PlayerBulletSpeed);
                playerBulletList.Add(playerBullet);
                Add(playerBullet);
            }

            //Lower Cooldown Upgrade
            if (pickedUpYellow)
            {
                PlayerShootCooldown = 5;
            }
            else
            {
                PlayerShootCooldown = 8;
            }
        }

        private void EnemyShoots(Enemy enemy)
        {
            float ShootPositionX = enemy.Position.X + enemy.Width / 2;
            float ShootPositionY = enemy.Position.Y + enemy.Height / 2;
            double bulletAngle = Math.Atan2((player.Position.Y + player.Height / 2) - ShootPositionY, (player.Position.X + player.Width / 2) - ShootPositionX);

            int bulletMoveSpeed = 15;
            if (bossSchoot)
            {
                bulletMoveSpeed = 25;
            }

            EnemyBullet enemyBullet = new(new Vector2(ShootPositionX, ShootPositionY), bulletAngle, bulletMoveSpeed);

            enemyBulletList.Add(enemyBullet);
            Add(enemyBullet);
        }

        private void BirdGrenade(Enemy enemy)
        {
            float ShootPositionX = enemy.Position.X + enemy.Width / 2;
            float ShootPositionY = enemy.Position.Y + enemy.Height / 2;

            double bulletAngle = Math.Atan2((player.Position.Y + player.Height / 2) - ShootPositionY, (player.Position.X + player.Width / 2) - ShootPositionX);

            grenadeCollisionBox = new GrenadeCollisionBox(new Vector2(player.Position.X + player.Width / 2, player.Position.Y + player.Height / 2));
            grenadeCollisionsList.Add(grenadeCollisionBox);
            Add(grenadeCollisionBox);

            Grenade grenade = new(new Vector2(ShootPositionX, ShootPositionY), new Vector2(grenadeCollisionBox.Position.X, grenadeCollisionBox.Position.Y), bulletAngle, 15, grenadeCollisionBox)
            {
                Gamestate = this
            };
            grenadeList.Add(grenade);
            Add(grenade);
        }

        public void BirdGrenadeExplode(Grenade grenade)
        {
            float ShootPositionX = grenade.Position.X;
            float ShootPositionY = grenade.Position.Y;

            double bulletAngle = Math.Atan2((player.Position.Y + player.Height / 2) - ShootPositionY, (player.Position.X + player.Width / 2) - ShootPositionX);

            for (int i = -1; i < 8; i++)
            {
                EnemyBullet enemyBullet = new(new Vector2(ShootPositionX, ShootPositionY), bulletAngle - 0.7f * i, 10);
                enemyBulletList.Add(enemyBullet);
                Add(enemyBullet);
            }
            grenadeKaboom = false;

            toRemoveList.Add(grenade);
        }

        private void boxCollision()
        {
            foreach (Box box in boxList)
            {
                if (player.CheckForPlayerCollision(box))
                {
                    toRemoveList.Add(box);
                    toRemoveList.Add(chooseUpgrade);
                    pickedUpPurple = true;
                }
            }
        }

        private void DoorCollision()
        {
            if (player.HandleCollision(Door))
            {
                EnteredDoor = true;
            }
        }

        private void ShowWaveIndicator()
        {
            //Spawns the wave indicator on the screen
            if (WaveIndicatorShowTime == 0)
            {
                waveIndicator = new WaveIndicator(new Vector2(GameEnvironment.Screen.X / 2, GameEnvironment.Screen.Y / 2), WaveCounter - 1);
                Add(waveIndicator);

                WaveIndicatorShowTime++;
                waveIndicator.Sprite.SheetIndex = WaveCounter - 1;
                waveRemoved = false;
            }

            //Timer till the Wave Indicator needs to be removed
            if (NewWave && WaveIndicatorShowTime <= 120)
            {
                WaveIndicatorShowTime++;
            }
            else if (!waveRemoved)
            {
                NewWave = false;
                toRemoveList.Add(waveIndicator);
                waveRemoved = true;
            }
        }

        private void CreateBackground()
        {
            background = new SpriteGameObject("Images/UI/Background/woodFloorBackground", -2, "background")
            {
                Scale = 1.45f
            };

            //use the width and height of the background to position it in the center of the screen

            background.Position = new Vector2((GameEnvironment.Screen.X / 2) - (background.Width / 2), 0);

            Add(background);
        }

        private void Retry()
        {
            //Reset Entities
            ResetEnemies();
            ResetBullets();
            ResetCurrency();

            //Reset everything Player
            player.InvulnerabilityCooldown = 30;
            player.HitPoints = player.BaseHitPoints;
            playerHealth.Text = $"{player.HitPoints}";
            pickedUpPurple = false;
            pickedUpYellow = false;


            //Reset the waves
            waveIndicator.Sprite.SheetIndex = 0;
            WaveCounter = 0;

            //Reset the door
            DoorCounter = 0;
            EnteredDoor = false;
            DoorSpawned = false;
            Remove(Door);
        }

        private void ResetEnemies()
        {
            foreach (Enemy enemy in enemyList)
            {
                toRemoveList.Add(enemy);
            }
        }

        private void ResetBullets()
        {
            foreach (PlayerBullet playerBullet in playerBulletList)
            {
                toRemoveList.Add(playerBullet);
            }
            foreach (EnemyBullet enemyBullet in enemyBulletList)
            {
                toRemoveList.Add(enemyBullet);
            }
        }

        private void ResetCurrency()
        {
            foreach (Currency currency in currencyList)
            {
                toRemoveList.Add(currency);
            }
            playerCurrency.Text = $"you collected {player.currencyCounter} currency";
        }

        private void HandleEndOfWave()
        {

        }
    }
}



