﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace ProjectHackAndSlashRPG
{
    abstract class GameObject
    {
        public Texture2D tex;
        public Rectangle hitBox;
        public float angle, rotation;
        public Vector2 center, origin, pos;

        public GameObject(Texture2D tex, Vector2 pos)
        {
            this.tex = tex;
            this.pos = pos;
            this.hitBox = new Rectangle((int)pos.X, (int)pos.Y, tex.Width, tex.Height);
            center = new Vector2(pos.X + tex.Width / 2, pos.Y + tex.Height / 2);
        }
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);

        public virtual bool IsCollidingObject(GameObject e)
        {
            return hitBox.Intersects(e.hitBox);
        }
        //public virtual bool IsCollidingEntity(Entity e)
        //{
        //    return hitBox.Intersects(e.hitBox);
        //}
    }
}

