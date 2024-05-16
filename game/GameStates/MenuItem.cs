using Blok3Game.Engine.GameObjects;
using Blok3Game.Engine.UI;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Blok3Game.GameStates
{
    public class MenuItem : GameObjectList
    {
        //private SpriteGameObject background;
        protected int ButtonOffSet = 100;
        protected const float BUTTON_SCALE = 0.2f;
        protected List<Button> buttons;
        protected List<TextInput> textInputs;
        protected List<TextGameObject> texts;
        protected string nextScreenName;
        public event Action ButtonActive;

        public MenuItem() : base()
        {
            InitializeVisualElements();

            ButtonActive += OnMenuItemOffscreen;
        }

        private void InitializeVisualElements()
        {
            // CreateBackground();

            buttons = new List<Button>();
            textInputs = new List<TextInput>();
            texts = new List<TextGameObject>();
        }

        protected void ButtonClicked()
        {
            ButtonActive?.Invoke();
        }

        protected void AddButton(Button button)
        {
            Add(button);
            buttons.Add(button);
        }

        protected void AddTextInput(TextInput textInput)
        {
            Add(textInput);
            textInputs.Add(textInput);
        }

        protected void AddText(TextGameObject text)
        {
            Add(text);
            texts.Add(text);
        }

        protected virtual void OnMenuItemStateActive()
        {
            foreach (Button button in buttons)
            {
                button.Disabled = false;
            }
        }

        protected virtual void OnMenuItemOffscreen()
        {
            foreach (Button button in buttons)
            {
                button.Disabled = true;
            }

            GameEnvironment.GameStateManager.SwitchToState(nextScreenName);
            OnMenuItemStateActive();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        // private void CreateBackground()
        // {
        //     background = new SpriteGameObject("Images/UI/backgroundMedieval", 0, "background")
        //     {
        //         Scale = 1,
        //     };

        //     //use the width and height of the background to position it in the center of the screen
        //     background.Position = new Vector2((GameEnvironment.Screen.X / 2) - (background.Width / 2), 0);

        //     Add(background);
        // }

        public override void Reset()
        {
            base.Reset();
        }

        protected TextGameObject CreateText(Vector2 position, string text)
        {
            TextGameObject textObject = new TextGameObject("Fonts/SpriteFont", 1, "text");
            textObject.Position = position;
            textObject.Color = Color.White;
            textObject.Text = text;
            Add(textObject);
            return textObject;
        }

        protected TextInput CreateTextInputField(Vector2 position, string accompanyingText)
        {
            CreateText(position - Vector2.UnitY * 20, accompanyingText);
            TextInput textInput = new TextInput(position, 0.2f);
            AddTextInput(textInput);
            return textInput;
        }
        protected Button CreateButton(Vector2 position, string text, Action<UIElement> onPressed, float scale = BUTTON_SCALE, string imageName = "Button@1x4")
        {
            Button button = new Button(position, scale, imageName);
            button.Text = text;
            button.Clicked += onPressed;
            AddButton(button);
            return button;
        }
    }
}
