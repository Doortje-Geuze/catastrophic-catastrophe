using Blok3Game.Engine.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Blok3Game.Engine.GameObjects
{

	public interface IPlayerPosition
	{
        int X { get; set; }
        int Y { get; set; }
        
        int Velocity { get; set; }

        void HandleInput(InputHelper inputHelper)
        {
            HandleInput(inputHelper);
            if (inputHelper.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.W) && Y > 0)
            {
                
            }
        }
		
		void Update(GameTime gameTime)
        {
            
        }
		void Draw(GameTime gameTime, SpriteBatch spriteBatch);

		void Reset();
	}
}