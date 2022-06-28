using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeLibrary
{
    public class GameMemento
    {
        public char[] Cells { get; private set; }
        public int PlayerTurn { get; private set; }

        public GameMemento(char[] cells, int playerTurn)
        {
            Cells = new char[cells.Length];
            for (int i = 0; i < cells.Length; i++)
            {
                Cells[i] = cells[i];
            }

            PlayerTurn = playerTurn;
        }
    }
}
