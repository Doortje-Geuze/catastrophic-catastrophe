using Microsoft.Xna.Framework;


namespace Blok3Game.GameObjects
{
    public abstract class Enemy : Character
    {
        private Vector2 steering;
        private Vector2 desired_velocity;
        public int EnemyShootCooldown = 120;

        public Enemy(int hitPoints, int moveSpeed, Vector2 position, string assetName, int layer = 0, string id = "", int sheetIndex = 0) : base(hitPoints, moveSpeed, position, assetName)
        {
        }

        public void EnemySeeking(Vector2 PlayerPosition) // Made with the help of https://code.tutsplus.com/understanding-steering-behaviors-seek--gamedev-849t
        {
            desired_velocity = PlayerPosition - position;
            desired_velocity.Normalize();
            desired_velocity *= MoveSpeed;

            steering = desired_velocity - velocity;

            steering = steering / 5;
            velocity = velocity + steering;
            position += velocity;
        }
    }
}