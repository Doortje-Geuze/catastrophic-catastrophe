using System;
using Blok3Game.Engine.GameObjects;
using Microsoft.Xna.Framework;

namespace Blok3Game.GameStates
{
    public class GameState : GameObjectList
    {
        public GameObjectList playerBullets;
        public GameState() : base()
        {           
            Player player = new(0, 0, 5);
            Add(player);

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            
            foreach (GameObject child in Children)
            {
                if (child is PlayerBullet playerBullet)
                {
                    playerBullet.CheckBulletMovement();
                }
            }
        }
    }
}
