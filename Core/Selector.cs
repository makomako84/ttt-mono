using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TTT
{
    public class Selector
    {
        public int _selectionX;
        public int _selectionY;
        public Texture2D _texture;
        public Vector2 _position;

        public Selector()
        {
            _selectionX = 0;
            _selectionY = 0;
            _position = Vector2.Zero;
        }

        public void Load(ContentManager content)
        {
            _texture = content.Load<Texture2D>("select");
        }

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

        public void Update(KeyboardState newState, KeyboardState oldState)
        {
            if(oldState.IsKeyUp(Keys.Left) && newState.IsKeyDown(Keys.Left))
            {
                SelectionX--;
            }
            else if(oldState.IsKeyUp(Keys.Right) && newState.IsKeyDown(Keys.Right))
            {
                SelectionX++;
            }
            else if(oldState.IsKeyUp(Keys.Up) && newState.IsKeyDown(Keys.Up))
            {
                SelectionY--;
            }
            else if(oldState.IsKeyUp(Keys.Down) && newState.IsKeyDown(Keys.Down))
            {
                SelectionY++;
            }

                _position = new Vector2(
                SelectionX * Configuration.CellSize,
                SelectionY * Configuration.CellSize
            );
        }

        public void Draw(SpriteBatch batch)
        {
            batch.Begin();
            batch.Draw(_texture, _position, Color.White);
            batch.End();
        }
    }
}