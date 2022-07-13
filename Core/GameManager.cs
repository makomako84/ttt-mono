using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TTT
{
    public class GameManager
    {
        private int _currentPlayerId;

        public Dictionary<int, Player> Identities = new Dictionary<int, Player>();

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

        public Player CurrentPlayer
        {
            get => Identities[_currentPlayerId];
        }


        public GameManager()
        {
            
        }

        public void Initialize()
        {
            Identities.Add(0, new Player(0));
            Identities.Add(1, new Player(1));
            Identities.Add(2, new Player(2));          

            CurrentPlayerId = 1;  
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