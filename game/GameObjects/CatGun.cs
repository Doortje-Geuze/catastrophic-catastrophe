using Blok3Game.Engine.GameObjects;
using Blok3Game.Engine.Helpers;
using Blok3Game.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

public class CatGun : RotatingSpriteGameObject
{
    private Player playerPos;
    private Crosshair crossHair;
    bool CatArms = false;
    public CatGun(Player player, Crosshair crosshair, Vector2 position) : base("Images/Characters/gunCat@2x1")
    {
        playerPos = player;
        parent = playerPos;
        Position = position;
        crossHair = crosshair;
    }

    public override void HandleInput(InputHelper inputHelper)
    {
        base.HandleInput(inputHelper);

        if (inputHelper.IsKeyDown(Keys.A) && Position.X > 0)
        {
            Sprite.Mirror = true;
        }
        if (inputHelper.IsKeyDown(Keys.D) && Position.X < GameEnvironment.Screen.X - Height)
        {
            Sprite.Mirror = false;
        }
        if (inputHelper.IsKeyDown(Keys.X))
        {
            CatArms = true;
        }
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);

        if (Sprite.Mirror)
        {
            position = new Vector2(playerPos.Position.X - 28, playerPos.Position.Y + 40);
            if (CatArms)
            {
                LookAt(crossHair, 180);
            }
        }
        else
        {
            position = new Vector2(playerPos.Position.X + 28, playerPos.Position.Y + 40);
            if (CatArms)
            {
                LookAt(crossHair);
            }
        }
    }
}
