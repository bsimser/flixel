﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;

namespace org.flixel
{
    public class FlxFactory : Microsoft.Xna.Framework.Game
    {
        //primary display buffer constants
#if !WINDOWS_PHONE
        private int resX = 1280; //DO NOT CHANGE THESE VALUES!!
        private int resY = 720;  //your game should only be concerned with the
        //resolution parameters used when you call
        //super() in your Game class.
#else
        private int resX = 480; //DO NOT CHANGE THESE VALUES!!
        private int resY = 800;  //your game should only be concerned with the
                                 //resolution parameters used when you call
                                 //super() in your FlxGame class.
#endif

#if XBOX360
        private bool _fullScreen = true;
#else
        private bool _fullScreen = false;
#endif
        //graphics management
        private GraphicsDeviceManager _graphics;
        //other variables
        private FlxGame _flixelgame;

        //nothing much to see here, typical XNA initialization code
        public FlxFactory()
        {
            //set up the graphics device and the content manager
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            if (_fullScreen)
            {
                resX = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
                resY = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
                /* TODO not implemented in MonoGame
                if (GraphicsAdapter.DefaultAdapter.IsWideScreen)
                {
                    //if user has it set to widescreen, let's make sure this
                    //is ACTUALLY a widescreen resolution.
                    if (((resX / 16) * 9) != resY)
                    {
                        resX = (resY / 9) * 16;
                    }
                }
                 */
            }

            //we don't need no new-fangled pixel processing
            //in our retro engine!
            _graphics.PreferMultiSampling = false;
            //set preferred screen resolution. This is NOT
            //the same thing as the game's actual resolution.
            _graphics.PreferredBackBufferWidth = resX;
            _graphics.PreferredBackBufferHeight = resY;
            //make sure we're actually running fullscreen if
            //fullscreen preference is set.
            if (_fullScreen && _graphics.IsFullScreen == false)
            {
                _graphics.ToggleFullScreen();
            }
            _graphics.ApplyChanges();

            FlxG.Game = this;
#if !WINDOWS_PHONE
            Components.Add(new GamerServicesComponent(this));
#endif
        }

        protected override void Initialize()
        {
            //load up the master class, and away we go!
            _flixelgame = new FlxGame(this);
            Components.Add(_flixelgame);
            base.Initialize();
        }

        public void super(int GameSizeX, int GameSizeY,
            FlxState InitialState, Color BGColor,
            bool showFlixelLogo, Color logoColor)
        {
            _flixelgame = new FlxGame(this);
            _flixelgame.initGame(GameSizeX, GameSizeY, InitialState, BGColor, showFlixelLogo, logoColor);
        }
    }
}