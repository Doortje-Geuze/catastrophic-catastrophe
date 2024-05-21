using Microsoft.Xna.Framework;

namespace Blok3Game.GameObjects
{
    public class FastEnemy : Enemy
    {
        public int EnemyHitPoints;
        public new int EnemyMoveSpeed = 10;
        
        public FastEnemy(int hitPoints, int moveSpeed, Vector2 position) : base(hitPoints, moveSpeed, position, "Images/Characters/FastEnemy", 0, " ", 0)
        {
            EnemyHitPoints = hitPoints;
            EnemyMoveSpeed = moveSpeed;
        }
    }
}

// public void EnemySeeking(Vector2 PlayerPosition) // Made with the help of https://code.tutsplus.com/understanding-steering-behaviors-seek--gamedev-849t
//         {
//             desired_velocity = PlayerPosition - position;
//             desired_velocity.Normalize();
//             desired_velocity *= EnemyMoveSpeed;

//             steering = desired_velocity - velocity;

//             steering = steering / 5;
//             velocity = velocity + steering;
//             position += velocity;
//         }