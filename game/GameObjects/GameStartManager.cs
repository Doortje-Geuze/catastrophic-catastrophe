namespace Blok3Game.GameObjects
{
    public static class GameStartManager
    {
        private static bool GameStarted = false;

        public static bool gameStarted
        {
            get { return GameStarted;}
            set
            {
                GameStarted = value;
            }
        }
    }
}