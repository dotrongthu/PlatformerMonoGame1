using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Familyheart_DX11;
using Familyheart_DX11.Utility;
using System;
using Familyheart.Character;

namespace Familyheart
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont font;
        Effect effect;
        GameObject obj;
        GameObject cube;
        Ariel ariel;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            ariel = new Ariel(new Vector2(100, 100), 0, new Vector2(0.5f, 0.5f));
            base.Initialize();
            
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("Fonts/Sans");
            ariel.LoadContent(Content);
            //cube = Content.CreateNewGameObject(new Vector2(400, 200), 0, new Vector2(0.5f, 0.5f), "Sprites/TestSubject");
            obj = Content.CreateNewGameObject(new Vector2(400, 200), 0, new Vector2(1, 1), "Sprites/Sanicthetestobj");
            //obj2 = Content.CreateNewGameObject(new Vector2(200, 200), 0, new Vector2(1, 1), "Sprites/Sanicthetestobj");
            effect = Content.Load<Effect>("Shader/ShaderTestSanc");
           
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here

        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            ariel.AIHandling();
            // TODO: Add your update logic here
            
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.IntilizeDraw();
            effect.CurrentTechnique.Passes[0].Apply();
            ariel.Draw(spriteBatch);
            spriteBatch.Draw(obj);

            /*if (Collision.AABBCollide(ariel + new Vector2(ariel.xSpeed, obj))
            {
                ariel.shouldMove = false;
                Console.Write("ha");
            }
              
            else
                if (ariel.shouldMove == false) ariel.shouldMove = true;
        */

            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
