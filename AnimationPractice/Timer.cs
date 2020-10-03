using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimationPractice
{
    public class Timer : Sprite
    {
        TimeSpan PreTime { get; set; } = TimeSpan.Zero;
        public Timer(Vector2 position, SpriteFont font, Color tint)
            : base(position, font, tint)
        {

        }

        public void Update(GameTime gameTime)
        {
            PreTime += gameTime.ElapsedGameTime;
            Text = PreTime.ToString();
        }
    }
}
