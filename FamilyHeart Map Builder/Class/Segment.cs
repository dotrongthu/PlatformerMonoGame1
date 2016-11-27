using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace FamilyHeart_Map_Builder.Class
{
    class Segment
    {
        private string name;
        private int sourceIndex;
        private Rectangle srcIndex;
        private SegmentFlag flag;

        public Segment(string _name, int _sourceIndex, Rectangle _srcIndex, SegmentFlag _flag)
        {
            name = _name;
            sourceIndex = _sourceIndex;
            srcIndex = _srcIndex;
            flag = _flag;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int SourceIndex
        {
            get { return sourceIndex; }
            set { sourceIndex = value; }
        }

        public Rectangle SrcIndex
        {
            get { return srcIndex; }
            set { srcIndex = value; }
        }
    }
}
