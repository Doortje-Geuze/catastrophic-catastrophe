using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using Blok3Game.Engine.GameObjects;
using Blok3Game.Engine.Helpers;
using Microsoft.Xna.Framework.Input;

public class Player : GameObjectList
{
    protected SpriteGameObject player;
    protected int HP;
    protected int X;
    protected int Y;
    private int MoveSpeed = 5;

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
        if (inputHelper.IsKeyDown(Keys.W) && player.Position.Y > 0)
        {
            player.Position = new Microsoft.Xna.Framework.Vector2(player.Position.X, player.Position.Y - MoveSpeed);
        }
        if (inputHelper.IsKeyDown(Keys.A) && player.Position.X > 0)
        {
            player.Position = new Microsoft.Xna.Framework.Vector2(player.Position.X - MoveSpeed, player.Position.Y);
        }
        if (inputHelper.IsKeyDown(Keys.S) && player.Position.Y < 410)
        {
            player.Position = new Microsoft.Xna.Framework.Vector2(player.Position.X, player.Position.Y + MoveSpeed);
        }
        if (inputHelper.IsKeyDown(Keys.D) && player.Position.X < 610)
        {
            player.Position = new Microsoft.Xna.Framework.Vector2(player.Position.X + MoveSpeed, player.Position.Y);
        }
        Console.WriteLine(player.Position);
    }
}