using Blok3Game.Engine.UI;
using Microsoft.Xna.Framework;

namespace Blok3Game.GameStates
{
    public class LoseScreenState : MenuItem
    {
        public LoseScreenState() : base()
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
            CreateButton(new Vector2(GameEnvironment.Screen.X / 2 - ButtonOffSet, (GameEnvironment.Screen.Y / 2) - ButtonOffSet), "RESTART GAME", OnButtonRestartClicked);
            CreateButton(new Vector2(GameEnvironment.Screen.X / 2 - ButtonOffSet, GameEnvironment.Screen.Y / 2), "MAIN_MENU_STATE", OnButtonSettingsClicked);
            // CreateButton(new Vector2(GameEnvironment.Screen.X / 2 - ButtonOffSet, (GameEnvironment.Screen.Y / 2) + ButtonOffSet), "EXIT GAME", ButtonNotImplimented);
        }

        private void ButtonNotImplimented(UIElement element)
        {
            GameEnvironment.AssetManager.AudioManager.PlaySoundEffect("button_not_implimented");
        }

        private void OnButtonRestartClicked(UIElement element)
        {
            GameEnvironment.AssetManager.AudioManager.PlaySoundEffect("button_agree");
            nextScreenName = "GAME_STATE";
            ButtonClicked();
        }

        private void OnButtonSettingsClicked(UIElement element)
        {
            GameEnvironment.AssetManager.AudioManager.PlaySoundEffect("button_agree");
            nextScreenName = "MAIN_MENU_STATE";
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
