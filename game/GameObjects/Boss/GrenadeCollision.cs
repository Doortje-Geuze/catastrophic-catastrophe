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
        public GrenadeCollision(Vector2 position, string assetName, string id = "", int sheetIndex = 0) : base(assetName, -1)
        {
            Position = position;
        }
    }
    public class GrenadeCollisionBox : GrenadeCollision
    {
        public bool hit = false;

        public GrenadeCollisionBox(Vector2 position) : base(position, "Images/Tiles/GrenadeHitbox", " ", 0)
        {
            scale = 2;
        }
    }
}