using System;
using Blok3Game.Engine.GameObjects;
using Blok3Game.Engine.Helpers;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Blok3Game.GameObjects;


public class ShootingEnemies : Enemy
{
    public int EnemyHp;
    public float EnemySpeed;

    public double XPosition { get; set; }
    public double YPosition { get; set; }
    public ShootingEnemies(int hp, float speed, Vector2 position, string assetName = "Images/Characters/rat") : base(hp, speed, position, assetName)
    {
        EnemyHp = hp;
        EnemySpeed = speed;
        Position = position;
        XPosition = position.X;
        YPosition = position.Y;
    }

}


