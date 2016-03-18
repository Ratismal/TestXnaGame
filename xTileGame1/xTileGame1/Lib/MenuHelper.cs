using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using TestGame.Buttons;

namespace TestGame.Lib
{
    class MenuHelper
    {
        /// <summary>
        /// Check if the mouse is within a rectangle range
        /// </summary>
        /// <param name="ms">The MouseState</param>
        /// <param name="rect">The Rectangle range</param>
        /// <returns></returns>
        public static bool CheckMouseInBounds(MouseState ms, Rectangle rect)
        {
            return ms.X >= rect.X && ms.X <= rect.X + rect.Width &&
                   ms.Y >= rect.Y && ms.Y <= rect.Y + rect.Height;
        }

        /// <summary>
        /// Checks if the mouse is hovering over a button
        /// </summary>
        /// <param name="ms">The MouseState</param>
        /// <param name="bl">The list of buttons</param>
        public static void CheckButtonHover(MouseState ms, List<Button> bl)
        {
            foreach (Button b in bl)
            {
                b.Hover = ms.X >= b.XCoord && ms.X <= b.XCoord + b.Width &&
                          ms.Y >= b.YCoord && ms.Y <= b.YCoord + b.Height;
            }
        }

        /// <summary>
        /// Check if the mouse is in the range of a button
        /// </summary>
        /// <param name="ms">The MouseState</param>
        /// <param name="bl">The list of button</param>
        /// <returns>The first button the mouse has clicked</returns>
        public static Button CheckButtonClick(MouseState ms, List<Button> bl)
        {
            return bl.FirstOrDefault(b => ms.X >= b.XCoord && ms.X <= b.XCoord + b.Width 
            && ms.Y >= b.YCoord && ms.Y <= b.YCoord + b.Height);
        }
    }
}