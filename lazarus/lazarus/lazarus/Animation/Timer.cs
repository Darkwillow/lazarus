using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lazarus
{
    /*! The Timer Class includes delay and elapsed time for object which have to updated in a specific interval*/
    class Timer
    {
        private int _delay; //Delay Time is a fixed value interval which show when the object have to updated
        private int _elapsed; //Elapsed Time is a value which show the current time

        public Timer(int delay)
        {
            Delay = delay;
        }

        public int Elapsed
        {
            get { return _elapsed; }
            set { _elapsed = value; }
        }

        public int Delay
        {
            get { return _delay; }
            set { _delay = value; }
        }

        /*! The function add up the elapsed time which have to set out of this class
         * param[in] elapsedTime is the past time from outside*/
        public void additionElapsedTime(int elapsedTime)
        {
            _elapsed = _elapsed + elapsedTime;
        }

        /*! CompareTime() compares Elapsed and Delay Time to check whether the time has expired*/
        public bool compareTime()
        {
            if (Elapsed >= Delay)
            {
                Elapsed = 0;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
