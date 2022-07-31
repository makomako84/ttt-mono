namespace TTT
{
    public interface ITurnService
    {
        public bool GameFinished { get; }
        public int CurrentTurn { get; }
    }
}