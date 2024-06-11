using System;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using Blok3Game.Engine.GameObjects;
using Blok3Game.GameObjects;
using Microsoft.Xna.Framework;

namespace Blok3Game.SpriteGameObjects
{
abstract public class Obstacle : SpriteGameObject
{
    public Obstacle(Vector2 position, string assetName = " ", int layer = 0, string id = "", int sheetIndex = 0) : base(assetName)
    {
        Position = position;
    }
}

public class GreenObstacle : Obstacle
{

public GreenObstacle(Vector2 position) : base(position, "Images/Tiles/GreenSquare.png", 0, " ", 0)
    {
        

    }
}

}