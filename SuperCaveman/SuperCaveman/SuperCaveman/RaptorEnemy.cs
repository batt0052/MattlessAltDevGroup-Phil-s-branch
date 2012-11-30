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
    class RaptorEnemy : BaseEnemy
    {
        #region Fields
        public AnimationPlayer raptor;

        private SpriteEffects flip;

        Vector2 m_origin;
        Vector2 m_destination;
        Vector2 m_currentPosition;

        TimeSpan timeToMove = TimeSpan.FromSeconds(0);
        TimeSpan timeSpent = TimeSpan.Zero;

        

        // Animations for the raptor character
        private Animation idle;
        private Animation run;
        #endregion

        #region Properties
        public AnimationPlayer Raptor
        {
            get { return raptor; }
        }

        public override Rectangle Bounds
        {
            get
            {
                Rectangle bounds = new Rectangle((int)Position.X - (raptor.Animation.FrameWidth / 2), (int)Position.Y - (raptor.Animation.FrameWidth / 2), raptor.Animation.FrameWidth, raptor.Animation.FrameHeight);
                return bounds;
            }
        }

        public SpriteEffects Flip
        {
            get { return flip; }
        }
        #endregion

        #region Constructors
        public RaptorEnemy()
        {
            
        }

        public RaptorEnemy(string name, Vector2 position, ContentManager content)
            : base()
        {
            this.Name = name;
            this.Position = position;
        }
        #endregion

        #region Methods
        public override void LoadContent(ContentManager content)
        {
            idle = new Animation(content.Load<Texture2D>("EnemySpritesheets/RaptorIdle"), 0.1f, true);
            run = new Animation(content.Load<Texture2D>("EnemySpritesheets/RaptorRun"), 0.1f, true);
            raptor.PlayAnimation(idle);
        }

        public override void Update(GameTime gameTime)
        {
            // TODO: Add enemy AI here.
            if (m_hasTarget == true)
            {
                //Vector2 m_origin;
                //Vector2 m_destination;
                //Vector2 m_currentPosition;

                //Add bullet/firing code here

                
            }
            else
            {
                if (timeSpent < timeToMove)
                {
                    Vector2 m_origin = Position;
                    Vector2 m_destination = new Vector2(50, 0);
                    //Vector2 m_currentPosition;
                    timeSpent += gameTime.ElapsedGameTime;
                    if (timeSpent >= timeToMove)
                    {
                        timeSpent = timeToMove;
                    }
                    float lerpAmount = (float)timeSpent.Ticks / timeToMove.Ticks;
                    m_currentPosition = Vector2.Lerp(m_origin, m_destination, lerpAmount);
                }
                else
                {
                    timeSpent = TimeSpan.Zero;
                    Vector2 tempOrigin = m_origin;
                    m_origin = m_destination;
                    m_destination = tempOrigin;
                    m_currentPosition = tempOrigin;
                }
            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            raptor.Draw(gameTime, spriteBatch, Position, flip);
        }
        #endregion
    }
}
