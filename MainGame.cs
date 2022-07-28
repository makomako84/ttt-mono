using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
namespace TTT
{
    /// <summary>
    /// Tic-tac-toe
    /// </summary>
    public class MainGame : Microsoft.Xna.Framework.Game
    {
        public GameManager gameManager;
        public Board _board;
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
            gameManager = new GameManager(Services);
            _board =  new Board(this);
            selector = new Selector(Services);

            

            Services.AddService<IConfiguration>(config);
            Services.AddService<IGameManager>(gameManager);
            Services.AddService<IBoard>(_board);

            Components.Add(_board);

            gameManager.DI();
            selector.Di();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            
            gameManager.Initialize();
            //(Services.GetService<IBoard>() as IGameComponent).Initialize();
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

            // simulate NextPlayer logic
            if(oldState.IsKeyUp(Keys.N) && newState.IsKeyDown(Keys.N))
            {
                gameManager.NextPlayerId();                
            }

            // simulate applymove
            // if(oldState.IsKeyUp(Keys.Enter) && newState.IsKeyDown(Keys.Enter))
            // {
            //     board.ApplyMove(selector.SelectionX, selector.SelectionY, gameManager.CurrentPlayer);
            // }
            

            selector.Update(newState, oldState);

            oldState = newState;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            //(Services.GetService<IBoard>() as IDrawable).Draw()
            _board.Draw(_spriteBatch);            
            selector.Draw(_spriteBatch);

            base.Draw(gameTime);
        }
    }
}
