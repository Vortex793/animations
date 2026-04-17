using System.Net;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace animations
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D tribbleBrownTexture, tribbleOrangeTexture, tribbleCreamTexture, tribbleGreyTexture;
        Rectangle brownTribbleRect, brownCreamRect;
        Rectangle window;
        Vector2 brownTribbleSpeed;
        SoundEffect tribbleSound;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            window = new Rectangle(0, 0, 800, 600);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();
            // TODO: Add your initialization logic here

            base.Initialize();
            brownTribbleRect = new Rectangle(301, 10, 100, 100);
            brownTribbleSpeed = new Vector2(2000, 0);
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            tribbleBrownTexture = Content.Load<Texture2D>("tribbleBrown");
            tribbleSound = Content.Load<SoundEffect>("tribble_coo");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            brownTribbleRect.X += (int)brownTribbleSpeed.X;
            if (brownTribbleRect.Right >= window.Width || brownTribbleRect.Left <= 0)
            {
                brownTribbleSpeed.X *= -1;
                tribbleSound.Play();
            }
            brownTribbleRect.Y += (int)brownTribbleSpeed.Y;
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(tribbleBrownTexture, brownTribbleRect, Color.White);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
