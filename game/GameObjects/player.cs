using Blok3Game.Engine.GameObjects;

public class Player : GameObjectList
{
    protected SpriteGameObject player;
    protected int HP;
    protected int X;
    protected int Y;

    public Player(int X, int Y, int Health) : base()
    {
        player = new SpriteGameObject("Images/Characters/circle", 1, "")
        {
            Position = new Microsoft.Xna.Framework.Vector2(X, Y)
        };
        Add(player);
    }
}