using System;
using System.Diagnostics;
using Blok3Game.Engine.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace Blok3Game.GameStates
{
    public class ShopState : MenuItem
    {
        public ShopState() : base()
        {
            CreateButtons();
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
            CreateButton(new Vector2(GameEnvironment.Screen.X / 2 - ButtonOffSet.X, GameEnvironment.Screen.Y / (float)1.5), "UPGRADES", OnButtonUpgradesClicked);
            CreateButton(new Vector2((GameEnvironment.Screen.X / 2) - ButtonOffSet.X, GameEnvironment.Screen.Y / 2 + (ButtonOffSet.X * 2)), "MAIN MENU", OnButtonMainMenuClicked);
            CreateButton(new Vector2(GameEnvironment.Screen.X / 2 - ButtonOffSet.X, (GameEnvironment.Screen.Y / 2) - ButtonOffSet.X), "RESTART?", OnButtonReviveClicked);
        }

        private void OnButtonUpgradesClicked(UIElement element)
        {
            GameEnvironment.AssetManager.AudioManager.PlaySoundEffect("button_agree");
            nextScreenName = "UPGRADE_STATE";
            ButtonClicked();
        }

        private void OnButtonMainMenuClicked(UIElement element)
        {
            GameEnvironment.AssetManager.AudioManager.PlaySoundEffect("button_cancel");
            nextScreenName = "MAIN_MENU_STATE";
            ButtonClicked();
        }

        private void OnButtonReviveClicked(UIElement element)
        {
            GameEnvironment.AssetManager.AudioManager.PlaySoundEffect("button_agree");
            nextScreenName = "GAME_STATE";
            ButtonClicked();
        }
    }
}