using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TTT
{
    public class Board : IGameComponent, IBoard, IDrawable, ILoadable
    {
        private Game game;
        private IGameManager _gameManager;
        private IConfiguration _config;
        private SpriteBatch _spriteBatch;


        private Cell[,] _cells;

        public Cell[,] Cells { get => _cells; }


        
        public Vector2 LeftCornerPosition { get => _leftCornerPosition; }

        public int DrawOrder => 0;

        public bool Visible => true;

        private Vector2 _leftCornerPosition;

        public event EventHandler<EventArgs> DrawOrderChanged;
        public event EventHandler<EventArgs> VisibleChanged;

        public Board(Game game)
        {
            this.game = game;
            
        }

        public void Initialize()
        {
            _gameManager = (IGameManager)game.Services.GetService(typeof(IGameManager)); 
            _config = (IConfiguration)game.Services.GetService(typeof(IConfiguration));

            _leftCornerPosition = _config.BoardLeftCornerPosition;

            _cells = new Cell[3,3];
            for(int i=0; i < _cells.GetLength(0); i++)
            {
                for(int j = 0; j < _cells.GetLength(1); j++)
                {
                    _cells[i,j] = new Cell();
                    _cells[i,j].CapturedBy = _gameManager.GetIdentities()[0];
                    _cells[i,j].Position = new Vector2(
                        _leftCornerPosition.X + _config.CellSize * i, 
                        _leftCornerPosition.Y + _config.CellSize * j);
                }
            }
        }

        public void ApplyMove(int x, int y, Player player)
        {
            _cells[x, y].CapturedBy = player;
        }

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

        public void Load(ContentManager content, SpriteBatch spriteBatch)
        {
            _spriteBatch = spriteBatch;
        }
    }
}