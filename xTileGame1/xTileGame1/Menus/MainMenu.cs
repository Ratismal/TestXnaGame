using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using xTile.Dimensions;
using xTileGame1.Buttons;
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

        public override void Initialize()
        {
            base.Initialize();
            //logoBanner = new Vector2(Game1.graphics.PreferredBackBufferWidth / 2 - 128, 32);
            LogoBanner = new Rectangle(Game1.Graphics.PreferredBackBufferWidth/2 - 128, 32, 256,
                128);

            ButtonLabel buttonOptions = new ButtonLabel(0, Game1.Graphics.PreferredBackBufferWidth / 2 - 136, 280, false,
                "Options");
            ButtonLabel buttonQuit = new ButtonLabel(1, Game1.Graphics.PreferredBackBufferWidth / 2 + 8, 280, false,
                "Quit");
            ButtonLabel buttonPlay = new ButtonLabel(2, Game1.Graphics.PreferredBackBufferWidth / 2 - 128, 200, true,
                "Play");
            ButtonList.Add(buttonOptions);
            ButtonList.Add(buttonQuit);
            ButtonList.Add(buttonPlay);
        }

        private bool _wasLogoBannerHover = false;

        public override void Update(GameTime gameTime)
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
            base.Update(gameTime);

        }

        public override void Draw(SpriteBatch b)
        {


            b.Draw(Resource.TextureMainMenuBackground, Vector2.Zero, Color.White);
            b.Draw(Resource.TextureLogoBanner, LogoBanner, Color.White);
            //button1.Draw(b);
            base.Draw(b);

        }

        public override void OnButtonClick(Button button, int mouseButton)
        {
            base.OnButtonClick(button, mouseButton);
            switch (button.Id)
            {
                case 0:
                    Console.Out.WriteLine("We would open the options menu now");
                    break;
                case 1:
                    Console.Out.WriteLine("Now we quit");
                    Game1.DoExit = true;
                    break;
                case 2:
                    Console.Out.WriteLine("Entering the actual game (or save load menu)");
                    Game1.SetGameMode(Game1.GameMode.MainGame);
                    break;
                default:
                    break;
            }
        }

    }
}
