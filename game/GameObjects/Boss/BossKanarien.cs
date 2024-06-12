using Microsoft.Xna.Framework;

namespace Blok3Game.GameObjects
{
    public class BossKanarien : Enemy
    {
        public BossKanarien(int hitPoints, int moveSpeed, Vector2 position) : base(hitPoints, moveSpeed, position, "Images/Enemies/Boss/Kanari", 0, " ", 0)
        {
        }
    }
}