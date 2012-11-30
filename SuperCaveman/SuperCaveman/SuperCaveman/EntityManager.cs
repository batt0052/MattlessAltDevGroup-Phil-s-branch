// Class created by: Kenneth J. Hughes III
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
    public class EntityManager
    {
        #region Fields
        List<BaseCharacter> m_entityList;
        static EntityManager m_instance;
        public static GraphicsDevice m_graphics;

        public static SpriteBatch m_spriteBatch;
        public static Player m_croPlayer;
        #endregion

        #region Properties
        public static EntityManager Instance
        {
            get
            {
                if (m_instance == null)
                {
                    m_instance = new EntityManager();
                }
                return m_instance;
            }
        }

        public List<BaseCharacter> EntityList
        {
            get { return m_entityList; }
            set { m_entityList = value; }
        }

        public Player CroPlayer
        {
            get { return m_croPlayer; }
            set { m_croPlayer = value; }
        }
        #endregion

        #region Constructors
        public EntityManager()
        {
            m_entityList = new List<BaseCharacter>();
        }

        public EntityManager(int maxEntities)
        {
            m_entityList = new List<BaseCharacter>(maxEntities);
        }
        #endregion

        #region Methods
        // Adds an Entity to the Entity List
        public void AddEntity(BaseCharacter entity)
        {
            if (entity != null)
            {
                m_entityList.Add(entity);
            }
        }
        // Removes an Entity from the Entity List
        public void RemoveEntity(BaseCharacter entity)
        {
            if (entity != null)
            {
                m_entityList.Remove(entity);
            }
        }
        // Returns an entity by name.
        // Loops through the Entity List, and returns null if none with that name exist.
        public BaseCharacter GetEntity(string name)
        {
            for (int i = 0; i < m_entityList.Count; i++)
            {
                if (m_entityList[i] != null && m_entityList[i].Name.Equals(name))
                {
                    return m_entityList[i];
                }
            }
            return null;
        }

        // Updates all entities in the Entity List
        public void UpdateAllEntities(GameTime gameTime)
        {
            for (int i = 0; i < m_entityList.Count; i++)
            {
                ((BaseCharacter)m_entityList[i]).Update(gameTime);
            }
        }

        // Draws all entities in the Entity List
        public void DrawAllEntities(GameTime gameTime, SpriteBatch spriteBatch)
        {
            for (int i = 0; i < m_entityList.Count; i++)
            {
                ((BaseCharacter)m_entityList[i]).Draw(gameTime, spriteBatch);
            }
        }

        // Load content for all entities in the Entity List
        public void LoadContentForAllEntities(ContentManager content)
        {
            for (int i = 0; i < m_entityList.Count; i++)
            {
                ((BaseCharacter)m_entityList[i]).LoadContent(content);
            }
        }
        #endregion
    }
}
