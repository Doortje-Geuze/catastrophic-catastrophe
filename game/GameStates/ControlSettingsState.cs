using System;
using System.Diagnostics;
using Blok3Game.Engine.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace Blok3Game.GameStates
{
    public class ControlSettingsState : MenuItem
    {
        public ControlSettingsState() : base()
        {
            //CreateButtons();
            CreateTexts();
        }

        public override void Reset()
        {
            base.Reset();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        private void CreateTexts()
        {
            CreateText(new Vector2(GameEnvironment.Screen.X / 3, (GameEnvironment.Screen.Y / 3) - (ButtonOffSet)), "Move around using WASD");
            CreateText(new Vector2(GameEnvironment.Screen.X / 3, (GameEnvironment.Screen.Y / 2) - (ButtonOffSet)), "Move crosshair with mouse and shoot with left-click");
            CreateText(new Vector2(GameEnvironment.Screen.X / 3, (GameEnvironment.Screen.Y / (float)1.5) - (ButtonOffSet)), "Dash using left-shift whilst moving");
        }
    }
}
