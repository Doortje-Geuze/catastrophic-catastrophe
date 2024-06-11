using System;
using System.Diagnostics;
using Blok3Game.Engine.GameObjects;
using Blok3Game.Engine.UI;
using Blok3Game.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace Blok3Game.GameStates
{
    public class UpgradeState : MenuItem
    {
        private readonly TextGameObject CurrencyCount = new("Fonts/SpriteFont@20px");
        private readonly TextGameObject BulletSpeedUpgradeText = new("Fonts/SpriteFont");
        private readonly TextGameObject SpeedUpgradeText = new("Fonts/SpriteFont");
        private readonly TextGameObject HealthUpgradeText = new("Fonts/SpriteFont");
        private readonly TextGameObject DashUpgradeText = new("Fonts/SpriteFont");
        private readonly TextGameObject InvulnerabilityUpgradeText = new("Fonts/SpriteFont");
        private int BulletSpeedUpgradeCost = 1;
        private int PlayerSpeedUpgradeCost = 1;
        private int PlayerHealthUpgradeCost = 1;
        private int DashCooldownUpgradeCost = 1;
        private int InvulnerabilityCooldownUpgradeCost = 1;
        private int BulletSpeedUpgradedAmount = 0;
        private int PlayerSpeedUpgradedAmount = 0;
        private int PlayerHealthUpgradedAmount = GameState.Instance.player.HitPoints;
        private int DashUpgradedAmount = 0;
        private int InvulnerabilityUpgradedAmount = 0;
        private readonly int BulletSpeedUpgradeMax = 3;
        private readonly int PlayerSpeedUpgradeMax = 3;
        private readonly int PlayerHealthUpgradeMax = 5;
        private readonly int DashUpgradeMax = 4;
        private readonly int InvulnerabilityUpgradeMax = 5;
        private readonly int BulletSpeedUpgradeValue = 3;
        private readonly int PlayerSpeedUpgradeValue = 1;
        private readonly int PlayerHealthUpgradeValue = 1;
        private readonly int DashUpgradeValue = 10;
        private readonly int InvulnerabilityUpgradeValue = 15;
        private Vector2 TextOffset = new(GameEnvironment.Screen.X / 80, GameEnvironment.Screen.Y / 12);
        public static UpgradeState Instance { get; private set; } = new();
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
            TextCreator(BulletSpeedUpgradeText, $"Bullet Speed Upgrade Cost: {BulletSpeedUpgradeCost}" + Environment.NewLine + 
                                                $"Increases bullet speed by {BulletSpeedUpgradeValue}," + Environment.NewLine  + 
                                                $"upgraded {BulletSpeedUpgradedAmount} out of {BulletSpeedUpgradeMax} times", 
                        new Vector2(0, GameEnvironment.Screen.Y / 3) + TextOffset);
            TextCreator(SpeedUpgradeText, $"Speed Upgrade Cost: {PlayerSpeedUpgradeCost}" + Environment.NewLine + 
                                          $"Increases player speed by {PlayerSpeedUpgradeValue}," + Environment.NewLine + 
                                          $"upgraded {PlayerSpeedUpgradedAmount} out of {PlayerSpeedUpgradeMax} times", 
                        new Vector2(GameEnvironment.Screen.X / 4, GameEnvironment.Screen.Y / 3) + TextOffset);
            TextCreator(HealthUpgradeText, $"Health Upgrade Cost: {PlayerHealthUpgradeCost}" + Environment.NewLine + 
                                           $"Increases player health by {PlayerHealthUpgradeValue}," + Environment.NewLine + 
                                           $"upgraded {PlayerHealthUpgradedAmount} out of {PlayerHealthUpgradeMax} times", 
                        new Vector2(GameEnvironment.Screen.X / 2, GameEnvironment.Screen.Y / 3) + TextOffset);
            TextCreator(DashUpgradeText, $"Dash Upgrade Cost: {DashCooldownUpgradeCost}" + Environment.NewLine + 
                                         $"Decreases dash cooldown by {DashUpgradeValue}," + Environment.NewLine + 
                                         $"upgraded {DashUpgradedAmount} out of {DashUpgradeMax} times", 
                        new Vector2(GameEnvironment.Screen.X / (float)1.3, GameEnvironment.Screen.Y / 3)+ TextOffset);
            TextCreator(InvulnerabilityUpgradeText, $"Invulnerability Upgrade Cost: {InvulnerabilityCooldownUpgradeCost}" + Environment.NewLine + 
                                                    $"Increase invulnerability timer by {InvulnerabilityUpgradeValue}," + Environment.NewLine + 
                                                    $"upgraded {InvulnerabilityUpgradedAmount} out of {InvulnerabilityUpgradeMax} times", 
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
            PlayerHealthUpgradedAmount = 3;
            nextScreenName = "SHOP_STATE";
            ButtonClicked();
        }

        private void OnButtonBulletSpeedClicked(UIElement element)
        {
            if (BulletSpeedUpgradedAmount >= BulletSpeedUpgradeMax) return;
            if (!IsUpgradeAffordable(BulletSpeedUpgradeCost)) return;
            GameState.Instance.PlayerBulletSpeed += 3;
            GameState.Instance.player.currencyCounter -= BulletSpeedUpgradeCost;
            BulletSpeedUpgradeCost *= 2;
            BulletSpeedUpgradedAmount++;
            nextScreenName = "UPGRADE_STATE";
            ButtonClicked();
        }

        private void OnButtonPlayerSpeedClicked(UIElement element)
        {
            if (PlayerSpeedUpgradedAmount >= PlayerSpeedUpgradeMax) return;
            if (!IsUpgradeAffordable(PlayerSpeedUpgradeCost)) return;
            InitiateUpgrade(1, "MoveSpeed", PlayerSpeedUpgradeCost);
            PlayerSpeedUpgradeCost *= 2;
            PlayerSpeedUpgradedAmount++;
        }

        private void OnButtonPlayerHealthClicked(UIElement element)
        {
            if (PlayerHealthUpgradedAmount >= PlayerHealthUpgradeMax) return;
            if (!IsUpgradeAffordable(PlayerHealthUpgradeCost)) return;
            InitiateUpgrade(1, "HitPoints", PlayerHealthUpgradeCost);
            PlayerHealthUpgradeCost *= 2;
            PlayerHealthUpgradedAmount++;
        }

        private void OnButtonInvulnerabilityCooldownClicked(UIElement element)
        {
            if (InvulnerabilityUpgradedAmount >= InvulnerabilityUpgradeMax) return;
            if (!IsUpgradeAffordable(InvulnerabilityCooldownUpgradeCost)) return;
            InitiateUpgrade(15, "InvulnerabilityCooldown", InvulnerabilityCooldownUpgradeCost);
            InvulnerabilityCooldownUpgradeCost *= 2;
            InvulnerabilityUpgradedAmount++;
        }

        private void OnButtonDashCooldownClicked(UIElement element)
        {
            if (DashUpgradedAmount >= DashUpgradeMax) return;
            if (!IsUpgradeAffordable(DashCooldownUpgradeCost)) return;
            InitiateUpgrade(10, "DashCooldown", DashCooldownUpgradeCost);
            DashCooldownUpgradeCost *= 2;
            DashUpgradedAmount++;
        }

        private bool IsUpgradeAffordable(int currencyRequirement)
        {
            if (GameState.Instance.player.currencyCounter < currencyRequirement) return false;
            GameEnvironment.AssetManager.AudioManager.PlaySoundEffect("button_agree");
            return true;
        }

        //types that can be given as parameters: "HitPoints, "MoveSpeed", "InvulnerabilityCooldown" & "DashCooldown".
        private void InitiateUpgrade(int value, string type, int currencyRequirement)
        {
            GameState.Instance.player.currencyCounter -= currencyRequirement;
            GameState.Instance.player.UpdateValue(value, type);
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
            BulletSpeedUpgradeText.Text = $"Bullet Speed Upgrade Cost: {BulletSpeedUpgradeCost}" + Environment.NewLine + 
                                          $"Increases bullet speed by {BulletSpeedUpgradeValue}," + Environment.NewLine + 
                                          $"upgraded {BulletSpeedUpgradedAmount} out of {BulletSpeedUpgradeMax} times";
            SpeedUpgradeText.Text = $"Speed Upgrade Cost: {PlayerSpeedUpgradeCost}" + Environment.NewLine + 
                                    $"Increases player speed by {PlayerSpeedUpgradeValue}," + Environment.NewLine + 
                                    $"upgraded {PlayerSpeedUpgradedAmount} out of {PlayerSpeedUpgradeMax} times";
            HealthUpgradeText.Text = $"Health Upgrade Cost: {PlayerHealthUpgradeCost}" + Environment.NewLine + 
                                     $"Increases player health, by {PlayerHealthUpgradeValue}" + Environment.NewLine + 
                                     $"upgraded {GameState.Instance.player.HitPoints} out of {PlayerHealthUpgradeMax} times";
            DashUpgradeText.Text = $"Dash Upgrade Cost: {DashCooldownUpgradeCost}" + Environment.NewLine + 
                                   $"Decreases dash cooldown by {DashUpgradeValue}," + Environment.NewLine + 
                                   $"upgraded {DashUpgradedAmount} out of {DashUpgradeMax} times";
            InvulnerabilityUpgradeText.Text = $"Invulnerability Upgrade Cost: {InvulnerabilityCooldownUpgradeCost}" + Environment.NewLine + 
                                              $"Increase invulnerability timer by {InvulnerabilityUpgradeValue}," + Environment.NewLine + 
                                              $"upgraded {InvulnerabilityUpgradedAmount} out of {InvulnerabilityUpgradeMax} times"; 
        }
    }
}