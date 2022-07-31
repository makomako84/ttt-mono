using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TTT
{
    public class Selector : IDrawable, IGameComponent, ILoadable, ISelector, IUpdateable
    {
        // dependencies
        private MainGame _game;
        private IConfiguration _conf;
        private IInputHandle _inputHandle;

        private IBoard _board;
        private SpriteBatch _batch;

        public int _selectionX;
        public int _selectionY;
        public Texture2D _texture;
        public Vector2 _position;

        public event EventHandler<EventArgs> DrawOrderChanged;
        public event EventHandler<EventArgs> VisibleChanged;
        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;

        public Cell Selection { get; private set; }

        public Selector(Game game)
        {
            _game = game as MainGame;
        }

        public void Initialize()
        {
            _conf = _game.Services.GetService<IConfiguration>();
            _board = _game.Services.GetService<IBoard>();
            _inputHandle = _game.Services.GetService<IInputHandle>();

            _selectionX = 0;
            _selectionY = 0;
            _position = _conf.BoardLeftCornerPosition;
        }

        public void Load(ContentManager content, SpriteBatch spriteBatch)
        {
            this._batch = spriteBatch;
            _texture = content.Load<Texture2D>("select");
        }

        public int SelectionX
        {
            get => _selectionX;
            set 
            {
                if(value >=0 && value < 3)
                {
                    _selectionX = value;
                    OnSelectionChanged();
                }
            }
        }

        public int SelectionY
        {
            get => _selectionY;
            set
            {
                if(value >= 0 && value <3)
                {
                    _selectionY = value;
                    OnSelectionChanged();
                }
            }
        }

        public int DrawOrder => 10;

        public bool Visible => true;

        public bool Enabled => true;

        public int UpdateOrder => 0;

        private void OnSelectionChanged()
        {
            Selection = _board.Cells[SelectionX, SelectionY];

            _position = new Vector2(
                _board.LeftCornerPosition.X + SelectionX * _conf.CellSize,
                _board.LeftCornerPosition.Y + SelectionY * _conf.CellSize
            );

            // System.Diagnostics.Debug.WriteLine($"OnSelectionChanged > Selection position: {Selection.Position}");
        }

        public void Update(KeyboardState newState, KeyboardState oldState)
        {

        }

        public void Draw(GameTime gameTime)
        {
            _batch.Begin();
            _batch.Draw(_texture, _position, Color.White);
            _batch.End();
        }

        public void Update(GameTime gameTime)
        {
            if(_inputHandle.IsLeftKeyPressed())
            {
                SelectionX--;
            }
            else if(_inputHandle.IsRightKeyPressed())
            {
                SelectionX++;
            }
            else if(_inputHandle.IsUpKeyPresed())
            {
                SelectionY--;
            }
            else if(_inputHandle.IsDownKeyPressed())
            {
                SelectionY++;
            }
        }
    }
}