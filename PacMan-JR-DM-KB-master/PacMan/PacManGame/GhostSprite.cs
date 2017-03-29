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
    /// <summary>
    /// Authors : Jacob Riendeau, Kevin Bui
    /// </summary>
    class GhostSprite : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private Texture2D ghostImage;
        private Texture2D eyeImage;
        private Game1 game; 
        private GhostPack ghostPack;

        private SoundEffect scared;
        private int threshold;
        private int counter;

        private int spriteSize = 16;

        /// <summary>
        /// Constructor of ghostSprite
        /// </summary>
        public GhostSprite(Game1 game) : base(game)
        {
            this.game = game;
        }

        /// <summary>
        /// Initializes the game
        /// </summary>
        public override void Initialize()
        {
            counter = 0;
            threshold = 8;
            base.Initialize();
        }

        /// <summary>
        /// Loads the content of the game
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            ghostImage = game.Content.Load<Texture2D>("ghost");
            eyeImage = game.Content.Load<Texture2D>("ghosteye");
            scared = game.Content.Load<SoundEffect>("ghostscared");
            game.PacManGame.Score.Eats += Scared;
            this.ghostPack = game.PacManGame.Ghostpack;

            base.LoadContent();
        }

        /// <summary>
        /// Updates the game
        /// </summary>
        /// <param name="gameTime">The game time</param>
        public override void Update(GameTime gameTime)
        {
            if (counter > threshold)
            {
                ghostPack.Move();
                counter = 0;
            } else { counter++; }

            base.Update(gameTime);
        }

        /// <summary>
        /// Plays the scared sound effect
        /// </summary>
        /// <param name="c">The collidable</param>
        public void Scared(ICollidable c)
        {
            SoundEffectInstance scaredInstance = scared.CreateInstance();

            if (c is Energizer)
            {
                scaredInstance.Play();
            }
        }

        /// <summary>
        /// Draws the spritebatch
        /// </summary>
        /// <param name="gameTime">The game time</param>
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
        
            foreach (Ghost g in ghostPack) {
                if (g.CurrentState == GhostState.Scared)
                {
                    spriteBatch.Draw(ghostImage, new Rectangle((int)g.Position.X * spriteSize, (int)g.Position.Y * spriteSize, spriteSize, spriteSize), Color.Blue);
                }
                else if (g.CurrentState == GhostState.Zombie)
                {
                    spriteBatch.Draw(ghostImage, new Rectangle((int)g.Position.X * spriteSize, (int)g.Position.Y * spriteSize, spriteSize, spriteSize), Color.Black);
                }
                else
                {
                    spriteBatch.Draw(ghostImage, new Rectangle((int)g.Position.X * spriteSize, (int)g.Position.Y * spriteSize, spriteSize, spriteSize), g.Colour);
                }

                spriteBatch.Draw(eyeImage, new Rectangle((int)g.Position.X * spriteSize, (int)g.Position.Y * spriteSize, spriteSize, spriteSize), Color.White);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
