using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lazarus
{
    class Frames
    {
        private int _widthOneFrame;
        private int _heightOneFrame;
        private int _totalFrameRate;
        private int _frameState;

        public Frames(int totalFrameWidth, int oneFrameHeight)
        {
            _totalFrameRate = 4; //total number of frames
            _heightOneFrame = oneFrameHeight;
            calcOneFrame(totalFrameWidth);
            _frameState = 0;
        }

        /*! The function calculated one Frame from the total Width of Frame
         * param[in] totalWidthF is the total width of a Frame*/
        private void calcOneFrame(int totalWidthF)
        {
            _widthOneFrame = totalWidthF / _totalFrameRate;
        }

        public int WidthFrame
        {
            get { return _widthOneFrame; }
        }

        public int HeightFrame
        {
            get { return _heightOneFrame; }
        }

        /*! FrameState includes the current State of the next Frame, which have to use for the source
         *  rectangle. It is important for the changing Frame-Events to make a picture walk.
         *  param[out] _frameState includes the State of Frame.*/
        public int FrameState
        {
            get { return _frameState; }
            set { _frameState = value; }
        }

        /*! This function compare the frame state with the total frame rate. If the frame is at the end of the frame state
         *  have to set to the beginning (0) of the picture.*/
        public void compareFrameState()
        {
            if (FrameState >= _totalFrameRate)
            {
                FrameState = 0;
            }
        }
    }
}
