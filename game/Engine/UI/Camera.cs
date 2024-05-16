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
        public Matrix Transform { get; private set; }
        //Viewport view;
        Vector2 centre;

        public void Follow(Character target)
        {
            var position = Matrix.CreateTranslation(new Vector3(-target.Position.X, -target.Position.Y, 0));
            var offset = Matrix.CreateTranslation(GameEnvironment.screen.X / 2, GameEnvironment.screen.Y / 2, 0);

            Transform = position * offset;
        }
        // public Camera(Viewport newView)
        // {
        //     view = newView;
        // }


        public override void Update(GameTime gameTime)
        {
            centre = new Vector2(PlayerPositionManager.PlayerPosition.X, PlayerPositionManager.PlayerPosition.Y);
            Transform = Matrix.CreateScale(new Vector3(1,1,0)) * Matrix.CreateTranslation(new Vector3(-centre.X, -centre.Y, 0));

        }
    }

}
