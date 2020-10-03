using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct2D1;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Text;

namespace AnimationPractice
{
    public class Ryu : Animation
    {
        private Vector2 Speed { get; set; }

        public Ryu(Texture2D texture, Vector2 position, Color tint, float scale, Vector2 Speed)
            : base(texture, position, tint)
        {
            FrameRate = 250;
            var cutout = new Rectangle(6, 6, 35, 75);
            var offset = new Point(3, 3);
            InitFrames( new Point(3, 1), new Vector2(cutout.Center.X, cutout.Center.Y), cutout, offset, SpriteEffects.None, 0f, scale, 0f);
            this.Speed = Speed;
        }
        
    }
}
