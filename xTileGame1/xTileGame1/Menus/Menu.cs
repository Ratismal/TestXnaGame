using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TestGame.Buttons;
using TestGame.Lib;

namespace TestGame.Menus
{
    class Menu
    {
        public List<Button> ButtonList;

        public Menu()
        {
            
        }

        public virtual void Initialize()
        {
            ButtonList = new List<Button>();
        }

        public virtual void Update(GameTime gameTime)
        {
            MouseState ms = Mouse.GetState();
            CheckInput(ms);
            MenuHelper.CheckButtonHover(ms, ButtonList);
        }

        public void CheckInput(MouseState ms)
        {
            Button button;
            
            if (ms.LeftButton == ButtonState.Pressed)
            {
                button = MenuHelper.CheckButtonClick(ms, ButtonList);
                if (button != null)
                    OnButtonClick(button, 0);
            }
            if (ms.MiddleButton == ButtonState.Pressed)
            {
                button = MenuHelper.CheckButtonClick(ms, ButtonList);
                if (button != null)
                    OnButtonClick(button, 2);
            }
            if (ms.RightButton == ButtonState.Pressed)
            {
                button = MenuHelper.CheckButtonClick(ms, ButtonList);
                if (button != null)
                    OnButtonClick(button, 1);
            }
        }

        public virtual void Draw(SpriteBatch b)
        {
            foreach (var button in ButtonList)
            {
                button.Draw(b);
            }
        }

        public virtual void OnButtonClick(Button button, int mouseButton)
        {
            
        }

    }
}
