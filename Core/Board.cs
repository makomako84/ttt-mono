using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TTT
{
    public class Board
    {
        public Cell[,] Cells;

        public GameManager gameManager;

        public Board(GameManager gameManager)
        {
            this.gameManager = gameManager;
        }

        public void Initialize()
        {
            Cells = new Cell[3,3];
            for(int i=0; i < Cells.GetLength(0); i++)
            {
                for(int j = 0; j < Cells.GetLength(1); j++)
                {
                    Cells[i,j] = new Cell();
                    Cells[i,j].CapturedBy = this.gameManager.Identities[0];
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
                    float cellSize = Configuration.CellSize;

                    Vector2 cellPosition = new Vector2(cellSize * i, cellSize * j);
                    Cells[i, j].Draw(spriteBatch, cellPosition);
                }
            }
            spriteBatch.End();
        }
    }
}