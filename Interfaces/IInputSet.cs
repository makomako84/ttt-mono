using Microsoft.Xna.Framework.Input;

namespace TTT
{
    /// <summary>
    /// Интерфейс для разграничения получения и установки инпута
    /// </summary>
    public interface IInputSet
    {
        void UpdateKeyboardPreviousState();
        void SetKeyboardCurrentState(KeyboardState currentState);
    }
}