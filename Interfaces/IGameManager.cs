using System.Collections.Generic;

namespace TTT
{
    public interface IGameManager
    {
        Dictionary<int, Player> GetIdentities();
        void NextPlayerId();
        Player CurrentPlayer { get; }
    }
}