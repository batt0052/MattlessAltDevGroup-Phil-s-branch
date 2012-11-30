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
    class PterEnemy : BaseEnemy
    {
        #region Fields
        public AnimationPlayer pter;
        private SpriteEffects flip;

        // Animations for the raptor character
        private Animation fly;
        private Animation idle;
        #endregion

        #region Properties
        public AnimationPlayer Pter
        {
            get { return pter; }
        }

        public override Rectangle Bounds
        {
            get
            {
                Rectangle bounds = new Rectangle((int)Position.X - (pter.Animation.FrameWidth / 2), (int)Position.Y - (pter.Animation.FrameWidth / 2), pter.Animation.FrameWidth, pter.Animation.FrameHeight);
                return bounds;
            }
        }

        public SpriteEffects Flip
        {
            get { return flip; }
        }
        #endregion

        #region Constructors
        public PterEnemy()
        {
            
        }

        public PterEnemy(string name, Vector2 position, ContentManager content)
            : base()
        {
            this.Name = name;
            this.Position = position;
        }
        #endregion

        #region Methods
        public override void LoadContent(ContentManager content)
        {
            fly = new Animation(content.Load<Texture2D>("EnemySpritesheets/PterFly"), 0.2f, true);
            idle = new Animation(content.Load<Texture2D>("EnemySpritesheets/PterIdle"), 0.1f, true);
            pter.PlayAnimation(fly);
        }

        public override void Update(GameTime gameTime)
        {
            // TODO: Add enemy AI here.

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            pter.Draw(gameTime, spriteBatch, Position, flip);
        }
        #endregion
    }
}
