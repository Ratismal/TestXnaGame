using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using xTileGame1.Buttons;

namespace xTileGame1.Lib
{
    class MenuHelper
    {
        public static bool CheckMouseInBounds(MouseState ms, Rectangle rect)
        {
            return ms.X >= rect.X && ms.X <= rect.X + rect.Width &&
                   ms.Y >= rect.Y && ms.Y <= rect.Y + rect.Height;
        }

        public static void CheckButtonHover(MouseState ms, List<Button> bl)
        {
            foreach (Button b in bl)
            {
                /*
                if (ms.X >= b.XCoord && ms.X <= b.XCoord + b.Width &&
                    ms.Y >= b.YCoord && ms.Y <= b.YCoord + b.Height)
                {
                    b.Hover = true;
                }
                else
                {
                    b.Hover = false;
                }
                */
                b.Hover = ms.X >= b.XCoord && ms.X <= b.XCoord + b.Width &&
                          ms.Y >= b.YCoord && ms.Y <= b.YCoord + b.Height;
            }
        }

        public static Button CheckButtonClick(MouseState ms, List<Button> bl)
        {
            return bl.FirstOrDefault(b => ms.X >= b.XCoord && ms.X <= b.XCoord + b.Width 
            && ms.Y >= b.YCoord && ms.Y <= b.YCoord + b.Height);
        }
    }
}