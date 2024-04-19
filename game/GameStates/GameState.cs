using System;
using System.Collections.Generic;
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
        private List<RedEnemies> redEnemiesList;


        public override void Update(GameTime gameTime)
        {
            foreach (var redEnemy in redEnemiesList)
            {
                if(redEnemy.XPosition >= 375)
                {
                    redEnemy.XPosition -= redEnemy.EnemySpeed;
                    redEnemy.Position = new Microsoft.Xna.Framework.Vector2((float)redEnemy.XPosition, (float)redEnemy.YPosition);
                }
                if(redEnemy.XPosition <= 375)
                {
                    redEnemy.XPosition += redEnemy.EnemySpeed;
                    redEnemy.Position = new Microsoft.Xna.Framework.Vector2((float)redEnemy.XPosition, (float)redEnemy.YPosition);
                }
                if(redEnemy.YPosition >= 225)
                {
                    redEnemy.YPosition -= redEnemy.EnemySpeed;
                    redEnemy.Position = new Microsoft.Xna.Framework.Vector2((float)redEnemy.XPosition, (float)redEnemy.YPosition);
                }
                if(redEnemy.YPosition <= 225)
                {
                    redEnemy.YPosition += redEnemy.EnemySpeed;
                    redEnemy.Position = new Microsoft.Xna.Framework.Vector2((float)redEnemy.XPosition, (float)redEnemy.YPosition);
                }
            }   
        }
        public GameState() : base()
        {
            redEnemiesList = new List<RedEnemies>();

            Random random = new Random();

            int swap = 0;

            for(int i = 0; i < 20; i++)
            {
                    int XPosition, YPosition;
                         
                    
                    XPosition = random.Next(0, 750);
                    YPosition = random.Next(0, 550); 
                    

                    do{
                        
                        if(swap % 2 == 0)
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
            
            
            RedEnemies redEnemy = new RedEnemies(100, 0.5, new Microsoft.Xna.Framework.Vector2(XPosition, YPosition));
            redEnemiesList.Add(redEnemy);
            Add(redEnemy);
            }
        }
    }
    
}
