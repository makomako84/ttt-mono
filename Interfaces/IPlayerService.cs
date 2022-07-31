using System.Collections.Generic;

namespace TTT
{
    public interface IPlayerService
    {
        Dictionary<int, Player> GetIdentities();
        void NextPlayerId();
        Player CurrentPlayer { get; }
    }
}