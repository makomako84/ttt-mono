using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TTT
{
    public class GameManager
    {
        public static Dictionary<int, Player> Identities = new Dictionary<int, Player>();

        public int _selectionX;
        public int _selectionY;

        public int SelectionX
        {
            get => _selectionX;
            set 
            {
                if(value >=0 && value < 3)
                {
                    _selectionX = value;
                }
            }
        }

        public int SelectionY
        {
            get => _selectionY;
            set
            {
                if(value >= 0 && value <3)
                {
                    _selectionY = value;
                }
            }
        }

        public GameManager()
        {
            _selectionX = 0;
            _selectionY = 0;
        }

        public void UpdateSelection(KeyboardState newState, KeyboardState oldState)
        {
            if(oldState.IsKeyUp(Keys.Left) && newState.IsKeyDown(Keys.Left))
            {
                SelectionX--;
                System.Diagnostics.Debug.WriteLine($"Left!, x,y: ({SelectionX},{SelectionY})");
            }
            else if(oldState.IsKeyUp(Keys.Right) && newState.IsKeyDown(Keys.Right))
            {
                SelectionX++;
                System.Diagnostics.Debug.WriteLine($"Right!, x,y: ({SelectionX},{SelectionY})");
            }
            else if(oldState.IsKeyUp(Keys.Up) && newState.IsKeyDown(Keys.Up))
            {
                SelectionY--;                
                System.Diagnostics.Debug.WriteLine($"Up!, x,y: ({SelectionX},{SelectionY})");
            }
            else if(oldState.IsKeyUp(Keys.Down) && newState.IsKeyDown(Keys.Down))
            {
                SelectionY++;
                System.Diagnostics.Debug.WriteLine($"Down!, x,y: ({SelectionX},{SelectionY})");
            }
        }

        public static void Setup()
        {
            Identities.Add(0, new Player(0, Art.E));
            Identities.Add(1, new Player(1, Art.X));
            Identities.Add(2, new Player(2, Art.O));
        }

        public void DrawSelector(SpriteBatch batch)
        {
            Vector2 position = new Vector2(
                SelectionX * Configuration.CellSize,
                SelectionY * Configuration.CellSize
            );

            batch.Begin();
            batch.Draw(Art.Select, position, Color.White);
            batch.End();
        }
    }
}