using System;
using Blok3Game.Engine.GameObjects;
using Microsoft.Xna.Framework;

namespace Blok3Game.GameObjects
{
    public class WaveIndicator : SpriteGameObject
    {
        private Vector2 Offset;
        public WaveIndicator(Vector2 position, int sheetIndex) : base("Images/UI/Waves/waveSheet@3x1", 2, " " , sheetIndex)
        {
            Offset = new Vector2(Width / 2, Height / 2);
            Position = position - Offset;
        }
    }
}