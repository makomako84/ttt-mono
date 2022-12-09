namespace TTT
{
    public interface IInputHandle
    {
        bool UpKeyPressed { get; }
        bool DownKeyPressed { get; }
        bool LeftKeyPressed { get; }
        bool RightKeyPressed { get; }
        bool EnterKeyPressed { get; }
        bool NKeyPressed { get; }

    }
}