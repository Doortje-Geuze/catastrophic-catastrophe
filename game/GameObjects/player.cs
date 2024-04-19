using System;
using System.Numerics;
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
            Position = new Vector2(X, Y)
        };
        Add(player);
    }

    public void CheckPlayerMovement()
    {
        CheckForKeys();

    }

    private void CheckForKeys()
    {
        string currentKeyDown;
        currentKeyDown = InputHelper.KeyIsDown(inputHelper.CurrentKeyboardState);
        Console.WriteLine(currentKeyDown);
    }

    public void InputHandler(InputHelper inputHelper)
    {
        
    }
}