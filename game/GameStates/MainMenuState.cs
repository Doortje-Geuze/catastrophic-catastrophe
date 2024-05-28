using Blok3Game.Engine.UI;
using Blok3Game.GameObjects;
using Microsoft.Xna.Framework;

namespace Blok3Game.GameStates
{
    public class MainMenuState : MenuItem
    {
        public MainMenuState() : base()
        {
            CreateButtons();
            // CreateTitle();
        }

        public override void Reset()
        {
            base.Reset();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        private void CreateButtons()
        {
            CreateButton(new Vector2(GameEnvironment.Screen.X / 2 - ButtonOffSet, (GameEnvironment.Screen.Y / 2) - ButtonOffSet), "NEW GAME/CONTINUE", OnButtonCreateClicked);
            CreateButton(new Vector2(GameEnvironment.Screen.X / 2 - ButtonOffSet, GameEnvironment.Screen.Y / 2), "SETTINGS", OnButtonSettingsClicked);
            // CreateButton(new Vector2(GameEnvironment.Screen.X / 2 - ButtonOffSet, (GameEnvironment.Screen.Y / 2) + ButtonOffSet), "EXIT GAME", ButtonNotImplimented);
        }

        private void ButtonNotImplimented(UIElement element)
        {
            GameEnvironment.AssetManager.AudioManager.PlaySoundEffect("button_not_implimented");
        }

        private void OnButtonCreateClicked(UIElement element)
        {
            GameEnvironment.AssetManager.AudioManager.PlaySoundEffect("button_agree");
            nextScreenName = "GAME_STATE";
            GameStartManager.gameStarted = true;
            ButtonClicked();
        }

        private void OnButtonSettingsClicked(UIElement element)
        {
            GameEnvironment.AssetManager.AudioManager.PlaySoundEffect("button_agree");
            nextScreenName = "SETTINGS_MENU_STATE";
            ButtonClicked();
        }

        // private void CreateTitle()
        // {
        //     mainTitle = new SpriteGameObject("Images/UI/titleMainMenu", 0, "title")
        //     {
        //         Scale = 1,
        //     };

        //     //use the width and height of the title to position it in the center of the screen
        //     mainTitle.Position = new Vector2((GameEnvironment.Screen.X / 2) - (mainTitle.Width / 2), GameEnvironment.Screen.Y / 7);

        //     Add(mainTitle);
        // }
    }
}
