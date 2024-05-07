using System;
using Blok3Game.Engine.GameObjects;
using Microsoft.Xna.Framework;


namespace Blok3Game.GameObjects
{
    public class Bullet : RotatingSpriteGameObject
    {
        public Bullet(Vector2 position, double angle, string assetName = " ", int layer = 0, string id = "", int sheetIndex = 0) : base(assetName)
        {
            Position = position;
            Angle = (float)angle;
        }
    }
}