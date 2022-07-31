using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TTT
{
    public class Board : IGameComponent, IBoard, IDrawable, ILoadable
    {
        // *** dependencies ***
        private MainGame _game;
        private IPlayerService _playerService;
        private IConfiguration _config;
        private SpriteBatch _spriteBatch;

        // *** data ***
        private int _fieldSize = 3;
        private Cell[,] _cells;
        private Vector2 _leftCornerPosition;
        private bool _isFinishState;

 

#region .ctor
        public Board(Game game)
        {
            _game = game as MainGame;
        }
#endregion

#region IGameComponent
        public void Initialize()
        {
            _playerService = (IPlayerService)_game.Services.GetService(typeof(IPlayerService)); 
            _config = (IConfiguration)_game.Services.GetService(typeof(IConfiguration));

            _leftCornerPosition = _config.BoardLeftCornerPosition;

            _cells = new Cell[_fieldSize, _fieldSize];
            for(int x = 0; x < _cells.GetLength(0); x++)
            {
                for(int y = 0; y < _cells.GetLength(1); y++)
                {
                    _cells[x,y] = new Cell();
                    _cells[x,y].CapturedBy = _playerService.GetPlayer(0);
                    _cells[x,y].Position = new Vector2(
                        _leftCornerPosition.X + _config.CellSize * x, 
                        _leftCornerPosition.Y + _config.CellSize * y);
                }
            }
        }
#endregion

#region IBoard
        public Cell[,] Cells => _cells;
        public Vector2 LeftCornerPosition { get => _leftCornerPosition; }
        public void ChangeCellState(int x, int y, Player player)
        {
            _cells[x, y].CapturedBy = player;
            DebugBoardState();
            _isFinishState = CheckWinningState(x, y, player.Identifier);
            System.Diagnostics.Debug.WriteLine($"Player {player.Identifier}, wins? : {_isFinishState}");
        }

        public bool CanChangeState(int x, int y)
            => _cells[x, y].CapturedBy.Identifier == 0;

        public bool IsFinishState()
            => _isFinishState;

        /// <summary>
        /// https://stackoverflow.com/questions/1056316/algorithm-for-determining-tic-tac-toe-game-over
        /// </summary>
        /// <returns></returns>
        private bool CheckWinningState(int x, int y, int cellState)
        {   
            
            bool product = true;
            for(int iy = 0; iy < _fieldSize; iy++)
            {
                product &= _cells[x, iy].CapturedBy.Identifier == cellState;
            }
#if DEBUG
            System.Diagnostics.Debug.WriteLine($"Vertical check: {product}, column: {x}");
#endif
            if(product) return true;
            
            product = true;
            for(int ix = 0; ix < _fieldSize; ix++)
            {
                product &= _cells[ix, y].CapturedBy.Identifier == cellState;
            }
#if DEBUG
            System.Diagnostics.Debug.WriteLine($"Horizontal check: {product}, row: {y}");
#endif
            if(product) return true;

            
            if(x == y)
            {
                product = true;
                for(int i = 0; i < _fieldSize; i++)
                {
                    product &= _cells[i,i].CapturedBy.Identifier == cellState;
                }
#if DEBUG
                System.Diagnostics.Debug.WriteLine($"Diagonal left to right check: {product}");
#endif
                if(product) return true;
            }
            if(x + y == _fieldSize - 1)
            {
                product = true;
                for(int i = 0; i < _fieldSize; i++)
                {
                    product &= _cells[i, (_fieldSize - 1) - i].CapturedBy.Identifier == cellState;
                }
#if DEBUG
                System.Diagnostics.Debug.WriteLine($"Diagonal right to left check: {product}");
#endif
                if(product) return true;
            }
            return false;
        }

        [System.Diagnostics.Conditional("DEBUG")]
        private void DebugBoardState()
        {
            for(int col = 0; col < _fieldSize; col++)
            {
                for(int row = 0; row < _fieldSize; row++)
                {
                    System.Diagnostics.Debug.Write(_cells[row, col].CapturedBy.Identifier);
                }
                System.Diagnostics.Debug.WriteLine("");
            }
        }
#endregion

#region IDrawable
        public int DrawOrder => 0;

        public bool Visible => true;
        public event EventHandler<EventArgs> DrawOrderChanged;
        public event EventHandler<EventArgs> VisibleChanged;
        public void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();
            for(int i=0; i < _cells.GetLength(0); i++)
            {
                for(int j=0; j < _cells.GetLength(1); j++)
                {
                    _cells[i, j].Draw(_spriteBatch);
                }
            }
            _spriteBatch.End();
        }
#endregion

#region ILoadable
        public void Load(ContentManager content, SpriteBatch spriteBatch)
        {
            _spriteBatch = spriteBatch;
        }
        #endregion
    }
}