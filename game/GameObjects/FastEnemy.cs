using Microsoft.Xna.Framework;

namespace Blok3Game.GameObjects
{
    public class FastEnemy : Enemy
    {
        public int EnemyHitPoints;
        public new int EnemyMoveSpeed = 10;
        
        public FastEnemy(int hitPoints, int moveSpeed, Vector2 position) : base(hitPoints, moveSpeed, position, "Images/Characters/fastEnemy", 0, " ", 0)
        {
            EnemyHitPoints = hitPoints;
            EnemyMoveSpeed = moveSpeed;
        }
    }
}

