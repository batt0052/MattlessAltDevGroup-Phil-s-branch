// Class created by: Kenneth J. Hughes III
// Created on November 22nd, 2012.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// This is a debug class. It will draw a box around the character's 'hit box', making it visible.
namespace SuperCaveman
{
    public static class CollisionRenderManager
    {
        static Texture2D m_Texture;
        //public static List<Rectangle> RectanglesToDraw = new List<Rectangle>();
        public static void OneTimeINIT(Texture2D theTxture)
        {
            m_Texture = theTxture;
        }
        public static void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

            for (int counter = 0; counter < EntityManager.Instance.EntityList.Count; counter++)
            {
                    Rectangle RectangleToDraw = EntityManager.Instance.EntityList[counter].Bounds;

                    spriteBatch.Draw(m_Texture, new Vector2(RectangleToDraw.X, RectangleToDraw.Y), new Rectangle(0, 0, RectangleToDraw.Width, 1), Color.Red);
                    spriteBatch.Draw(m_Texture, new Vector2(RectangleToDraw.X, RectangleToDraw.Y + RectangleToDraw.Height), new Rectangle(0, 0, RectangleToDraw.Width, 1), Color.Red);
                    spriteBatch.Draw(m_Texture, new Vector2(RectangleToDraw.X, RectangleToDraw.Y), new Rectangle(0, 0, 1, RectangleToDraw.Height), Color.Red);
                    spriteBatch.Draw(m_Texture, new Vector2(RectangleToDraw.X + RectangleToDraw.Width, RectangleToDraw.Y), new Rectangle(0, 0, 1, RectangleToDraw.Height), Color.Red);
            }
        }
        

    }
}
