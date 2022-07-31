using Microsoft.Xna.Framework.Input;

namespace TTT
{
    public interface ISelector
    {
        int SelectionX { get; set; } 

        int SelectionY { get; set;}

        bool SelectionConfirmed { get; }

        void ResetConfirm();
    }
}