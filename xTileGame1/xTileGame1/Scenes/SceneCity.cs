using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TestGame.Characters;
using xTile;
using xTile.Dimensions;
using xTile.Display;
using TestGame.Maps;
using TestGame.Resources;
using Rectangle = xTile.Dimensions.Rectangle;

namespace TestGame.Scene
{
    internal class SceneCity : IScene
    {
        private readonly ContentManager Content;
        private readonly Game1 game;
        private readonly GraphicsDeviceManager graphics;
        private readonly GraphicsDevice graphicsDevice;
        private Map map;
        private IDisplayDevice mapDisplayDevice;

        private PlayerCharacter playerCharacter;
        private SpriteBatch spriteBatch;


        private Rectangle viewport;

        public SceneCity(GraphicsDeviceManager graphics, GraphicsDevice graphicsDevice, ContentManager content,
            Game1 game)
        {
            this.graphics = graphics;
            this.graphicsDevice = graphicsDevice;
            Content = content;
            this.game = game;
        }

        public void Initialize()
        {
            mapDisplayDevice = new XnaDisplayDevice(Content, graphicsDevice);

            viewport = new Rectangle(new Size(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight));
            game.IsMouseVisible = true;
        }

        public void LoadContent()
        {
            spriteBatch = new SpriteBatch(graphicsDevice);

            map = Resources.Resource.MapMageCity;
            map.LoadTileSheets(mapDisplayDevice);

            playerCharacter = Characters.Characters.playerCharacter;
            playerCharacter.SetPos(graphics.PreferredBackBufferWidth/2, graphics.PreferredBackBufferHeight/2);
        }

        public void UnloadContent()
        {
        }

        //private int speed = 10;


        public void Update(GameTime gameTime)
        {
            viewport = playerCharacter.Update(gameTime, map, viewport);
        }

        public void Draw(GameTime gameTime)
        {
            map.Draw(mapDisplayDevice, viewport);

            spriteBatch.Begin();
            playerCharacter.Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}