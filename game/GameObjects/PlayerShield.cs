using Blok3Game.Engine.GameObjects;
using Microsoft.Xna.Framework;

namespace Blok3Game.GameObjects
{
    public class PlayerShield : SpriteGameObject
    {
        public Vector2 Offset = new((float)-72.5, (float)-76);
        public PlayerShield(Vector2 position, string assetName = "Images/UI/shield") : base(assetName)
        {
            Position = position + Offset;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}