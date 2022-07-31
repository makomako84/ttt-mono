using System.Collections.Generic;

namespace TTT
{
    public interface IPlayerService
    {
        /// <summary>
        /// Установить следующего игрока
        /// </summary>
        void NextPlayer();

        /// <summary>
        /// Получить текущего игрока
        /// </summary>
        Player CurrentPlayer { get; }

        /// <summary>
        /// Получить игрока по индексу
        /// </summary>
        Player GetPlayer(int index);

        bool LastPlayer { get; }
    }
}