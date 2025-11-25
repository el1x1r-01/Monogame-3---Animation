using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Monogame_3___Animation
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Random generator = new Random();

        Rectangle window, tribbleBrownRect, tribbleTanRect, tribbleGreyRect, tribbleOrangeRect, tribbleBrownRectAlt;

        Texture2D tribbleBrownTexture, tribbleTanTexture, tribbleGreyTexture, tribbleOrangeTexture;

        Vector2 tribbleBrownSpeed, tribbleTanSpeed, tribbleGreySpeed, tribbleOrangeSpeed;

        int backgroundColorNumber, tribbleGreyHorizontalFlip, tribbleGreyVerticalFlip;

        SpriteEffects greyTribbleFlip;

        Color backgroundColor;

        SoundEffect tribbleCoo;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            window = new Rectangle(0, 0, 800, 600);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();

            tribbleBrownRect = new Rectangle(0, 0, 100, 100);
            tribbleBrownRectAlt = new Rectangle(-1000, -1000, 100, 100);
            tribbleBrownSpeed = new Vector2(2, 1);

            tribbleTanRect = new Rectangle(generator.Next(1, 700), generator.Next(1, 500), 100, 100);
            tribbleTanSpeed = new Vector2(4, -2);

            tribbleGreyRect = new Rectangle(generator.Next(1, 700), generator.Next(1, 500), 100, 100);
            tribbleGreySpeed = new Vector2(generator.Next(-5, 6), generator.Next(-5, 6));

            tribbleOrangeRect = new Rectangle(generator.Next(1, 700), generator.Next(1, 500), 100, 100);
            tribbleOrangeSpeed = new Vector2(20, 20);

            tribbleGreyHorizontalFlip = 1;
            tribbleGreyVerticalFlip = 1;
            if (tribbleGreySpeed.Y > 0)
                greyTribbleFlip = SpriteEffects.FlipVertically;
            else
                greyTribbleFlip = SpriteEffects.None;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            tribbleBrownTexture = Content.Load<Texture2D>("TibbleBrown");
            tribbleTanTexture = Content.Load<Texture2D>("TribbleTan");
            tribbleGreyTexture = Content.Load<Texture2D>("TribbleGrey");
            tribbleOrangeTexture = Content.Load<Texture2D>("TribbleOrange");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            tribbleBrownRect.X += (int)tribbleBrownSpeed.X;
            tribbleBrownRect.Y += (int)tribbleBrownSpeed.Y;

            if (tribbleBrownRect.Right == window.Width)
            {
                tribbleBrownRectAlt.X = -100;
                tribbleBrownRectAlt.Y = -100;
            }

            tribbleBrownRectAlt.X += (int)tribbleBrownSpeed.X;
            tribbleBrownRectAlt.Y += (int)tribbleBrownSpeed.Y;

            if (tribbleBrownRectAlt.Right == window.Width)
            {
                tribbleBrownRect.X = -100;
                tribbleBrownRect.Y = -100;
            }

            tribbleTanRect.X += (int)tribbleTanSpeed.X;
            tribbleTanRect.Y += (int)tribbleTanSpeed.Y;

            if (tribbleTanRect.Right > window.Width || tribbleTanRect.Left < 0)
            {
                tribbleTanSpeed.X *= -1;

                backgroundColorNumber++;
                if (backgroundColorNumber == 1)
                {
                    backgroundColor = Color.LightCoral;
                }
                else if (backgroundColorNumber == 2)
                {
                    backgroundColor = Color.LightSalmon;
                }
                else if (backgroundColorNumber == 3)
                {
                    backgroundColor = new Color(244, 249, 126);
                }
                else if (backgroundColorNumber == 4)
                {
                    backgroundColor = Color.LightGreen;
                }
                else if (backgroundColorNumber == 5)
                {
                    backgroundColor = Color.CornflowerBlue;
                }
                else if (backgroundColorNumber == 6)
                {
                    backgroundColor = Color.Plum;
                    backgroundColorNumber = 0;
                }
            }

            if (tribbleTanRect.Bottom > window.Height || tribbleTanRect.Top < 0)
            {
                tribbleTanSpeed.Y *= -1;
                GraphicsDevice.Clear(backgroundColor);

                backgroundColorNumber++;
                if (backgroundColorNumber == 1)
                {
                    backgroundColor = Color.LightCoral;
                }
                else if (backgroundColorNumber == 2)
                {
                    backgroundColor = Color.LightSalmon;
                }
                else if (backgroundColorNumber == 3)
                {
                    backgroundColor = new Color(244, 249, 126);
                }
                else if (backgroundColorNumber == 4)
                {
                    backgroundColor = Color.LightGreen;
                }
                else if (backgroundColorNumber == 5)
                {
                    backgroundColor = Color.CornflowerBlue;
                }
                else if (backgroundColorNumber == 6)
                {
                    backgroundColor = Color.Plum;
                    backgroundColorNumber = 0;
                }
            }

            tribbleGreyRect.X += (int)tribbleGreySpeed.X;
            tribbleGreyRect.Y += (int)tribbleGreySpeed.Y;

            if (tribbleGreyRect.Right > window.Width || tribbleGreyRect.Left < 0)
            {
                tribbleGreySpeed.X *= -1;

                tribbleGreyHorizontalFlip *= -1;

                if (tribbleGreyHorizontalFlip == -1 && tribbleGreyVerticalFlip == -1)
                {
                    tribbleGreyTexture = Content.Load<Texture2D>("TribbleGrey");
                }
                else if (tribbleGreyHorizontalFlip == 1 && tribbleGreyVerticalFlip == -1)
                {
                    tribbleGreyTexture = Content.Load<Texture2D>("TribbleGreyHorizontalFlip");
                }
                else if (tribbleGreyHorizontalFlip == 1 && tribbleGreyVerticalFlip == 1)
                {
                    tribbleGreyTexture = Content.Load<Texture2D>("TribbleGreyFlipped");
                }
                else if (tribbleGreyHorizontalFlip == -1 && tribbleGreyVerticalFlip == 1)
                {
                    tribbleGreyTexture = Content.Load<Texture2D>("TribbleGreyVerticalFlip");
                }
            }

            if (tribbleGreyRect.Bottom > window.Height || tribbleGreyRect.Top < 0)
            {
                tribbleGreySpeed.Y *= -1;

                tribbleGreyVerticalFlip *= -1;

                if (tribbleGreyHorizontalFlip == -1 && tribbleGreyVerticalFlip == -1)
                {
                    tribbleGreyTexture = Content.Load<Texture2D>("TribbleGrey");
                }
                else if (tribbleGreyHorizontalFlip == 1 && tribbleGreyVerticalFlip == -1)
                {
                    tribbleGreyTexture = Content.Load<Texture2D>("TribbleGreyHorizontalFlip");
                }
                else if (tribbleGreyHorizontalFlip == 1 && tribbleGreyVerticalFlip == 1)
                {
                    tribbleGreyTexture = Content.Load<Texture2D>("TribbleGreyFlipped");
                }
                else if (tribbleGreyHorizontalFlip == -1 && tribbleGreyVerticalFlip == 1)
                {
                    tribbleGreyTexture = Content.Load<Texture2D>("TribbleGreyVerticalFlip");
                }
            }

            tribbleOrangeRect.X += (int)tribbleOrangeSpeed.X;
            tribbleOrangeRect.Y += (int)tribbleOrangeSpeed.Y;

            if (tribbleOrangeRect.Right > window.Width || tribbleOrangeRect.Left < 0)
            {
                tribbleOrangeSpeed.X *= -1;

                if (tribbleOrangeSpeed.Y < 0)
                {
                    tribbleOrangeSpeed.Y = (generator.Next(-20, 1));
                }
                else
                {
                    tribbleOrangeSpeed.Y = (generator.Next(0, 21));
                }
            }

            if (tribbleOrangeRect.Bottom > window.Height || tribbleOrangeRect.Top < 0)
            {
                tribbleOrangeSpeed.Y *= -1;

                if (tribbleOrangeSpeed.X < 0)
                {
                    tribbleOrangeSpeed.X = (generator.Next(-20, 1));
                }
                else
                {
                    tribbleOrangeSpeed.X = (generator.Next(0, 21));
                }
            }
            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(backgroundColor);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            _spriteBatch.Draw(tribbleBrownTexture, tribbleBrownRect, Color.White);
            _spriteBatch.Draw(tribbleTanTexture, tribbleTanRect, Color.White);
            _spriteBatch.Draw(tribbleGreyTexture, tribbleGreyRect, Color.White);
            _spriteBatch.Draw(tribbleOrangeTexture, tribbleOrangeRect, Color.White);

            _spriteBatch.Draw(tribbleBrownTexture, tribbleBrownRectAlt, Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
