using Blok3Game.Engine.GameObjects;
using Blok3Game.GameObjects;

namespace Blok3Game.GameStates
{
    public class GameState : GameObjectList
    {
        private RedEnemies redEnemies;
        public GameState() : base()
        {
            redEnemies = new RedEnemies(100, 5);
            Add(redEnemies);
        }
    }
}
