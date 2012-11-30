// Class created by: Kieran Houstoun
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
    class BaseEnemy : BaseCharacter
    {
        Vector2 targetPosition;

        Player targetPlayer;

        protected bool m_hasTarget = false;

        public Vector2 TargetPosition
        {
            get
            {
                targetPosition = targetPlayer.Position;
                return targetPosition;
            }
            set { targetPosition = value; }
        }

        public Player TargetPlayer
        {
            get
            {
                return targetPlayer;
            }
            set
            {
                targetPlayer = value;
            }
        }

        #region Methods
        public override void LoadContent(ContentManager content)
        {

        }

        public override void Update(GameTime gameTime)
        {

        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

        }

        public void trackPlayer()
        {
            Vector2 distance = new Vector2(TargetPosition.X - Position.X, TargetPosition.Y - Position.Y);

            if(distance.Length() < 500)
            {
                m_hasTarget = true;
            }
        }
        #endregion

    }
}
