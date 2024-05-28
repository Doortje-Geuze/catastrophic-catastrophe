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
            CreateText(new Vector2(GameEnvironment.Screen.X / 2, GameEnvironment.Screen.Y / 6), $"Currency counter: You have {GameState.Instance.player.currencyCounter}");
            Console.WriteLine(GameState.Instance.player.currencyCounter);
        }

        private void CreateButtons()
        {
            CreateButton(new Vector2(GameEnvironment.Screen.X / 2 - ButtonOffSet, GameEnvironment.Screen.Y / (float)1.5), "SHOP", OnButtonShopClicked);
            CreateButton(new Vector2(GameEnvironment.Screen.X / (float)1.5 - ButtonOffSet * (float)1.5, GameEnvironment.Screen.Y / 2 / (float)1.5), "BULLET SPEED INCREASE", OnButtonBulletSpeedClicked);
            CreateButton(new Vector2(GameEnvironment.Screen.X / 4 - ButtonOffSet * 2, GameEnvironment.Screen.Y / 2 / (float)1.5), "PLAYER HEALTH INCREASE", OnButtonPlayerHealthClicked);
            CreateButton(new Vector2(GameEnvironment.Screen.X / 2 - ButtonOffSet * 2, GameEnvironment.Screen.Y / 2 / (float)1.5), "PLAYER SPEED INCREASE", OnButtonPlayerSpeedClicked);
            CreateButton(new Vector2(GameEnvironment.Screen.X - ButtonOffSet * 2, GameEnvironment.Screen.Y / 2 / (float)1.5), "INVULNERABILITY INCREASE", OnButtonInvulnerabilityCooldownClicked);
            CreateButton(new Vector2(GameEnvironment.Screen.X / 2 - ButtonOffSet, GameEnvironment.Screen.Y / 2 + ButtonOffSet / 2), "DASH COOLDOWN DECREASE", OnButtonDashCooldownClicked);
        }

        private void OnButtonShopClicked(UIElement element)
        {
            GameEnvironment.AssetManager.AudioManager.PlaySoundEffect("button_agree");
            nextScreenName = "SHOP_STATE";
            ButtonClicked();
        }

        private void OnButtonBulletSpeedClicked(UIElement element)
        {
            if (GameState.Instance.PlayerBulletSpeed >= 30) return;
            if (GameState.Instance.player.currencyCounter < 1) return;
            GameEnvironment.AssetManager.AudioManager.PlaySoundEffect("button_agree");
            GameState.Instance.PlayerBulletSpeed += 3;
            GameState.Instance.player.currencyCounter -= 1;
            nextScreenName = "UPGRADE_STATE";
            ButtonClicked();
        }

        private void OnButtonPlayerSpeedClicked(UIElement element)
        {
            if (GameState.Instance.player.BaseMoveSpeed >= 9) return;
            UpgradeButtonClicked(1, "MoveSpeed", 1);
        }

        private void OnButtonPlayerHealthClicked(UIElement element)
        {
            if (GameState.Instance.player.HitPoints >= 5) return;
            UpgradeButtonClicked(1, "HitPoints", 1);
        }

        private void OnButtonInvulnerabilityCooldownClicked(UIElement element)
        {
            if (GameState.Instance.player.BaseInvulnerabilityCooldown >= 180) return;
            UpgradeButtonClicked(15, "InvulnerabilityCooldown", 1);
        }

        private void OnButtonDashCooldownClicked(UIElement element)
        {
            if (GameState.Instance.player.BaseDashCooldown <= 20) return;
            UpgradeButtonClicked(10, "DashCooldown", 1);
        }

        private void UpgradeButtonClicked(int value, string type, int currencyRequirement)
        {
            if (GameState.Instance.player.currencyCounter < currencyRequirement) return;
            GameEnvironment.AssetManager.AudioManager.PlaySoundEffect("button_agree");
            GameState.Instance.player.UpdateValue(value, type);
            GameState.Instance.player.currencyCounter -= currencyRequirement;
            nextScreenName = "UPGRADE_STATE";
            ButtonClicked();
        }
    }
}