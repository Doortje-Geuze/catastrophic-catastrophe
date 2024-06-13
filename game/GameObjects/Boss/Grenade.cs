using System;
using System.Diagnostics;
using System.Xml.Serialization;
using Blok3Game.Engine.GameObjects;
using Blok3Game.SpriteGameObjects;
using Microsoft.Xna.Framework;
using Blok3Game.GameStates;


namespace Blok3Game.GameObjects
{
    public class Grenade : RotatingSpriteGameObject
    {
        public GameState Gamestate { get; set; }
        protected int BulletMoveSpeed = 0;
        private Vector2 PositionPlayer;
        private int grenadeTimer = 50;
        GrenadeCollisionBox CollisionBox;

        public Grenade(Vector2 position, Vector2 positionPlayer, double angle, int bulletMoveSpeed, GrenadeCollisionBox grenadeCollisionBox, string assetName = "Images/Bullets/Grenade") : base(assetName)
        {
            Position = position;
            PositionPlayer = positionPlayer;
            Angle = (float)angle;
            BulletMoveSpeed = bulletMoveSpeed;
            CollisionBox = grenadeCollisionBox;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (CollisionBox.hit)
            {
                // x 10 * angle + Y * angle makes grenade do an arc
                if (grenadeTimer <= 0)
                {
                    Gamestate.grenadeKaboom = true;
                    grenadeTimer = 50;
                    CollisionBox.hit = false;
                }
                else
                {
                    grenadeTimer--;
                    velocity = new Vector2(0, 0);
                }
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
                    CollisionBox.hit = true;
                    break;
            }
        }
    }
}