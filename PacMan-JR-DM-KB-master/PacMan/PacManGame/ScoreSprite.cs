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
        private Texture2D gameOver;
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
            lives = game.Content.Load<Texture2D>("lives");
            gameOver = game.Content.Load<Texture2D>("gameover");
            base.LoadContent();
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
           
            spriteBatch.Begin();
            spriteBatch.DrawString(font, "Score", new Vector2(780, 80), Color.White);
            spriteBatch.DrawString(font, "" + game.PacManGame.Score.Score, new Vector2(780, 100), Color.White);
            spriteBatch.DrawString(font, "points", new Vector2(820, 100), Color.White);
            spriteBatch.DrawString(font, "Lives", new Vector2(780, 180), Color.White);
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
            } else if (game.PacManGame.Score.Lives == 0)
            {
                spriteBatch.Draw(gameOver, new Rectangle(0, 0, 950, 736), Color.White);
            } 
            spriteBatch.End();
            base.Draw(gameTime);


        }
    }
}