using System.Collections.Generic;
using System.Numerics;
using Blok3Game.Engine.GameObjects;

public class PlayerBullet : SpriteGameObject
{
    public int playerBulletCooldown = 2;
    public Vector2 Direction;
    public int BulletMoveSpeed = 10;

    // public PlayerBullet(int x, int y) : base()
    // {
    //     playerBullet = new SpriteGameObject("Images/Characters/Witte-circle")
    //     {
    //         Position = new Vector2(x, y),
    //     };
    //     Add(playerBullet);
    // }

    public PlayerBullet(Microsoft.Xna.Framework.Vector2 position, string assetName = "Images/Characters/Witte-circle") : base(assetName)
    {
        Position = position;
    }

    public void CheckBulletMovement()
    {
        Position = new Vector2(Position.X, Position.Y + BulletMoveSpeed);
    }
}

