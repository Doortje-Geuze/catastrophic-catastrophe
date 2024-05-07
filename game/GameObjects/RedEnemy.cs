using System;
using Blok3Game.Engine.GameObjects;
using Microsoft.Xna.Framework;

namespace Blok3Game.GameObjects
{
    public class RedEnemies : Enemies
    {
        private int EnemyHp;
        public double EnemySpeed;
        public double XPosition { get; set; }
        public double YPosition { get; set; }
        public RedEnemies(int hp, double speed, Vector2 position, 
                          string assetName = "Images/Enemies/standardEnemy") : base(hp, speed, position, assetName)
        {
            EnemyHp = hp;
            EnemySpeed = (double)speed;
            Position = position;
            XPosition = (double)position.X;
            YPosition = (double)position.Y;
        }
    }
}