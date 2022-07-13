using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace TTT
{
    /// <summary>
    /// Tic-tac-toe
    /// </summary>
    public class MainGame : Microsoft.Xna.Framework.Game
    {
        public GameManager gameManager;
        public Board board;
        public Selector selector;
        public Configuration config;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private KeyboardState oldState;

        public MainGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            config = new Configuration
            (
                cellSize: 100,
                boardLeftCornerPosition: new Vector2(100, 100)
            );

            gameManager = new GameManager();
            board =  new Board(gameManager, config);
            selector = new Selector(config, board);
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            
            gameManager.Initialize();
            board.Initialize();
            selector.Initialize();

            // Set Empty field to zero identifier
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            
            gameManager.Load(Content);
            selector.Load(Content);
            
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            KeyboardState newState = Keyboard.GetState();


            if(oldState.IsKeyUp(Keys.N) && newState.IsKeyDown(Keys.N))
            {
                gameManager.NextPlayerId();
                //board.ApplyMove(selector.SelectionX, selector.SelectionY, gameManager.Identities[1]);
            }

            if(oldState.IsKeyUp(Keys.Enter) && newState.IsKeyDown(Keys.Enter))
            {
                board.ApplyMove(selector.SelectionX, selector.SelectionY, gameManager.CurrentPlayer);
            }

            if(oldState.IsKeyUp(Keys.A) && newState.IsKeyDown(Keys.A))
            {
                board.ApplyMove(selector.SelectionX, selector.SelectionY, gameManager.Identities[1]);
            }
            else if(oldState.IsKeyUp(Keys.S) && newState.IsKeyDown(Keys.S))
            {
                board.ApplyMove(selector.SelectionX, selector.SelectionY, gameManager.Identities[2]);
            }

            selector.Update(newState, oldState);

            oldState = newState;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here


            board.Draw(_spriteBatch);            
            selector.Draw(_spriteBatch);

            base.Draw(gameTime);
        }
    }
}
