using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace xTileGame1.Buttons
{
    class Button
    {
        public int Id, XCoord, YCoord, Width, Height;
        public bool Hover = false;
        
        public Button(int id, int xCoord, int yCoord, int width, int height)
        {
            Id = id;
            XCoord = xCoord;
            YCoord = yCoord;
            Width = width;
            Height = height;
        }

        public virtual void Draw(SpriteBatch b)
        {
         //   System.Console.WriteLine("Doing a button thing! ");

            // NO-OP
        }

        public virtual void OnClick(MouseState ms)
        {
            // NO-OP
        }

    }
}
