using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace FamilyHeart_Map_Builder.WinformController
{
    class MainScreen : WinFormsGraphicsDevice.GraphicsDeviceControl
    {
        private SpriteBatch batch;
        private ContentManager manager;

        protected override void Draw()
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
        }

        protected override void Initialize()
        {
            manager = new ContentManager(Services);
        }
    }
}
