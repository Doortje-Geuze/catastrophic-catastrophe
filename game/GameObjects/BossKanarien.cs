using Microsoft.Xna.Framework;

namespace Blok3Game.GameObjects
{
    public class BossKanarien : Enemy
    {
        public int EnemyHitPoints;
        
        public BossKanarien(int hitPoints, int moveSpeed, Vector2 position) : base(hitPoints, moveSpeed, position, "Images/Characters/rat", 0, " ", 0)
        {
            EnemyHitPoints = hitPoints;
        }
    }
}