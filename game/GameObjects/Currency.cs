using System;
using Blok3Game.Engine.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Blok3Game.GameObjects
{
    public class Currency : SpriteGameObject
    {
        private int animationTimer = 0;
        private int animationCounter = 1;
        public Currency(Vector2 position, string assetName = "Images/UI/animalCoin@2x2") : base(assetName)
        {
            Position = position;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            DoAnimation();
        }

        private void DoAnimation()
        {
            var Switcher = Math.Floor((float)(animationTimer / 12));
            animationTimer += animationCounter;
            switch (Switcher) 
            {
                case -1:
                    animationCounter = 1;
                    return;
                case 0:
                    Sprite.SheetIndex = 0;
                    return;
                case 1:
                    Sprite.SheetIndex = 1;
                    return;
                case 2:
                    Sprite.SheetIndex = 2;
                    return;
                case 3:
                    Sprite.SheetIndex = 3;
                    return;
                case 4:
                    animationCounter = -1;
                    return;
            }
        }
    }
}