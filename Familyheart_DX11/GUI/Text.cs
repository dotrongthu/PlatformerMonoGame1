using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Familyheart_DX11.GUI
{

    public class Text
    {
        public string text;
        public SpriteFont font;
        public Vector2 pos;
        public Color normalColor;
        public Color changedColor;
        private float size;

        public float Size
        {
            get { return size; }
            set { size = value; }
        }

        public Text(string _text, SpriteFont _font, Vector2 _pos, Color _normalColor, Color _changedColor)
        {
            text = _text;
            font = _font;
            pos = _pos;
            normalColor = _normalColor;
            changedColor = _changedColor;
   
            size = 1f;
        }

    }
}
