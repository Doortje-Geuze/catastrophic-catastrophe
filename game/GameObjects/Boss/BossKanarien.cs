using System;
using System.Linq.Expressions;
using Microsoft.VisualBasic;
using Microsoft.Xna.Framework;

namespace Blok3Game.GameObjects
{
    public class BossKanarien : Enemy
    {
        public int animationTimer = 0;
        private int animationCounter = 1;
        private double Switcher = 0;
        public int InvulnerabilityCooldown = 0;
        public BossKanarien(int hitPoints, int moveSpeed, Vector2 position) : base(hitPoints, moveSpeed, position, "Images/Enemies/Boss/KanariSpriteSheet@10x2", 0, " ", 0)
        {
        }

        public void DoWalking()
        {
            if (Velocity.X < 0)
            {
                Sprite.Mirror = false;
            }
            if (Velocity.X > 0)
            {
                Sprite.Mirror = true;
            }

            Switcher = Math.Floor((float)(animationTimer / 6));
            animationTimer += animationCounter;
            switch (Switcher)
            {
                case 0:
                    Sprite.SheetIndex = 0;
                    break;
                case 1:
                    Sprite.SheetIndex = 1;
                    break;
                case 2:
                    Sprite.SheetIndex = 2;
                    break;
                case 3:
                    Sprite.SheetIndex = 3;
                    break;
                case 4:
                    Sprite.SheetIndex = 4;
                    break;
                case 5:
                    Sprite.SheetIndex = 5;
                    break;
                case 6:
                    Sprite.SheetIndex = 6;
                    break;
                case 7:
                    Sprite.SheetIndex = 7;
                    break;
                case 8:
                    Sprite.SheetIndex = 8;
                    break;
                case 9:
                    Sprite.SheetIndex = 9;
                    break;
                case 10:
                    Sprite.SheetIndex = 10;
                    animationTimer = 0;
                    break;
            }
        }

        public void DoShooting()
        {
            Sprite.SheetIndex = 12;
        }
    }
}
