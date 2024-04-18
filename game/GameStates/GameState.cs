using Blok3Game.Engine.GameObjects;

namespace Blok3Game.GameStates
{
    public class GameState : GameObjectList
    {
        public GameState() : base()
        {           
            Player player = new(300, 300, 5);
            Add(player);
        }        
    }
}
