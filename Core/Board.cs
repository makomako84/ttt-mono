using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TTT
{
    public class Board
    {
        public Cell[,] Cells;

        private GameManager _gameManager;
        private Configuration _config;
        
        public Vector2 leftCornerPosition;

        public Board(
            GameManager gameManager,
            Configuration config)
        {
            _gameManager = gameManager;
            _config = config;
        }

        public void Initialize()
        {
            leftCornerPosition = _config.BoardLeftCornerPosition;

            Cells = new Cell[3,3];
            for(int i=0; i < Cells.GetLength(0); i++)
            {
                for(int j = 0; j < Cells.GetLength(1); j++)
                {
                    Cells[i,j] = new Cell();
                    Cells[i,j].CapturedBy = _gameManager.Identities[0];
                    Cells[i,j].Position = new Vector2(
                        leftCornerPosition.X + _config.CellSize * i, 
                        leftCornerPosition.Y + _config.CellSize * j);
                }
            }
        }

        public void ApplyMove(int x, int y, Player player)
        {
            Cells[x, y].CapturedBy = player;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            for(int i=0; i < Cells.GetLength(0); i++)
            {
                for(int j=0; j < Cells.GetLength(1); j++)
                {
                    Cells[i, j].Draw(spriteBatch);
                }
            }
            spriteBatch.End();
        }
    }
}