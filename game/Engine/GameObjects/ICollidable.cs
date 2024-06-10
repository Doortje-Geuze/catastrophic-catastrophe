using Blok3Game.Engine.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Blok3Game.Engine.GameObjects
{
	public interface ICollidable
	{
		bool HandleCollision(SpriteGameObject spriteGameObject);
	}
}