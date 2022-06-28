using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeLibrary
{
    public class GameHistory
    {
        public Stack<GameMemento> Turns { get; private set; }

        public GameHistory()
        {
            Turns = new Stack<GameMemento>();
        }
    }
}
