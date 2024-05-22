using Blok3Game.Engine.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Blok3Game.GameObjects
{
    public class Crosshair : SpriteGameObject
    {
        public Crosshair(Vector2 position, string assetName = "Images/UI/crosshair") : base(assetName, 9)
        {
            Position = position;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            Position = new Vector2(Mouse.GetState().X - (Width / 2), Mouse.GetState().Y - (Height / 2));
        }
    }
}