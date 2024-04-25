using System;
using System.Collections.Generic;
using System.Diagnostics;
using Blok3Game.Engine.GameObjects;
using Blok3Game.GameStates;
using Microsoft.Xna.Framework;

public class PlayerBullet : RotatingSpriteGameObject
{
    public int playerBulletCooldown = 2;
    public Vector2 Direction;
    public int BulletMoveSpeed = 15;

    public PlayerBullet(Vector2 position, double angle, string assetName = "Images/Characters/Witte-circle45") : base(assetName)
    {
        Position = position;
        Angle = (float)angle;
        // velocity = new Vector2((float)Math.Cos(Angle), (float)Math.Sin(Angle)) * BulletMoveSpeed;
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);

        if ( Position.X > 0 - Width && Position.X < GameEnvironment.Screen.X + Width && Position.Y > 0 - Width && Position.Y < GameEnvironment.Screen.Y + Width)
        {
            position += AngularDirection * BulletMoveSpeed;
        }
        else
        {
            velocity = new Vector2(0,0);
        }
    }

    public bool CheckForEnemyCollision(SpriteGameObject enemy)
    {
        if (CollidesWith(enemy))
        {
            return true;
        } return false;
    }
}

