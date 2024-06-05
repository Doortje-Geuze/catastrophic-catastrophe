using System;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using Blok3Game.Engine.GameObjects;
using Blok3Game.GameObjects;
using Microsoft.Xna.Framework;

namespace Blok3Game.SpriteGameObjects
{
    public abstract class Box : SpriteGameObject
    {
        public Box(Vector2 position, string assetName, int layer = 0, string id = "", int sheetIndex = 0) : base(assetName)
        {
            Position = position;
        }
    }

    // yelow box gives Lower Cooldown Upgrade
    public class YellowBox : Box
    {
        public YellowBox(Vector2 position) : base(position, "Images/Tiles/SquareYellow", 0, " ", 0)
        {
        }
    }

    // purple box gives Shotgun upgrade 
    public class PurpleBox : Box
    {
        public PurpleBox(Vector2 position) : base(position, "Images/Tiles/PurpleSquare", 0, " ", 0)
        {

        }
    }
}



