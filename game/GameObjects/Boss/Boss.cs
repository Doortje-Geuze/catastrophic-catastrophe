using Microsoft.Xna.Framework;

namespace Blok3Game.GameObjects
{
    public class Boss : Enemy
    {
        public int EnemyHitPoints;
        
        public Boss(int hitPoints, int moveSpeed, Vector2 position) : base(hitPoints, moveSpeed, position, "Images/Characters/rat", 0, " ", 0)
        {
            EnemyHitPoints = hitPoints;
        }
    }
}