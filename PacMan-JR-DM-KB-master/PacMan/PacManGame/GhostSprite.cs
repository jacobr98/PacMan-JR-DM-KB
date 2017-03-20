using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        private GhostPack ghostpack;

        public GhostSprite(Game game) : base(game)
        {
            this.game = game;
            this.spriteBatch = game.SpriteBatch;
        }

        public override void Initialize()
        {
        }

        protected override void LoadContent()
        {

        }
        public override void Update(GameTime gameTime)
        {
        }
        public override void Draw(GameTime gameTime)
        {

        }
    }
}
