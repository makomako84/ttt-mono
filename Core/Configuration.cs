using Microsoft.Xna.Framework;

namespace TTT
{
    public class Configuration : IConfiguration
    {
        // *** data ***
        private readonly float _cellSize;
        private readonly Vector2 _boardLeftCornerPosition;

#region .ctor
        public Configuration(
            float cellSize,
            Vector2 boardLeftCornerPosition)
        {
            _cellSize = cellSize;
            _boardLeftCornerPosition = boardLeftCornerPosition;
        }
#endregion

#region IConfiguration
        public float CellSize { get => _cellSize; }
        public Vector2 BoardLeftCornerPosition { get => _boardLeftCornerPosition; }
#endregion
    }
}