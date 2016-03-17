using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using xTile;
using xTileGame1.Menus;
using xTileGame1.Ref;

namespace xTileGame1.Resources
{
    class Resources
    {
        // Maps
        public static Map mapMageCity;

        // Sprites
        public static Texture2D spritePlayerCharacter;

        // Textures
        public static Texture2D textureMainMenuBackground;
        public static Texture2D textureLogoBanner;
        public static Texture2D textureMainMenuButton;
        public static Texture2D textureMainMenuButtonLong;



        public static void init()
        {
            // Maps
            mapMageCity = RefNames.content.Load<Map>(RefNames.Maps.MAGE_CITY);

            // Sprites
            spritePlayerCharacter = RefNames.content.Load<Texture2D>(RefNames.Sprites.PLAYER);

            // Textures
            textureMainMenuBackground = RefNames.content.Load<Texture2D>(RefNames.Textures.MAIN_MENU_BACKGROUND);
            textureLogoBanner = RefNames.content.Load<Texture2D>(RefNames.Textures.LOGO_BANNER);
            textureMainMenuButton = RefNames.content.Load<Texture2D>(RefNames.Textures.MAIN_MENU_BUTTON);
            textureMainMenuButtonLong = RefNames.content.Load<Texture2D>(RefNames.Textures.MAIN_MENU_BUTTON_LONG);
            

        }
    }
}
