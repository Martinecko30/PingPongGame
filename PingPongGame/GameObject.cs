using SFML.Graphics;
using SFML.System;

namespace PingPongGame
{
    public interface GameObject
    {
        public abstract void Update();
        public abstract Shape GetShape();
    }
}
