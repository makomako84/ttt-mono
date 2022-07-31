using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TTT
{
    public class PlayerService : IPlayerService, IGameComponent, ILoadable
    {
        // *** dependencies ***
        private Game _game;

        // *** data ***
        private int _currentPlayerId;
        private Dictionary<int, Player> _identities = new Dictionary<int, Player>();
        private bool _lastPlayer;

        private int CurrentPlayerId
        {
            get => _currentPlayerId;
            set
            {
                if(value > 0 && value < _identities.Count)
                {
                    _currentPlayerId = value;
                    System.Diagnostics.Debug.WriteLine($"OnPlayerIdChanged > id: {_currentPlayerId}");
                }
            }
        }

#region IPlayerService
        public Player CurrentPlayer
        {
            get => _identities[_currentPlayerId];
        }

        public bool LastPlayer => _lastPlayer;

        public void NextPlayer()     
        {
            _lastPlayer = false;
            int next = _currentPlayerId + 1;
            if(next >= _identities.Count)
            {
                _lastPlayer = true;
                next = 1;
                CurrentPlayerId = next;
            }
            else
            {
                CurrentPlayerId++;
            }
        }

        public Player GetPlayer(int index)
        {
            return _identities[index];
        }
#endregion

#region .ctor
        public PlayerService(Game game)
        {
            _game = game as MainGame;
        }
#endregion

#region IGameComponent
        public void Initialize()
        {
            // добавили игроков
            _identities.Add(0, new Player(0));
            _identities.Add(1, new Player(1));
            _identities.Add(2, new Player(2));          

            // установили указатель игрока на первого
            CurrentPlayerId = 1;  
        }   
#endregion

#region ILoadable
        public void Load(ContentManager content, SpriteBatch spriteBatch)
        {
            _identities[0].Sign = content.Load<Texture2D>("e");
            _identities[1].Sign = content.Load<Texture2D>("x");
            _identities[2].Sign = content.Load<Texture2D>("o");
        }
        #endregion

    }
}