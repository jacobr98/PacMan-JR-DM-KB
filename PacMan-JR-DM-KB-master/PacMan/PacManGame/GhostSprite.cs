using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using PacMan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacMan;

namespace PacManGame
{
    class GhostSprite : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private Texture2D ghostImage;
        private Game game;
        //we will create the ghosts in the constructor 
        private GhostPack ghostpack;

        public GhostSprite(Game game, GhostPack ghostpack) : base(game)
        {
            this.game = game;
            this.ghostpack = ghostpack;
        }

        public override void Initialize()
        {
            //code
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //code

            base.LoadContent();
        }
        public override void Update(GameTime gameTime)
        {
            //code

            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            //code

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
