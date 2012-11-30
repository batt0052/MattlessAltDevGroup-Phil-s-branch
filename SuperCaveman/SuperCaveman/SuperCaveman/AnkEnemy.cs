// A Class by: Kenneth J. Hughes III
// Created on November 22nd, 2012.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace SuperCaveman
{
    class AnkEnemy : BaseEnemy
    {
        #region Fields
        public AnimationPlayer ank;

        private SpriteEffects flip;

        // Animations for the raptor character
        private Animation walk;
        private Animation idle;
        #endregion

        #region Properties
        public AnimationPlayer Ank
        {
            get { return ank; }
        }

        public override Rectangle Bounds
        {
            get
            {
                Rectangle bounds = new Rectangle((int)Position.X - (ank.Animation.FrameWidth / 2), (int)Position.Y - (ank.Animation.FrameWidth / 2), ank.Animation.FrameWidth, ank.Animation.FrameHeight);
                return bounds;
            }
        }

        public SpriteEffects Flip
        {
            get { return flip; }
        }
        #endregion

        #region Constructors
        public AnkEnemy()
        {
            
        }

        public AnkEnemy(string name, Vector2 position, ContentManager content)
            : base()
        {
            this.Name = name;
            this.Position = position;
        }
        #endregion

        #region Methods
        public override void LoadContent(ContentManager content)
        {
            walk = new Animation(content.Load<Texture2D>("EnemySpritesheets/AnkWalk"), 0.1f, true);
            idle = new Animation(content.Load<Texture2D>("EnemySpritesheets/AnkIdle"), 0.1f, true);
            ank.PlayAnimation(idle);
        }

        public override void Update(GameTime gameTime)
        {
            // TODO: Add enemy AI here.

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            ank.Draw(gameTime, spriteBatch, Position, flip);
        }
        #endregion
    }
}

