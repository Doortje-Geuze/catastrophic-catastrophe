using System;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using Blok3Game.Engine.GameObjects;
using Blok3Game.GameObjects;
using Microsoft.Xna.Framework;

 
public class PinkGun : PlayerBullet, Istorable
{
   
   PinkGun active;
   PinkGun  new int BulletMoveSpeed;

    public PinkGun(Vector2 position, double angle, string assetName = "Images/Bullet/PInkSquare") : base(position, angle, assetName)
    {
        Position = position;
        Angle = (float)angle;
        BulletMoveSpeed = 10;
          
          void save()
          {
            Console.WriteLine("save"); 
          }

        void pickUp()
          {
            Console.WriteLine("pickup");
          }

       

         bool NeedSave {
                get; set;
             } 

    }
     interface  Istorable
    {
    void save();
    void PickUp();

     bool NeedSave { get; set;}

  }
}

