using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TTT
{
    public class GameManager
    {
        public static Dictionary<int, Player> Identities = new Dictionary<int, Player>();



        public GameManager()
        {

        }



        public static void Setup()
        {
            Identities.Add(0, new Player(0, Art.E));
            Identities.Add(1, new Player(1, Art.X));
            Identities.Add(2, new Player(2, Art.O));
        }


    }
}