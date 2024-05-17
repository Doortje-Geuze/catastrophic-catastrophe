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
    }
}