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
    class MazeSprite : DrawableGameComponent
    {
        private Game1 game;
        private SpriteBatch spriteBatch;
        private Texture2D empty;
        private Texture2D wall;
        private Texture2D pellet;
        private Texture2D energizer;
        private Maze maze;

        public MazeSprite(Game1 game) : base(game)
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
            empty = game.Content.Load<Texture2D>("empty");
            wall = game.Content.Load<Texture2D>("wall");
            pellet = game.Content.Load<Texture2D>("pellet");
            energizer = game.Content.Load<Texture2D>("energizer");
            this.maze = game.PacManGame.Maze;
            base.LoadContent();
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            for (int i = 0; i < maze.Size; i++)
            {
                
                for (int j = 0; j < maze.Size; j++) {
                    if (maze[i, j] is Wall)
                    {
                        spriteBatch.Draw(wall, new Rectangle(i * 32, j * 32, 32, 32), Color.White);
                    }
                    
                    else if (maze[i, j] is Tile) {
                        if (maze[i,j].Member is Pellet)
                            spriteBatch.Draw(pellet, new Rectangle(i * 32, j * 32, 32, 32), Color.White);
                        else if(maze[i,j].Member is Energizer)
                            spriteBatch.Draw(energizer, new Rectangle(i * 32, j * 32, 32, 32), Color.White);
                        else
                            spriteBatch.Draw(empty, new Rectangle(i * 32, j * 32, 32, 32), Color.White);
                    } 
                }
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
