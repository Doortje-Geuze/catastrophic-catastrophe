using Blok3Game.Engine.GameObjects;
using Blok3Game.Engine.Helpers;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Data;
using Blok3Game.SpriteGameObjects;

public class Player : Character
{
    //all variables that a player needs
    public TextGameObject playerHealth;
    public Vector2 PlayerHealthOffset = new(40, 100);
    private int PlayerDashTimer = 0;
    private Vector2 Direction = new();
    private bool IsDashing = false;
    private int DashCooldown = 0;
    public int InvulnerabilityCooldown = 0;
    public int BaseHitPoints = 3;
    public const int BaseMoveSpeed = 5;
    public const int BaseInvulnerabilityCooldown = 120;

    public Player(int hitPoints, int moveSpeed, Vector2 position) : 
                  base(hitPoints, moveSpeed, position,"Images/Characters/playerCat@2x1", 0, " ", 0)
    {
        HitPoints = hitPoints;
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
        CheckPlayerInvulnerabilityCooldown();
    }

    //Increases movement speed for a short duration, which launches the player forward, and puts dash on a cooldown
    private void PlayerDash()
    {
        Position = new Vector2(Position.X + MoveSpeed * Direction.X, Position.Y + MoveSpeed * Direction.Y);
        PlayerDashTimer++;
        DashCooldown = 60;
        MoveSpeed = BaseMoveSpeed * 3;
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
        if (PlayerDashTimer > 5)
        {
            ResetDashValue();
            return;
        }
    }

    //Reduces InvulnerabilityCooldown every frame
    private void CheckPlayerInvulnerabilityCooldown()
    {
        if (InvulnerabilityCooldown > 0)
        {
            InvulnerabilityCooldown--;
        }
    }

    //checks for wasd movement, then sets position based on movespeed and direction (which is determined by what key on the keyboard is pressed)
    private void CheckForMovementInputs(InputHelper inputHelper)
    {
        var dir = Vector2.Zero;
        base.HandleInput(inputHelper);
        if (inputHelper.IsKeyDown(Keys.W) && Position.Y > 0)
        {
            dir.Y = -1;
        }
        if (inputHelper.IsKeyDown(Keys.A) && Position.X > 0)
        {
            Sprite.SheetIndex = 1;
            dir.X = -1;
        }
        if (inputHelper.IsKeyDown(Keys.S) && Position.Y < GameEnvironment.Screen.Y - Height)
        {
            dir.Y = 1;
        }
        if (inputHelper.IsKeyDown(Keys.D) && Position.X < GameEnvironment.Screen.X - Width)
        {
            Sprite.SheetIndex = 0;
            dir.X = 1;
        }
        if (dir == Vector2.Zero) return;
        dir.Normalize();
        Position += dir * MoveSpeed;
    }

    private void ResetDashValue()
    {
        IsDashing = false;
        PlayerDashTimer = 0;
        MoveSpeed = BaseMoveSpeed;
    }

    //checks player-enemy collision, then activates HP loss and invulnerability timer
    public void CheckForEnemyCollision(SpriteGameObject enemy)
    {
        if (CollidesWith(enemy) && InvulnerabilityCooldown <= 0)
        {
            HitPoints -= 1;
            playerHealth.Text = $"{HitPoints}";
            InvulnerabilityCooldown = BaseInvulnerabilityCooldown;
            Console.WriteLine(HitPoints);
        }
    }
    public void CheckForPlayerCollision(SpriteGameObject box)
    {
        Console.WriteLine("box gone!");
    }
}