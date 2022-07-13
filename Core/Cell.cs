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

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            var texture = CapturedBy.PlayerIdentifier.Sign;
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}