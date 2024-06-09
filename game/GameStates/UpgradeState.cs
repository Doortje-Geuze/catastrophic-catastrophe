using System;
using System.Diagnostics;
using Blok3Game.Engine.GameObjects;
using Blok3Game.Engine.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace Blok3Game.GameStates
{
    public class UpgradeState : MenuItem
    {
        private TextGameObject CurrencyCount = new("Fonts/SpriteFont@20px");
        private TextGameObject BulletSpeedUpgradeText = new("Fonts/SpriteFont");
        private TextGameObject SpeedUpgradeText = new("Fonts/SpriteFont");
        private TextGameObject HealthUpgradeText = new("Fonts/SpriteFont");
        private TextGameObject InvulnerabilityUpgradeText = new("Fonts/SpriteFont");
        private TextGameObject DashUpgradeText = new("Fonts/SpriteFont");
        private int BulletSpeedUpgradeCost = 1;
        private int PlayerSpeedUpgradeCost = 1;
        private int PlayerHealthUpgradeCost = 1;
        private int InvulnerabilityCooldownUpgradeCost = 1;
        private int DashCooldownUpgradeCost = 1;
        private Vector2 TextOffset = new(GameEnvironment.Screen.X / 80, GameEnvironment.Screen.Y / 8);
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
            CurrencyCountUpdate();
            UpdateUpgradeText();
        }

        private void CreateTexts()
        {
            TextCreator(CurrencyCount, $"Currency counter: You have {GameState.Instance.player.currencyCounter}", 
                        new Vector2(GameEnvironment.Screen.X / 3, GameEnvironment.Screen.Y / 6) - TextOffset);
            TextCreator(BulletSpeedUpgradeText, $"Bullet Speed Upgrade Cost: {BulletSpeedUpgradeCost}", 
                        new Vector2(0, GameEnvironment.Screen.Y / 3) + TextOffset);
            TextCreator(SpeedUpgradeText, $"Speed Upgrade Cost: {PlayerSpeedUpgradeCost}", 
                        new Vector2(GameEnvironment.Screen.X / 4, GameEnvironment.Screen.Y / 3) + TextOffset);
            TextCreator(HealthUpgradeText, $"Health Upgrade Cost: {PlayerHealthUpgradeCost}", 
                        new Vector2(GameEnvironment.Screen.X / 2, GameEnvironment.Screen.Y / 3) + TextOffset);
            TextCreator(DashUpgradeText, $"Dash Upgrade Cost: {DashCooldownUpgradeCost}", 
                        new Vector2(GameEnvironment.Screen.X / (float)1.3, GameEnvironment.Screen.Y / 3)+ TextOffset);
            TextCreator(InvulnerabilityUpgradeText, $"Invulnerability Upgrade Cost: {InvulnerabilityCooldownUpgradeCost}", 
                        new Vector2(GameEnvironment.Screen.X / 2 - ButtonOffSet.X, GameEnvironment.Screen.Y / 2) + TextOffset);
        }

        private void CreateButtons()
        {
            CreateButton(new Vector2(GameEnvironment.Screen.X / 2 - ButtonOffSet.X, GameEnvironment.Screen.Y / (float)1.5), "SHOP", OnButtonShopClicked);
            CreateButton(new Vector2(0, GameEnvironment.Screen.Y / 3), "BULLET SPEED INCREASE", OnButtonBulletSpeedClicked);
            CreateButton(new Vector2(GameEnvironment.Screen.X / 4, GameEnvironment.Screen.Y / 3), "PLAYER SPEED INCREASE", OnButtonPlayerSpeedClicked);
            CreateButton(new Vector2(GameEnvironment.Screen.X / 2, GameEnvironment.Screen.Y / 3), "PLAYER HEALTH INCREASE", OnButtonPlayerHealthClicked);
            CreateButton(new Vector2(GameEnvironment.Screen.X / (float)1.3, GameEnvironment.Screen.Y / 3), "DASH COOLDOWN DECREASE", OnButtonDashCooldownClicked);
            CreateButton(new Vector2(GameEnvironment.Screen.X / 2 - ButtonOffSet.X, GameEnvironment.Screen.Y / 2), "INVULNERABILITY INCREASE", OnButtonInvulnerabilityCooldownClicked);
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
            if (GameState.Instance.player.currencyCounter < BulletSpeedUpgradeCost) return;
            GameEnvironment.AssetManager.AudioManager.PlaySoundEffect("button_agree");
            GameState.Instance.PlayerBulletSpeed += 3;
            GameState.Instance.player.currencyCounter -= BulletSpeedUpgradeCost;
            BulletSpeedUpgradeCost *= 2;
            nextScreenName = "UPGRADE_STATE";
            ButtonClicked();
        }

        private void OnButtonPlayerSpeedClicked(UIElement element)
        {
            if (GameState.Instance.player.BaseMoveSpeed >= 9) return;
            UpgradeButtonClicked(1, "MoveSpeed", PlayerSpeedUpgradeCost);
            PlayerSpeedUpgradeCost *= 2;
        }

        private void OnButtonPlayerHealthClicked(UIElement element)
        {
            if (GameState.Instance.player.HitPoints >= 5) return;
            UpgradeButtonClicked(1, "HitPoints", PlayerHealthUpgradeCost);
            PlayerHealthUpgradeCost *= 2;
        }

        private void OnButtonInvulnerabilityCooldownClicked(UIElement element)
        {
            if (GameState.Instance.player.BaseInvulnerabilityCooldown >= 180) return;
            UpgradeButtonClicked(15, "InvulnerabilityCooldown", InvulnerabilityCooldownUpgradeCost);
            InvulnerabilityCooldownUpgradeCost *= 2;
        }

        private void OnButtonDashCooldownClicked(UIElement element)
        {
            if (GameState.Instance.player.BaseDashCooldown <= 20) return;
            UpgradeButtonClicked(10, "DashCooldown", DashCooldownUpgradeCost);
            DashCooldownUpgradeCost *= 2;
        }

        //types that can be given as parameters: "HitPoints, "MoveSpeed", "InvulnerabilityCooldown" & "DashCooldown".
        private void UpgradeButtonClicked(int value, string type, int currencyRequirement)
        {
            Console.WriteLine($"the player has {GameState.Instance.player.currencyCounter} left");
            if (GameState.Instance.player.currencyCounter < currencyRequirement) return;
            GameEnvironment.AssetManager.AudioManager.PlaySoundEffect("button_agree");
            GameState.Instance.player.UpdateValue(value, type);
            GameState.Instance.player.currencyCounter -= currencyRequirement;
            nextScreenName = "UPGRADE_STATE";
            ButtonClicked();
            Console.WriteLine($"{currencyRequirement} currency was removed from the player");
        }

        private void CurrencyCountUpdate()
        {
            CurrencyCount.Text = $"Currency counter: You have {GameState.Instance.player.currencyCounter}";
            GameState.Instance.playerCurrency.Text = $"you collected {GameState.Instance.player.currencyCounter} currency";
        }

        private void TextCreator(TextGameObject textObject, string text, Vector2 position)
        {
            textObject.Text = text;
            textObject.Position = position;
            Add(textObject);
        }

        private void UpdateUpgradeText()
        {
            BulletSpeedUpgradeText.Text = $"Bullet Speed Upgrade Cost: {BulletSpeedUpgradeCost}";
            SpeedUpgradeText.Text = $"Speed Upgrade Cost: {PlayerSpeedUpgradeCost}";
            HealthUpgradeText.Text = $"Health Upgrade Cost: {PlayerHealthUpgradeCost}";
            DashUpgradeText.Text = $"Dash Upgrade Cost: {DashCooldownUpgradeCost}";
            InvulnerabilityUpgradeText.Text = $"Invulnerability Upgrade Cost: {InvulnerabilityCooldownUpgradeCost}";
        }
    }
}