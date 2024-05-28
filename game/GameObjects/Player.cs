using Blok3Game.Engine.GameObjects;
using Blok3Game.Engine.Helpers;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Data;
using Blok3Game.SpriteGameObjects;
using Blok3Game.GameObjects;
using Blok3Game.GameStates;

public class Player : Character, ICollidable
{
    //all variables that a player needs
    public GameState Gamestate { get; set; }
    private int PlayerDashTimer = 0;
    private Vector2 Direction = new();
    private bool IsDashing = false;
    private int DashCooldown = 0;
    public int InvulnerabilityCooldown = 0;
    public int BaseHitPoints = 3;
    public int currencyCounter = 0;
    public const int BaseMoveSpeed = 5;
    public const int BaseInvulnerabilityCooldown = 120;

    public Player(int hitPoints, int moveSpeed, Vector2 position) :
                  base(hitPoints, moveSpeed, position, "Images/Characters/playerCat@2x1", 0, " ", 0)
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
            if ((Position.X <= 0 && Position.X >= GameEnvironment.Screen.X) || (Position.Y <= 0 && Position.Y >= GameEnvironment.Screen.Y))
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
        MoveSpeed = BaseMoveSpeed * 5;
        Position = new Vector2(Position.X + MoveSpeed * Direction.X, Position.Y + MoveSpeed * Direction.Y);
        return;
    }

    //Reduces DashCooldown every frame, and also stops the player from dashing once the dash duration limit is met
    private void CheckPlayerDashDuration()
    {
        if (DashCooldown > 0)
        {
            DashCooldown--;
            Gamestate.dashIndicator.SwitchSprites(DashCooldown);
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

    //handles player collision with spritegameobjects, using a switch-case to correctly handle the collision based on the type of spritegameobject
    public void HandleCollision(SpriteGameObject spriteGameObject)
    {
        if (CollidesWith(spriteGameObject) == false) return;
        switch (spriteGameObject)
        {
            case Enemy:
                if (InvulnerabilityCooldown <= 0)
                {
                    UpdatePlayerHealth();
                }
                break;
            case EnemyBullet:
                if (InvulnerabilityCooldown <= 0)
                {
                    UpdatePlayerHealth();
                }
                break;
            case Currency:
                currencyCounter++;
                Gamestate.playerCurrency.Text = $"you collected {currencyCounter} currency";
                Gamestate.toRemoveList.Add(spriteGameObject);
                break;
        }
    }

    //updates the playerHealth when the player is hit by an enemy or enemyBullet
    private void UpdatePlayerHealth()
    {
        HitPoints -= 1;
        Gamestate.playerHealth.Text = $"{HitPoints}";
        InvulnerabilityCooldown = BaseInvulnerabilityCooldown;
        Console.WriteLine(HitPoints);
    }
    public bool CheckForPlayerCollision(SpriteGameObject box)
    {
        if (CollidesWith(box))
        {
            return true;
        }
        return false;
    }
}