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
    class GhostSprite : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private Texture2D ghostImage;
        private Game1 game;
        //we will create the ghosts in the constructor 
        private GhostPack ghostPack;
        private int threshold;
        private int counter;

        public GhostSprite(Game1 game) : base(game)
        {
            this.game = game;
        }

        public override void Initialize()
        {
            counter = 0;
            threshold = 10;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            ghostImage = game.Content.Load<Texture2D>("ghost");
            this.ghostPack = game.PacManGame.Ghostpack; 
         
            base.LoadContent();
        }
        public override void Update(GameTime gameTime)
        {
            if (counter > threshold)
            {
                ghostPack.Move();
                counter = 0;
            }
            else { counter++; }
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
        
            foreach (Ghost g in ghostPack) {
                if (g.CurrentState == GhostState.Scared)
                {
                    spriteBatch.Draw(ghostImage, new Rectangle((int)g.Position.X * 32, (int)g.Position.Y * 32, 32, 32), Color.Blue);
                }
                else if (g.CurrentState == GhostState.Zombie)
                {
                    spriteBatch.Draw(ghostImage, new Rectangle((int)g.Position.X * 32, (int)g.Position.Y * 32, 32, 32), Color.Bisque);
                }
                else
                {
                    spriteBatch.Draw(ghostImage, new Rectangle((int)g.Position.X * 32, (int)g.Position.Y * 32, 32, 32), g.Colour);
                }

            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
