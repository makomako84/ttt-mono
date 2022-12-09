using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TTT
{
    public interface ILoadable
    {
        void Load(ContentManager content, SpriteBatch spriteBatch);
    }
}