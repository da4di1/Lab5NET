using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeLibrary
{
    public class Game
    {
        private char[] cells = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        private int playerTurn = 1;
        public int Winner { get; private set; }


        public int CheckTurn()
        {
            if (playerTurn % 2 == 0)
            {
                return 2;
            }
            else
            {
                return 1;
            }
        }


        public string ShowBoard()
        {
            return $"     |     |      \n" +
                $"  {cells[1]}  |  {cells[2]}  |  {cells[3]}\n" +
                $"_____|_____|_____ \n" +
                $"     |     |      \n" +
                $"  {cells[4]}  |  {cells[5]}  |  {cells[6]}\n" +
                $"_____|_____|_____ \n" +
                $"     |     |      \n" +
                $"  {cells[7]}  |  {cells[8]}  |  {cells[9]}\n" +
                $"     |     |      \n";
        }


        public string ChooseCell(int choice)
        {
            if (cells[choice] != 'X' && cells[choice] != 'O')
            {
                if (playerTurn % 2 == 0)
                {
                    cells[choice] = 'O';
                    playerTurn++;
                    return "0";
                }
                else
                {
                    cells[choice] = 'X';
                    playerTurn++;
                    return "0";
                }
            }
            else
            {
                return $"Sorry the row {choice} is already marked with {cells[choice]}\n";
            }
        }


        public int CheckGameEnd()
        {
            if (cells[1] == cells[2] && cells[2] == cells[3] ||
                cells[4] == cells[5] && cells[5] == cells[6] ||
                cells[6] == cells[7] && cells[7] == cells[8] ||
                cells[1] == cells[4] && cells[4] == cells[7] ||
                cells[2] == cells[5] && cells[5] == cells[8] ||
                cells[3] == cells[6] && cells[6] == cells[9] ||
                cells[1] == cells[5] && cells[5] == cells[9] ||
                cells[3] == cells[5] && cells[5] == cells[7])
            {
                Winner = (playerTurn % 2) + 1;
                return 1;
            }
            else if (cells[1] != '1' && cells[2] != '2' && cells[3] != '3' &&
                cells[4] != '4' && cells[5] != '5' && cells[6] != '6' &&
                cells[7] != '7' && cells[8] != '8' && cells[9] != '9')
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }


        public GameMemento SaveTurn()
        {
            return new GameMemento(cells, playerTurn);
        }


        public void RestoreTurn(GameMemento memento)
        {
            for(int i = 0; i < cells.Length; i++)
            {
                this.cells[i] = memento.Cells[i];
            }

            this.playerTurn = memento.PlayerTurn;
        }
    }
}
