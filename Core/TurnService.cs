using System;
using Microsoft.Xna.Framework;

namespace TTT
{
    public class TurnService : ITurnService, IGameComponent, IUpdateable
    {
        // *** dependencies ***
        private MainGame _game;
        private IBoard _board;
        private ISelector _selector;
        private IInputHandle _inputHandle;
        private IPlayerService _playerService;

        // *** data ***
        private int _currentTurnIndex;
        private bool _gameFinished;

        public bool GameFinished 
        {
            get
            {
                return _gameFinished;
            }
        }

        public int CurrentTurn => _currentTurnIndex;



        #region .ctor
        public TurnService(
            Game game)
        {
            _game = game as MainGame;
        }
#endregion

#region IGameComponent
        public void Initialize()
        {
            _board = _game.Services.GetService<IBoard>();
            _inputHandle = _game.Services.GetService<IInputHandle>();
            _playerService = _game.Services.GetService<IPlayerService>();
            _selector = _game.Services.GetService<ISelector>();

            _currentTurnIndex = 1;
            _gameFinished = false;
            System.Diagnostics.Debug.WriteLine($"===Turn {_currentTurnIndex}===");
        }
        #endregion

#region IUpdateable
        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;
        public bool Enabled => true;

        public int UpdateOrder => 0;
        public void Update(GameTime gameTime)
        {
            if(GameFinished) return;

            if(_selector.SelectionConfirmed)
            {
                _board.ChangeCellState(
                    _selector.SelectionX, _selector.SelectionY, 
                    _playerService.CurrentPlayer);
                _gameFinished = _board.IsFinishState();

                if(_gameFinished)
                {
                    System.Diagnostics.Debug.WriteLine($"Game finished! Winner: {_playerService.CurrentPlayer.Identifier}");
                    return;
                }


                _selector.ResetConfirm();
                _playerService.NextPlayer();
                if(_playerService.LastPlayer)
                {
                    _currentTurnIndex++;
                     System.Diagnostics.Debug.WriteLine($"===Turn {_currentTurnIndex}===");
                }


            }
        }
#endregion
    }
}