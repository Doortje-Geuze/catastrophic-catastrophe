using System;
using System.Drawing;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Blok3Game.Engine.GameObjects;
using Blok3Game.Engine.Helpers;
using Microsoft.Xna.Framework.Input;

public class Player : GameObjectList
{
    //all variables that a player needs
    protected SpriteGameObject player;
    protected int HP;
    protected int X;
    protected int Y;
    protected int Size = 187;
    private int MoveSpeed = 5;
    private int PlayerDashTimer = 0;
    private Vector2 Direction = new Vector2();
    private bool IsDashing = false;
    private int DashCooldown = 0;

    public Player(int X, int Y, int Health) : base()
    {
        //initialises player with a sprite and position
        player = new SpriteGameObject("Images/Characters/circle", 1, "")
        {
            Position = new Microsoft.Xna.Framework.Vector2(X, Y)
        };
        Add(player);
    }

    public override void HandleInput(InputHelper inputHelper)
    {
        Console.WriteLine(PlayerDashTimer);
        base.HandleInput(inputHelper);
        CheckPlayerDashDuration();

        //sets dashing state to true when the shift button is pressed and the cooldown requirement is met, and then activates dashing logic while IsDashing is still true
        if (inputHelper.KeyPressed(Keys.LeftShift) && DashCooldown <= 0)
        {
            IsDashing = true;
        }
        if (IsDashing)
        {
            PlayerDash();
        }
        CheckForMovementInputs(inputHelper);
    }

    //Increases movement speed for a short duration, which launches the player forward, and puts dash on a cooldown
    private void PlayerDash()
    {
        MoveSpeed = 15;
        player.Position = new Microsoft.Xna.Framework.Vector2(player.Position.X + MoveSpeed * Direction.X, player.Position.Y + MoveSpeed * Direction.Y);
        PlayerDashTimer++;
        DashCooldown = 60;
        return; 
    }

    //Reduces DashCooldown every frame, and also stops the player from dashing once the dash duration limit is met
    private void CheckPlayerDashDuration()
    {
        if (DashCooldown > 0)
        {
            DashCooldown--;
        }
        if (PlayerDashTimer > 5)
        {
            IsDashing = false;
            PlayerDashTimer = 0;
            MoveSpeed = 5;
            return;
        }
    }

    //checks for wasd movement, then sets position based on movespeed and direction (which is determined by what key on the keyboard is pressed)
    private void CheckForMovementInputs(InputHelper inputHelper)
    {
        base.HandleInput(inputHelper);
        if (inputHelper.IsKeyDown(Keys.W) && player.Position.Y > 0)
        {
            Direction = new Vector2(0, -1);
            player.Position = new Microsoft.Xna.Framework.Vector2(player.Position.X, player.Position.Y + MoveSpeed * Direction.Y);
        }
        if (inputHelper.IsKeyDown(Keys.A) && player.Position.X > 0)
        {
            Direction = new Vector2(-1, 0);
            player.Position = new Microsoft.Xna.Framework.Vector2(player.Position.X + MoveSpeed * Direction.X, player.Position.Y);
        }
        if (inputHelper.IsKeyDown(Keys.S) && player.Position.Y < 600 - Size)
        {
            Direction = new Vector2(0, 1);
            player.Position = new Microsoft.Xna.Framework.Vector2(player.Position.X, player.Position.Y + MoveSpeed * Direction.Y);
        }
        if (inputHelper.IsKeyDown(Keys.D) && player.Position.X < 800 - Size)
        {
            Direction = new Vector2(1, 0);
            player.Position = new Microsoft.Xna.Framework.Vector2(player.Position.X + MoveSpeed * Direction.X, player.Position.Y);
        }
    }
}