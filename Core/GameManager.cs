using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TTT
{
    public class GameManager : IGameManager
    {
        // di
        private readonly GameServiceContainer _services;

        private int _currentPlayerId;

        public Dictionary<int, Player> Identities = new Dictionary<int, Player>();

        public bool IsGameFinished { get; private set; }

        public Player CurrentPlayer
        {
            get => Identities[_currentPlayerId];
        }

        // interface methods
        public Dictionary<int, Player> GetIdentities()
        {
            return Identities;
        }


        public int CurrentPlayerId
        {
            get => _currentPlayerId;
            set
            {
                if(value > 0 && value < Identities.Count)
                {
                    _currentPlayerId = value;
                    OnPlayerIdChanged();
                }
            }
        }

        public void NextPlayerId()     
        {
            int next = _currentPlayerId + 1;
            if(next >= Identities.Count)
            {
                next = 1;
                CurrentPlayerId = next;
            }
            else
            {
                CurrentPlayerId++;
            }
        }


        public GameManager(GameServiceContainer services)
        {
            _services = services;
        }

        public void DI()
        {
            
        }

        public void Initialize()
        {
            // добавили игроков
            Identities.Add(0, new Player(0));
            Identities.Add(1, new Player(1));
            Identities.Add(2, new Player(2));          

            // установили указатель игрока на первого
            CurrentPlayerId = 1;  
        }   

        public void UpdateGameFinishState()
        {
            
        }


        private void OnPlayerIdChanged()
        {
            System.Diagnostics.Debug.WriteLine($"OnPlayerIdChanged > id: {_currentPlayerId}");
        }



        public void Load(ContentManager content)
        {           
            Identities[0].Sign = content.Load<Texture2D>("e");
            Identities[1].Sign = content.Load<Texture2D>("x");
            Identities[2].Sign = content.Load<Texture2D>("o");
        }


    }
}