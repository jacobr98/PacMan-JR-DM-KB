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
        private ScoreAndLives scoreAndLives;
        private Game game;
        private SpriteBatch spriteBatch;
        private Boolean isGameOver;

        public ScoreSprite(Game game, ScoreAndLives scoreAndLives) : base(game)
        {
            this.game = game;
            this.scoreAndLives = scoreAndLives;
            isGameOver = false;
        }

 
        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            base.LoadContent();
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            if (isGameOver)
            {
                //do something
            }
            spriteBatch.Begin();

            //code

            spriteBatch.End();
            base.Draw(gameTime);


        }
        public void GameOver()
        {
            isGameOver = true;
        }
    }
}
