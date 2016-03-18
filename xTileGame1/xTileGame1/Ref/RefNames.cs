using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;

namespace TestGame.Ref
{
    public static class RefNames
    {
        public static ContentManager content;

        public static readonly string APP_DIRECTORY =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Game1.GameName);

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

        public static class Textures
        {
            public static readonly string PREFIX = "Textures/";
            public static readonly string LOGO_BANNER = PREFIX + "logoBanner";
            public static readonly string MAIN_MENU_BACKGROUND = PREFIX + "mainMenuBackground";
            public static readonly string MAIN_MENU_BUTTON = PREFIX + "mainMenuButton";
            public static readonly string MAIN_MENU_BUTTON_LONG = PREFIX + "mainMenuButtonLong";
        }

        public static class Fonts
        {
            public static readonly string PREFIX = "Fonts/";
            public static readonly string ARIAL = PREFIX + "arial";
        }
    }
}
