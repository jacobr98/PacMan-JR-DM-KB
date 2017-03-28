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

        //maze walls
        private Texture2D wall;
        private Texture2D vertical;
        private Texture2D closedhorizontal;
        private Texture2D connectorhorizontal;
        private Texture2D closedvertical;
        private Texture2D connectorvertical;
        private Texture2D cornerbot;
        private Texture2D cornertop;

        //test
        private Texture2D energizerAnimation;

        //maze items
        private Texture2D pellet;
        private Texture2D energizer;

        private Maze maze;
        private int frame;
        private int animationcounter;

        //sounds
        private SoundEffect eat;

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

            //maze walls
            empty = game.Content.Load<Texture2D>("empty");
            wall = game.Content.Load<Texture2D>("wall");
            vertical = game.Content.Load<Texture2D>("wallvertical");
            closedhorizontal = game.Content.Load<Texture2D>("closedhorizontal");
            connectorhorizontal = game.Content.Load<Texture2D>("connectorhorizontal");
            closedvertical = game.Content.Load<Texture2D>("closedvertical");
            connectorvertical = game.Content.Load<Texture2D>("connectorvertical");
            cornerbot = game.Content.Load<Texture2D>("cornerbot");
            cornertop = game.Content.Load<Texture2D>("cornertop");

            //test
            energizerAnimation = game.Content.Load<Texture2D>("energizeranimation");

            //game items
            pellet = game.Content.Load<Texture2D>("pellet");
            energizer = game.Content.Load<Texture2D>("energizer");

            //sound
            eat = game.Content.Load<SoundEffect>("pacmaneatfruit");

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
            for (int i = 0; i < maze.Height; i++)
            {
                
                for (int j = 0; j < maze.Length; j++) {
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
                            case WallType.ConnectorD:
                                spriteBatch.Draw(connectorvertical, new Rectangle(i * 32, j * 32, 32, 32), Color.White);
                                break;
                            case WallType.ConnectorU:
                                spriteBatch.Draw(connectorvertical, new Rectangle(i * 32, j * 32, 32, 32), null, Color.White, 0, new Vector2(0, 0), SpriteEffects.FlipVertically, 0);
                                break;
                            case WallType.CornerUR:
                                spriteBatch.Draw(cornertop, new Rectangle(i * 32, j * 32, 32, 32), Color.White);
                                break;
                            case WallType.CornerUL:
                                spriteBatch.Draw(cornertop, new Rectangle(i * 32, j * 32, 32, 32), null, Color.White, 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 0);
                                break;
                            case WallType.CornerDR:
                                spriteBatch.Draw(cornerbot, new Rectangle(i * 32, j * 32, 32, 32), Color.White);
                                break;
                            case WallType.CornerDL:
                                spriteBatch.Draw(cornerbot, new Rectangle(i * 32, j * 32, 32, 32), null, Color.White, 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 0);
                                break;
                        }
                        
                    }
                    
                    else if (maze[i, j] is Tile) {
                        if (maze[i,j].Member is Pellet)
                            spriteBatch.Draw(pellet, new Rectangle(i * 32, j * 32, 32, 32), Color.White);
                        else if(maze[i,j].Member is Energizer)
                        {
                            if (frame == 0)
                            {
                                spriteBatch.Draw(energizer, new Rectangle(i * 32, j * 32, 32, 32), Color.White);
                            } else if (frame == 1)
                            {
                                spriteBatch.Draw(energizerAnimation, new Rectangle(i * 32, j * 32, 32, 32), new Rectangle(i * 32, (j * 32) * frame, 32, 32), Color.White);
                            }                                 
                        }

                        else
                            spriteBatch.Draw(empty, new Rectangle(i * 32, j * 32, 32, 32), Color.White);

                    } 
                }
            }

            if (animationcounter > 5)
            {
                frame++;
                animationcounter = 0;
            }
            else
                animationcounter++;

            if (frame > 1)
                frame = 0;

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
