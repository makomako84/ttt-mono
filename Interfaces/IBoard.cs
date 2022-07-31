using Microsoft.Xna.Framework;

namespace TTT
{
    public interface IBoard
    {
        /// <summary>
        /// Положение доски в пространстве
        /// (тема с окнами)
        /// </summary>
        Vector2 LeftCornerPosition { get; }

        /// <summary>
        /// Состояние клеток доски
        /// </summary>
        Cell[,] Cells { get; }

        /// <summary>
        /// Изменить состояние клетки в засимости
        /// от игрока player занявшего ее
        /// </summary>
        void ChangeCellState(int x, int y, Player player);
    }
}