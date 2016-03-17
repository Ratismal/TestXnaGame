using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;

namespace xTileGame1.Ref
{
    public static class RefNames
    {
        public static ContentManager content;
        public static class Maps
        {
            public static readonly string PREFIX = "Maps/";
            public static readonly string MAGE_CITY = PREFIX + "MageCity";
        }

        public static class TileSheets
        {
            public static readonly string PREFIX = "TileSheets/";
            public static readonly string MAGE_CITY = PREFIX + "mageCity";
        }

        public static class Sprites
        {
            public static readonly string PREFIX = "Sprites/";
            public static readonly string PLAYER = PREFIX + "player";
        }
    }
}
