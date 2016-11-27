using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Familyheart_DX11;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Familyheart_DX11.Utility;
using Microsoft.Xna.Framework.Input;

namespace Familyheart.Character
{
    public class Ariel: GameObject
    {
        enum State {
            Idle = 0,
            Run = 1,
            Talking = 2,
            Surpising = 3
        }

        public int xSpeed = 10;
        public int ySpeed = 10;
        public List<Vector2> originList;
        public bool shouldMove;

        public Ariel(Vector2 pos, float rotation, Vector2 scale): base (pos, rotation,scale)
        {
            shouldMove = true;
            position = pos;
            this.rotation = rotation;
            this.scale = scale;
            TexturesAnimation = new List<Texture2D>();
            originList = new List<Vector2>();
            
        }

        public void LoadContent(ContentManager manager)
        {
            TexturesAnimation.Add(manager.Load<Texture2D>("Sprites/TestSubject"));
            originList.Add(ExtensionsMethod.GetTextureCenterOrigin(TexturesAnimation[0]));
        }

        public void AIHandling()
        {
            
            if (shouldMove)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.A)) position -= new Vector2(10, 0);
                if (Keyboard.GetState().IsKeyDown(Keys.D)) position += new Vector2(10, 0);
                if (Keyboard.GetState().IsKeyDown(Keys.S)) position += new Vector2(0, 10);
                if (Keyboard.GetState().IsKeyDown(Keys.W)) position -= new Vector2(0, 10);
            }
          
        }

        public void Draw(SpriteBatch batch)
        {
            batch.Draw(TexturesAnimation[0], position, null, Color.Wheat, rotation, originList[0], scale, SpriteEffects.None, 0);
        }
            
    }
}
