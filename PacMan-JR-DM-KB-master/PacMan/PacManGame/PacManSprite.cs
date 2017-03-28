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
        private Texture2D pacmanHorizontal;
        private Texture2D pacmanVertical;

        private Game1 game;
        private Pacman pacman;

        private KeyboardState oldState;
        private int counter;
        private int threshold;

        private int movecounter;
        private int movethreshold;

        private int frame;
        private int animationcounter;

        //sounds
        private SoundEffect eatEnergizer;


        public PacManSprite(Game1 game) : base(game)
        {
            this.game = game;
        }



        public override void Initialize()
        {
            oldState = Keyboard.GetState();
            threshold = 10;
            movecounter = 0;
            movethreshold = 8;
            frame = 0;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            pacmanHorizontal = game.Content.Load<Texture2D>("pacman");
            pacmanVertical = game.Content.Load<Texture2D>("pacman2");

            //sound
            eatEnergizer = game.Content.Load<SoundEffect>("pacmaneatfruit");

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
            switch (pacman.PacmanDirection) {
                case Direction.Right:
                    spriteBatch.Draw(pacmanHorizontal, new Rectangle((int)pacman.Position.X * 32, (int)pacman.Position.Y * 32, 32, 32), new Rectangle(0, 32 * frame, 32, 32), Color.White);
                    break;
                case Direction.Left:
                    spriteBatch.Draw(pacmanHorizontal, new Rectangle((int)pacman.Position.X * 32, (int)pacman.Position.Y * 32, 32, 32), new Rectangle(0, 32 * frame, 32, 32), Color.White,0, new Vector2(0,0),SpriteEffects.FlipHorizontally,0);
                    break;
                case Direction.Up:
                    spriteBatch.Draw(pacmanVertical, new Rectangle((int)pacman.Position.X * 32, (int)pacman.Position.Y * 32, 32, 32), new Rectangle(32 * frame, 0 , 32, 32), Color.White, 0, new Vector2(0, 0), SpriteEffects.FlipVertically, 0);
                    break;
                case Direction.Down:
                    spriteBatch.Draw(pacmanVertical, new Rectangle((int)pacman.Position.X * 32, (int)pacman.Position.Y * 32, 32, 32), new Rectangle(32 *frame, 0, 32, 32), Color.White, 0, new Vector2(0, 0), SpriteEffects.None, 0);
                    break;
            }
            if (animationcounter > 5)
            {
                frame++;
                animationcounter = 0;
            }
            else
                animationcounter++;

            if (frame > 2)
                frame = 0;
            spriteBatch.End();
            base.Draw(gameTime);
        }


    }
}
