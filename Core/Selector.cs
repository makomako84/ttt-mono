using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TTT
{
    public class Selector : IDrawable, IGameComponent, ILoadable, ISelector, IUpdateable
    {
        // *** dependencies ***
        private MainGame _game;
        private IConfiguration _conf;
        private IInputHandle _inputHandle;
        private IBoard _board;
        private ITurnService _turnService;
        private SpriteBatch _batch;

        // *** data ***
        private int _selectionX;
        private int _selectionY;
        private bool _selectionConfirmed;
        private Texture2D _texture;

        /// <summary>
        /// Положение селектора в пространстве
        /// </summary>
        public Vector2 _position;

        /// <summary>
        /// Обновлять координаты и положение селектора, когда производится единичное нажатие
        /// </summary>
        private void UpdateSelection()
        {
            if(_turnService.GameFinished) return;

            if(_inputHandle.LeftKeyPressed)
            {
                SelectionX--;
            }
            else if(_inputHandle.RightKeyPressed)
            {
                SelectionX++;
            }
            else if(_inputHandle.UpKeyPressed)
            {
                SelectionY--;
            }
            else if(_inputHandle.DownKeyPressed)
            {
                SelectionY++;
            }
            else if(_inputHandle.EnterKeyPressed)
            {
                if(_board.CanChangeState(SelectionX, SelectionY))
                {
                    _selectionConfirmed = true;
                    System.Diagnostics.Debug.WriteLine("Выбор подтвержден");
                }
                    
            }
        }

        /// <summary>
        /// Обновлять положение селектора в пространстве, когда
        /// изменяются координаты селектора на доске
        /// </summary>
        private void OnSelectionChanged()
        {
            _position = new Vector2(
                _board.LeftCornerPosition.X + SelectionX * _conf.CellSize,
                _board.LeftCornerPosition.Y + SelectionY * _conf.CellSize
            );
        }

#region ISelector
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

        public bool SelectionConfirmed => _selectionConfirmed;
        public void ResetConfirm()
            => _selectionConfirmed = false;


#endregion

#region .ctor
        public Selector(Game game)
        {
            _game = game as MainGame;
        }
#endregion

#region IGameComponent
        public void Initialize()
        {
            _conf = _game.Services.GetService<IConfiguration>();
            _board = _game.Services.GetService<IBoard>();
            _inputHandle = _game.Services.GetService<IInputHandle>();
            _turnService = _game.Services.GetService<ITurnService>();

            _selectionX = 0;
            _selectionY = 0;
            _position = _conf.BoardLeftCornerPosition;
        }
#endregion

#region ILoadable
        public void Load(ContentManager content, SpriteBatch spriteBatch)
        {
            this._batch = spriteBatch;
            _texture = content.Load<Texture2D>("select");
        }
#endregion

#region IDrawable
        public event EventHandler<EventArgs> DrawOrderChanged;
        public event EventHandler<EventArgs> VisibleChanged;
        public int DrawOrder => 10;

        public bool Visible => true;
        public void Draw(GameTime gameTime)
        {
            _batch.Begin();
            _batch.Draw(_texture, _position, Color.White);
            _batch.End();
        }
#endregion

#region IUpdateable
        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;
        public bool Enabled => true;

        public int UpdateOrder => 0;

        public void Update(GameTime gameTime)
        {
            UpdateSelection();
        }
        #endregion

    }

}