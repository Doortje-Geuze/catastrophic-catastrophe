using System;
using System.Diagnostics;
using Blok3Game.Engine.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace Blok3Game.GameStates
{
    public class SettingsMenuState : MenuItem
    {
        public SettingsMenuState() : base()
        {
            CreateButtons();
            // CreateTexts();
        }

        public override void Reset()
        {
            base.Reset();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        private void CreateButtons()
        {
            CreateButton(new Vector2((GameEnvironment.Screen.X / 2) + ButtonOffSet.X, GameEnvironment.Screen.Y / 2), "Music Louder", onButtonMusicLouderClicked);
            CreateButton(new Vector2((GameEnvironment.Screen.X / 2) - (ButtonOffSet.X * 3), GameEnvironment.Screen.Y / 2), "Music Softer", onButtonMusicSofterClicked);

            CreateButton(new Vector2((GameEnvironment.Screen.X / 2) + ButtonOffSet.X, (GameEnvironment.Screen.Y / 2) - ButtonOffSet.Y), "Effects Louder", onButtonEffectsLouderClicked);
            CreateButton(new Vector2((GameEnvironment.Screen.X / 2) - (ButtonOffSet.X * 3), (GameEnvironment.Screen.Y / 2) - ButtonOffSet.Y), "Effects Lower", onButtonEffectsSofterClicked);

            CreateButton(new Vector2((GameEnvironment.Screen.X / 2) - ButtonOffSet.X, GameEnvironment.Screen.Y / 2 + (ButtonOffSet.Y * 2)), "Main Menu", OnButtonMainMenuClicked);
        }

        // private void CreateTexts()
        // {
        //     CreateText(new Vector2(GameEnvironment.Screen.X / 2, (GameEnvironment.Screen.Y / 2) - (ButtonOffSet)), musicVolume.ToString("0"));
        // }

        private void onButtonMusicLouderClicked(UIElement element)
        {
            if (MediaPlayer.Volume <= 0.9f)
            {
                GameEnvironment.AssetManager.AudioManager.PlaySoundEffect("button_agree");
                MediaPlayer.Volume += 0.1f;
                // CreateTexts();

                Debug.WriteLine(MediaPlayer.Volume);
            }
            else
            {
                Debug.WriteLine("The sound is loud enough. Protect your ears!");
            }
        }

        private void onButtonMusicSofterClicked(UIElement element)
        {
            if (MediaPlayer.Volume >= 0.0f)
            {
                GameEnvironment.AssetManager.AudioManager.PlaySoundEffect("button_agree");
                MediaPlayer.Volume -= 0.1f;
            }
            else
            {
                Debug.WriteLine("The sound is quiet. You don't hear it anymore!");
            }
        }

        private void onButtonEffectsLouderClicked(UIElement element)
        {
            if (SoundEffect.MasterVolume <= 0.9f)
            {
                SoundEffect.MasterVolume = Math.Max(SoundEffect.MasterVolume + 0.1f, 0.0f);
                GameEnvironment.AssetManager.AudioManager.PlaySoundEffect("button_agree");
            }
            else
            {
                Debug.WriteLine("The sound is loud enough. Protect your ears!");
            }
        }

        private void onButtonEffectsSofterClicked(UIElement element)
        {
            if (SoundEffect.MasterVolume >= 0.0f)
            {
                SoundEffect.MasterVolume = Math.Max(SoundEffect.MasterVolume - 0.1f, 0.0f);
                GameEnvironment.AssetManager.AudioManager.PlaySoundEffect("button_agree");
            }
            else
            {
                Debug.WriteLine("The sound is quiet. You don't hear it anymore!");
            }
        }

        private void OnButtonMainMenuClicked(UIElement element)
        {
            GameEnvironment.AssetManager.AudioManager.PlaySoundEffect("button_cancel");
            nextScreenName = "MAIN_MENU_STATE";
            ButtonClicked();
        }
    }
}
