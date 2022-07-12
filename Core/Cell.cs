namespace TTT.Core
{
    public class Cell
    {
        /// <summary>
        /// Состояние клетки.
        /// Идентификатор игрока занявшего клетку и представление
        /// </summary>
        public Player CapturedBy { get; set; }
    }
}