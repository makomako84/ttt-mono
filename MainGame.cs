﻿using System.Collections.Generic;
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
        
        public Configuration config;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private readonly IInputSet _inputSet;
        private readonly IInputHandle _inputHandler;

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

            var inputHandler = new InputHandler();
            _inputSet = inputHandler as IInputSet;
            
            Services.AddService<IConfiguration>(config);
            Services.AddService<IGameManager>(gameManager);
            Services.AddService<IBoard>(board);
            Services.AddService<ISelector>(selector);
            Services.AddService<IInputHandle>(inputHandler);

            _inputHandler = Services.GetService<IInputHandle>();

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
            _inputSet.SetKeyboardCurrentState(Keyboard.GetState());

            // simulate NextPlayer logic
            if(_inputHandler.IsNKeyPressed())
                Services.GetService<IGameManager>().NextPlayerId();                

            var selector = Services.GetService<ISelector>();
            //simulate applymove
            if(_inputHandler.IsEnterKeyPressed())
            {
                var gameManager = Services.GetService<IGameManager>();
                Services.GetService<IBoard>().ApplyMove(selector.SelectionX, selector.SelectionY, gameManager.CurrentPlayer);
            }
            // base update должен быть помещен перед обновлением oldState
            // видимо компоненты IUpdatable обновляются вместе с base.Update класса Game
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
