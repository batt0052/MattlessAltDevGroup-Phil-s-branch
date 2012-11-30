// Class added by: Kenneth J. Hughes III
// Created on November 24th, 2012.

using System;
using Microsoft.Xna.Framework.Graphics;

namespace SuperCaveman
{
    public class AnimationForCro : Animation
    {
        #region Fields
        int m_croFrameWidth = 158;
        Texture2D m_texture;
        float m_frameTime;
        bool m_isLooping;
        #endregion

        #region Properties
        public override int FrameCount
        {
            get { return Texture.Width / FrameWidth; }
        }

        public override int FrameWidth
        {
            get
            { return m_croFrameWidth; }
        }

        public override Texture2D Texture
        {
            get { return m_texture; }
        }

        public override float FrameTime
        {
            get { return m_frameTime; }
        }

        public override bool IsLooping
        {
            get { return m_isLooping; }
        }
        #endregion

        #region Constructors
        public AnimationForCro(Texture2D texture, float frameTime, bool isLooping)
            : base()
        {
            this.m_texture = texture;
            this.m_frameTime = frameTime;
            this.m_isLooping = isLooping;
        }
        #endregion
    }
}
