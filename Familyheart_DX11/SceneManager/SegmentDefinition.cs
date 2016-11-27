using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Familyheart_DX11.SceneManager
{
    public class SegmentDefinition
    {
        public string name;
        private Rectangle drawRect;
        private SegmentFlag flag;
        private int srcIndex;
        public string tag;

        public int SourceMapIndex
        {
            get { return srcIndex; }
            set { srcIndex = value; }
        }

        public Rectangle DrawRectangle
        {
            get { return drawRect; }
            set { drawRect = value; }
        }

        public SegmentFlag Flag
        {
            get { return flag; }
            set { flag = value; }
        }

        public SegmentDefinition(string _name, Rectangle _drawRect, SegmentFlag _flag, int _srcIndex, string _tag)
        {
            name = _name;
            drawRect = _drawRect;
            flag = (SegmentFlag)_flag;
            srcIndex = _srcIndex;
            tag = _tag;
        }
    }
}
