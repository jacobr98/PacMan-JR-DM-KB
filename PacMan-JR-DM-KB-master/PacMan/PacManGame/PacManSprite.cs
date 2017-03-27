using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Storage;
using PacMan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacManGame
{
    class PacManSprite : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private Texture2D pacmanImage;
        private Game1 game;
        private Pacman pacman;
        private KeyboardState oldState;
        private int counter;
        private int threshold;
        private int movecounter;
        private int movethreshold;
        public PacManSprite(Game1 game) : base(game)
        {
            this.game = game;
        }



        public override void Initialize()
        {
            oldState = Keyboard.GetState();
            threshold = 10;
            movecounter = 0;
            movethreshold = 10;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            pacmanImage = game.Content.Load<Texture2D>("pacman");
            this.pacman = game.PacManGame.Pacman;
            base.LoadContent();
        }
        public override void Update(GameTime gameTime)
        {
            if (movecounter > movethreshold)
            {
                movecounter = 0;
                KeyboardState newState = Keyboard.GetState();
                if (newState.IsKeyDown(Keys.Right))
                {
                    
                    if (!oldState.IsKeyDown(Keys.Right))
                    {
                        pacman.Move(Direction.Right);
                        counter = 0;

                    }
                    else
                    {
                        counter++;
                        if (counter > threshold)
                            pacman.Move(Direction.Right);
                    }
                }
                //Left
                if (newState.IsKeyDown(Keys.Left))
                {
                    if (!oldState.IsKeyDown(Keys.Left))
                    {
                        pacman.Move(Direction.Left);
                        counter = 0;
                    }
                    else
                    {
                        counter++;
                        if (counter > threshold)
                            pacman.Move(Direction.Left);
                    }
                }
                //Up
                if (newState.IsKeyDown(Keys.Up))
                {
                    if (!oldState.IsKeyDown(Keys.Up))
                    {
                        pacman.Move(Direction.Up);
                        counter = 0;
                    }
                    else
                    {
                        counter++;
                        if (counter > threshold)
                            pacman.Move(Direction.Up);
                    }
                }
                //Down
                if (newState.IsKeyDown(Keys.Down))
                {
                    if (!oldState.IsKeyDown(Keys.Down))
                    {
                        pacman.Move(Direction.Down);
                        counter = 0;
                    }
                    else
                    {
                        counter++;
                        if (counter > threshold)
                            pacman.Move(Direction.Down);
                    }
                }
            }
            else { movecounter++; }

            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(pacmanImage, new Rectangle((int)pacman.Position.X * 32, (int)pacman.Position.Y * 32, 32, 32), Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }


    }
}
