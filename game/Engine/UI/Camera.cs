using Blok3Game.Engine.GameObjects;
using Blok3Game.Engine.Helpers;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Blok3Game.GameStates;
using Microsoft.Xna.Framework.Graphics;
using System;
using Blok3Game.GameObjects;

namespace Blok3Game.Engine.UI
{
    public class Camera : GameObject
    {
        public Matrix transform;
        Viewport view;
        Vector2 centre;

        public Camera(Viewport newView)
        {
            view = newView;
        }


        public override void Update(GameTime gameTime)
        {
            centre = new Vector2(player.Position.X + (player.Width / 2), player.Position.Y + (player.Height / 2));
            transform = Matrix.CreateScale(new Vector3(1,1,0)) * Matrix.CreateTranslation(new Vector3(-centre.X, -centre.Y, 0));

        }
    }

}
