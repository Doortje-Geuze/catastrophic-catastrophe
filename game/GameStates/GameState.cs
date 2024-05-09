using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using Blok3Game.Engine.GameObjects;
using Blok3Game.Engine.Helpers;
using Blok3Game.GameObjects;
using Microsoft.VisualBasic.FileIO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
namespace Blok3Game.GameStates
{
    public class GameState : GameObjectList
    {
        //Lijst met alle enemies
        private List<StandardEnemy> standardEnemyList;
        private List<ShootingEnemy> enemiesToRemove;
        private List<PlayerBullet> playerBulletList;
        private List<PlayerBullet> playerBulletsToRemove;
        private List<EnemyBullet> enemyBulletList;
        private List<ShootingEnemy> shootingEnemyList;
        public Player player;
        public StandardEnemy standardEnemy;
        public Crosshair crosshair;
        public CatGun catGun;
        public ShootingEnemy shootingEnemy;
        public int e = 0;
        public int frameCounter = 0;
        public int WaveCounter = 1;

        public GameState() : base()
        {
            //Aanmaken van een nieuwe lijst
            standardEnemyList = new List<StandardEnemy>();
            shootingEnemyList = new List<ShootingEnemy>();
            playerBulletList = new List<PlayerBullet>();
            enemiesToRemove = new List<ShootingEnemy>();
            playerBulletsToRemove = new List<PlayerBullet>();
            enemyBulletList = new List<EnemyBullet>();
            SpawnStandardEnemies();

            player = new Player(3, 5, new Vector2((GameEnvironment.Screen.X / 2) - (90 / 2), (GameEnvironment.Screen.Y / 2) - (90 / 2)));
            Add(player);

            crosshair = new Crosshair(new Vector2(Mouse.GetState().X, Mouse.GetState().Y));
            Add(crosshair);

            catGun = new CatGun(player, crosshair, new Vector2(10, 10));
            Add(catGun);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            e++;
            frameCounter++;
            int ChosenEnemy = 0;

            //Loop door de lijst met enemies
            foreach (var Enemy in shootingEnemyList)
            {
                //If-statements om te checken wat de positie van de enemies is ten opzichte van een bepaald punt
                if (Enemy.XPosition >= player.Position.X)
                {
                    Enemy.XPosition -= Enemy.EnemyMoveSpeed;
                    Enemy.Position = new Vector2((float)Enemy.XPosition, (float)Enemy.YPosition);
                    Enemy.Sprite.Mirror = false;
                }
                if (Enemy.XPosition <= player.Position.X)
                {
                    Enemy.XPosition += Enemy.EnemyMoveSpeed;
                    Enemy.Position = new Vector2((float)Enemy.XPosition, (float)Enemy.YPosition);
                    Enemy.Sprite.Mirror = true;
                }
                if (Enemy.YPosition >= player.Position.Y)
                {
                    Enemy.YPosition -= Enemy.EnemyMoveSpeed;
                    Enemy.Position = new Vector2((float)Enemy.XPosition, (float)Enemy.YPosition);
                }
                if (Enemy.YPosition <= player.Position.Y)
                {
                    Enemy.YPosition += Enemy.EnemyMoveSpeed;
                    Enemy.Position = new Vector2((float)Enemy.XPosition, (float)Enemy.YPosition);
                }
                if (e % 120 == 0 && ChosenEnemy % 3 == 0)
                {
                    EnemyShoots(Enemy);
                }
                ChosenEnemy++;

                player.CheckForEnemyCollision(Enemy);
                foreach (var playerBullet in playerBulletList)
                {
                    if (playerBullet.CheckForEnemyCollision(Enemy))
                    {
                        enemiesToRemove.Add(Enemy);
                        playerBulletsToRemove.Add(playerBullet);
                    }
                }
            }

            foreach (var enemyBullet in enemyBulletList)
            {
                player.CheckForEnemyCollision(enemyBullet);
            }

            if (player.PlayerHitPoints <= 0)
            {
                GameEnvironment.GameStateManager.SwitchToState("LOSE_SCREEN_STATE");
                player.PlayerHitPoints = 3;
                ResetBullets();
            }
            if (player.InvulnerabilityCooldown >= 0)
            {
                if (player.InvulnerabilityCooldown == 0 && player.playerShield != null)
                {
                    Remove(player.playerShield);
                }
                if (player.InvulnerabilityCooldown == 119)
                {
                    Add(player.playerShield);
                } else if (player.InvulnerabilityCooldown <= 118 && player.InvulnerabilityCooldown > 0)
                {
                    player.playerShield.Position = player.Position + player.playerShield.Offset;
                }
            }
            foreach (var enemyToRemove in enemiesToRemove)
            {
                shootingEnemyList.Remove(enemyToRemove);
                Remove(enemyToRemove);
            }
            foreach (var playerBulletToRemove in playerBulletsToRemove)
            {
                playerBulletList.Remove(playerBulletToRemove);
                Remove(playerBulletToRemove);
            }
            if (shootingEnemyList.Count == 0 && WaveCounter != 3)
            {
                WaveCounter++;
                ResetBullets();
                SpawnStandardEnemies();
            }
            if (shootingEnemyList.Count == 0 && WaveCounter == 3)
            {
                GameEnvironment.GameStateManager.SwitchToState("WIN_SCREEN_STATE");
                ResetBullets();
                SpawnStandardEnemies();
            }
            foreach (var playerBulletToRemove in playerBulletsToRemove)
            {
                Remove(playerBulletToRemove);
                playerBulletList.Remove(playerBulletToRemove);
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

                } while (XPosition >= 0 && XPosition <= GameEnvironment.Screen.X && YPosition >= 0 && YPosition <= GameEnvironment.Screen.Y);

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

            PlayerBullet playerBullet = new PlayerBullet(new Vector2(ShootPositionX, ShootPositionY), bulletAngle, 18);

            playerBulletList.Add(playerBullet);
            Add(playerBullet);
        }

        private void EnemyShoots(ShootingEnemy shootingEnemy)
        {
            float ShootPositionX = shootingEnemy.Position.X + shootingEnemy.Width / 2;
            float ShootPositionY = shootingEnemy.Position.Y + shootingEnemy.Height / 2;
            double bulletAngle = Math.Atan2(player.Position.Y - ShootPositionY, player.Position.X - ShootPositionX);

            EnemyBullet enemyBullet = new EnemyBullet(new Vector2(ShootPositionX, ShootPositionY), bulletAngle, 15);

            enemyBulletList.Add(enemyBullet);
            Add(enemyBullet);
        }

        private void ResetBullets()
        {
            foreach (PlayerBullet playerBullet in playerBulletList)
            {
                playerBulletsToRemove.Add(playerBullet);
            }
        }
    }
    
}
