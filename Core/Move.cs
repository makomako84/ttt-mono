namespace TTT
{
    /// <summary>
    /// Состояние хода, которое Player передает системе
    /// </summary>
    public class Move
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Player Player { get; set;}
    }
}