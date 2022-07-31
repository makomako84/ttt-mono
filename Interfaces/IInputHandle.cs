namespace TTT
{
    public interface IInputHandle
    {
        bool IsUpKeyPresed();
        bool IsDownKeyPressed();
        bool IsLeftKeyPressed();
        bool IsRightKeyPressed();
        bool IsEnterKeyPressed();
        bool IsNKeyPressed();

    }
}