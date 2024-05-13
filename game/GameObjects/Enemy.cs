using System;
using Blok3Game.Engine.GameObjects;
using Microsoft.Xna.Framework;
 

namespace Blok3Game.GameObjects
{
    public class Enemy : Character
    {
        public int EnemyMoveSpeed;
        public Enemy(int hitPoints, int moveSpeed, Vector2 position, string assetName, int layer = 0, string id = "", int sheetIndex = 0) : base(hitPoints, moveSpeed, position, assetName)
        {
            EnemyMoveSpeed = moveSpeed;
        }
    }
}