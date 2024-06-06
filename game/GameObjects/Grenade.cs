using System;
using System.Diagnostics;
using Blok3Game.Engine.GameObjects;
using Blok3Game.SpriteGameObjects;
using Microsoft.Xna.Framework;


namespace Blok3Game.GameObjects
{
    public class Grenade : RotatingSpriteGameObject
    {
        protected int BulletMoveSpeed = 0;
        private Vector2 PositionPlayer;
        private bool KaboomTime = false;

        public Grenade(Vector2 position, Vector2 positionPlayer, double angle, int bulletMoveSpeed, bool kaboomTime, string assetName = "Images/Bullets/enemyBullet") : base(assetName)
        {
            Position = position;
            PositionPlayer = positionPlayer;
            Angle = (float)angle;
            BulletMoveSpeed = bulletMoveSpeed;
            KaboomTime = kaboomTime;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (KaboomTime)
            {
                velocity = new Vector2(0, 0); // x 10 * angle + Y * angle makes grenade do an arc
                Debug.WriteLine("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAH");
            }
            else
            {
                position += AngularDirection * BulletMoveSpeed;
            }
        }

        public void HandleCollision(SpriteGameObject spriteGameObject)
        {
            if (CollidesWith(spriteGameObject) == false) return;
            switch (spriteGameObject)
            {
                case GrenadeCollisionBox:
                    KaboomTime = true;
                    break;
            }
        }
    }
}