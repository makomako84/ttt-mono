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

        bool IsFinishState();

        /// <summary>
        /// Можно ли изменить состояние клетки
        /// (клетка не занята игроком (Identifier > 0))
        /// </summary>
        bool CanChangeState(int x, int y);
    }
}