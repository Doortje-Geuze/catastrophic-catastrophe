using Blok3Game.Engine.GameObjects;
using Blok3Game.Engine.Helpers;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Blok3Game.GameStates;
using Microsoft.Xna.Framework.Graphics;
using System;

public abstract class Character : SpriteGameObject
{
    //all variables that a character needs
    protected int HitPoints;
    protected int MoveSpeed;

    public Character(int hitPoints, int moveSpeed, Vector2 position, string assetName = " ", int layer = 0, string id = "", int sheetIndex = 0) : base(assetName)
    {
        HitPoints = hitPoints;
        MoveSpeed = moveSpeed;
        Position = position;
    }
}