using System;
using Blok3Game.Engine.GameObjects;
using Microsoft.Xna.Framework;


namespace Blok3Game.GameObjects
{
    public class EnemyBullet : Bullet
    {
        public int BulletMoveSpeed = 8;
        //private float Angle;
        
        public EnemyBullet(Vector2 position, double angle, string assetName = "Images/Bullets/EnemyBullet") : base(position, assetName)
        {
            Position = position;
            Angle = (float)angle;
            velocity = new Vector2((float)Math.Cos(Angle), (float)Math.Sin(Angle)) * BulletMoveSpeed;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (Position.X > 0 - Width && Position.X < GameEnvironment.Screen.X + Width && Position.Y > 0 - Width && Position.Y < GameEnvironment.Screen.Y + Width)
            {
                position += velocity;
            }
            else
            {
                velocity = new Vector2(0, 0);
            }
        }
    }
}