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
    class TriceraEnemy : BaseEnemy
    {
        #region Fields
        public AnimationPlayer tricera;

        private SpriteEffects flip;

        // Animations for the raptor character
        private Animation fly;
        #endregion

        #region Properties
        public AnimationPlayer Tricera
        {
            get { return tricera; }
        }

        public override Rectangle Bounds
        {
            get
            {
                Rectangle bounds = new Rectangle((int)Position.X - (tricera.Animation.FrameWidth / 2), (int)Position.Y - (tricera.Animation.FrameWidth / 2), tricera.Animation.FrameWidth, tricera.Animation.FrameHeight);
                return bounds;
            }
        }

        public SpriteEffects Flip
        {
            get { return flip; }
        }
        #endregion

        #region Constructors
        public TriceraEnemy()
        {
            
        }

        public TriceraEnemy(string name, Vector2 position, ContentManager content)
            : base()
        {
            this.Name = name;
            this.Position = position;
        }
        #endregion

        #region Methods
        public override void LoadContent(ContentManager content)
        {
            fly = new Animation(content.Load<Texture2D>("EnemySpritesheets/Tricera"), 0.1f, true);
            tricera.PlayAnimation(fly);
        }

        public override void Update(GameTime gameTime)
        {
            // TODO: Add enemy AI here.

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            tricera.Draw(gameTime, spriteBatch, Position, flip);
        }
        #endregion
    }
}

