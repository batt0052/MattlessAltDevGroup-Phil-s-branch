// Class added by: Kenneth J. Hughes III
// Created on November 22nd, 2012.

using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace SuperCaveman
{
    public struct AnimationPlayer
    {
        public Animation Animation
        {
            get { return animation; }
        }
        Animation animation;

        public int FrameIndex
        {
            get { return frameIndex; }
        }
        int frameIndex;

        private float time;


        public Vector2 Origin
        {
            get { return new Vector2(Animation.FrameWidth/2, Animation.FrameHeight/2); }
        }

        public void PlayAnimation(Animation animation)
        {
            // If this animation is already running, do not restart it.
            if (Animation == animation)
                return;

            // Start the new animation.
            this.animation = animation;
            this.frameIndex = 0;
            this.time = 0.0f;
        }

        // Advances the time position and draws the current frame of the animation.
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, Vector2 position, SpriteEffects spriteEffects)
        {
            if (Animation == null)
                throw new NotSupportedException("No animation is currently playing.");

            // Process passing time.
            time += (float)gameTime.ElapsedGameTime.TotalSeconds;
            while (time > Animation.FrameTime)
            {
                time -= Animation.FrameTime;

                // Advance the frame index; looping or clamping as appropriate.
                if (Animation.IsLooping)
                {
                    frameIndex = (frameIndex + 1) % Animation.FrameCount;
                }
                else
                {
                    frameIndex = Math.Min(frameIndex + 1, Animation.FrameCount - 1);
                }
            }

            // Calculate the source rectangle of the current frame.
            Rectangle source = new Rectangle(FrameIndex * Animation.FrameWidth, 0, Animation.FrameWidth, Animation.Texture.Height);

            // Draw the current frame.
            spriteBatch.Draw(Animation.Texture, position, source, Color.White, 0.0f, Origin, 1.0f, spriteEffects, 0.0f);
            
        }
    }
}
