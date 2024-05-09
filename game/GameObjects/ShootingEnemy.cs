using System;
using Blok3Game.Engine.GameObjects;
using Blok3Game.Engine.Helpers;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Blok3Game.GameObjects;
using System.Data.SqlTypes;
using System.Diagnostics.Contracts;
using Microsoft.Xna.Framework.Graphics;


public class ShootingEnemy : Enemy
{
    public int EnemyHitPoints;
    public float XPosition {get; set;}
    public float YPosition {get; set;}
    public Vector2 steering;
    public Vector2 desired_velocity;
    public ShootingEnemy(int hitPoints, int moveSpeed, Vector2 position) : base(hitPoints, moveSpeed, position, "Images/Characters/rat", 0, " ", 0)
    {
        EnemyHitPoints = hitPoints;
        XPosition = position.X;
        YPosition = position.Y;
    }

    public void EnemySeeking(Vector2 PlayerPosition) // Made with the help of https://code.tutsplus.com/understanding-steering-behaviors-seek--gamedev-849t
    {
        desired_velocity = PlayerPosition - position;
        desired_velocity.Normalize();
        desired_velocity *= EnemyMoveSpeed;

        steering = desired_velocity - velocity;

        steering = steering / 5;
        velocity = velocity + steering;
        position += velocity;
    }
}