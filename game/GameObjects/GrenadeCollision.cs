using System;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using Blok3Game.Engine.GameObjects;
using Blok3Game.GameObjects;
using Microsoft.Xna.Framework;

namespace Blok3Game.SpriteGameObjects
{
    public class GrenadeCollision : SpriteGameObject
    {
        public GrenadeCollision(Vector2 position, string assetName, int layer = 0, string id = "", int sheetIndex = 0) : base(assetName)
        {
            Position = position;
        }
    }
    public class GrenadeCollisionBox : Box
    {
        public bool kaboomTime = false;

        public GrenadeCollisionBox(Vector2 position) : base(position, "Images/Tiles/SquareYellow", 0, " ", 0)
        {
            scale = 2;
        }
    }
}