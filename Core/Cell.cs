using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TTT
{
    public class Cell
    {
        /// <summary>
        /// Состояние клетки.
        /// Идентификатор игрока занявшего клетку и представление
        /// </summary>
        public Player CapturedBy { get; set; }

        public Vector2 Position { get; set; }

        public void Draw(SpriteBatch spriteBatch)
        {
            var texture = CapturedBy.Sign;
            spriteBatch.Draw(texture, Position, Color.White);
        }
    }
}