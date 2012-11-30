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
    public class Player : BaseCharacter
    {
        #region Fields
        private AnimationPlayer topAnimation;
        private AnimationPlayer bottomAnimation;

        private SpriteEffects flip;

        // Animations for each movment state (bottom part)
        private AnimationForCro idle;
        private AnimationForCro jump;
        private AnimationForCro run;
        private AnimationForCro dash;

        // Animations for each direction (top part)
        private AnimationForCro straight;
        private AnimationForCro down;
        private AnimationForCro downDiag;
        private AnimationForCro up;
        private AnimationForCro upDiag;
        #endregion

        #region Properties
        public AnimationPlayer TopAnimation
        {
            get { return topAnimation; }
        }

        public AnimationPlayer BottomAnimation
        {
            get { return bottomAnimation; }
        }

        public override Rectangle Bounds
        {
            get
            {
                Rectangle bounds = new Rectangle((int)Position.X - (topAnimation.Animation.FrameWidth / 2), (int)Position.Y - (topAnimation.Animation.FrameHeight / 2), topAnimation.Animation.FrameWidth, topAnimation.Animation.FrameHeight);
                return bounds;
            }
        }

        public SpriteEffects Flip
        {
            get { return flip; }
        }
        #endregion

        #region Constructors
        public Player()
        {

        }

        public Player(string name, Vector2 position, ContentManager content) : base()
        {
            this.Name = name;
            this.Position = position;
        }
        #endregion


        #region Methods
        public override void LoadContent(ContentManager content)
        {
            // Loading images for the bottom animation.
            idle = new AnimationForCro(content.Load<Texture2D>("Cro/Idle"), 0.1f, true);
            jump = new AnimationForCro(content.Load<Texture2D>("Cro/Jump"), 0.1f, false);
            run = new AnimationForCro(content.Load<Texture2D>("Cro/Run"), 0.2f, true);
            dash = new AnimationForCro(content.Load<Texture2D>("Cro/Run"), 0.1f, true);
            // Set default state to 'idle'
            bottomAnimation.PlayAnimation(idle);

            // Loading the images for the top animation.
            straight = new AnimationForCro(content.Load<Texture2D>("Cro/GunStraight"), 1.0f, true);
            down = new AnimationForCro(content.Load<Texture2D>("Cro/GunDown"), 1.0f, true);
            downDiag = new AnimationForCro(content.Load<Texture2D>("Cro/GunDownDiag"), 1.0f, true);
            up = new AnimationForCro(content.Load<Texture2D>("Cro/GunUp"), 1.0f, true);
            upDiag = new AnimationForCro(content.Load<Texture2D>("Cro/GunUpDiag"), 1.0f, true);
            topAnimation.PlayAnimation(straight);
        }

        public override void Update(GameTime gameTime)
        {
            bool isMoving = false;

            KeyboardState keystate = Keyboard.GetState();

            // If the player is moving leftward, they can switch between running, dashing and jumping.
            if (keystate.IsKeyDown(Keys.Left))
            {
                isMoving = true;
                // Because all my animations are right facing, flip them horizontally if the charager faces left.
                flip = SpriteEffects.FlipHorizontally;
                Position = new Vector2(Position.X - 4, Position.Y);
                if (keystate.IsKeyDown(Keys.LeftControl))
                {
                    if (keystate.IsKeyDown(Keys.Space))
                    {
                        bottomAnimation.PlayAnimation(jump);
                    }
                    else
                    {
                        bottomAnimation.PlayAnimation(dash);
                    }
                    if (keystate.IsKeyDown(Keys.Up))
                    {
                        topAnimation.PlayAnimation(upDiag);
                    }
                    else if (keystate.IsKeyDown(Keys.Down))
                    {
                        topAnimation.PlayAnimation(downDiag);
                    }
                    else
                    {
                        topAnimation.PlayAnimation(straight);
                    }
                    Position = new Vector2(Position.X - 2, Position.Y);
                }
                else
                {
                    if (keystate.IsKeyDown(Keys.Space))
                    {
                        bottomAnimation.PlayAnimation(jump);
                    }
                    else
                    {
                        bottomAnimation.PlayAnimation(run);
                    }
                    if (keystate.IsKeyDown(Keys.Up))
                    {
                        topAnimation.PlayAnimation(upDiag);
                    }
                    else if (keystate.IsKeyDown(Keys.Down))
                    {
                        topAnimation.PlayAnimation(downDiag);
                    }
                    else
                    {
                        topAnimation.PlayAnimation(straight);
                    }
                }
            }
            // If the player is moving rightward, they can switch between running, dashing and jumping.
            else if (keystate.IsKeyDown(Keys.Right))
            {
                isMoving = true;
                flip = SpriteEffects.None;
                Position = new Vector2(Position.X + 4, Position.Y);
                if (keystate.IsKeyDown(Keys.LeftControl))
                {
                    if (keystate.IsKeyDown(Keys.Space))
                    {
                        bottomAnimation.PlayAnimation(jump);
                    }
                    else
                    {
                        bottomAnimation.PlayAnimation(dash);
                    }
                    if (keystate.IsKeyDown(Keys.Up))
                    {
                        topAnimation.PlayAnimation(upDiag);
                    }
                    else if (keystate.IsKeyDown(Keys.Down))
                    {
                        topAnimation.PlayAnimation(downDiag);
                    }
                    else
                    {
                        topAnimation.PlayAnimation(straight);
                    }
                    Position = new Vector2(Position.X + 2, Position.Y);
                }
                else
                {
                    if (keystate.IsKeyDown(Keys.Space))
                    {
                        bottomAnimation.PlayAnimation(jump);
                    }
                    else
                    {
                        bottomAnimation.PlayAnimation(run);
                    }
                    if (keystate.IsKeyDown(Keys.Up))
                    {
                        topAnimation.PlayAnimation(upDiag);
                    }
                    else if (keystate.IsKeyDown(Keys.Down))
                    {
                        topAnimation.PlayAnimation(downDiag);
                    }
                    else
                    {
                        topAnimation.PlayAnimation(straight);
                    }
                }
            }
            // If the player isn't moving, you can alternate between jumping and idle.
            if (!isMoving)
            {
                if (keystate.IsKeyDown(Keys.Space))
                {
                    bottomAnimation.PlayAnimation(jump);
                }
                else
                {
                    bottomAnimation.PlayAnimation(idle);
                }
                if (keystate.IsKeyDown(Keys.Up))
                {
                    topAnimation.PlayAnimation(up);
                }
                else if (keystate.IsKeyDown(Keys.Down))
                {
                    if (keystate.IsKeyDown(Keys.Space))
                    {
                        topAnimation.PlayAnimation(down);
                    }
                    else
                    {
                        topAnimation.PlayAnimation(downDiag);
                    }
                }
                else
                {
                    topAnimation.PlayAnimation(straight);
                }
            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            bottomAnimation.Draw(gameTime, spriteBatch, Position, flip);
            topAnimation.Draw(gameTime, spriteBatch, Position, flip);
        }
        #endregion


    }
}
