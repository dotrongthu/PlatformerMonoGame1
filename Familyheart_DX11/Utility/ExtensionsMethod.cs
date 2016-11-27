using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using System.Xml;

using Fam
using Familyheart_DX11.SceneManager;
using Familyheart_DX11.GUI;

namespace Familyheart_DX11.Utility
{
    public static class ExtensionsMethod
    {

        public static void DrawText(this SpriteBatch batch, Text text, bool swap)
        {
            batch.DrawString(text.font,text.text, text.pos, swap ? text.changedColor : text.normalColor);
        }

        public static bool DrawClickText(this SpriteBatch batch, Text text, Vector2 mousePos, bool mouseClick)
        {
            bool r = false;
            bool changedColor = false;

            if (mousePos.X> text.pos.X &&
                mousePos.Y > text.pos.Y &&
                mousePos.X < text.font.MeasureString(text.text).X * text.Size &&
                mousePos.Y<text.font.MeasureString(text.text).Y * text.Size)
            {
                r = true;
                changedColor = true;
            }

            batch.DrawText(text, changedColor);

            return r;
        }

        /*
        public static SceneTotalLoader LoadSceneTotalManager(this ContentManager manager, string path)
        {
            XmlReader reader = new XmlReader();

        }*/

        public static bool SaveTileMap(this ContentManager manager, string path)
        {
            if (File.Exists(path))
            {
#if BUILDER
            Debug.WriteLine("File Exists before");
#else
             throw new Exception("File exists before");
#endif
            }

            StreamWriter writer = new StreamWriter(path);




            return true;
        }

        public static TileMap LoadTiles(this ContentManager manager, string path)
        {
            TileMap scene = new TileMap();
            StreamReader reader = new StreamReader(path);
            
            
            
            string line = " ";
            int n;
            int currentTexThrough = 0;
            int currentDefenition = -1;
            Rectangle takeRect = new Rectangle();
            string[] splited;
            while (!reader.EndOfStream)
            {
                line = reader.ReadLine();



                if (line.StartsWith("#src"))
                {
                    ///Doing this, i can confirm the string has been reserved.
                    splited = line.Split(' ');
                    if (splited.Length > 1)
                    {
                        Console.WriteLine(splited[1]);
                        n = Convert.ToInt32(splited[1]);
                        currentTexThrough = n - 1;
                    }
                    line = reader.ReadLine();

                    string pathz = line;
                    scene.TileMaps.Add(manager.Load<Texture2D>(path));
                }
                else
                {
                    currentDefenition++;
                    string name = line;
                    splited = line.Split(' ');
                    if (splited.Length > 3)
                    {
                        takeRect.X = Convert.ToInt32(splited[0]);
                        takeRect.Y = Convert.ToInt32(splited[1]);
                        takeRect.Width = Convert.ToInt32(splited[2]) - takeRect.X;
                        takeRect.Width = Convert.ToInt32(splited[3]) - takeRect.Y;
                    }
                    else
                    {
                        throw new Exception("Segment reader get error cause the rect input is less than four parameters");

                    }

                    int tex = currentTexThrough;
                    line = reader.ReadLine();
                    int flags = Convert.ToInt32(line);
                    line = reader.ReadLine();
                    string tag = line;


                    scene.ObjectSprites.Add(new SegmentDefinition(name, takeRect,(SegmentFlag)flags,tex, tag));
                   
                }


            }

            return scene;

            
        }

        /// <summary>
        /// Create a new object
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="position"></param>
        /// <param name="rotation"></param>
        /// <param name="scale"></param>
        /// <param name="texturePath"></param>
        /// <returns></returns>
        public static GameObject CreateNewGameObject(this ContentManager manager, Vector2 position, float rotation, Vector2 scale, string texturePath)
        {
            if (texturePath == " ") throw new Exception("The path to texture is empty");
            Texture2D texture = manager.Load<Texture2D>(texturePath);
            if (texture == null) throw new Exception("The texture is null or doesnt exists. Check the source or link"); else Console.WriteLine("Texture loaded success");
            return new GameObject(position, rotation, scale, texture);
        }

        /// <summary>
        /// Create a new object with list of Texture
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="position"></param>
        /// <param name="rotation"></param>
        /// <param name="scale"></param>
        /// <param name="texturePath"></param>
        /// <returns></returns>
        public static GameObject CreateNewGameObject(this ContentManager manager, Vector2 position, float rotation, Vector2 scale, List<string> texturePath)
        {
            List<Texture2D> textureObject = new List<Texture2D>();
            for (int i = 0; i<=texturePath.Count; i++)
            {
                Texture2D texture = manager.Load<Texture2D>(texturePath[i]);
                if (texture == null) throw new Exception("The texture is null or doesnt exists. Check the source or link"); else Console.WriteLine("Texture loaded success");
                textureObject.Add(texture);
            }
            
            return new GameObject(position, rotation, scale, textureObject);
        }

        public static Vector2 GetTextureCenterOrigin(Texture2D tex)
        {
            return new Vector2(tex.Width / 2, tex.Height / 2);
        }

        /// <summary>
        /// Draw a GameObject
        /// </summary>
        /// <param name="batch"></param>
        /// <param name="gameObject"></param>
        public static void Draw(this SpriteBatch batch,GameObject gameObject,int index)
        {
            if (gameObject == null) throw new Exception("gameObject is null. I think you didnt create it");
                
            batch.Draw(gameObject.Texture[index], gameObject.Position, null, Color.Wheat, gameObject.Rotation, gameObject.Origin, gameObject.Scale, SpriteEffects.None,0);
           
        }

        public static void AttatchCamera(this GraphicsDevice device, Camera2D cam)
        {
            cam.position.X = device.Viewport.Width / 2;
            cam.position.Y = device.Viewport.Height / 2;
            cam.FollowArea.X = device.Viewport.Width * 0.5f;
            cam.FollowArea.Y = device.Viewport.Height * 0.5f;
        }

#region Draw Intilize
        public static void IntilizeDraw(this SpriteBatch batch, Effect effect, Camera2D camFollow)
        {
            batch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, null, null, null, effect, camFollow.GetMatrixTransform());
        }

        public static void IntilizeDraw(this SpriteBatch batch, Camera2D camFollow)
        {
            batch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, null, null, null, null, camFollow.GetMatrixTransform());
        }

        public static void IntilizeDraw(this SpriteBatch batch)
        {
            batch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
        }
#endregion

    }
}
