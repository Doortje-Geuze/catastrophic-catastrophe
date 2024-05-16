using Blok3Game.Engine.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Blok3Game.Engine.GameObjects
{

	public static class PlayerPositionManager
	{
        private static Vector2 playerPosition;

        public static Vector2 PlayerPosition 
        {
            get { return playerPosition; }
            set { playerPosition = value; }
        }

 
	}
}