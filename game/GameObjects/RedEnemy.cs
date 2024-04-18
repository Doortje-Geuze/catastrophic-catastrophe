using System;
using Blok3Game.Engine.GameObjects;
using Microsoft.Xna.Framework;

namespace Blok3Game.GameObjects
{
    public class RedEnemies : Enemies
    {
        private int EnemyHp;
        private int EnemySpeed;
        public RedEnemies(int hp, int speed, string assetName = "Images/Enemies/standaard enemy") : base(hp, speed, assetName)
        {
            EnemyHp = hp;
            EnemySpeed = speed;
        }
    }
}