using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using xTile;
using xTile.Dimensions;
using xTile.Display;
using xTileGame1.Maps;
using xTileGame1.Ref;
using xTileGame1.Scene;
using Rectangle = xTile.Dimensions.Rectangle;

namespace xTileGame1
{
    /// <summary>
    ///     This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        public static GraphicsDeviceManager graphics;


        private SpriteBatch spriteBatch;
        public Movement verticalMovement;
        public Movement horizontalMovement;
        private KeyboardState oldState;

        private SceneCity scene;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        ///     Allows the game to perform any initialization it needs to before starting to run.
        ///     This is where it can query for any required services and load any non-graphic
        ///     related content.  Calling base.Initialize will enumerate through any components
        ///     and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            RefNames.content = Content;
            InitMaps.init();
            Characters.Characters.init();
            scene = new SceneCity(graphics, GraphicsDevice, Content, this);
            scene.Initialize();

            base.Initialize();

            
        }

        /// <summary>
        ///     LoadContent will be called once per game and is the place to load
        ///     all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            scene.LoadContent();
            // TODO: use this.Content to load your game content here

        }

        /// <summary>
        ///     UnloadContent will be called once per game and is the place to unload
        ///     all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            scene.UnloadContent();
        }


        /// <summary>
        ///     Allows the game to run logic such as updating the world,
        ///     checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                Exit();

            GetInput();
            //System.Console.WriteLine(verticalMovement + " " + horizontalMovement);
            // TODO: Add your update logic here
            scene.Update(gameTime);

           // map.GetLayer.

            base.Update(gameTime);
        }

        public void GetInput()
        {
            KeyboardState newState = Keyboard.GetState();

            //Vertical Movement
            if (newState.IsKeyDown(Keys.W) && newState.IsKeyDown(Keys.S))
                verticalMovement = Movement.NEUTRAL;
            else if (newState.IsKeyDown(Keys.W))
                verticalMovement = Movement.POSITIVE;
            else if (newState.IsKeyDown(Keys.S))
                verticalMovement = Movement.NEGATIVE;
            else
                verticalMovement = Movement.NEUTRAL;

            if (newState.IsKeyDown(Keys.A) && newState.IsKeyDown(Keys.D))
                horizontalMovement = Movement.NEUTRAL;
            else if (newState.IsKeyDown(Keys.A))
                horizontalMovement = Movement.NEGATIVE;
            else if (newState.IsKeyDown(Keys.D))
                horizontalMovement = Movement.POSITIVE;
            else
                horizontalMovement = Movement.NEUTRAL;


            oldState = newState;


        }


        public enum Movement
        {
            POSITIVE,
            NEGATIVE,
            NEUTRAL
        }

        /// <summary>
        ///     This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            scene.Draw(gameTime);

            base.Draw(gameTime);
        }
    }
}