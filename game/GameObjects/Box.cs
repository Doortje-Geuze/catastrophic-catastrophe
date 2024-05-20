using System;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using Blok3Game.Engine.GameObjects;
using Blok3Game.GameObjects;
using Microsoft.Xna.Framework;

namespace Blok3Game.SpriteGameObjects
{
  

    class Box : SpriteGameObject
       {
        public  Box ( Vector2 position, int layer = 0, string id = "") : base( position, layer, id, 0)
        {
          
           
            
        }

        
    }


 class YellowBox : Box
{
    public YellowBox (Vector2 position, int layer = 0, string id = "") : base(position, layer, "Images/Tiles/SquareYellow")
    {
         
       
    }
}
}



