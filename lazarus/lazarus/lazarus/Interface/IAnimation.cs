using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lazarus
{
    interface IAnimation
    {
        Rectangle DestinationRec { get; set; }
        Rectangle SourceRec { get; set; }
        int DestinationRecX { set; }
        int DestinationRecY { set; }
        int SourceRecX { set; }
        int SourceRecY { set; }
        void DrawAnimation(Texture2D texutre);
    }
}
