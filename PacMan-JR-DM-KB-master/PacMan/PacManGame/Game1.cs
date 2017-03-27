using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Storage;
using PacMan;
using System.IO;

namespace PacManGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private GhostSprite ghostSprite;
        private MazeSprite mazeSprite;
        private ScoreSprite scoreSprite;
        private PacManSprite pacmanSprite;
        private GameState gameState;
        public GameState PacManGame { get { return this.gameState; } }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 736;
            graphics.PreferredBackBufferWidth = 950;
            graphics.ApplyChanges();

            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            string level1 = File.ReadAllText("../../../../../PacMan/levelsPen.csv");
            this.gameState = GameState.Parse(level1);
            this.mazeSprite = new MazeSprite(this);
            this.ghostSprite = new GhostSprite(this);
            this.pacmanSprite = new PacManSprite(this);
            this.scoreSprite = new ScoreSprite(this);
            Components.Add(scoreSprite);
            Components.Add(mazeSprite);
            Components.Add(ghostSprite);
            Components.Add(pacmanSprite);
            base.Initialize();

            this.PacManGame.Maze.PacmanWon += Maze_PacmanWon;
            this.PacManGame.Score.GameOver += Score_GameOver;
           
        }

        private void Score_GameOver(string obj)
        {
            Components.Remove(ghostSprite);
            Components.Remove(pacmanSprite);
            Components.Remove(mazeSprite);           
        }

        private void Maze_PacmanWon(ICollidable obj)
        {
            Components.Remove(ghostSprite);
            Components.Remove(pacmanSprite);
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            //backgroundMusic = Content.Load<SoundEffect>("pacman_beginning");
            //backgroundMusic.Play();
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            KeyboardState newState = Keyboard.GetState();
            if (newState.IsKeyDown(Keys.Enter))
            {
                this.Reset();
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            base.Draw(gameTime);
        }

        private void Reset()
        {
            this.PacManGame.Score.Lives = 3;
            this.PacManGame.Score.Score = 0;
            Initialize();
        }
    }
}
