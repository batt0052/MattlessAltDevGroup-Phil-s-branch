// Class created by: Kieran Houstoun
// Content added by: Kenneth J. Hughes III
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
    public abstract class BaseCharacter
    {
        #region Fields

        Texture2D m_texture;
        protected Vector2 m_position;

        string m_name;
        int m_health;
        int m_damage;
        int m_speed;
        int m_jumpheight;
        public Color[] m_textureData;
        protected Color m_tintColor = Color.White;

        #endregion

        #region Properties
        public Texture2D Texture
        {
            get { return m_texture; }
            set { m_texture = value; }
        }

        public Vector2 Position
        {
            get { return m_position; }
            set { m_position = value; }
        }

        public string Name
        {
            get { return m_name; }
            set { m_name = value; }
        }

        public int Health
        {
            get { return m_health; }
            set { m_health = value; }
        }

        public int Damage
        {
            get { return m_damage; }
            set { m_damage = value; }
        }

        public int Speed
        {
            get { return m_speed; }
            set { m_speed = value; }
        }

        public int Jumpheight
        {
            get { return m_jumpheight; }
            set { m_jumpheight = value; }
        }

        public Color[] TextureData
        {
            get { return m_textureData; }
            set { m_textureData = value; }
        }
        virtual public Rectangle Bounds
        {
            get
            {
                Rectangle bounds = new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
                return bounds;
            }
        }


        #endregion

        #region Constructors
        public BaseCharacter()
        {
            
        }

        public BaseCharacter(string name, Vector2 position)
        {
            this.TextureData = m_textureData;
            this.Name = m_name;
            this.Position = m_position;
        }

        #endregion

        #region Methods
        public virtual void LoadContent(ContentManager content)
        {
            
        }

        public virtual void Update(GameTime gameTime)
        {
            //CheckCollision();
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            
        }

        static bool IntersectPixels(Rectangle animA, Color[] dataA, Rectangle animB, Color[] dataB)
        {
            // Find the bounds of the rectangle intersection
            int top = Math.Max(animA.Top, animB.Top);
            int bottom = Math.Min(animA.Bottom, animB.Bottom);
            int left = Math.Max(animA.Left, animB.Left);
            int right = Math.Min(animA.Right, animB.Right);

            // Check every point within the intersection bounds
            for (int y = top; y < bottom; y++)
            {
                for (int x = left; x < right; x++)
                {
                    // Get the color of both pixels at this point
                    Color colourA = dataA[(x - animA.Left) + (y - animA.Top) * animA.Width];
                    Color colourB = dataB[(x - animB.Left) + (y - animB.Top) * animB.Width];

                    // If both pixels are not completely transparent ...
                    if (colourA.A != 0 && colourB.A != 0)
                    {
                        // Then an intersection happened and ...
                        return true;
                    }
                }
            }
            // If no intersection was found ...
            return false;
        }

        public virtual void HandleCollision(BaseCharacter entity)
        {
            //if (this.Bounds.Intersects(entity.Bounds))
            //{
            //     entity.m_tintColor = Color.Red;
            //}
            //else
            //{
            //    entity.m_tintColor = Color.White;
            //}

            Player CroPlayer = null;
            if (this.Name == "Cro")
            {
                CroPlayer = EntityManager.m_croPlayer;
            }

            if (CroPlayer != null)
            {
                // Check to see if the bounding rectangles of both entities are intersecting with the bottom animation.
                if (this.Bounds.Intersects(entity.Bounds))
                {
                    // Creating a Spritebatch and RenderTarget2D to facilitate perpixel collision for the animation.
                    SpriteBatch spriteBatch = EntityManager.m_spriteBatch;
                    RenderTarget2D theRenderTargetBottom = null;
                    RenderTarget2D theRenderTargetTop = null;

                    theRenderTargetBottom = new RenderTarget2D(EntityManager.m_graphics, CroPlayer.BottomAnimation.Animation.FrameWidth, CroPlayer.BottomAnimation.Animation.FrameHeight);
                    theRenderTargetTop = new RenderTarget2D(EntityManager.m_graphics, CroPlayer.TopAnimation.Animation.FrameWidth, CroPlayer.TopAnimation.Animation.FrameHeight);

                    EntityManager.m_graphics.SetRenderTarget(theRenderTargetBottom);
                    EntityManager.m_graphics.SetRenderTarget(theRenderTargetTop);

                    EntityManager.m_graphics.Clear(Color.Transparent);

                    spriteBatch.Begin();
                    Rectangle source = new Rectangle(CroPlayer.BottomAnimation.FrameIndex * CroPlayer.BottomAnimation.Animation.FrameWidth, 0, CroPlayer.BottomAnimation.Animation.FrameWidth, CroPlayer.BottomAnimation.Animation.Texture.Height);
                    spriteBatch.Draw(CroPlayer.BottomAnimation.Animation.Texture, Vector2.Zero, source, Color.White, 0.0f, Vector2.Zero, 1.0f, CroPlayer.Flip, 0.0f);
                    spriteBatch.Draw(CroPlayer.TopAnimation.Animation.Texture, Vector2.Zero, source, Color.White, 0.0f, Vector2.Zero, 1.0f, CroPlayer.Flip, 0.0f);
                    spriteBatch.End();

                    EntityManager.m_graphics.SetRenderTarget(null);

                    // Take the texture data for both entities and put them into colour arrays.
                    Color[] entityData = new Color[theRenderTargetBottom.Width * theRenderTargetBottom.Height];
                    theRenderTargetBottom.GetData(entityData);
                    Color[] entityData2 = new Color[entity.Texture.Width * entity.Texture.Height];
                    entity.Texture.GetData(entityData2);

                    // Pass in the texture data and bounds of both entites in collision.
                    if (IntersectPixels(this.Bounds, entityData, entity.Bounds, entityData2) == true)
                    {
                        // Change colour to red if there is a hit.
                        entity.m_tintColor = Color.Red;
                    }
                    else
                    {
                        // Leave it as/change it back to white if there is no collision.
                        entity.m_tintColor = Color.White;
                    }
                }
            }
           
        }

        protected void CheckCollision()
        {
            for (int i = 0; i < EntityManager.Instance.EntityList.Count; i++)
            {
                if (EntityManager.Instance.EntityList[i] != this)
                {
                    HandleCollision(EntityManager.Instance.EntityList[i]);
                }
            }
        }
        #endregion
    }
}
