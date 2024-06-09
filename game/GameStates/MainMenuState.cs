using Blok3Game.Engine.UI;
using Microsoft.Xna.Framework;

namespace Blok3Game.GameStates
{
    public class MainMenuState : MenuItem
    {
        public MainMenuState() : base()
        {
            CreateButtons();
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

        private void CreateButtons()
        {
            CreateButton(new Vector2(GameEnvironment.Screen.X / 2 - ButtonOffSet.X, (GameEnvironment.Screen.Y / 2) - ButtonOffSet.Y), "NEW GAME/CONTINUE", OnButtonGameClicked);
            CreateButton(new Vector2(GameEnvironment.Screen.X / 2 - ButtonOffSet.X, GameEnvironment.Screen.Y / 2), "SETTINGS", OnButtonSettingsClicked);
            CreateButton(new Vector2(GameEnvironment.Screen.X / 2 - ButtonOffSet.X, (GameEnvironment.Screen.Y / 2) + ButtonOffSet.Y), "CONTROLS", OnButtonControlsClicked);
        }

        private void CreateTexts()
        {
            CreateText(new Vector2((GameEnvironment.Screen.X / 4) + 50, 50), "Move around using WASD");
            CreateText(new Vector2((GameEnvironment.Screen.X / 4) - 60, 100), "Move crosshair with mouse and shoot with left-click");
            CreateText(new Vector2((GameEnvironment.Screen.X / 4), 150), "Dash using left-shift whilst moving");
        }

        private void OnButtonGameClicked(UIElement element)
        {
            GameEnvironment.AssetManager.AudioManager.PlaySoundEffect("button_agree");
            nextScreenName = "GAME_STATE";
            ButtonClicked();
        }

        private void OnButtonSettingsClicked(UIElement element)
        {
            GameEnvironment.AssetManager.AudioManager.PlaySoundEffect("button_agree");
            nextScreenName = "SETTINGS_MENU_STATE";
            ButtonClicked();
        }

        private void OnButtonControlsClicked(UIElement element)
        {
            GameEnvironment.AssetManager.AudioManager.PlaySoundEffect("button_agree");
            nextScreenName = "CONTROLS_MENU_STATE";
            ButtonClicked();
        }
    }
}
