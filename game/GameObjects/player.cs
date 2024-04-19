using System;
using Blok3Game.Engine.GameObjects;
using Blok3Game.Engine.Helpers;
using Microsoft.Xna.Framework.Input;

public class Player : GameObjectList
{
    protected SpriteGameObject player;
    protected int HP;
    protected int X;
    protected int Y;

    public Player(int X, int Y, int Health) : base()
    {
        player = new SpriteGameObject("Images/Characters/circle", 1, "")
        {
            Position = new Microsoft.Xna.Framework.Vector2(X, Y)
        };
        Add(player);
    }

    public override void HandleInput(InputHelper inputHelper)
    {
        base.HandleInput(inputHelper);
        if (inputHelper.IsKeyDown(Keys.W))
        {
            Position = new Microsoft.Xna.Framework.Vector2(Position.X, Position.Y - 5);
        }
        if (inputHelper.IsKeyDown(Keys.A))
        {
            Position = new Microsoft.Xna.Framework.Vector2(Position.X - 5, Position.Y);
        }
        if (inputHelper.IsKeyDown(Keys.S))
        {
            Position = new Microsoft.Xna.Framework.Vector2(Position.X, Position.Y + 5);
        }
        if (inputHelper.IsKeyDown(Keys.D))
        {
            Position = new Microsoft.Xna.Framework.Vector2(Position.X + 5, Position.Y);
        }
    }
}