using System;
using Blok3Game.Engine.GameObjects;
using Blok3Game.Engine.Helpers;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

public class Player : SpriteGameObject
{
    //all variables that a player needs
    public int HP;
    private readonly int Size = 90;
    private int MoveSpeed = 5;
    private int PlayerDashTimer = 0;
    private Vector2 Direction = new();
    private bool IsDashing = false;
    private int DashCooldown = 0;

    public Player(int PlayerHealth, Microsoft.Xna.Framework.Vector2 position, string assetName = "Images/Characters/circle90") : base(assetName)
    {
        HP = PlayerHealth;
        Position = position;
    }

    public override void HandleInput(InputHelper inputHelper)
    {
        base.HandleInput(inputHelper);
        CheckPlayerDashDuration();

        //sets dashing state to true when the shift button is pressed and the cooldown requirement is met, and then activates dashing logic while IsDashing is still true
        if (inputHelper.KeyPressed(Keys.LeftShift) && DashCooldown <= 0)
        {
            IsDashing = true;
        }
        if (IsDashing)
        {
            if (Position.X is <= 0 or >= 710 || Position.Y is <= 0 or >= 510) 
            {
                ResetDashValue();
                return;
            }
            PlayerDash();
        }
        CheckForMovementInputs(inputHelper);
    }

    //Increases movement speed for a short duration, which launches the player forward, and puts dash on a cooldown
    private void PlayerDash()
    {
        Position = new Microsoft.Xna.Framework.Vector2(Position.X + MoveSpeed * Direction.X, Position.Y + MoveSpeed * Direction.Y);
        PlayerDashTimer++;
        DashCooldown = 60;
        MoveSpeed = 15;
        Position = new Vector2(Position.X + MoveSpeed * Direction.X, Position.Y + MoveSpeed * Direction.Y);
        return; 
    }

    //Reduces DashCooldown every frame, and also stops the player from dashing once the dash duration limit is met
    private void CheckPlayerDashDuration()
    {
        if (DashCooldown > 0)
        {
            DashCooldown--;
        }
        if (PlayerDashTimer > 3)
        {
            ResetDashValue();
            return;
        }
    }

    //checks for wasd movement, then sets position based on movespeed and direction (which is determined by what key on the keyboard is pressed)
    private void CheckForMovementInputs(InputHelper inputHelper)
    {
        base.HandleInput(inputHelper);
        if (inputHelper.IsKeyDown(Keys.W) && Position.Y > 0)
        {
            Direction = new Vector2(0, -1);
            Position = new Microsoft.Xna.Framework.Vector2(Position.X, Position.Y + MoveSpeed * Direction.Y);
        }
        if (inputHelper.IsKeyDown(Keys.A) && Position.X > 0)
        {
            Direction = new Vector2(-1, 0);
            Position = new Microsoft.Xna.Framework.Vector2(Position.X + MoveSpeed * Direction.X, Position.Y);
        }
        if (inputHelper.IsKeyDown(Keys.S) && Position.Y < 600 - Size)
        {
            Direction = new Vector2(0, 1);
            Position = new Microsoft.Xna.Framework.Vector2(Position.X, Position.Y + MoveSpeed * Direction.Y);
        }
        if (inputHelper.IsKeyDown(Keys.D) && Position.X < 800 - Size)
        {
            Direction = new Vector2(1, 0);
            Position = new Microsoft.Xna.Framework.Vector2(Position.X + MoveSpeed * Direction.X, Position.Y);
        }
    }

    private void ResetDashValue()
    {
        IsDashing = false;
        PlayerDashTimer = 0;
        MoveSpeed = 5;
    }
}