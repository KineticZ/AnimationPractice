using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AnimationPractice
{
    public abstract class Animation : Sprite
    {
        private int CurrentFrame { get; set; }
        private int EndFrame => Frames.Count - 1;
        private List<Frame> Frames { get; set; }
        private TimeSpan PreTime { get; set; } = TimeSpan.Zero;
        public double FrameRate { get; set; }
        private TimeSpan MaxTime => TimeSpan.FromMilliseconds(FrameRate);
        public Animation(Texture2D texture, Vector2 position, Color tint)
            : base(texture, position, tint)
        {
            CurrentFrame = 0;
            FrameRate = 100;
        }

        //can be used to return frames into a dictionary
        public void InitFrames(Point numberOfFrames, Vector2 originOfRotation, Rectangle cutoutSource, Point offset, 
            SpriteEffects Effects, float Rotation, float Scale, float LayerDepth)
        {
            Frames = new List<Frame>();
            for (int i = 0; i < numberOfFrames.Y; i++)
            {
                for (int j = 0; j < numberOfFrames.X; j++)
                {
                    Frames.Add(new Frame(originOfRotation, cutoutSource, Effects, Rotation, Scale, LayerDepth));
                    cutoutSource.X = cutoutSource.X + cutoutSource.Width + offset.X;
                }
                cutoutSource.Y = cutoutSource.Y + cutoutSource.Height + offset.Y;
            }
        }

        private void UpdateFrames()
            => CurrentFrame = CurrentFrame >= EndFrame ? 0 : CurrentFrame + 1;
        
        public void Update(GameTime gameTime)
        {
            PreTime += gameTime.ElapsedGameTime;
            if (PreTime >= MaxTime)
            {
                PreTime = TimeSpan.Zero;

                UpdateFrames();
            }
        }

        public void Animate(SpriteBatch spriteBatch)
        {
            Draw(spriteBatch, Frames[CurrentFrame].CutoutSource, 
                              Frames[CurrentFrame].Rotation, 
                              Frames[CurrentFrame].OriginOfRotation, 
                              Frames[CurrentFrame].Scale, 
                              Frames[CurrentFrame].Effects, 
                              Frames[CurrentFrame].LayerDepth);
        }
    }
}
