using SFML.System;

namespace PingPongGame
{
    public class GameTime
    {
        private const float LOW_LIMIT = 0.0167f;            // Keep At/Below 60fps
        private const float HIGH_LIMIT = 0.1f;              // Keep At/Above 10fps
        private static float lastTime = 0;

        public static float DeltaTime { get; protected set; }

        public static void UpdateTime() {
            float currentTime = DateTime.Now.Millisecond;
            DeltaTime = (currentTime - lastTime) / 1000.0f;
            if (DeltaTime < LOW_LIMIT)
                DeltaTime = LOW_LIMIT;
            else if (DeltaTime > HIGH_LIMIT)
                DeltaTime = HIGH_LIMIT;

            lastTime = currentTime;
        }
    }
}
