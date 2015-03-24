using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectHackAndSlashRPG
{
    public static class TextureManager
    {
        public static Texture2D testTexture { get; private set; }
        public static Texture2D startBackground { get; private set; }
        public static Texture2D map { get; private set; }
        public static SpriteFont font { get; private set; }



        public static void LoadTextures(Game1 game)
        {
            testTexture = game.Content.Load<Texture2D>("one frame wizard");
            startBackground = game.Content.Load<Texture2D>("StartScreen AlphaPix");
            map = game.Content.Load<Texture2D>("map");
            font = game.Content.Load<SpriteFont>("font");

            
        }
    }
}
