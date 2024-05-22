using Blok3Game.Engine.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Blok3Game.GameObjects
{
    public class Currency : SpriteGameObject
    {
        public Currency(Vector2 position, string assetName = "Images/UI/shield") : base(assetName)
        {
            Position = position;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}