using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using xTile.Dimensions;
using xTileGame1.Lib;
using xTileGame1.Resources;
using Rectangle = Microsoft.Xna.Framework.Rectangle;


namespace xTileGame1.Menus
{
    class MainMenu : Menu
    {
        private Rectangle LogoBanner;

        public MainMenu()
        {
            
        }

        public new void Initialize()
        {
            //logoBanner = new Vector2(Game1.graphics.PreferredBackBufferWidth / 2 - 128, 32);
            LogoBanner = new Rectangle(Game1.Graphics.PreferredBackBufferWidth/2 - 128, 32, 256,
                128);
        }

        private bool _wasLogoBannerHover = false;

        public new void Update(GameTime gameTime)
        {
            MouseState ms = Mouse.GetState();

            if (MenuHelper.CheckMouseInBounds(ms, LogoBanner))
            {
                _wasLogoBannerHover = true;
                LogoBanner.X = Game1.Graphics.PreferredBackBufferWidth/2 - 160;
                LogoBanner.Y = 16;
                LogoBanner.Width = 320;
                LogoBanner.Height = 160;
            } else if (_wasLogoBannerHover)
            {
                _wasLogoBannerHover = false;
                LogoBanner.X = Game1.Graphics.PreferredBackBufferWidth / 2 - 128;
                LogoBanner.Y = 32;
                LogoBanner.Width = 256;
                LogoBanner.Height = 128;
            }
        }

        public new void Draw(SpriteBatch b)
        {
            b.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);

            b.Draw(Resources.Resources.textureMainMenuBackground, Vector2.Zero, Color.White);
            b.Draw(Resources.Resources.textureLogoBanner, LogoBanner, Color.White);
            b.End();
        }

        

    }
}
