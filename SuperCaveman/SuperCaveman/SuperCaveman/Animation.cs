// Class added by: Kenneth J. Hughes III
// Created on November 22nd, 2012.

using System;
using Microsoft.Xna.Framework.Graphics;

namespace SuperCaveman
{
        public class Animation
        {
            #region Fields
            Texture2D m_texture;
            float m_frameTime;
            bool m_isLooping;

            #endregion

            #region Properties
            public virtual Texture2D Texture
            {
                get { return m_texture; }
            }

            public virtual float FrameTime
            {
                get { return m_frameTime; }
            }

            public virtual bool IsLooping
            {
                get { return m_isLooping; }
            }

            public virtual int FrameCount
            {
                get { return Texture.Width / FrameWidth; }
            }

            public virtual int FrameWidth
            {
                get
                { return Texture.Height; }
            }

            public int FrameHeight
            {
                get { return Texture.Height; }
            }
            #endregion

            #region Constructors
            public Animation()
            {
                
            }

            public Animation(Texture2D texture, float frameTime, bool isLooping)
            {
                this.m_texture = texture;
                this.m_frameTime = frameTime;
                this.m_isLooping = isLooping;
            }
            #endregion
        }
}
