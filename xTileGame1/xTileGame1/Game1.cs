using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using xTileGame1.Maps;
using xTileGame1.Menus;
using xTileGame1.Ref;
using xTileGame1.Scene;

namespace xTileGame1
{
    /// <summary>
    ///     This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        public enum GameMode
        {
            MainMenu,
            LoadSave,
            MainGame
        }

        public static GraphicsDeviceManager Graphics;

        private static GameMode _gameMode = GameMode.MainMenu;

        private MainMenu _mainMenu;

        private SceneCity _scene;


        private SpriteBatch _spriteBatch;

        public Game1()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        public static GameMode GetGameMode()
        {
            return _gameMode;
        }

        public static void SetGameMode(GameMode mode)
        {
            _gameMode = mode;
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
            GraphicsDevice.SamplerStates[0] = SamplerState.PointClamp;
            RefNames.content = Content;
            InitMaps.init();
            Characters.Characters.init();
            _scene = new SceneCity(Graphics, GraphicsDevice, Content, this);
            _scene.Initialize();
            _mainMenu = new MainMenu();
            _mainMenu.Initialize();
            Resources.Resources.init();

            base.Initialize();
        }

        /// <summary>
        ///     LoadContent will be called once per game and is the place to load
        ///     all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _scene.LoadContent();
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        ///     UnloadContent will be called once per game and is the place to unload
        ///     all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            _scene.UnloadContent();
        }


        /// <summary>
        ///     Allows the game to run logic such as updating the world,
        ///     checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            switch (_gameMode)
            {
                case GameMode.MainMenu:
                    _mainMenu.Update(gameTime);
                    break;
                case GameMode.LoadSave:
                    break;
                case GameMode.MainGame:
                    _scene.Update(gameTime);
                    break;
                default:
                    _mainMenu.Update(gameTime);
                    break;
            }
            // TODO: Add your update logic here


            base.Update(gameTime);
        }

        /// <summary>
        ///     This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            switch (_gameMode)
            {
                case GameMode.MainMenu:
                    _mainMenu.Draw(_spriteBatch);
                    break;
                case GameMode.LoadSave:
                    break;
                case GameMode.MainGame:
                    _scene.Draw(gameTime);
                    break;
            }

            base.Draw(gameTime);
        }
    }
}