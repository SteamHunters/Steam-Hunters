﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectHackAndSlashRPG
{
    public class StartScreen
    {
        private Game1 game;
        private KeyboardState lastState;

        public StartScreen(Game1 game)
        {
            this.game = game;
            TextureManager.LoadTextures(game);
        }
        public void Update()
        {
            KeyboardState keyboardState = Keyboard.GetState();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Start == ButtonState.Pressed)
            {
                game.StartGame();
            }
            lastState = keyboardState;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(TextureManager.startBackground, new Vector2(0f, 0f), Color.White);
            spriteBatch.End();
        }
    }
}
