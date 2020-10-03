using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct2D1.Effects;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimationPractice
{
    public class Frame
    {
        public Rectangle CutoutSource;
        public float Rotation { get; set; }
        public float Scale { get; set; }
        public SpriteEffects Effects { get; set; }
        public float LayerDepth { get; set; }
        public Vector2 OriginOfRotation { get; set; }
        

        public Frame(Vector2 originOfRotation, Rectangle cutoutSource, SpriteEffects Effects, float Rotation, float Scale, float LayerDepth)
        {
            OriginOfRotation = originOfRotation;
            CutoutSource = cutoutSource;
            this.Effects = Effects;
            this.Rotation = Rotation;
            this.Scale = Scale;
            this.LayerDepth = LayerDepth;
        }
    }
}
