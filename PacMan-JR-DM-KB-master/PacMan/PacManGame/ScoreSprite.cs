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
        private Game1 game;
        private SpriteBatch spriteBatch;
        private SpriteFont font;
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

            base.LoadContent();
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
           
            spriteBatch.Begin();
            spriteBatch.DrawString(font, "" + game.PacManGame.Score.Score, new Vector2(800, 100), Color.White);
         

            spriteBatch.End();
            base.Draw(gameTime);


        }
    }
}
