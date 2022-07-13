using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TTT
{
    public class GameManager
    {
        public Dictionary<int, Player> Identities = new Dictionary<int, Player>();



        public GameManager()
        {
            Identities.Add(0, new Player(0));
            Identities.Add(1, new Player(1));
            Identities.Add(2, new Player(2));
        }



        public void Load(ContentManager content)
        {           
            Identities[0].Sign = content.Load<Texture2D>("e");
            Identities[1].Sign = content.Load<Texture2D>("x");
            Identities[2].Sign = content.Load<Texture2D>("o");
        }


    }
}