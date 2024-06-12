using Blok3Game.Engine.GameObjects;
using Microsoft.Xna.Framework;

namespace Blok3Game.SpriteGameObjects
{

    public abstract class Door : SpriteGameObject
    {
        public Door(Vector2 position, string assetName, int layer = 0, string id = "", int sheetIndex = 0) : base(assetName)
        {
            Position = position;
        }
    }
    public class OpenDoor : Door
    {
        public OpenDoor(Vector2 position) : base(position, "Images/UI/pixel-door-open", 0, " ", 0)
        {
        }
    }
}