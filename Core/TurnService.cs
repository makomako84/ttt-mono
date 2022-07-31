using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TTT
{
    public class TurnService : ITurnService, IGameComponent
    {
        // *** dependencies ***
        private MainGame _game;
        private IBoard _board;

        // *** data ***
        private int _currentTurnIndex;

        public bool GameFinished 
        {
            get
            {
                return false;
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

            _currentTurnIndex = 1;
        }
#endregion
    }
}