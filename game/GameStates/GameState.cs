using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Compression;
using Blok3Game.Engine.GameObjects;
using Blok3Game.Engine.Helpers;
using Blok3Game.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
namespace Blok3Game.GameStates
{
    public class GameState : GameObjectList
    {
        //all lists, objects and variables at the start of the game for the gamestate are created here
        private List<PlayerBullet> playerBulletList;
        private List<EnemyBullet> enemyBulletList;
        private List<ShootingEnemy> shootingEnemyList;
        private List<GameObject> toRemoveList;
        public Player player;
        public Crosshair crosshair;
        public CatGun catGun;
        public ShootingEnemy shootingEnemy;
        public DashIndicator dashIndicator;
        public WaveIndicator waveIndicator;
        public TextGameObject playerHealth;
        public int WaveCounter = 1;
        public int ChosenEnemy = 0;
        public int FramesPerSecond = 60;
        public int WaveIndicatorShowTime = 0;
        private bool NewWave = true;

        public GameState() : base()
        {
            //Aanmaken van een nieuwe lijst
            shootingEnemyList = new List<ShootingEnemy>();
            playerBulletList = new List<PlayerBullet>();
            enemyBulletList = new List<EnemyBullet>();
            toRemoveList = new List<GameObject>();

            //Spawn Enemies for the first wave
            SpawnStandardEnemies();

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

            dashIndicator = new DashIndicator(Vector2.Zero);
            Add(dashIndicator);
            dashIndicator.Parent = player;

            ShowWaveIndicator();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            ShowWaveIndicator();

            switch (WaveCounter)
            {
                case 1: //Wave 1
                    if (shootingEnemyList.Count == 0)
                    {
                        WaveCounter++;
                        NewWave = true;
                        WaveIndicatorShowTime = 0;
                        ResetBullets();
                        SpawnStandardEnemies();
                    }
                    break;
                case 2: //Wave 2
                    if (shootingEnemyList.Count == 0)
                    {
                        WaveCounter++;
                        NewWave = true;
                        WaveIndicatorShowTime = 0;
                        ResetBullets();
                        SpawnStandardEnemies();
                    }
                    break;
                case 3: //Wave 3
                    if (shootingEnemyList.Count == 0)
                    {
                        ResetBullets();
                        GameEnvironment.GameStateManager.SwitchToState("WIN_SCREEN_STATE");
                    }
                    break;
            }

            //switches to lose screen if player's HP falls below 0
            if (player.HitPoints <= 0)
            {
                Retry();
                GameEnvironment.GameStateManager.SwitchToState("LOSE_SCREEN_STATE");
            }

            //Goes through every enemy and updates where they need to go, when they can shoot and checks for collision
            foreach (var Enemy in shootingEnemyList)
            {
                Enemy.EnemySeeking(player.Position);

                if (Enemy.EnemyShootCooldown == 0)
                {
                    EnemyShoots(Enemy); //Calculate where the enemy needs to shoot
                    Enemy.EnemyShootCooldown = 140;
                }
                Enemy.EnemyShootCooldown--;

                player.CheckForEnemyCollision(Enemy); //Checks if player and enemy collide
                foreach (var playerBullet in playerBulletList)
                {
                    if (playerBullet.CheckForEnemyCollision(Enemy)) //Checks if bullet from the player and enemy collide
                    {
                        toRemoveList.Add(Enemy);
                        toRemoveList.Add(playerBullet);
                    }
                }
            }

            // Goes through all the bullets the enemy shot and checks if they hit the player
            foreach (var enemyBullet in enemyBulletList)
            {
                player.CheckForEnemyCollision(enemyBullet); //If player hit by bullet, hp -1
                if (enemyBullet.CheckForEnemyCollision(player))
                {
                    toRemoveList.Add(enemyBullet);
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

            //Removes objects from their respective lists before deleting them from the game
            foreach (var gameObject in toRemoveList)
            {
                if (gameObject is PlayerBullet playerBullet)
                {
                    playerBulletList.Remove(playerBullet);
                }
                if (gameObject is ShootingEnemy shootingEnemy)
                {
                    shootingEnemyList.Remove(shootingEnemy);
                }
                if (gameObject is EnemyBullet enemyBullet)
                {
                    enemyBulletList.Remove(enemyBullet);
                }
                Remove(gameObject);
            }
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);

            if (inputHelper.MouseLeftButtonPressed)
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
                shootingEnemyList.Add(shootingEnemy);

                Add(shootingEnemy);
            }
        }

        private void PlayerShoot(float MousePositionX, float MousePositionY)
        {
            float ShootPositionX = player.Position.X + player.Width / 2;
            float ShootPositionY = player.Position.Y + player.Height / 2;
            double bulletAngle = Math.Atan2(MousePositionY - ShootPositionY, MousePositionX - ShootPositionX);

            PlayerBullet playerBullet = new(new Vector2(ShootPositionX, ShootPositionY), bulletAngle, 18);

            playerBulletList.Add(playerBullet);
            Add(playerBullet);
        }

        private void EnemyShoots(ShootingEnemy shootingEnemy)
        {
            float ShootPositionX = shootingEnemy.Position.X + shootingEnemy.Width / 2;
            float ShootPositionY = shootingEnemy.Position.Y + shootingEnemy.Height / 2;
            double bulletAngle = Math.Atan2((player.Position.Y + player.Height / 2) - ShootPositionY, (player.Position.X + player.Width / 2) - ShootPositionX);

            EnemyBullet enemyBullet = new(new Vector2(ShootPositionX, ShootPositionY), bulletAngle, 15);

            enemyBulletList.Add(enemyBullet);
            Add(enemyBullet);
        }

        private void ShowWaveIndicator()
        {
            if (WaveIndicatorShowTime == 0)
            {
                waveIndicator = new WaveIndicator(new Vector2(GameEnvironment.Screen.X / 2, GameEnvironment.Screen.Y / 2), WaveCounter - 1);
                Add(waveIndicator);

                WaveIndicatorShowTime++;
                waveIndicator.Sprite.SheetIndex = WaveCounter - 1;
            }

            if (NewWave && WaveIndicatorShowTime <= 120)
            {
                WaveIndicatorShowTime++;
            }
            else
            {
                NewWave = false;
                toRemoveList.Add(waveIndicator);
            }
        }

        public void Retry()
        {
            ResetBullets();
            ResetEnemies();
            WaveCounter = 1;
            player.InvulnerabilityCooldown = 0;
            player.HitPoints = player.BaseHitPoints;
            playerHealth.Text = $"{player.HitPoints}";
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
        private void ResetEnemies()
        {
            foreach (ShootingEnemy shootingEnemy in shootingEnemyList)
            {
                toRemoveList.Add(shootingEnemy);
            }
        }
    }

}


