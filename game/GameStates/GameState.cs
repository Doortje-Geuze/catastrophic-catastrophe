using System;
using System.Numerics;
using Blok3Game.Engine.GameObjects;
using Blok3Game.GameObjects;

namespace Blok3Game.GameStates
{
    public class GameState : GameObjectList
    {
        private RedEnemies redEnemies;
        public GameState() : base()
        {

            Random random = new Random();

            int swap = 0;

            for(int i = 0; i < 200; i++)
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

                    
            
            
            redEnemies = new RedEnemies(100, 5, new Vector2(XPosition, YPosition));
            Add(redEnemies);
            }
        }
    }
}
