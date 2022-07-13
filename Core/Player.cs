using Microsoft.Xna.Framework.Graphics;

namespace TTT
{
    public class Player
    {
        public Player(int id, Texture2D sign)
        {
            PlayerIdentifier = new PlayerIdentifier(id, sign);
        }

        public PlayerIdentifier PlayerIdentifier { set; get; }
        public void MakeMove(Move move)
        {
            
        }
    }
}