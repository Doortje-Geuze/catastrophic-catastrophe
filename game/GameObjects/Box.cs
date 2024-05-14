using System;
using Blok3Game.Engine.GameObjects;
using Blok3Game.GameObjects;
using Microsoft.Xna.Framework;

namespace Blok3Game.SpriteGameObjects
{
 
  abstract class Box : SpriteGameObject
    {
        public  Box ( Vector2 position, int layer = 0, string id = "") : base("Images/Tiles/SquareYellow", layer, id, 0)
        {
            // I Store
            // position 
        }
    }


 class BoxYelllow : Box
{
    public BoxYelllow (Vector2 position, int layer = 0, string id = "") : base(position, layer, id)
    {

    }
}
}