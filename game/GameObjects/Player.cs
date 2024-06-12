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
    private int PlayerDashTimer = 0;
    private Vector2 Direction = new();
    private bool IsDashing = false;
    private int DashCooldown = 0;
    public int InvulnerabilityCooldown = 0;
    public int BaseHitPoints = 3;
    public int currencyCounter;
    public int BaseMoveSpeed = 5;
    public int BaseInvulnerabilityCooldown = 120;
    public int BaseDashCooldown = 60;

    public Player(int hitPoints, int moveSpeed, Vector2 position) :
                  base(hitPoints, moveSpeed, position, "Images/Characters/playerCat@2x1", 0, " ", 0)
    {
        HitPoints = hitPoints;
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);

        if (IsDashing)
        {
            if (Position.X <= 0 || Position.X >= GameEnvironment.Screen.X - Width || Position.Y <= 0 || Position.Y >= GameEnvironment.Screen.Y - Height)
            {
                ResetDashValue();
                return;
            }
            PlayerDash();
        }
        CheckPlayerInvulnerabilityCooldown();
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
    }

    //Increases movement speed for a short duration, which launches the player forward, and puts dash on a cooldown
    private void PlayerDash()
    {
        Position = new Vector2(Position.X + MoveSpeed * Direction.X, Position.Y + MoveSpeed * Direction.Y);
        PlayerDashTimer++;
        DashCooldown = BaseDashCooldown;
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
            GameState.Instance.dashIndicator.SwitchSprites(DashCooldown, BaseDashCooldown);
        }
        if (PlayerDashTimer > 5)
        {
            ResetDashValue();
            return;
        }
    }

    //if-statement that flashes red colouring over the player to indicate that they have been hit, and are currently invulnerable
    private void CheckPlayerInvulnerabilityCooldown()
    {
        if (InvulnerabilityCooldown > 0)
        {
            if (InvulnerabilityCooldown % (BaseInvulnerabilityCooldown / 2) > (BaseInvulnerabilityCooldown / 4))
            {
                Shade = new Color(255, 0, 0);
            }
            if (InvulnerabilityCooldown % (BaseInvulnerabilityCooldown / 2) < (BaseInvulnerabilityCooldown / 4))
            {
                Shade = new Color(255, 255, 255);
            }
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
    public bool HandleCollision(SpriteGameObject spriteGameObject)
    {
        
        if (CollidesWith(spriteGameObject) == false) return false;
        switch (spriteGameObject)
        {
            case Enemy:
                if (InvulnerabilityCooldown <= 0)
                {
                    UpdatePlayerHealth();
                }
                return true;
            case EnemyBullet:
                if (InvulnerabilityCooldown <= 0)
                {
                    UpdatePlayerHealth();
                }
                return true;
            case Currency:
                GameState.Instance.playerCurrency.Text = $"you collected {currencyCounter} currency";
                GameState.Instance.toRemoveList.Add(spriteGameObject);
                break;
            case Door:
                return true;

        }
        return false;
    }

    //updates the playerHealth when the player is hit by an enemy or enemyBullet
    private void UpdatePlayerHealth()
    {
        HitPoints -= 1;
        GameState.Instance.playerHealth.Text = $"{HitPoints}";
        InvulnerabilityCooldown = BaseInvulnerabilityCooldown;
    }

    public bool CheckForPlayerCollision(SpriteGameObject box)
    {
        if (CollidesWith(box))
        {
            return true;
        }
        return false;
    }

    public void UpdateValue(int value, string type)
    {
        switch (type)
        {
            case "HitPoints":
                HitPoints += value;
                GameState.Instance.playerHealth.Text = $"{HitPoints}";
                break;
            case "MoveSpeed":
                BaseMoveSpeed += value;
                MoveSpeed += value;
                break;
            case "InvulnerabilityCooldown":
                BaseInvulnerabilityCooldown += value;
                break;
            case "DashCooldown":
                BaseDashCooldown -= value;
                break;
        }
    }
}