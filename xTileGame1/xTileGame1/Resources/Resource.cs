using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using TestGame.Ref;
using xTile;
using TestGame.Menus;

namespace TestGame.Resources
{
    class Resource
    {
        // Maps
        public static Map MapMageCity;

        // Sprites
        public static Texture2D SpritePlayerCharacter;

        // Textures
        public static Texture2D TextureMainMenuBackground;
        public static Texture2D TextureLogoBanner;
        public static Texture2D TextureMainMenuButton;
        public static Texture2D TextureMainMenuButtonLong;

        // Fonts
        public static SpriteFont FontArial;


        public static void Init(ContentManager content)
        {
            // Maps
            MapMageCity = content.Load<Map>(RefNames.Maps.MAGE_CITY);

            // Sprites
            SpritePlayerCharacter = content.Load<Texture2D>(RefNames.Sprites.PLAYER);

            // Textures
            TextureMainMenuBackground = content.Load<Texture2D>(RefNames.Textures.MAIN_MENU_BACKGROUND);
            TextureLogoBanner = content.Load<Texture2D>(RefNames.Textures.LOGO_BANNER);
            TextureMainMenuButton = content.Load<Texture2D>(RefNames.Textures.MAIN_MENU_BUTTON);
            TextureMainMenuButtonLong = content.Load<Texture2D>(RefNames.Textures.MAIN_MENU_BUTTON_LONG);

            // Fonts
            FontArial = content.Load<SpriteFont>(RefNames.Fonts.ARIAL);

        }
    }
}
