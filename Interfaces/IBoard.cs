using Microsoft.Xna.Framework;

namespace TTT
{
    public interface IBoard
    {
        Vector2 LeftCornerPosition { get; }
        Cell[,] Cells { get; }
    }
}