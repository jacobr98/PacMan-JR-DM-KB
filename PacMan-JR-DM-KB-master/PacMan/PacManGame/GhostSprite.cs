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

namespace PacManGame
{
    class GhostSprite : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private Texture2D ghostImage;
        private Game1 game;
        private Maze maze;
        private Ghost ghost1;
        private Ghost ghost2;
        private Ghost ghost3;
        private Ghost ghost4;
        //we will create the ghosts in the constructor 
        private GhostPack ghostpack;

        public GhostSprite(Game1 game, GhostPack ghostpack) : base(game)
        {
            this.game = game;
            this.ghostpack = ghostpack;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            ghostImage = game.Content.Load<Texture2D>("ghost");
            this.maze = game.PacManGame.Maze;
            ghost1 = new Ghost(game.PacManGame, 11, 8, new Vector2(), GhostState.Chase, Color.Red);
            base.LoadContent();
        }
        public override void Update(GameTime gameTime)
        {
            ghost1.Move();
            //ghost2.Move();
            //ghost3.Move();
            //ghost4.Move();
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            int counter = 1;

            if (maze[11, 8] is Path && counter == 1)
            {
                spriteBatch.Draw(ghostImage, new Rectangle(11 * 32, 8 * 32, 32, 32), Color.Red);
                counter++;
            }

            if (maze[11, 10] is Path && counter == 2)
            {
                spriteBatch.Draw(ghostImage, new Rectangle(11 * 32, 10 * 32, 32, 32), Color.Blue);
                counter++;
            }
            if (maze[10, 10] is Path && counter == 3)
            {
                spriteBatch.Draw(ghostImage, new Rectangle(10 * 32, 10 * 32, 32, 32), Color.Yellow);
                counter++;
            }
            if (maze[12, 10] is Path && counter == 4)
            {
                spriteBatch.Draw(ghostImage, new Rectangle(12 * 32, 10 * 32, 32, 32), Color.Green);
                counter++;
            }


            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
