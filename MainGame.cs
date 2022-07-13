using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace TTT
{
    /// <summary>
    /// Tic-tac-toe
    /// </summary>
    public class MainGame : Microsoft.Xna.Framework.Game
    {
        public Board board;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private AnimatedSprite _animatedSprite;
        private Model _model;

        private Matrix world = Matrix.CreateTranslation(new Vector3(0, 0, 0));
        private Matrix view = Matrix.CreateLookAt(new Vector3(0, 0, 10), new Vector3(0, 0, 0), Vector3.UnitY);
        private Matrix projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45), 800f / 480f, 0.1f, 100f);

        private Vector3 position;
        private float angle;
        private KeyboardState oldState;

        public MainGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            position = Vector3.Zero;
            angle = 0;

            // Set Empty field to zero identifier
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            Art.Load(Content);
            Identifiers.Setup();

            var texture = Content.Load<Texture2D>("SmileyWalk");
            _animatedSprite = new AnimatedSprite(texture, 4, 4);

            _model = Content.Load<Model>("box");
            board = new Board();
            
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            _animatedSprite.Update();
            position += new Vector3(0, 0.01f, 0);
            angle += 0.03f;
            world = Matrix.CreateRotationY(angle) * Matrix.CreateTranslation(position);

            KeyboardState newState = Keyboard.GetState();
            if(oldState.IsKeyUp(Keys.Left) && newState.IsKeyDown(Keys.Left))
            {
                System.Diagnostics.Debug.WriteLine("FIRE!");
            }
            oldState = newState;

            base.Update(gameTime);
        }

        private void DrawModel(Model model, Matrix world, Matrix view, Matrix projection)
        {
            foreach (ModelMesh mesh in model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.World = world;
                    effect.View = view;
                    effect.Projection = projection;
                }
        
                mesh.Draw();
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // batch - партия, серия
            // TODO: Add your drawing code here
            // _spriteBatch.Begin();
            // _spriteBatch.Draw(_xTexture, new Vector2(0, 0), Color.White);
            // _spriteBatch.End();

            // _spriteBatch.Begin();
            // _spriteBatch.Draw(_eTexture, new Vector2(100, 0), Color.White);
            // _spriteBatch.End();

            // _spriteBatch.Begin();
            // _spriteBatch.Draw(_oTexture, new Vector2(200, 0), Color.White);
            // _spriteBatch.End();

            // _animatedSprite.Draw(_spriteBatch, new Vector2(400, 200));
            // DrawModel(_model, world, view, projection);


            board.Draw(_spriteBatch);

            base.Draw(gameTime);
        }
    }
}
