using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

using Familyheart_DX11;


namespace FamilyHeart_Map_Builder.Class
{

    public class Scene
    {

        List<Texture2D> tileMaps;
        List<GameObject> objectSprite;

        public Scene()
        {
            objectSprite = new List<GameObject>();
        }

        public bool DrawMapSegments(SpriteBatch batch, int viewportWidth, int viewportHeight)
        {
            Rectangle sourceRect;
            Vector2 destination;

            batch.Begin();
            for (int i = 0; i < objectSprite.Count(); i++)
            {
                destination.X = (int)(viewportWidth / 20 * 19);
                destination.Y = 50 + i * 60;
                sourceRect = objectSprite[i].DrawArea;

                

            }
            batch.End();

            return true;
        }

        /// <summary>
        /// Read the map and encode it with special encoding method.
        /// <para>The map is design as follow</para>
        /// <para>The line starts with "//" means it's a comment</para>
        /// <para>Next line is the name of texture</para>
        /// <para>After that, we got the rect of a triangle to draw</para>
        /// <para>Finally is the flag for the tex to import to the scene</para>
        /// <para>Exceptions will throw</para>
        /// <para>1. Path doesnt exist</para>
        /// <para>2. Rect to draw is less then four paras</para>
        /// </summary>
        /// <param name="path"></param>
        /// 
        /// 
        /// <returns></returns>
        /// 



       

        public bool MapSaving(bool saveAs, string path)
        {
            return true;
        }

    }
}
