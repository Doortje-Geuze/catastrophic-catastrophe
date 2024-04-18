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
			
            screen = new Point(800, 600);
            ApplyResolutionSettings();
			
			InitializeSocketClient();

            GameStateManager.AddGameState("MAIN_MENU_STATE", new MainMenuState());
            GameStateManager.AddGameState("GAME_STATE", new GameState());
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
