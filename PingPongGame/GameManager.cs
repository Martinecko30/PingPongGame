using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPongGame
{
    public class GameManager
    {
        public Player player1, player2;

        public uint p1Score = 0, p2Score = 0;

        public GameManager(Player player1, Player player2)
        {
            this.player1 = player1;
            this.player2 = player2;
        }

        public void Update()
        {
            
        }
    }
}
