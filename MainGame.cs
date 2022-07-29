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
        private List<ILoadable> _loadList = new List<ILoadable>();
        
        public Configuration config;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private KeyboardState _oldState;
        private KeyboardState _newState;

        public KeyboardState OldState => _oldState;
        public KeyboardState NewState => _newState;

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
            
            var gameManager = new GameManager(this);
            var board =  new Board(this);
            var selector = new Selector(this);
            
            Services.AddService<IConfiguration>(config);
            Services.AddService<IGameManager>(gameManager);
            Services.AddService<IBoard>(board);
            Services.AddService<ISelector>(selector);

            Components.Add(gameManager);
            Components.Add(board);
            Components.Add(selector);

            _loadList.Add(board);
            _loadList.Add(gameManager);
            _loadList.Add(selector);
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            // Set Empty field to zero identifier
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            
            // TODO: use this.Content to load your game content here
            foreach(var item in _loadList)
            {
                item.Load(Content, _spriteBatch);
            }
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            _newState = Keyboard.GetState();

            // simulate NextPlayer logic
            if(_oldState.IsKeyUp(Keys.N) && _newState.IsKeyDown(Keys.N))
            {
                Services.GetService<IGameManager>().NextPlayerId();                
            }

            var selector = Services.GetService<ISelector>();
            //simulate applymove
            if(_oldState.IsKeyUp(Keys.Enter) && _newState.IsKeyDown(Keys.Enter))
            {
                var gameManager = Services.GetService<IGameManager>();
                
                Services.GetService<IBoard>().ApplyMove(selector.SelectionX, selector.SelectionY, gameManager.CurrentPlayer);
            }
            

            selector.Update(_newState, _oldState);

            // TASK: разобраться с инпутами (command pattern или InputHandler)

            _oldState = _newState;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            base.Draw(gameTime);
        }
    }
}
