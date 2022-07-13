using Microsoft.Xna.Framework.Graphics;

namespace TTT.Core
{
    public class PlayerIdentifier
    {
        public PlayerIdentifier(int identifier, Texture2D sign)
        {
            Identifier = identifier;
            Sign = sign;
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
    }
}