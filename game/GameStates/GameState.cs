using System;

using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using Blok3Game.Engine.GameObjects;
using Blok3Game.GameObjects;
using Microsoft.VisualBasic.FileIO;
using Microsoft.Xna.Framework;
namespace Blok3Game.GameStates
{
    public class GameState : GameObjectList
    {
        //Lijst met alle enemies
        private List<RedEnemies> redEnemiesList;
        public Player player;
        public GameState() : base()
        {
            //Aanmaken van een nieuwe lijst
            redEnemiesList = new List<RedEnemies>();

            Random random = new Random();

            int swap = 0;

            //For-loop om meerdere enemies aan te maken
            for (int i = 0; i < 20; i++)
            {
                int XPosition, YPosition;

                //Willekeurige posities waar de enemies spawnen
                XPosition = random.Next(0, 750);
                YPosition = random.Next(0, 550);


                //Do-While loop die ervoor zorgt dat de enemies aan de buiten randen spawnen 
                //De swap variabele zorgt ervoor dat de enemies evenredig worden verdeel aan alle kanten
                do
                {

                    if (swap % 2 == 0)
                    {
                        XPosition = random.Next(0, 750);
                        swap++;
                    }
                    else
                    {
                        YPosition = random.Next(0, 550);
                        swap++;
                    }

                } while (XPosition >= 50 && XPosition <= 700 && YPosition >= 50 && YPosition <= 500);

                //Aanmaken van de enemies
                RedEnemies redEnemy = new RedEnemies(100, 0.5, new Microsoft.Xna.Framework.Vector2(XPosition, YPosition));
                redEnemiesList.Add(redEnemy);
                Add(redEnemy);
            }

            player = new Player(5, new Microsoft.Xna.Framework.Vector2((GameEnvironment.Screen.X / 2) - (90 / 2), (GameEnvironment.Screen.Y / 2) - (90 / 2)));
            Add(player);
        }

        public override void Update(GameTime gameTime)
        {
            //Loop door de lijst met enemies
            foreach (var redEnemy in redEnemiesList)
            {
                //If-statements om te checken wat de positie van de enemies is ten opzichte van een bepaald punt
                if (redEnemy.XPosition >= 375)
                {
                    redEnemy.XPosition -= redEnemy.EnemySpeed;
                    redEnemy.Position = new Microsoft.Xna.Framework.Vector2((float)redEnemy.XPosition, (float)redEnemy.YPosition);
                }
                if (redEnemy.XPosition <= 375)
                {
                    redEnemy.XPosition += redEnemy.EnemySpeed;
                    redEnemy.Position = new Microsoft.Xna.Framework.Vector2((float)redEnemy.XPosition, (float)redEnemy.YPosition);
                }
                if (redEnemy.YPosition >= 225)
                {
                    redEnemy.YPosition -= redEnemy.EnemySpeed;
                    redEnemy.Position = new Microsoft.Xna.Framework.Vector2((float)redEnemy.XPosition, (float)redEnemy.YPosition);
                }
                if (redEnemy.YPosition <= 225)
                {
                    redEnemy.YPosition += redEnemy.EnemySpeed;
                    redEnemy.Position = new Microsoft.Xna.Framework.Vector2((float)redEnemy.XPosition, (float)redEnemy.YPosition);
                }
            }
            Debug.WriteLine(player.Position.X);
        }
    }
}
