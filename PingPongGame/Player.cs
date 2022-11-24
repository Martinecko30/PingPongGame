using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPongGame
{
    public class Player : GameObject
    {
        private Keyboard.Key upKey, downKey;
        private RectangleShape shape;

        private const float SPEED = 500;

        public Player(Keyboard.Key upKey, Keyboard.Key downKey, Vector2f startingPosition)
        {
            shape = new RectangleShape(new Vector2f(14, 100));
            shape.Position = startingPosition;
            shape.FillColor = Color.White;
            this.upKey = upKey;
            this.downKey = downKey;
        }

        public Shape GetShape()
        {
            return shape;
        }

        public void Update()
        {
            if(Keyboard.IsKeyPressed(downKey))
            {
                if (shape.Position.Y + shape.Size.Y + 1 > 600) return;
                Move(new Vector2f(0, 1f) * SPEED * GameTime.DeltaTime);
            }
            else if (Keyboard.IsKeyPressed(upKey))
            {
                if (shape.Position.Y - 1 < 0) return;
                Move(new Vector2f(0, -1f) * SPEED * GameTime.DeltaTime);
            }
        }

        private void Move(Vector2f position)
        {
            shape.Position += position;
        }
    }
}
