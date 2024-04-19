using System;
using Blok3Game.Engine.GameObjects;

namespace Blok3Game.GameStates
{
    public class GameState : GameObjectList
    {
        public GameState() : base()
        {           
            Player player = new(0, 0, 5);
            Add(player);
            
            Bullet bullet = new Bullet(player.x , player.y);
            Add (bullet);
        }        
    }
}
