using SFML.Graphics;
using SFML.Graphics.Glsl;
using SFML.System;
using SFML.Window;
using System.Reflection.Metadata;

namespace PingPongGame
{
    public class Ball : GameObject
    {
        CircleShape shape;
        Vector2f velocity;
        Vector2u bounds;

        private float speedBuff = 1.01f;

        Vector2f startPos;

        private bool lastInteracted = false;

        public Ball(uint width, uint height)
        {
            bounds = new Vector2u(width, height);
            shape = new CircleShape(12);
            velocity = new Vector2f(150f, 150f);

            shape.FillColor = Color.White;
            startPos = new Vector2f(width/2, height/2);
            shape.Position = startPos;
        }

        public Shape GetShape()
        {
            return shape;
        }

        public void Update()
        {
            IsInBounds();
            Move(velocity * GameTime.DeltaTime);
        }

        private void Move(Vector2f position)
        {
            shape.Position += position;
        }

        private void IsInBounds()
        {
            float left = shape.Position.X;
            float right = shape.Position.X + (shape.Radius * 2);
            float top = shape.Position.Y;
            float bottom = shape.Position.Y + (shape.Radius * 2);

            if (bottom > bounds.Y)
            {
                // bottom wall
                velocity.X *= speedBuff;
                velocity.Y *= -speedBuff;
            }
            else if (top < 0)
            {
                // top wall
                velocity.X *= speedBuff;
                velocity.Y *= -speedBuff;
            }
            else if (right > bounds.X)
            {
                // right wall

                Engine.manager.p1Score++;
                Reset();
                /*
                velocity.X *= -speedBuff;
                velocity.Y *= speedBuff;
                */
            }
            else if (left < 0)
            {
                // left wall

                Engine.manager.p2Score++;
                Reset();
                /*
                velocity.X *= -speedBuff;
                velocity.Y *= speedBuff;
                */
            }



            if(shape.GetGlobalBounds().Intersects(Engine.manager.player1.GetShape().GetGlobalBounds()))
            {
                if (lastInteracted) return;

                velocity.X *= -speedBuff;
                velocity.Y *= speedBuff;

                lastInteracted = true;
            }
            else if (shape.GetGlobalBounds().Intersects(Engine.manager.player2.GetShape().GetGlobalBounds()))
            {
                if (lastInteracted) return;

                velocity.X *= -speedBuff;
                velocity.Y *= speedBuff;

                lastInteracted = true;
            } else 
                lastInteracted = false;
        }

        private void Reset()
        {
            Random rand = new Random();
            velocity = new Vector2f(rand.Next(2) == 0 ? 150f : -150f, rand.Next(2) == 0 ? 150f : -150f);
            shape.Position = startPos;
        }
    }
}
