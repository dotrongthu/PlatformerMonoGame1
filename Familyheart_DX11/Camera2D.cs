using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Runtime.InteropServices;

namespace Familyheart_DX11
{
    public class Camera2D
    {
        public Matrix transform;
        public Vector2 position;
        protected float zoom;
        protected float rotation;
        public Vector2 FollowArea;
        

        public float Zoom
        {
            get { return zoom; }
            set { zoom = value; }
        }

        public float Rotation
        {
            get { return rotation; }
            set { rotation = value; }
        }

        public Camera2D(Vector2 pos, float zoom, float rotation)
        {
            position = pos;
            this.zoom = zoom;
            this.rotation = rotation;
        }

        

        public Matrix GetMatrixTransform()
        {
    
            transform = Matrix.CreateTranslation(new Vector3(-position.X, -position.Y, 0)) *
                Matrix.CreateRotationZ(rotation) *
                Matrix.CreateScale(new Vector3(zoom, zoom, 0)) *
                Matrix.CreateTranslation(new Vector3(FollowArea.X, FollowArea.Y, 0));

            return transform;
        }

        public void Move(Vector2 distance)
        {
            position += distance;
        }



    }
}
