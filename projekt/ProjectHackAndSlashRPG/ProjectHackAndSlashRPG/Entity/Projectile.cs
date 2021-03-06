﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectHackAndSlashRPG
{
    class Projectile : Entity
    {
        private Vector2 direction;
        private float speed = 1f;
        int projectileLife;
        bool stepRemove;
        public bool StepRemove
        {
            get { return stepRemove; }
        }

        public Projectile(Vector2 pos, Texture2D tex, Vector2 movement, float angle, Point frameSize, Point sheetSize)
            : base(pos, tex, frameSize, sheetSize)
        {
            this.pos = pos;
            origin = new Vector2(tex.Width / 2, tex.Height / 2);
            direction = movement;

            if (movement != Vector2.Zero)
                direction.Normalize();

            this.angle = angle;
        }

        public override void Update(GameTime gameTime)
        {
            pos += direction * speed * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            hitBox = new Rectangle((int)pos.X, (int)pos.Y, tex.Width, tex.Height);
            projectileLife++;

            if (projectileLife == 75)
            {
                stepRemove = true;
            }

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tex, pos,  hitBox, Color.Blue);

            spriteBatch.Draw(tex, new Rectangle((int)pos.X, (int)pos.Y, tex.Width, tex.Height), null, Color.White, angle, origin, SpriteEffects.None, 0);
        }
    }
}
