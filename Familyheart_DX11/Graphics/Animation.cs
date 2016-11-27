using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Familyheart_DX11.Graphics
{
    class SheetAnimation
    {
        Vector2 frameArray;
        float totalDuration;
        float timePassed = 0;
        GameTime gameTime;
        int currentFrameX;
        int currentFrameY;

        public float TotalDuration
        {
            get { return totalDuration; }
            set { totalDuration = value; }
        }


        public SheetAnimation(Vector2 frameArray, float totalDuration)
        {
            this.frameArray = frameArray;
            this.totalDuration = totalDuration;
            gameTime = new GameTime();
        }

        //Play
        public Rectangle Play(GameObject obj)
        {
            int totalFrames = (int)frameArray.X * (int)frameArray.Y;
            float duration = totalDuration / totalFrames;
            timePassed += gameTime.ElapsedGameTime.Milliseconds;
            if (timePassed > duration)
            {
                timePassed -= duration;
                ++currentFrameX;
                if (currentFrameX >= frameArray.X)
                {
                    currentFrameX = 0;
                    ++currentFrameY;
                    if (currentFrameY >= frameArray.Y)
                        currentFrameY = 0;
                }
            }
            float frameWidth = obj.width / frameArray.X;
            float frameHeight = obj.height / frameArray.Y;

            return new Rectangle((int)frameWidth * currentFrameX, (int)frameHeight * currentFrameY, (int)frameWidth, (int)frameHeight);
        }
    }
}

  
