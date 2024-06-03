# Different game screens

## Probleem
Aan het begin van dit project wordt alles van de game laten zien op 1 scherm van de game. Dit wordt in deze repository, de gamestate genoemd.

```C#
namespace Blok3Game.GameStates
{
    public class GameState : GameObjectList
    {
        //all lists, objects and variables at the start of the game for the gamestate are created here
        private List<PlayerBullet> playerBulletList;
        private List<EnemyBullet> enemyBulletList;
        private List<Enemy> EnemyList;
        private List<Currency> currencyList;
        public List<GameObject> toRemoveList;
        private List<Box> boxlist;
        public Player player;
        public Crosshair crosshair;
        public CatGun catGun;
        public Box box;
        public YellowBox yellowBox;
        public PurpleBox purpleBox;
        public ShootingEnemy shootingEnemy;
        public FastEnemy fastEnemy;
        public DashIndicator dashIndicator;
        public WaveIndicator waveIndicator;
        public TextGameObject playerHealth;
        public int WaveCounter = 0;
        public int ChosenEnemy = 0;
        public int FramesPerSecond = 60;
        public int WaveIndicatorShowTime = -20;
        private bool NewWave = true;
        private SpriteGameObject background;
        public TextGameObject playerCurrency;
        public TextGameObject chooseUpgrade;
        public int EnemyShoot = 0;
        public int PlayerShootCooldown = 0;
        public int PlayerAttackTimes = 0;
        private bool pickedUpPurple = false;
        private bool pickedUpYellow = false;
        private bool waveRemoved = false;

        public GameState() : base()
        {
        }
    }
}