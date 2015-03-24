using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectHackAndSlashRPG
{
    class Entity : GameObject
    {
        protected SpriteEffects EntityFx = 0;

        public Vector2 Center
        {
            get { return center; }
        }
        //Animation
        public Point frameSize;
        public Point currentFrame = new Point(0, 0);
        public Point sheetSize;

        protected int timerSinceLastFrame = 0;
        protected int milliSecondsPerFrame = 30;

        protected int size = 50;
        public Entity(Vector2 pos, Texture2D tex, Point frameSize, Point sheetSize)
            :base(tex,pos)
        {
            this.pos = pos;
            this.tex = tex;
            this.frameSize = frameSize;
            this.sheetSize = sheetSize;
            center = new Vector2(pos.X + frameSize.X / 2, pos.Y + frameSize.Y / 2);
            origin = new Vector2(frameSize.X / 2, frameSize.Y / 2);
        }

        public override void Update(GameTime gameTime)
        {
            hitBox = new Rectangle((int)pos.X, (int)pos.Y, frameSize.X, frameSize.Y);

            center = new Vector2(pos.X + frameSize.X / 2, pos.Y + frameSize.Y / 2);

            //Animation loop
            timerSinceLastFrame += (int)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (timerSinceLastFrame > milliSecondsPerFrame)
            {
                timerSinceLastFrame -= milliSecondsPerFrame;
                ++currentFrame.X;
                if (currentFrame.X >= sheetSize.X)
                {
                    currentFrame.X = 0;
                    ++currentFrame.Y;
                    if (currentFrame.Y >= sheetSize.Y)
                        currentFrame.Y = 0;
                }
            }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tex, pos, new Rectangle(currentFrame.X * frameSize.X, currentFrame.Y * frameSize.Y, frameSize.X, frameSize.Y), Color.White, 0, origin, 1, EntityFx, 1);
        }
    }
}
