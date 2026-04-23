using System;
using System.Net;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace animations
{
    public class Game1 : Game
    {
        //Curtis Apfelbeck
        //Tribble Animations
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        
        Random randNum = new Random();

        Texture2D tribbleBrownTexture, tribbleOrangeTexture, tribbleCreamTexture, tribbleGreyTexture;
        Rectangle tribbleBrownRect, tribbleCreamRect, tribbleGreyRect, tribbleOrangeRect;
        
        Rectangle window;
        
        Rectangle enterpriceBackgroundRect;
        Texture2D enterpriseTexture;

        Vector2 tribbleBrownSpeed, tribbleCreamSpeed, tribbleGreySpeed, tribbleOrangeSpeed;
        
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
            //Tribble Rectangles
            tribbleBrownRect = new Rectangle(randNum.Next(0, 700), randNum.Next(0, 500), 100, 100);
            tribbleCreamRect = new Rectangle(randNum.Next(0, 700), randNum.Next(0, 500), 100, 100);
            tribbleGreyRect = new Rectangle(randNum.Next(0, 700), randNum.Next(0, 500), 100, 100);
            tribbleOrangeRect = new Rectangle(randNum.Next(0, 700), randNum.Next(0, 500), 100, 100);

            //Tribble Speed
            tribbleBrownSpeed = new Vector2(2, 2);
            tribbleCreamSpeed = new Vector2(2, 0);
            tribbleGreySpeed = new Vector2(0, 2);
            tribbleOrangeSpeed = new Vector2(3, 1);

            //Background
            enterpriceBackgroundRect = new Rectangle(0, 0, 800, 600);
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            tribbleBrownTexture = Content.Load<Texture2D>("tribbleBrown");
            tribbleCreamTexture = Content.Load<Texture2D>("tribbleCream");
            tribbleGreyTexture = Content.Load<Texture2D>("tribbleGrey");
            tribbleOrangeTexture = Content.Load<Texture2D>("tribbleOrange");

            tribbleSound = Content.Load<SoundEffect>("tribble_coo");

            enterpriseTexture = Content.Load<Texture2D>("enterprise_inside");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            //Brown
            tribbleBrownRect.X += (int)tribbleBrownSpeed.X;
            if (tribbleBrownRect.Right >= window.Width || tribbleBrownRect.Left <= 0)
            {
                tribbleBrownSpeed.X *= -1;
                tribbleSound.Play();
            }

            tribbleBrownRect.Y += (int)tribbleBrownSpeed.Y;
            if (tribbleBrownRect.Bottom >= window.Height || tribbleBrownRect.Top <= 0)
            {
                tribbleBrownSpeed.Y *= -1;
                tribbleSound.Play();
            }

            //Cream
            tribbleCreamRect.X += (int)tribbleCreamSpeed.X;
            if (tribbleCreamRect.Right >= window.Width || tribbleCreamRect.Left <= 0)
            {
                tribbleCreamSpeed.X *= -1;
                tribbleSound.Play();
            }

            tribbleCreamRect.Y += (int)tribbleCreamSpeed.Y;
            if (tribbleCreamRect.Bottom >= window.Height || tribbleCreamRect.Top <= 0)
            {
                tribbleCreamSpeed.Y *= -1;
                tribbleSound.Play();
            }

            //Grey
            tribbleGreyRect.X += (int)tribbleGreySpeed.X;
            if (tribbleGreyRect.Right >= window.Width || tribbleGreyRect.Left <= 0)
            {
                tribbleGreySpeed.X *= -1;
                tribbleSound.Play();
            }

            tribbleGreyRect.Y += (int)tribbleGreySpeed.Y;
            if (tribbleGreyRect.Bottom >= window.Height || tribbleGreyRect.Top <= 0)
            {
                tribbleGreySpeed.Y *= -1;
                tribbleSound.Play();
            }

            //Orange
            tribbleOrangeRect.X += (int)tribbleOrangeSpeed.X;
            if (tribbleOrangeRect.Right < 0)
            {
                tribbleOrangeRect.X = window.Width;
                tribbleSound.Play();
            }
            else if (tribbleOrangeRect.Left > window.Width)
            {
                tribbleOrangeRect.X = -tribbleOrangeRect.Width;
                tribbleSound.Play();
            }

            tribbleOrangeRect.Y += (int)tribbleOrangeSpeed.Y;
            if (tribbleOrangeRect.Bottom < 0)
            {
                tribbleOrangeRect.Y = window.Height;
                tribbleSound.Play();
            }
            else if (tribbleOrangeRect.Top > window.Height)
            {
                tribbleOrangeRect.Y = -tribbleOrangeRect.Height;
                tribbleSound.Play();
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(enterpriseTexture, enterpriceBackgroundRect, Color.White);    //Background
            _spriteBatch.Draw(tribbleBrownTexture, tribbleBrownRect, Color.White);          //Brown
            _spriteBatch.Draw(tribbleCreamTexture, tribbleCreamRect, Color.White);          //Cream
            _spriteBatch.Draw(tribbleGreyTexture, tribbleGreyRect, Color.White);            //Grey
            _spriteBatch.Draw(tribbleOrangeTexture, tribbleOrangeRect, Color.White);        //Orange
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
