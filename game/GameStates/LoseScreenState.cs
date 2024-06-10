using Blok3Game.Engine.GameObjects;
using Blok3Game.Engine.UI;
using Microsoft.Xna.Framework;

namespace Blok3Game.GameStates
{
    public class LoseScreenState : MenuItem
    {
        public LoseScreenState() : base()
        {
            CreateButtons();
            CreateTitle();
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
            CreateButton(new Vector2(GameEnvironment.Screen.X / 2 - ButtonOffSet.X, (GameEnvironment.Screen.Y / 2) - ButtonOffSet.Y), "RESTART?", OnButtonRestartClicked);
            CreateButton(new Vector2(GameEnvironment.Screen.X / 2 - ButtonOffSet.X, GameEnvironment.Screen.Y / 2), "MAIN MENU", OnButtonMainMenuClicked);
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

        private void OnButtonMainMenuClicked(UIElement element)
        {
            GameEnvironment.AssetManager.AudioManager.PlaySoundEffect("button_agree");
            nextScreenName = "MAIN_MENU_STATE";
            ButtonClicked();
        }

        private void CreateTitle()
        {
            SpriteGameObject defeatText = new ("Images/UI/defeatText", 0, "defeat")
            {
                 Scale = 1,
             };

             //use the width and height of the title to position it in the center of the screen
             defeatText.Position = new Vector2((GameEnvironment.Screen.X / 2) - (defeatText.Width / 2), GameEnvironment.Screen.Y / 7);

        Add(defeatText);
        }
    }
}
