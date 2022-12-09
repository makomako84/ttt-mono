using Microsoft.Xna.Framework;

namespace TTT
{
    public interface IConfiguration
    {
        float CellSize { get;}
        Vector2 BoardLeftCornerPosition { get; }
    }
}