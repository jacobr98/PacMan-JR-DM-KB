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
        private Texture2D vertical;
        private Texture2D closedhorizontal;
        private Texture2D connectorhorizontal;
        private Texture2D closedvertical;

        private Texture2D pellet;
        private Texture2D energizer;
        private Texture2D victory;
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
            vertical = game.Content.Load<Texture2D>("wallvertical");
            closedhorizontal = game.Content.Load<Texture2D>("closedhorizontal");
            connectorhorizontal = game.Content.Load<Texture2D>("connectorhorizontal");
            closedvertical = game.Content.Load<Texture2D>("closedvertical");

            pellet = game.Content.Load<Texture2D>("pellet");
            energizer = game.Content.Load<Texture2D>("energizer");
            victory = game.Content.Load<Texture2D>("victory");
            this.maze = game.PacManGame.Maze;
            base.LoadContent();
        }
        public override void Update(GameTime gameTime)
        {
            game.PacManGame.Maze.CheckMembersLeft();
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
                        switch (((Wall)maze[i, j]).Type)
                        {
                            case WallType.Horizontal:
                                spriteBatch.Draw(wall, new Rectangle(i * 32, j * 32, 32, 32), Color.White);
                                break;
                            case WallType.Vertical:
                                spriteBatch.Draw(vertical, new Rectangle(i * 32, j * 32, 32, 32), Color.White);
                                break;
                            case WallType.ClosedR:
                                spriteBatch.Draw(closedhorizontal, new Rectangle(i * 32, j * 32, 32, 32), Color.White);
                                break;
                            case WallType.ClosedL:
                                spriteBatch.Draw(closedhorizontal, new Rectangle(i * 32, j * 32, 32, 32),null, Color.White,0,new Vector2(0,0),SpriteEffects.FlipHorizontally,0);
                                break;
                            case WallType.ConnectorR:
                                spriteBatch.Draw(connectorhorizontal, new Rectangle(i * 32, j * 32, 32, 32), Color.White);
                                break;
                            case WallType.ConnectorL:
                                spriteBatch.Draw(connectorhorizontal, new Rectangle(i * 32, j * 32, 32, 32), null, Color.White, 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 0);
                                break;
                            case WallType.ClosedD:
                                spriteBatch.Draw(closedvertical, new Rectangle(i * 32, j * 32, 32, 32),Color.White);
                                break;
                            case WallType.ClosedU:
                                spriteBatch.Draw(closedvertical, new Rectangle(i * 32, j * 32, 32, 32), null, Color.White, 0, new Vector2(0, 0), SpriteEffects.FlipVertically, 0);
                                break;
                        }
                        
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

            if (game.PacManGame.Maze.gameWon() == true && game.PacManGame.Score.Lives > 0)
            {
                spriteBatch.Draw(victory, new Rectangle(0, 0, 736, 736), Color.White);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
