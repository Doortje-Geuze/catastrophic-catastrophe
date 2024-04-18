using System;
using Blok3Game.Engine.GameObjects;
using Microsoft.Xna.Framework;

namespace Blok3Game.GameObjects
{
    public class RedEnemies : Enemies
    {
        private int EnemyHp;
        private int EnemySpeed;
        public RedEnemies(int hp, int speed, Vector2 position, string assetName = "Images/Enemies/standaard enemy") : base(hp, speed, position, assetName)
        {
            EnemyHp = hp;
            EnemySpeed = speed;
            Position = position;
        }
    }
}