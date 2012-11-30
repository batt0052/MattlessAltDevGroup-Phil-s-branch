// Class created by: Phil Battison
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
    class GameConstants
    {
        //Global constants


        //For Cro////////////////////////////////////////////
        //Constants used for controlling the horizontal movement
        private const float MovementAccel = 10000.0f;
        private const float MaxMoveSpeed = 1000.0f;
        private const float GroundFriction = 0.5f;
        private const float AirFriction = 0.75f;

        //Constants used for controlling the vertical movement
        private const float MaxInAirTime = 0.4f;
        private const float JumpInitialVelocity = -2750.0f;
        private const float GravityAccel = 2500.0f;
        private const float MaxFallingSpeed = 500.0f;
        private const float JumpControlForce = 0.10f;

        // Constants for his Animation Class
        private const float croFrameWidth = 158;
        ///////////////////////////////////////////////////

        //For the projectiles//////////////////////////////
        //Horizontal movement
        private const float ProjectileAccel = 12000.0f;
        private const float ProjectileMaxSpeed = 1200.0f;
        
        //Vertical movement
        private const float ProjectileInitialVelocity = -750.0f;
        private const float ProjMaxFallSpeed = 300.0f;
        ///////////////////////////////////////////////////

        //For the bombs////////////////////////////////////
        //Horizontal movement
        private const float BombSpeed = 900.0f;
        ///////////////////////////////////////////////////

        //For the pterrordactyl////////////////////////////
        //Horizontal movement
        private const float PterrorSpeed = 900.0f;

        //Vertical movement
        //TODO: A lerp will be used to control its vertical movement
        ///////////////////////////////////////////////////

        //For the Veloci-Renegade//////////////////////////
        //Horizontal movement
        private const float VRMoveAcceleration = 12000.0f;
        private const float VRMaxMoveSpeed = 1300.0f;
        //////////////////////////////////////////////////

        //For the Ankleo-Soldier//////////////////////////
        //Horizontal movement
        private const float ASMoveAcceleration = 8000.0f;
        private const float ASMaxMoveSpeed = 850.0f;
        //////////////////////////////////////////////////

        //For the Tricera-Rocket//////////////////////////
        //Horizontal movement
        private const float TRMoveSpeed = 14000.0f;

        //Vertical movement
        //TODO: A lerp will be used to control its vertical movement
        //////////////////////////////////////////////////
    }
}
