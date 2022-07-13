using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TTT
{
    public class Board
    {
        public Cell[,] Cells;

        private GameManager _gameManager;
        private Configuration _config;

        public Board(
            GameManager gameManager,
            Configuration config)
        {
            _gameManager = gameManager;
            _config = config;
        }

        public void Initialize()
        {
            Cells = new Cell[3,3];
            for(int i=0; i < Cells.GetLength(0); i++)
            {
                for(int j = 0; j < Cells.GetLength(1); j++)
                {
                    Cells[i,j] = new Cell();
                    Cells[i,j].CapturedBy = _gameManager.Identities[0];
                    Cells[i,j].Position = new Vector2(
                        _config.CellSize * i, 
                        _config.CellSize * j);
                }
            }
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