using Blok3Game.Engine.GameObjects;
using Blok3Game.Engine.Helpers;
using Blok3Game.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

public class CatGun : RotatingSpriteGameObject
{
    Player playerPos;
    Crosshair crossHair;
    public CatGun(Player player, Crosshair crosshair, Vector2 position) : base("Images/Characters/GunCat@2x1")
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
        if (inputHelper.IsKeyDown(Keys.D) && Position.X < 800 - Height)
        {
            Sprite.Mirror = false;
        }
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);

        if (Sprite.Mirror)
        {
            position = new Vector2(playerPos.Position.X - 28, playerPos.Position.Y + 40);
            LookAt(crossHair, 180);
        }
        else
        {
            position = new Vector2(playerPos.Position.X + 28, playerPos.Position.Y + 40);
            LookAt(crossHair);
        }
    }
}
