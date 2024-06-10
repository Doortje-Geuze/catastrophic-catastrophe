using System;
using Blok3Game.Engine.SocketIOClient;
using Blok3Game.GameStates;
using Microsoft.Xna.Framework;

namespace BaseProject
{
    public class Game : GameEnvironment
    {
        protected override void LoadContent()
        {
            base.LoadContent();

            screen = new Point(1440, 720);
            ApplyResolutionSettings();

            InitializeSocketClient();

            GameStateManager.AddGameState("MAIN_MENU_STATE", new MainMenuState());
            GameStateManager.AddGameState("SETTINGS_MENU_STATE", new SettingsMenuState());
            GameStateManager.AddGameState("GAME_STATE", new GameState());
            GameStateManager.AddGameState("LOSE_SCREEN_STATE", new LoseScreenState());
            GameStateManager.AddGameState("WIN_SCREEN_STATE", new WinScreenState());
            GameStateManager.AddGameState("CONTROLS_MENU_STATE", new ControlSettingsState());
            GameStateManager.AddGameState("SHOP_STATE", new ShopState());
            GameStateManager.AddGameState("UPGRADE_STATE", new UpgradeState());
            GameStateManager.SwitchToState("MAIN_MENU_STATE");
        }

        private void InitializeSocketClient()
        {
            SocketClient.Instance.Initialize();
        }

        protected override void OnExiting(object sender, EventArgs args)
        {
            base.OnExiting(sender, args);

            //do something when the game exits
        }
    }
}
