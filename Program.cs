using System;

namespace TTT
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new TTT())
                game.Run();
        }
    }
}
