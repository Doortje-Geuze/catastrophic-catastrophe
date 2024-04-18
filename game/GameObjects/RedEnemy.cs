using System;
using Blok3Game.Engine.GameObjects;
using Microsoft.Xna.Framework;


namespace Blok3Game.GameObjects
{   

    public class RedEnemies : Enemies
    {
            public RedEnemies(int hp, int speed) : base(assetName, layer, id, sheetIndex, hp, speed)
            {   
                this.hp = 100;
                
            }
    }
}