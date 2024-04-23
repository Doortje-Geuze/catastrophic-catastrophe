using System.Numerics;
using Blok3Game.Engine.GameObjects;

public class PlayerBullet : SpriteGameObject
{
    protected SpriteGameObject playerBullet;

    public int x;

    public int y;


    public int playerBulletCooldown = 2;

    public Vector2 Direction;

    public int BulletMoveSpeed = 10;

    public PlayerBullet (int x, int y): base()
    {
        playerBullet = new SpriteGameObject("Images/Characters/Witte-circle")
        {
            Position = new Vector2(x, y), 
        };
        Add(playerBullet);
    }
    public void CheckBulletMovement()
    {
        playerBullet.Position = new Vector2(playerBullet.Position.X, playerBullet.Position.Y + BulletMoveSpeed);
    }
}

