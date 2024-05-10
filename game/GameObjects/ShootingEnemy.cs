using Microsoft.Xna.Framework;
using Blok3Game.GameObjects;



public class ShootingEnemy : Enemy
{
    public int EnemyHitPoints;
    public Vector2 steering;
    public Vector2 desired_velocity;
    public int EnemyShootCooldown = 120;
    public ShootingEnemy(int hitPoints, int moveSpeed, Vector2 position) : base(hitPoints, moveSpeed, position, "Images/Characters/rat", 0, " ", 0)
    {
        EnemyHitPoints = hitPoints;
    }

    public void EnemySeeking(Vector2 PlayerPosition) // Made with the help of https://code.tutsplus.com/understanding-steering-behaviors-seek--gamedev-849t
    {
        desired_velocity = PlayerPosition - position;
        desired_velocity.Normalize();
        desired_velocity *= EnemyMoveSpeed;

        steering = desired_velocity - velocity;

        steering = steering / 5;
        velocity = velocity + steering;
        position += velocity;
    }
}