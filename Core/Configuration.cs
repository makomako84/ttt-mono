using Microsoft.Xna.Framework;

namespace TTT
{
    public class Configuration : IConfiguration
    {
        private readonly float _cellSize;
        private readonly Vector2 _boardLeftCornerPosition;

        public float CellSize { get => _cellSize; }
        public Vector2 BoardLeftCornerPosition { get => _boardLeftCornerPosition; }

        public Configuration(
            float cellSize,
            Vector2 boardLeftCornerPosition)
        {
            _cellSize = cellSize;
            _boardLeftCornerPosition = boardLeftCornerPosition;
        }
    }
}