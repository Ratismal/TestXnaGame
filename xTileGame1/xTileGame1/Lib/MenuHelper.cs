using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace xTileGame1.Lib
{
    class MenuHelper
    {



        public static bool CheckMouseInBounds(MouseState ms, Rectangle rect)
        {
            return ms.X >= rect.X && ms.X <= rect.X + rect.Width &&
                   ms.Y >= rect.Y && ms.Y <= rect.Y + rect.Height;
        }

    }
}
