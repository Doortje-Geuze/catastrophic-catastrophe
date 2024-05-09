using System;
using Blok3Game.Engine.GameObjects;
using Blok3Game.Engine.Helpers;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Blok3Game.GameObjects;


public class ShootingEnemy : Enemy
{
    public int EnemyHitPoints;
    public float XPosition {get; set;}
    public float YPosition {get; set;}
    public ShootingEnemy(int hitPoints, int moveSpeed, Vector2 position) : base(hitPoints, moveSpeed, position, "Images/Characters/rat", 0, " ", 0)
    {
        EnemyHitPoints = hitPoints;
        XPosition = position.X;
        YPosition = position.Y;
    }
}