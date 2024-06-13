using Blok3Game.Engine.GameObjects;
using Blok3Game.Engine.Helpers;
using Blok3Game.Engine.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Blok3Game.GameStates
{
    public class TitleScreenState : MenuItem
    {
        public TitleScreenState() : base()
        {
            CreateTitle();
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

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);

            if (inputHelper.KeyPressed(Keys.Enter))
            {
                nextScreenName = "MAIN_MENU_STATE";
                ButtonClicked();
            }
        }

        private void CreateTitle()
        {
            SpriteGameObject logoText = new ("Images/UI/gameLogo", 0);

             //use the width and height of the title to position it in the center of the screen
             logoText.Position = new Vector2((GameEnvironment.Screen.X / 2) - (logoText.Width / 2), GameEnvironment.Screen.Y / 7);

        Add(logoText);
        }

        private void CreateTexts()
        {
            CreateText(new Vector2((GameEnvironment.Screen.X / 2) - ButtonOffSet.X, GameEnvironment.Screen.Y / (float)1.5), "Press ENTER to go to main menu");
        }
    }
}
