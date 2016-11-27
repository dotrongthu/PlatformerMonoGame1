using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Familyheart_DX11.Graphics;

namespace Familyheart_DX11
{

    /// <summary>
    /// A gameObject is an object in a game which contains:
    /// 
    /// </summary>
    public class GameObject
    {
        private Vector2 position;
        private float rotation;
        private Vector2 scale;
        private Rectangle drawArea;

        private Vector2 origin;
        public string name;

        public float width, height;
        private List<Texture2D> texture;

        public string tag;
        public int srcIndex;

        private SheetAnimation sheetAni;

        GameobjectFlag flag;


        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public float Rotation
        {
            get { return rotation; }
            set { rotation = value; }
        }

        public Vector2 Scale
        {
            get { return scale; }
            set { scale = value; }
        }

        public Rectangle DrawArea
        {
            get { return drawArea; }
            set { drawArea = value; }
        }

        public Vector2 Origin
        {
            get { return origin; }
            set { origin = value; }
        }


        public List<Texture2D> Texture { get { return texture; } set { texture = value; } }


        /// <summary>
        /// Intilize a GameObject
        /// <para>
        /// Why the srcIndex exists?
        /// The reason exists is for a tile map. If i load a ton of tex into it, that will take a lot of memory
        /// Instead, i will have a list of map tile in the scene class. That's easier
        /// However some neednt, so the gameobject still have a texture element
        /// </para>
        /// </summary>
        /// <param name="_name"></param>
        /// <param name="_srcIndex"></param>
        /// <param name="_drawRect"></param>
        /// <param name="_flag"></param>
        /// <param name="_tag"></param>

        public GameObject(string _name, int _srcIndex, Rectangle _drawRect, GameobjectFlag _flag, string _tag)
        {
            name = _name;
            srcIndex = _srcIndex;
            drawArea = _drawRect;
            flag = _flag;
            tag = _tag;
        }

        public GameObject(Vector2 position, float rotation, Vector2 scale, Texture2D tex)
        {
            this.position = position;
            this.rotation = rotation;
            this.scale = scale;
            this.texture.Add(tex);
            this.width = tex.Width;
            this.height = tex.Height;
            drawArea = new Rectangle(0, 0, tex.Width, tex.Height);
            origin = new Vector2(width/2,height/2);
        }

        public GameObject(Vector2 position, float rotation, Vector2 scale, List<Texture2D> tex)
        {
            this.position = position;
            this.rotation = rotation;
            this.scale = scale;
            this.texture = tex;
            this.width = tex[0].Width;
            this.height = tex[0].Height;
            drawArea = new Rectangle(0, 0, tex[0].Width, tex[0].Height);
            origin = new Vector2(width / 2, height / 2);
        }

        public GameObject(Vector2 position, float rotation, Vector2 scale)
        {
            this.position = position;
            this.rotation = rotation;
            this.scale = scale;
            this.texture = null;
            drawArea = new Rectangle();
            origin = new Vector2(width / 2, height / 2);
        }


        /// <summary>
        /// This must be called in Update()
        /// </summary>
        /// <param name="cam"></param>
        public void AttachandUpdateCamera(Camera2D cam)
        {
            cam.position.X = position.X;
            cam.position.Y = position.Y;
            cam.FollowArea.X = width * 0.5f ;
            cam.FollowArea.Y = height * 0.5f;
        }
    }
}
