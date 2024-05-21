using System;
using System.Collections.Generic;
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
        public StandardEnemy standardEnemy;
        public Crosshair crosshair;
        public CatGun catGun;
        public ShootingEnemy shootingEnemy;
        public DashIndicator dashIndicator;
        public TextGameObject playerHealth;
        public int EnemyShoot = 0;
        public int WaveCounter = 1;
        public int ChosenEnemy = 0;
        public int FramesPerSecond = 60;

        public GameState() : base()
        {
            //Aanmaken van een nieuwe lijst
            shootingEnemyList = new List<ShootingEnemy>();
            playerBulletList = new List<PlayerBullet>();
            enemyBulletList = new List<EnemyBullet>();
            toRemoveList = new List<GameObject>();

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
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            //Loop door de lijst met enemies
            foreach (var Enemy in shootingEnemyList)
            {
                Enemy.EnemySeeking(player.Position);

                if (Enemy.EnemyShootCooldown >= 120)
                {
                    EnemyShoots(Enemy);
                    Enemy.EnemyShootCooldown = 0;
                }
                Enemy.EnemyShootCooldown++;

                player.CheckForEnemyCollision(Enemy);
                foreach (var playerBullet in playerBulletList)
                {
                    if (playerBullet.CheckForEnemyCollision(Enemy))
                    {
                        toRemoveList.Add(Enemy);
                        toRemoveList.Add(playerBullet);
                    }
                }
            }

            foreach (var enemyBullet in enemyBulletList)
            {
                player.CheckForEnemyCollision(enemyBullet);
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
                Remove(gameObject);
            }

            // if (shootingEnemyList.Count == 0 && WaveCounter != 3)
            // {
            //     WaveCounter++;
            //     ResetBullets();
            //     SpawnStandardEnemies();
            // }
            // if (shootingEnemyList.Count == 0 && WaveCounter == 3)
            // {
            //     GameEnvironment.GameStateManager.SwitchToState("WIN_SCREEN_STATE");
            //     ResetBullets();
            //     SpawnStandardEnemies();
            // }
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
                XPosition = random.Next(0 - 100, GameEnvironment.Screen.X + 500);
                YPosition = random.Next(0 - 100, GameEnvironment.Screen.Y + 500);


                //Do-While loop die ervoor zorgt dat de enemies aan de buiten randen spawnen 
                //De swap variabele zorgt ervoor dat de enemies evenredig worden verdeel aan alle kanten
                do
                {
                    if (swap % 2 == 0)
                    {
                        XPosition = random.Next(0 - 100, GameEnvironment.Screen.X + 500);
                        swap++;
                    }
                    else
                    {
                        YPosition = random.Next(0 - 100, GameEnvironment.Screen.Y + 500);
                        swap++;
                    }

                } while (XPosition >= 0 && XPosition <= GameEnvironment.Screen.X && 
                         YPosition >= 0 && YPosition <= GameEnvironment.Screen.Y);

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
            double bulletAngle = Math.Atan2(player.Position.Y - ShootPositionY, player.Position.X - ShootPositionX);

            EnemyBullet enemyBullet = new(new Vector2(ShootPositionX, ShootPositionY), bulletAngle, 15);

            enemyBulletList.Add(enemyBullet);
            Add(enemyBullet);
        }

        private void ResetBullets()
        {
            foreach (PlayerBullet playerBullet in playerBulletList)
            {
                toRemoveList.Add(playerBullet);
            }
        }
    }

}


