using System;
using System.Runtime.Serialization;
using Blok3Game.Engine.GameObjects;
using Microsoft.Xna.Framework;

public class Shopkeeper : SpriteGameObject, ICollidable
{
    public bool Exists = false;
    public Shopkeeper(Vector2 position, string assetName = "Images/Characters/shopkeeper") : base(assetName)
    {
        Position = position;
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
    }

    public bool HandleCollision(SpriteGameObject spriteObject)
    {
        if (!CollidesWith(spriteObject)) return false;
        if (spriteObject is Player)
        {
            return true;
        } else return false;
    }
}