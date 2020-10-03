using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimationPractice
{
    public abstract class Sprite
    {
        public Vector2 Position;
        public Texture2D Texture { get; set; }
        public Color Tint { get; set; }
        public SpriteFont Font { get; set; }
        public string Text { get; set; }
        //Hitbox is only valid for none animating sprites
        public Rectangle HitBox => new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
        public Sprite(Texture2D texture, Vector2 position, Color tint)
        {
            Texture = texture;
            Position = position;
            Tint = tint;
        }
        public Sprite(Vector2 position, SpriteFont font, Color color)
        {
            Position = position;
            Font = font;
            Tint = color;
        }
        public void DrawString(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(Font, Text, Position, Tint);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Tint);
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle? cutoutSource, float rotation, Vector2 originOfRotation, float scale, SpriteEffects effects, float layerDepth)
        {
            spriteBatch.Draw(Texture, Position, cutoutSource, Tint, rotation, originOfRotation, scale, effects, layerDepth);
        }
    }
}
