using System;
using Blok3Game.Engine.GameObjects;
using Microsoft.Xna.Framework;

namespace Blok3Game.GameObjects
{
    public class WaveIndicator : SpriteGameObject
    {
        public WaveIndicator(Vector2 position, string assetName = "Images/UI/Waves/wave1") : base(assetName)
        {
            Position = position;
        }
    }
}