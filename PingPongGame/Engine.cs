using SFML.Graphics;
using SFML.Window;
using System.Data;

namespace PingPongGame
{
    public class Engine
    {
        private RenderWindow window;
        public List<GameObject> objects = new List<GameObject>();
        public static GameManager manager;

        private const uint WIDTH = 1000, HEIGHT = 600;

        public Engine()
        {
            window = new RenderWindow(new VideoMode(WIDTH, HEIGHT), "PingPong Game");

            InitObjects();

            window.Closed += OnClose;

            window.SetFramerateLimit(120);
            window.SetVerticalSyncEnabled(false);

            while (window.IsOpen)
            {
                Update();

                Draw();
            }
        }

        private void Update()
        {
            MainKeyboardInput();
            GameTime.UpdateTime();

            window.DispatchEvents();

            manager.Update();

            foreach (var gameObject in objects)
            {
                gameObject.Update();
            }
        }

        private void Draw()
        {
            window.Clear();

            foreach (var gameObject in objects)
            {
                window.Draw(gameObject.GetShape());
            }


            window.Display();
        }

        private void InitObjects()
        {
            var player1 = new Player(Keyboard.Key.W, Keyboard.Key.S, new SFML.System.Vector2f(50, HEIGHT / 2));
            var player2 = new Player(Keyboard.Key.Up, Keyboard.Key.Down, new SFML.System.Vector2f(WIDTH - 50, HEIGHT / 2));
            manager = new GameManager(player1, player2);
            objects.Add(new Ball(WIDTH, HEIGHT));
            objects.Add(player1);
            objects.Add(player2);
        }


        private void MainKeyboardInput()
        {
            if(Keyboard.IsKeyPressed(Keyboard.Key.Escape))
            {
                window.Close();
            }
        }

        private void OnClose(object? sender, EventArgs e)
        {
            window.Close();
        }
    }
}
