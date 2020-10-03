using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AnimationPractice
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Ryu Ryu { get; set; }
        private Timer GameTimer { get; set; }
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            var defaultFont = Content.Load<SpriteFont>("DefaultFont");
            var ryuTexture = Content.Load<Texture2D>("Ryu Street Fighter 2 SpriteSheet");

            GameTimer = new Timer(Vector2.Zero, defaultFont, Color.White);
            Ryu = new Ryu(ryuTexture, Vector2.One * 100, Color.White, 1.2f, Vector2.One * 2);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            GameTimer.Update(gameTime);
            Ryu.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            GameTimer.DrawString(_spriteBatch);
            Ryu.Animate(_spriteBatch);

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
