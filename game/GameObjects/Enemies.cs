using System;
using Blok3Game.Engine.GameObjects;
using Microsoft.Xna.Framework;


namespace Blok3Game.GameObjects
{

    public class Enemies : SpriteGameObject
    {
        public Enemies(int hp, double speed, Vector2 position, string assetName, int layer = 0, string id = "", int sheetIndex = 0) : base(assetName, layer, id, sheetIndex)
        {

        }
    }
}