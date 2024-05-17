using System;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using Blok3Game.Engine.GameObjects;
using Blok3Game.GameObjects;
using Microsoft.Xna.Framework;

namespace Blok3Game.SpriteGameObjects
{
 
  abstract class Box : SpriteGameObject, Istorable
    {
        public  Box ( Vector2 position, int layer = 0, string id = "") : base( Vector2, layer, id, 0)
        {
            
           
            
        }

       
    }


 class YellowBox : Box
{
    public YellowBox (Vector2 position, int layer = 0, string id = "") : base(position, layer, "Images/Tiles/SquareYellow")
    {
        public YellowBox yellowbox;
        void save()
          {
            Console.WriteLine("save"); 
          }

        void pickUp()
          {
            Console.WriteLine("pickup");
          }

       

        public bool NeedSave {
                get, set,
             }
    }
}
}

interface  Istorable
{
     public void save();
     public void PickUp();

     public bool NeedSave { get; set;}

}

