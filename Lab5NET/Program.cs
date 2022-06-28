using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using TicTacToeLibrary;

namespace Lab5NET
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            GameHistory history = new GameHistory();
            int turn;
            string choosingError;
            int choice;
            int flag = 0; // 1 - win, -1 - draw

            try
            {
                do
                {
                    try
                    {
                        Console.Clear();
                        Console.WriteLine("Player1:X and Player2:O");
                        Console.WriteLine("\n");

                        turn = game.CheckTurn();
                        if (turn == 2)
                        {
                            Console.WriteLine("Player 2 turn");
                        }
                        else
                        {
                            Console.WriteLine("Player 1 turn");
                        }

                        Console.WriteLine("\n");
                        ShowBoard(game);

                        Console.WriteLine("Choose cell to mark. Type 0 to cancel go one turn back:");
                        choice = int.Parse(Console.ReadLine());
                        if (choice == 0)
                        {
                            game.RestoreTurn(history.Turns.Pop());
                            Console.WriteLine("Cancelling the turn. Please wait 2 second board is loading again.....");
                            Thread.Sleep(2000);
                        }
                        else
                        {
                            history.Turns.Push(game.SaveTurn());
                            choosingError = game.ChooseCell(choice);
                            if (choosingError != "0")
                            {
                                Console.WriteLine(choosingError);
                                Console.WriteLine("Please wait 2 second board is loading again.....");
                                history.Turns.Pop();
                                Thread.Sleep(2000);
                            }
                        }
                        
                        flag = CheckEnd(game);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("Please wait 2 second board is loading again.....");
                        Thread.Sleep(2000);
                    }
                }
                while (flag != 1 && flag != -1);

                Console.Clear();
                ShowBoard(game);

                if (flag == 1) // win
                {
                    Console.WriteLine("Player {0} has won", game.Winner);
                }
                else // draw
                {
                    Console.WriteLine("Draw");
                }
                Console.ReadLine();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        private static void ShowBoard(Game game)
        {
            Console.WriteLine(game.ShowBoard());
        }


        private static int CheckEnd(Game game)
        {
            return game.CheckGameEnd();
        }
    }
}
