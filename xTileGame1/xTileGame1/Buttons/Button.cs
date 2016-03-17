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
        
        public Button(int id, int xCoord, int yCoord, int width, int height)
        {
            Id = id;
            XCoord = xCoord;
            YCoord = yCoord;
            Width = width;
            Height = height;
        }

        public void Draw(SpriteBatch b)
        {
            // NO-OP
        }

        public void OnClick(MouseState ms)
        {
            
        }
    }
}
