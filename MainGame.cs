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
        private List<ILoadable> _loadList = new List<ILoadable>();
        public Configuration _config;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private readonly IInputSet _inputSet;
        private readonly IInputHandle _inputHandler;

        public MainGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _config = new Configuration
            (
                cellSize: 100,
                boardLeftCornerPosition: new Vector2(100, 100)
            );
            
            var playerService = new PlayerService(this);
            var board =  new Board(this);
            var selector = new Selector(this);
            var turnService = new TurnService(this);

            var inputHandler = new InputHandler();
            _inputSet = inputHandler as IInputSet;
            
            Services.AddService<IConfiguration>(_config);
            Services.AddService<IPlayerService>(playerService);
            Services.AddService<IBoard>(board);
            Services.AddService<ISelector>(selector);
            Services.AddService<IInputHandle>(inputHandler);
            Services.AddService<ITurnService>(turnService);

            _inputHandler = Services.GetService<IInputHandle>();

            Components.Add(playerService);
            Components.Add(board);
            Components.Add(selector);
            Components.Add(turnService);
            
            _loadList.Add(board);
            _loadList.Add(playerService);
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
            _inputSet.SetKeyboardCurrentState(Keyboard.GetState());         
            base.Update(gameTime);
            _inputSet.UpdateKeyboardPreviousState();
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            base.Draw(gameTime);
        }
    }
}
