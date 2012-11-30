using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace SuperCaveman
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        enum GameState
        {
            MainMenu,
            Options,
            Credits,
            Playing,
        }
        
        GameState CurrentGameState = GameState.MainMenu;

        //Screen adjustments
        int screenWidth = 1280, screenHeight = 720;

        Button buttonPlay;
        Button buttonOptions;
        Button buttonCredits;
        Button buttonBack;
        Button buttonBack2;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
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
            // TODO: Add your initialization logic here
            EntityManager.m_graphics = graphics.GraphicsDevice;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            EntityManager.m_spriteBatch = spriteBatch;

            // Loading the Player into the Entity Manager
            Player player = new Player("Cro", new Vector2(300, 300), this.Content);
            EntityManager.Instance.AddEntity(player);

            // Loading Enemy character into Entity Manager
            PterEnemy pter01 = new PterEnemy("Pter01", new Vector2(500, 300), this.Content);
            EntityManager.Instance.AddEntity(pter01);

            // TODO: use this.Content to load your game content here
            EntityManager.Instance.LoadContentForAllEntities(this.Content);

            //Screen
            graphics.PreferredBackBufferWidth = screenWidth;
            graphics.PreferredBackBufferHeight = screenHeight;
            //graphics.IsFullScreen = true;
            graphics.ApplyChanges();
            IsMouseVisible = true;

            buttonPlay = new Button(Content.Load<Texture2D>("Buttons/Start"), graphics.GraphicsDevice);
            buttonPlay.setPosition(new Vector2(350, 300));

            buttonOptions = new Button(Content.Load<Texture2D>("Buttons/Options"), graphics.GraphicsDevice);
            buttonOptions.setPosition(new Vector2(350, 400));

            buttonCredits = new Button(Content.Load<Texture2D>("Buttons/Credits"), graphics.GraphicsDevice);
            buttonCredits.setPosition(new Vector2(350, 500));

            buttonBack = new Button(Content.Load<Texture2D>("Buttons/Back"), graphics.GraphicsDevice);
            buttonBack.setPosition(new Vector2(50, 100));

            buttonBack2 = new Button(Content.Load<Texture2D>("Buttons/Back2"), graphics.GraphicsDevice);
            buttonBack2.setPosition(new Vector2(50, 100));
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            MouseState mouse = Mouse.GetState();
            buttonPlay.Update(mouse, gameTime);
            buttonOptions.Update(mouse, gameTime);
            buttonCredits.Update(mouse, gameTime);
            buttonBack.Update(mouse, gameTime);
            buttonBack2.Update(mouse, gameTime);

            //// Allows the game to exit
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            //    this.Exit();

            // TODO: Add your update logic here


            switch (CurrentGameState)
            {
                case GameState.MainMenu:
                    if (buttonPlay.isClicked == true) CurrentGameState = GameState.Playing;
                    if (buttonOptions.isClicked == true) CurrentGameState = GameState.Options;
                    if (buttonCredits.isClicked == true) CurrentGameState = GameState.Credits;
                    break;

                case GameState.Options:
                    if (buttonBack.isClicked == true) CurrentGameState = GameState.MainMenu;
                    break;

                case GameState.Credits:
                    if (buttonBack2.isClicked == true) CurrentGameState = GameState.MainMenu;
                    break;

                case GameState.Playing:
                    EntityManager.Instance.UpdateAllEntities(gameTime);
                    break;
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            switch (CurrentGameState)
            {
                case GameState.MainMenu:
                    spriteBatch.Draw(Content.Load<Texture2D>("Backgrounds/MainMenu"), new Rectangle(0, 0, screenWidth, screenHeight), Color.White);
                    buttonPlay.Draw(spriteBatch);
                    buttonOptions.Draw(spriteBatch);
                    buttonCredits.Draw(spriteBatch);
                    break;

                case GameState.Options:
                    GraphicsDevice.Clear(Color.Red);
                    buttonBack.Draw(spriteBatch);
                    break;

                case GameState.Credits:
                    GraphicsDevice.Clear(Color.Black);
                    buttonBack2.Draw(spriteBatch);
                    break;

                case GameState.Playing:
                    EntityManager.Instance.DrawAllEntities(gameTime, spriteBatch);
                    break;
            }
            

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
