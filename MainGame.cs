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
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        
        private KeyboardState oldState;

        public MainGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            gameManager = new GameManager();
            board =  new Board(gameManager);
            selector = new Selector();

            // Set Empty field to zero identifier
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            
            gameManager.Load(Content);
            board.Initialize();
            selector.Load(Content);
            
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            KeyboardState newState = Keyboard.GetState();
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
