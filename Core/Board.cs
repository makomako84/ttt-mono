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
        private Cell[,] _cells;
        private Vector2 _leftCornerPosition;

        public bool CheckWinningState()
        {
            for(int i=0; i < _cells.GetLength(0); i++)
            {
                for(int j = 0; j < _cells.GetLength(1); j++)
                {
                    // Cells[i,j]
                    // TODO: algo here
                }
            }
            return true;
        }

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

            _cells = new Cell[3,3];
            for(int i=0; i < _cells.GetLength(0); i++)
            {
                for(int j = 0; j < _cells.GetLength(1); j++)
                {
                    _cells[i,j] = new Cell();
                    _cells[i,j].CapturedBy = _playerService.GetPlayer(0);
                    _cells[i,j].Position = new Vector2(
                        _leftCornerPosition.X + _config.CellSize * i, 
                        _leftCornerPosition.Y + _config.CellSize * j);
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