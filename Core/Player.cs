using Microsoft.Xna.Framework.Graphics;

namespace TTT
{
    public class Player
    {
        public Player(int identifier)
        {
            Identifier = identifier;
        }

        /// <summary>
        /// Идентификатор игрока, допустим игрок 1, или игрок 2
        /// </summary>
        /// <value>1, 2, 3 ...</value>
        public int Identifier { get; set; }

        /// <summary>
        /// Графическое представление клетки игрока
        /// Если бы это было консольное приложение, то это был бы символ
        /// Приложение графическое, значит представлением является текстура
        /// </summary>
        /// <value></value>
        public Texture2D Sign { get; set; }

        public void MakeMove(Move move)
        {
            
        }
    }
}