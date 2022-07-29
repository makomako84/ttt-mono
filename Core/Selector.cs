using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TTT
{
    public class Selector : IDrawable, IGameComponent, ILoadable
    {
        // dependencies
        private Game _game;
        private IConfiguration _conf;
        private IBoard _board;

        private SpriteBatch _batch;

        public int _selectionX;
        public int _selectionY;
        public Texture2D _texture;
        public Vector2 _position;

        public event EventHandler<EventArgs> DrawOrderChanged;
        public event EventHandler<EventArgs> VisibleChanged;

        public Cell Selection { get; private set; }

        public Selector(Game game)
        {
            _game = game;
        }

        public void Initialize()
        {
            _conf = _game.Services.GetService<IConfiguration>();
            _board = _game.Services.GetService<IBoard>();

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
            if(oldState.IsKeyUp(Keys.Left) && newState.IsKeyDown(Keys.Left))
            {
                SelectionX--;
            }
            else if(oldState.IsKeyUp(Keys.Right) && newState.IsKeyDown(Keys.Right))
            {
                SelectionX++;
            }
            else if(oldState.IsKeyUp(Keys.Up) && newState.IsKeyDown(Keys.Up))
            {
                SelectionY--;
            }
            else if(oldState.IsKeyUp(Keys.Down) && newState.IsKeyDown(Keys.Down))
            {
                SelectionY++;
            }
        }

        public void Draw(GameTime gameTime)
        {
            _batch.Begin();
            _batch.Draw(_texture, _position, Color.White);
            _batch.End();
        }
    }
}