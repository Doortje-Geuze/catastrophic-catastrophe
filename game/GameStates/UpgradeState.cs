using System;
using System.Diagnostics;
using Blok3Game.Engine.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace Blok3Game.GameStates
{
    public class UpgradeState : MenuItem
    {
        public UpgradeState() : base()
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
            CreateButton(new Vector2(GameEnvironment.Screen.X / 2 - ButtonOffSet, GameEnvironment.Screen.Y / (float)1.5), "SHOP", OnButtonShopClicked);
        }

        private void OnButtonShopClicked(UIElement element)
        {
            GameEnvironment.AssetManager.AudioManager.PlaySoundEffect("button_agree");
            nextScreenName = "SHOP_STATE";
            ButtonClicked();
        }
    }
}