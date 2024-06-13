using System.Net.NetworkInformation;
using Blok3Game.Engine.GameObjects;
using Microsoft.Xna.Framework;


namespace Blok3Game.GameObjects
{
    public abstract class Bullet : RotatingSpriteGameObject
    {
        public int BulletMoveSpeed = 0;

        public Bullet(Vector2 position, double angle, int bulletMoveSpeed, string assetName) : base(assetName)
        {
            Position = position;
            Angle = (float)angle;
            BulletMoveSpeed = bulletMoveSpeed;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (Position.X > 0 - Width && Position.X < GameEnvironment.Screen.X + Width && Position.Y > 0 - Width && 
                Position.Y < GameEnvironment.Screen.Y + Width)
            {
                position += AngularDirection * BulletMoveSpeed;
            }
            else
            {
                velocity = new Vector2(0, 0);
            }
        }
    }
}