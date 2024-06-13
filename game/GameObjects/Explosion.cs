using Blok3Game.Engine.GameObjects;
using Microsoft.Xna.Framework;
 
namespace Blok3Game.GameObjects
{
    public class Explosion : SpriteGameObject
    {
        public Explosion(Vector2 position, string assetName = "Images/Bullets/Boom") : base(assetName)
        {
            Position = position;
            scale = 2;
        }

        public bool CheckForEnemyCollision(SpriteGameObject player)
        {
            if (CollidesWith(player))
            {
                return true;
            }
            return false;
        }
    }
}