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

        public Player CurrentPlayer
        {
            get => _identities[_currentPlayerId];
        }

        // interface methods
        public Dictionary<int, Player> GetIdentities()
        {
            return _identities;
        }


        public int CurrentPlayerId
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

        public void NextPlayerId()     
        {
            int next = _currentPlayerId + 1;
            if(next >= _identities.Count)
            {
                next = 1;
                CurrentPlayerId = next;
            }
            else
            {
                CurrentPlayerId++;
            }
        }

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