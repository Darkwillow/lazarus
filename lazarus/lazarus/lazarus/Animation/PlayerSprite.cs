using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lazarus
{
    class PlayerSprite
    {
        private Rectangle _destinationRec; //Rectangle area where I am drawing
        private Rectangle _sourceRec; //Rectangle of frame, which navigates step by step over all the picture of one animation

        private SpriteBatch _sprite;

        public PlayerSprite(Point point, Frames frame, SpriteBatch sprite)
        {
            _destinationRec = new Rectangle(point.X, point.Y, frame.WidthFrame, frame.HeightFrame); //Rectangle(DrawingPosX, DrawingPosY,WidthOfDrawingField,HeightOfDrawingField)
            _sourceRec = new Rectangle(frame.WidthFrame, 0, frame.WidthFrame, frame.HeightFrame); //Rectangle(BeginningOfFrameX,BeginningofFrameY,..,..)

            _sprite = sprite;
        }

        public Rectangle DestinationRec
        {
            get { return _destinationRec; }
            set { _destinationRec = value; }
        }

        public int DestinationRecX
        {
            set { _destinationRec.X = value; }
        }

        public int DestinationRecY
        {
            set { _destinationRec.Y = value; }
        }

        public Rectangle SourceRec
        {
            get { return _sourceRec; }
            set { _sourceRec = value; }
        }

        public int SourceRecX
        {
            set { _sourceRec.X = value; }
        }

        public int SourceRecY
        {
            set { _sourceRec.Y = value; }
        }

        public void DrawAnimation(Texture2D texture)
        {
            _sprite.Draw(texture, DestinationRec, SourceRec, Color.White);
        }
    }
}
