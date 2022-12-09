using Microsoft.Xna.Framework.Input;

namespace TTT
{
    public class InputHandler : IInputSet, IInputHandle
    {
        private KeyboardState _previousState;
        private KeyboardState _currentState;

        public KeyboardState PreviousState => _previousState;
        public KeyboardState CurrentState => _currentState;

        public bool DownKeyPressed
            => _previousState.IsKeyUp(Keys.Down) && _currentState.IsKeyDown(Keys.Down);

        public bool EnterKeyPressed
            => _previousState.IsKeyUp(Keys.Enter) && _currentState.IsKeyDown(Keys.Enter);

        public bool LeftKeyPressed
            => _previousState.IsKeyUp(Keys.Left) && _currentState.IsKeyDown(Keys.Left);

        public bool NKeyPressed
            => _previousState.IsKeyUp(Keys.N) && _currentState.IsKeyDown(Keys.N);

        public bool RightKeyPressed
            => _previousState.IsKeyUp(Keys.Right) && _currentState.IsKeyDown(Keys.Right);

        public bool UpKeyPressed
            => _previousState.IsKeyUp(Keys.Up) && _currentState.IsKeyDown(Keys.Up);

        public void SetKeyboardCurrentState(KeyboardState currentState)
        {
            _currentState = currentState;
        }

        public void UpdateKeyboardPreviousState()
        {
            _previousState = _currentState;
        }
    }
}