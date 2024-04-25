using System.Diagnostics;
using System.Security.Cryptography;
using Blok3Game.Engine.GameObjects;
using Blok3Game.Engine.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Blok3Game.GameObjects
{
    public class Crosshair : SpriteGameObject
    {
        public Crosshair(Vector2 position, string assetName = "Images/UI/Crosshair") : base(assetName)
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