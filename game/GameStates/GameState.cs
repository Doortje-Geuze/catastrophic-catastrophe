using System;
using System.Collections.Generic;
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
        private List<Enemy> EnemyList;
        private List<Currency> currencyList;
        private List<Explosion> explosionList;
        public List<GameObject> toRemoveList;
        private List<Box> boxlist;
        private List<GrenadeCollisionBox> grenadeCollisionsList;
        public BossKanarien bossKanarie;
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
        public int WaveCounter = 0;
        public int ChosenEnemy = 0;
        public int FramesPerSecond = 60;
        public int WaveIndicatorShowTime = -20;
        private bool NewWave = true;
        private SpriteGameObject background;
        public TextGameObject playerCurrency;
        public TextGameObject chooseUpgrade;
        public int EnemyShoot = 0;
        public int PlayerShootCooldown = 0;
        public int PlayerAttackTimes = 0;
        private bool pickedUpPurple = false;
        private bool pickedUpYellow = false;
        private bool waveRemoved = false;
        private int BossCooldown = 120;
        public bool grenadeKaboom = false;
        private bool bossWave = true;
        private int BossWalking = 0;

        public GameState() : base()
        {
            CreateBackground();

            //List creator
            EnemyList = new List<Enemy>();
            playerBulletList = new List<PlayerBullet>();
            enemyBulletList = new List<EnemyBullet>();
            grenadeList = new List<Grenade>();
            currencyList = new List<Currency>();
            boxlist = new List<Box>();
            explosionList = new List<Explosion>();
            toRemoveList = new List<GameObject>();
            grenadeCollisionsList = new List<GrenadeCollisionBox>();

            player = new Player(3, 5, new Vector2((GameEnvironment.Screen.X / 2) - (90 / 2), (GameEnvironment.Screen.Y / 2) - (90 / 2)))
            {
                Gamestate = this
            };
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

            bossKanarie = new BossKanarien(5, 1, new Vector2(10, 10));
            Add(bossKanarie);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            //The Waves controller
            // switch (WaveCounter)
            // {
            //     case 0: //Wave 1
            //         if (EnemyList.Count == 0)
            //         {
            //             WaveCounter++;
            //             NewWave = true;
            //             WaveIndicatorShowTime = 0;
            //             ResetBullets();
            //             SpawnStandardEnemies();
            //         }
            //         break;
            //     case 1: //Wave 2
            //         if (EnemyList.Count == 0)
            //         {
            //             if (boxlist.Count == 0 && (!pickedUpPurple || !pickedUpYellow))
            //             {
            //                 //Lower Cooldown Upgrade
            // yellowBox = new YellowBox(new Vector2((GameEnvironment.Screen.X / 2) - 100, 150));
            //                 boxlist.Add(yellowBox);

            //                 Add(yellowBox);

            //                 //Shotgun upgrade
            //                 purpleBox = new PurpleBox(new Vector2((GameEnvironment.Screen.X / 2) + 100, 150));
            //                 boxlist.Add(purpleBox);

            //                 Add(purpleBox);

            //                 chooseUpgrade = new TextGameObject("Fonts/SpriteFont@20px", 1);
            //                 Add(chooseUpgrade);
            //                 chooseUpgrade.Text = $"Choose your upgrade!";
            //                 chooseUpgrade.Color = new(255, 255, 255);
            //                 chooseUpgrade.Position = new Vector2((GameEnvironment.Screen.X / 2 - chooseUpgrade.Size.X / 2) + 20, 200);
            //             }
            //             else if (pickedUpPurple || pickedUpYellow)
            //             {
            //                 WaveCounter++;
            //                 NewWave = true;
            //                 WaveIndicatorShowTime = 0;
            //                 ResetBullets();
            //                 SpawnFastEnemies();
            //             }

            //             boxCollision();
            //         }
            //         break;
            //     case 2: //Wave 3
            //         if (EnemyList.Count == 0)
            //         {
            //             WaveCounter++;
            //             NewWave = true;
            //             WaveIndicatorShowTime = 0;
            //             ResetBullets();
            //             SpawnStandardEnemies();
            //         }
            //         break;
            //     case 3: //Player Wins
            //         if (EnemyList.Count == 0)
            //         {
            //             ResetBullets();
            //             GameEnvironment.GameStateManager.SwitchToState("WIN_SCREEN_STATE");
            //         }
            //         break;
            // }

            //Shows to the player which wave it is
            ShowWaveIndicator();

            //switches to lose screen if player's HP falls below 0
            if (player.HitPoints <= 0)
            {
                Retry();
                GameEnvironment.GameStateManager.SwitchToState("LOSE_SCREEN_STATE");
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

            //Tells every enemy where to go, when to shoot and what to do when it collides with the player. Does the same for the PlayerBullets
            // foreach (Enemy enemy in EnemyList)
            // {
            //     enemy.EnemySeeking(player.Position);

            //     // if (enemy.EnemyShootCooldown >= 120 && enemy is not FastEnemy fastEnemy)
            //     // {
            //     //     EnemyShoots(enemy);
            //     //     enemy.EnemyShootCooldown = 0;
            //     // }
            //     // enemy.EnemyShootCooldown++;

            //     player.HandleCollision(enemy);
            //     foreach (var playerBullet in playerBulletList)
            //     {
            //         if (playerBullet.CheckForEnemyCollision(enemy))
            //         {
            //             if (enemy.HitPoints > 0)
            //             {
            //                 enemy.HitPoints--;
            //             }
            //             else if (enemy.HitPoints <= 0)
            //             {
            //                 Currency currency = new(enemy.Position + new Vector2(enemy.Width / 2, enemy.Height / 2))
            //                 {
            //                     Scale = 2
            //                 };
            //                 currencyList.Add(currency);
            //                 Add(currency);

            //                 toRemoveList.Add(enemy);
            //             }

            //             toRemoveList.Add(playerBullet);
            //         }

            //     }
            // }

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
                if (BossWalking != 0)
                {
                    bossKanarie.Velocity = new Vector2(0, 0);
                    BossWalking--;
                }
                else if (BossWalking <= 0)
                {
                    bossKanarie.EnemySeeking(player.Position);
                }

                if (BossCooldown != 0)
                {
                    if (BossCooldown == 10 && BossWalking <= 0)
                    {
                        BossWalking = 20;
                    }
                    BossCooldown--;
                }
                else if (BossCooldown <= 0)
                {
                    Random random = new Random();
                    int attack = random.Next(0, 2);
                    Debug.WriteLine(attack);

                    switch (attack)
                    {
                        case 0: //SCHIET
                            EnemyShoots(bossKanarie);
                            BossCooldown = 120;
                            break;
                        case 1:
                            BirdGrenade(bossKanarie);
                            BossCooldown = 120;
                            break;
                    }

                }
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
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);

            if (inputHelper.MouseLeftButtonPressed && PlayerShootCooldown == 0)
            {
                PlayerShoot(inputHelper.MousePosition.X, inputHelper.MousePosition.Y);
            }
            if (inputHelper.KeyPressed(Keys.V))
            {
                // foreach (Enemy enemy in EnemyList)
                // {
                //     BirdAirstrike(enemy);
                // }
                foreach (Enemy enemy in EnemyList)
                {
                    BirdGrenade(enemy);
                }
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
                fastEnemy = new FastEnemy(1, 4, new Vector2(XPosition, YPosition));

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
                    PlayerBullet playerBullet = new(new Vector2(ShootPositionX, ShootPositionY), bulletAngle - 0.3f * i, 18);
                    playerBulletList.Add(playerBullet);
                    Add(playerBullet);
                }
            }
            else
            {
                PlayerBullet playerBullet = new(new Vector2(ShootPositionX, ShootPositionY), bulletAngle, 18);
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

        private void BirdAirstrike(Enemy enemy)
        {
            float ShootPositionX = player.Position.X;
            float ShootPositionY = player.Position.Y;

            if (BossCooldown <= 0)
            {
                for (int i = 0; i < GameEnvironment.Screen.X; i++)
                {
                    Explosion explosion = new(new Vector2(0 + 20 * i, ShootPositionY));

                    explosionList.Add(explosion);
                    Add(explosion);
                    BossCooldown = 100;
                }
            }
            else
            {
                BossCooldown--;
            }
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
                Scale = 2.1f,
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
            player.InvulnerabilityCooldown = 0;
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
            player.currencyCounter = 0;
            playerCurrency.Text = $"you collected {player.currencyCounter} currency";
        }
    }
}


