using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lazarus
{
    class Player
    {
        private Texture2D _rightWalkFrame;
        private Texture2D _leftWalkFrame;
        private Texture2D _standingFrame;

        private WalkingState _direction;

        Frames frames;
        PlayerSprite playerSprite;
        Timer timer;

        public Player(ContentManager content, SpriteBatch sprite, int delayTime)
        {
            _rightWalkFrame = content.Load<Texture2D>("RunningRight");
            _leftWalkFrame = content.Load<Texture2D>("RunningLeft");
            _standingFrame = content.Load<Texture2D>("StandingFull");

            frames = new Frames(_rightWalkFrame.Width, _rightWalkFrame.Height);
            timer = new Timer(delayTime);

            Point startPosition; //help value to handle start position
            startPosition.X = 300;
            startPosition.Y = 300;
            playerSprite = new PlayerSprite(startPosition, frames, sprite);
        }

        public WalkingState Direction
        {
            get { return _direction; }
            set { _direction = value; }
        }

        /*! This function compares the current direction with the given direction, to recognize that
         *  the player changes the direction of walking.
         *  param[in] expectedState includes the expected direction of walking, if the player change it.*/
        public bool compareDirection(WalkingState expectedState)
        {
            if (Direction != expectedState)
            {
                Direction = expectedState;
                return false;
            }
            return true;
        }

        /*! Updated everytime the player state.
         *  param[in] gameTime is the current Time from the current Update function
         *  param[in] walking is the current walking direction from the user input.*/
        public void Update(GameTime gameTime, WalkingState walking)
        {
            //Is the Frame at the end?
            frames.compareFrameState();

            //Addition of time with gametime
            timer.additionElapsedTime((int)gameTime.ElapsedGameTime.TotalMilliseconds);

            //It is time to play the next Frame?
            if (timer.compareTime())
            {
                frames.FrameState = frames.FrameState + 1;
            }

            //Is the direction changed?
            if (!compareDirection(walking))
            {
                frames.FrameState = 0;
            }
        }

        //Right and Left is the only direction implemntation
        private void moveRight()
        {
            playerSprite.DestinationRecX = MovingHandler.moveRight(playerSprite.DestinationRec.X);
        }

        private void moveLeft()
        {
            playerSprite.DestinationRecX = MovingHandler.moveLeft(playerSprite.DestinationRec.X);
        }

        /*! This function handels the drawing on the Screen.*/
        public void drawCharacterOnScreen()
        {
            switch (Direction)
            {
                case WalkingState.LeftWalking:
                    moveLeft();
                    playerSprite.SourceRecX = frames.WidthFrame * frames.FrameState; //Handel the next Frame
                    playerSprite.DrawAnimation(_leftWalkFrame);
                    break;
                case WalkingState.RightWalking:
                    moveRight();
                    playerSprite.SourceRecX = frames.WidthFrame * frames.FrameState;
                    playerSprite.DrawAnimation(_rightWalkFrame);
                    break;
                case WalkingState.NotWalking:
                    playerSprite.SourceRecX = 0;
                    playerSprite.DrawAnimation(_standingFrame);
                    break;
                default:
                    break;
            }
        }
    }
}

enum WalkingState
{
    LeftWalking,
    RightWalking,
    NotWalking
};

