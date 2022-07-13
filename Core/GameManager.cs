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

        }



        public void Load(ContentManager content)
        {           
            Identities.Add(0, new Player(0, content.Load<Texture2D>("e")));
            Identities.Add(1, new Player(0, content.Load<Texture2D>("x")));
            Identities.Add(2, new Player(0, content.Load<Texture2D>("o")));
        }


    }
}