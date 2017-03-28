using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacMan;

namespace PacManGame
{
    class ScoreSprite : DrawableGameComponent
    {
        private Game1 game;
        private SpriteBatch spriteBatch;
        private SpriteFont font;
        private Texture2D lives;
        private Texture2D livesTitle;
        private Texture2D score;
        private Texture2D gameOver;
        private Texture2D victory;
        
        //sound
        private SoundEffect death;
        private SoundEffect beginning;
        public ScoreSprite(Game1 game) : base(game)
        {
            this.game = game;  
        }

 
        public override void Initialize()
        {
           
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = game.Content.Load<SpriteFont>("score");
            lives = game.Content.Load<Texture2D>("livesimage");
            score = game.Content.Load<Texture2D>("scoretitle");
            
            //game state
            gameOver = game.Content.Load<Texture2D>("gameover");
            victory = game.Content.Load<Texture2D>("victory");
            livesTitle = game.Content.Load<Texture2D>("lives");

            //sounds
            death = game.Content.Load<SoundEffect>("pacmandeath");
            beginning = game.Content.Load<SoundEffect>("pacmanbeginning");

            beginning.Play();
            base.LoadContent();
        }
        public override void Update(GameTime gameTime)
        {
            if (game.PacManGame.Score.Lives == 0)
            {
                death.Play();
                game.PacManGame.Score.Lives = -1;
            }

            
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
           
            spriteBatch.Begin();
            spriteBatch.Draw(score, new Vector2(770, 80), Color.White);
            spriteBatch.DrawString(font, "" + game.PacManGame.Score.Score, new Vector2(800, 400), Color.White);
            spriteBatch.DrawString(font, "" + game.PacManGame.Pacman.Position.X + ":" + game.PacManGame.Pacman.Position.Y, new Vector2(780, 350), Color.Yellow);
            int counter = 0;
            foreach (Ghost g in game.PacManGame.Ghostpack)
            {
                spriteBatch.DrawString(font, "" + g.GhostTarget.X + ":" + g.GhostTarget.Y, new Vector2(800, 450 + counter), g.Colour);
                counter += 50;
            }
           // spriteBatch.DrawString(font, "" + game.PacManGame.Maze.Length + " " + game.PacManGame.Maze.Height, new Vector2(800, 650), Color.White);
            spriteBatch.Draw(livesTitle, new Vector2(780, 160), Color.White);
            if (game.PacManGame.Score.Lives == 3)
            {
                spriteBatch.Draw(lives, new Rectangle(780, 200, 40, 40), Color.White);
                spriteBatch.Draw(lives, new Rectangle(820, 200, 40, 40), Color.White);
                spriteBatch.Draw(lives, new Rectangle(860, 200, 40, 40), Color.White);
            } else if (game.PacManGame.Score.Lives == 2)
            {
                spriteBatch.Draw(lives, new Rectangle(780, 200, 40, 40), Color.White);
                spriteBatch.Draw(lives, new Rectangle(820, 200, 40, 40), Color.White);
            } else if (game.PacManGame.Score.Lives == 1)
            {
                spriteBatch.Draw(lives, new Rectangle(780, 200, 40, 40), Color.White);
            }

            if (game.PacManGame.Score.Lives == -1)
            {
                spriteBatch.Draw(gameOver, new Rectangle(190, 200, 360, 166), Color.White);
            }

            if (game.PacManGame.Maze.gameWon() == true && game.PacManGame.Score.Lives > 0)
            {
                spriteBatch.Draw(victory, new Rectangle(190, 200, 360, 270), Color.White);
            }
            spriteBatch.End();
            base.Draw(gameTime);


        }
    }
}