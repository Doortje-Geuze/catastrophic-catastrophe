using System;
using Blok3Game.Engine.GameObjects;
using Microsoft.Xna.Framework;

namespace Blok3Game.GameObjects
{
    public class DashIndicator : SpriteGameObject
    {
        public Vector2 Offset = new(100, 0);
        public DashIndicator(Vector2 position, string assetName = "Images/UI/dashIndicator@3x3") : base(assetName)
        {
            Position = position + Offset;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public void SwitchSprites(int dashCooldown)
        {
            var Switcher = Math.Floor((float)(dashCooldown / 8));
            switch(Switcher)
            {
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
            Sprite.SheetIndex = 4;
            return;
            case 5:
            Sprite.SheetIndex = 5;
            return;
            case 6:
            Sprite.SheetIndex = 6;
            return;
            default:
            Sprite.SheetIndex = 0;
            return;
            
            }
        }
    }
}