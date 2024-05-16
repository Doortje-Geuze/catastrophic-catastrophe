using Microsoft.Xna.Framework;

namespace Blok3Game.GameObjects
{
    public class StandardEnemy : Enemy
    {
        public int EnemyHitPoints;
        public StandardEnemy(int hitPoints, int moveSpeed, Vector2 position) : base(hitPoints, moveSpeed, position, "Images/Enemies/standardEnemy", 0, " ", 0)
        {
            EnemyHitPoints = hitPoints;
        }
    }
}