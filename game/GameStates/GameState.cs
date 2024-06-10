using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
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
    public class GameState : MenuItem
    {
        //all lists, objects and variables at the start of the game for the gamestate are created here
        private List<PlayerBullet> playerBulletList;
        private List<EnemyBullet> enemyBulletList;
        private List<Enemy> EnemyList;
        private List<Currency> currencyList;
        public List<GameObject> toRemoveList;
        public static GameState Instance { get; private set;}
        private List<Box> boxlist;
        public static GameState Instance { get; private set;}
        public Player player;
        public Crosshair crosshair;
        public CatGun catGun;
        public Box box;
        public YellowBox yellowBox;
        public PurpleBox purpleBox;
        public ShootingEnemy shootingEnemy;
        public FastEnemy fastEnemy;
        public DashIndicator dashIndicator;
        public WaveIndicator waveIndicator;
        public TextGameObject playerHealth;
        public TextGameObject playerCurrency;
        public int WaveCounter = 0;
        public int ChosenEnemy = 0;
        public int FramesPerSecond = 60;
        public int WaveIndicatorShowTime = -20;
        private bool NewWave = true;
        private SpriteGameObject background;
        public TextGameObject chooseUpgrade;
        public int EnemyShoot = 0;
        public int PlayerShootCooldown = 0;
        public int PlayerAttackTimes = 0;
        public int PlayerBulletSpeed = 18;
        private bool pickedUpPurple = false;
        private bool pickedUpYellow = false;
        private bool waveRemoved = false;
        public OpenDoor Door; 
        public bool EnteredDoor = false;

        public GameState() : base()
        {
            if (Instance != null)
            {
                throw new Exception("Only one instance of GameState is allowed");
            }

            Instance = this;
            if (Instance != null)
            {
                throw new Exception("Only one instance of GameState is allowed");
            }

            Instance = this;
            CreateBackground();

            //List creator
            EnemyList = new List<Enemy>();
            playerBulletList = new List<PlayerBullet>();
            enemyBulletList = new List<EnemyBullet>();
            currencyList = new List<Currency>();
            boxlist = new List<Box>();
            toRemoveList = new List<GameObject>();

            player = new Player(3, 5, new Vector2((GameEnvironment.Screen.X / 2) - (90 / 2), (GameEnvironment.Screen.Y / 2) - (90 / 2)));
            Add(player);

            crosshair = new Crosshair(new Vector2(Mouse.GetState().X, Mouse.GetState().Y));
            Add(crosshair);

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

            //The Waves controller
            switch (WaveCounter)
            {
                case 0: //Wave 1
                    if (EnemyList.Count == 0)
                    {
                        WaveCounter++;
                        NewWave = true;
                        WaveIndicatorShowTime = 0;
                        ResetBullets();
                        SpawnStandardEnemies();
                    }
                    break;
                case 1: //Wave 2
                    //if (EnemyList.Count == 0)
                    //{
                        if (boxlist.Count == 0 && (!pickedUpPurple || !pickedUpYellow))
                        {
                            //Lower Cooldown Upgrade
                            yellowBox = new YellowBox(new Vector2((GameEnvironment.Screen.X / 2) - 100, 150));
                            boxlist.Add(yellowBox);

                            Add(yellowBox);

                            //Shotgun upgrade
                            purpleBox = new PurpleBox(new Vector2((GameEnvironment.Screen.X / 2) + 100, 150));
                            boxlist.Add(purpleBox);

                            Add(purpleBox);

                            chooseUpgrade = new TextGameObject("Fonts/SpriteFont@20px", 1);
                            Add(chooseUpgrade);
                            chooseUpgrade.Text = $"Choose your upgrade!";
                            chooseUpgrade.Color = new(255, 255, 255);
                            chooseUpgrade.Position = new Vector2((GameEnvironment.Screen.X / 2 - chooseUpgrade.Size.X / 2) + 20, 200);
                        }
                        else if (pickedUpPurple || pickedUpYellow)
                        {
                            Door = new OpenDoor(new Vector2((GameEnvironment.Screen.X / 2) - 220, 300));
                            Add(Door);
                            Console.WriteLine(Door);

                            if(EnteredDoor)
                            {
                                WaveCounter++;
                                NewWave = true;
                                WaveIndicatorShowTime = 0;
                                ResetBullets();
                                SpawnFastEnemies();
                            }
                        }

                        boxCollision();
                    //}
                    break;
                case 2: //Wave 3
                    if (EnemyList.Count == 0)
                    {
                        WaveCounter++;
                        NewWave = true;
                        WaveIndicatorShowTime = 0;
                        ResetBullets();
                        SpawnStandardEnemies();
                    }
                    break;
                case 3: //Player Wins
                    if (EnemyList.Count == 0)
                    {
                        ResetBullets();
                        GameEnvironment.GameStateManager.SwitchToState("WIN_SCREEN_STATE");
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
                SocketClient.Instance.SendDataPacket(new MatchData{
                    TotalWavesSurvived = 2,
                    KilledBy = "rat",
                    Kills = 4,
                    HealthLeft = 2
                });
            }

            if (PlayerShootCooldown != 0)
            {
                PlayerShootCooldown--;
            }

            //Tells every enemy where to go, when to shoot and what to do when it collides with the player. Does the same for the PlayerBullets
            foreach (Enemy enemy in EnemyList)
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
                    if (playerBullet.CheckForEnemyCollision(enemy))
                    {
                        if (enemy.HitPoints <= 0)
                        {
                            Currency currency = new(enemy.Position + new Vector2(enemy.Width / 2, enemy.Height / 2))
                        {
                            Scale = 2
                        };
                        currencyList.Add(currency);
                        Add(currency);
                        toRemoveList.Add(enemy);
                        toRemoveList.Add(playerBullet);
                        } else 
                        {
                            enemy.HitPoints -= playerBullet.damage;
                        }
                        
                    }

                }
            }

            foreach (var enemyBullet in enemyBulletList)
            {
                player.HandleCollision(enemyBullet);
            }

            foreach (var currency in currencyList)
            {
                player.HandleCollision(currency);
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
                    EnemyList.Remove(enemy);
                }
                if (gameObject is EnemyBullet enemyBullet)
                {
                    enemyBulletList.Remove(enemyBullet);
                }
                if (gameObject is Currency currency)
                {
                    currencyList.Remove(currency);
                }
                if (gameObject is Box box)
                {
                    boxlist.Remove(box);
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
                EnemyList.Add(shootingEnemy);

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
                fastEnemy = new FastEnemy(1, 3, new Vector2(XPosition, YPosition));

                EnemyList.Add(fastEnemy);
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

            EnemyBullet enemyBullet = new(new Vector2(ShootPositionX, ShootPositionY), bulletAngle, 15);

            enemyBulletList.Add(enemyBullet);
            Add(enemyBullet);
        }


        private void BoxCollision()
        {
            foreach (Box box in boxlist)
            {
                if (player.CheckForPlayerCollision(box))
                {
                    if (box is YellowBox)
                    {
                        pickedUpYellow = true;
                    }

                    if (box is PurpleBox)
                    {
                        pickedUpPurple = true;
                    }
                }

                if (pickedUpPurple || pickedUpYellow)
                {
                    toRemoveList.Add(box);
                    toRemoveList.Add(chooseUpgrade);
                }
            }
        }

        private void DoorCollision()
        {
            if (SpriteGameObject.CollidesWith(Door))
            {

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
            background = new SpriteGameObject("Images/UI/Background/woodFloorBackground", -1, "background")
            {
                Scale = 3.75f,
            };

            //use the width and height of the background to position it in the center of the screen
            
            background.Position = new Vector2((GameEnvironment.Screen.X / 2) - (background.Width / 2), 0);

            Add(background);
        }

        public void Retry()
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
        }

        private void ResetEnemies()
        {
            foreach (Enemy enemy in EnemyList)
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
    }
}


