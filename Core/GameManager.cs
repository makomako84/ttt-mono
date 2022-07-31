using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TTT
{
    public class GameManager : IGameManager
    {
        // *** dependencies ***
        private readonly Game _game;

        public bool IsGameFinished { get; private set; }

#region .ctor
        public GameManager(Game game)
        {
            _game = game;
        }
#endregion



        public void UpdateGameFinishState()
        {
            
        }
    }
}