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
            CreateButton(new Vector2(GameEnvironment.Screen.X / 2 - ButtonOffSet, GameEnvironment.Screen.Y / 2 / (float)1.5), "BULLET SPEED INCREASE", OnButtonBulletSpeedClicked);
        }

        private void OnButtonShopClicked(UIElement element)
        {
            GameEnvironment.AssetManager.AudioManager.PlaySoundEffect("button_agree");
            nextScreenName = "SHOP_STATE";
            ButtonClicked();
        }

        private void OnButtonBulletSpeedClicked(UIElement element)
        {
            if (GameState.Instance.player.currencyCounter <= 0) return;
            GameEnvironment.AssetManager.AudioManager.PlaySoundEffect("button_agree");
            GameState.Instance.PlayerBulletSpeed += 5;
            GameState.Instance.player.currencyCounter -= 1;
            nextScreenName = "UPGRADE_STATE";
            ButtonClicked();
        }
    }
}