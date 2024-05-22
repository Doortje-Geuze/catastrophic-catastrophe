using Blok3Game.Engine.GameObjects;
using Microsoft.Xna.Framework;


namespace Blok3Game.GameObjects
{
    public class EnemyBullet : Bullet
    {
        public EnemyBullet(Vector2 position, double angle, int bulletMoveSpeed, string assetName = "Images/Bullets/enemyBullet") : base(position, angle, bulletMoveSpeed, assetName)
        {
        }

        public bool CheckForEnemyCollision(SpriteGameObject player)
        {
            if (CollidesWith(player))
            {
                return true;
            }
            return false;
        }
    }
}