using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Familyheart_DX11
{
    public static class Collision
    {
        //Test collision for two gameobject. Default collision check with a rectangle.
        public static bool Collide(GameObject obj1, GameObject obj2)
        {
            Rectangle collider1 = new Rectangle((int)obj1.Position.X, (int)obj1.Position.Y, (int)obj1.width, (int)obj1.height);
            Rectangle collider2 = new Rectangle((int)obj1.Position.X, (int)obj1.Position.Y, (int)obj1.width, (int)obj1.height);

            return collider1.Intersects(collider2);
        }

        public static bool Collide(CircleCollider coll1, CircleCollider coll2) {
            return coll1.Intersects(coll2);
        }

        ///<summary>This is not the best way :-<</summary>
        ///And i scrap it already :->
        public static bool AABBCollide(GameObject obj1, GameObject obj2)
        {
            Console.WriteLine("Argument AABB: {0} {1} {2} {3} {4} {5} {6} {7}", obj1.Position.X + obj1.Origin.X, obj2.Position.X + obj2.width - obj2.Origin.Y,
               obj1.Position.X + obj1.Origin.X +obj1.width , obj2.Position.X - obj2.Origin.X,
               obj1.Position.Y + obj1.Origin.Y, obj2.Position.Y + obj2.height - obj2.Origin.Y,
               obj1.Position.Y + obj1.height + obj1.Origin.Y, obj2.Position.Y - obj2.Origin.Y);

             if (obj1.Position.X + obj1.Origin.X < obj2.Position.X + obj2.width - obj2.Origin.Y &&
                 obj1.Position.X + obj1.Origin.X + obj1.width > obj2.Position.X - obj2.Origin.X &&
                 obj1.Position.Y + obj1.Origin.Y < obj2.Position.Y + obj2.height - obj2.Origin.Y &&
                 obj1.Position.Y + obj1.height + obj1.Origin.Y > obj2.Position.Y - obj2.Origin.Y)
             {


                 return true;
             }
            return false;
        }

       
    }

    ///<summary>Nice.</summary>
    public struct CircleCollider {
       
        public Vector2 center { get; set; }
        public float radius { get; set; }

        public CircleCollider(Vector2 center, float radius)
        {
            this.center = center;
            this.radius = radius;

        }

        ///<summary>Check if the circle contatins "point" point wink wink</summary>
        public bool Contains(Vector2 point)
        {
            return (((point - center).Length()) <= radius);
        }

        ///<summary>Check if two circle interests with each other</summary>
        public bool Intersects(CircleCollider collider)
        {
            return Math.Abs((collider.center - center).Length()) < Math.Abs(collider.radius - radius);
        }

    }

   
}
