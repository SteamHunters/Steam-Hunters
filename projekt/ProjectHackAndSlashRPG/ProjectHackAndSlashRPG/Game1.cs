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

namespace ProjectHackAndSlashRPG
{
    enum Screen
    {
        StartScreen,
        GamePlayScreen,
        GameOverScreen
    }
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        StartScreen startScreen;
        GamePlayScreen gamePlayScreen;
        GameOverScreen gameOverScreen;

        Screen currentScreen;

        int height;
        int width;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            
            //window
            width = graphics.PreferredBackBufferWidth = 1000;
            height = graphics.PreferredBackBufferHeight = 1000;

            graphics.IsFullScreen = false;
            this.Window.Title = "HackAndSlashRPG";

            graphics.ApplyChanges();
            
            Content.RootDirectory = "Content";


        }
        protected override void Initialize()
        {
            base.Initialize();
            IsMouseVisible = true;
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            startScreen = new StartScreen(this);
            currentScreen = Screen.StartScreen;

            base.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed|| Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            switch (currentScreen)
            {
                case Screen.StartScreen:
                    if (startScreen != null)
                        startScreen.Update();
                    break;
                case Screen.GamePlayScreen:
                    if (gamePlayScreen != null)
                        gamePlayScreen.Update(gameTime);
                    break;
                case Screen.GameOverScreen:
                    if (gameOverScreen != null)
                        gameOverScreen.Update();
                    break;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            switch (currentScreen)
            {
                case Screen.StartScreen:
                    if (startScreen != null)
                        startScreen.Draw(spriteBatch);
                    break;
                case Screen.GamePlayScreen:
                    if (gamePlayScreen != null)
                        gamePlayScreen.Draw(spriteBatch);
                    break;
                case Screen.GameOverScreen:
                    if (gameOverScreen != null)
                        gameOverScreen.Draw(spriteBatch);
                    break;
            }

            base.Draw(gameTime);
        }

        public void StartGame()
        {
            gamePlayScreen = new GamePlayScreen(this);
            currentScreen = Screen.GamePlayScreen;

            startScreen = null;
            gameOverScreen = null;
        }

        public void EndGame()
        {
            gameOverScreen = new GameOverScreen(this);
            currentScreen = Screen.GameOverScreen;

            gamePlayScreen = null;
        }
    }
}
