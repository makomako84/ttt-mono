using Microsoft.Xna.Framework;

namespace TTT
{
    public class Configuration
    {
        public readonly float CellSize;
        public readonly Vector2 BoardLeftCornerPosition;

        public Configuration(
            float cellSize,
            Vector2 boardLeftCornerPosition)
        {
            CellSize = cellSize;
            BoardLeftCornerPosition = boardLeftCornerPosition;
        }
    }
}