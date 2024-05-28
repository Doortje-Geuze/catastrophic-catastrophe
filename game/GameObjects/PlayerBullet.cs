using System;
using Blok3Game.Engine.GameObjects;
using Blok3Game.GameObjects;
using Blok3Game.GameStates;
using Microsoft.Xna.Framework;

public class PlayerBullet : Bullet
{
    public int playerBulletCooldown = 2;
    public int damage = 1;

    public PlayerBullet(Vector2 position, double angle, int bulletMoveSpeed, string assetName = "Images/Characters/whiteCircle45") : base(position, angle, bulletMoveSpeed, assetName)
    {
        BulletMoveSpeed = bulletMoveSpeed;
    }

    public bool CheckForEnemyCollision(SpriteGameObject enemy)
    {
        if (CollidesWith(enemy))
        {
            return true;
        } return false;
    }
}

