using Blok3Game.Engine.GameObjects;
using Microsoft.Xna.Framework;

public abstract class Character : SpriteGameObject
{
    //all variables that a character needs
    public int HitPoints;
    protected float MoveSpeed;

    public Character(int hitPoints, float moveSpeed, Vector2 position, string assetName = " ", int layer = 0, string id = "", int sheetIndex = 0) : base(assetName)
    {
        HitPoints = hitPoints;
        MoveSpeed = moveSpeed;
        Position = position;
    }
}