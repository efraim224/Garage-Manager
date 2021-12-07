using System;
using B21_Ex05.ReverseTicTacToeObjects;

namespace B21_Ex05.ReverseTicTacToeInterface
{
    internal class InputReader
    {
        private const string k_InvalidBoardSize = "The valid length is between 3 to 9. Please Re-enter.";
        private const string k_InvalidMode = "The mode can only be 1 or 2. Please re-enter:";
        private const string k_InvalidPlayerName = "Cannot accept an empty name. Please re-enter:";
        private const string k_SelectBoardSize = "Please enter the board dimension, a single digit (for both height and width) between 3 and 9:";
        private const string k_InvalidBoardPosition = "Invalid position! Please Re-enter.";
        private const string k_PickCard = "pick a cell on the board (Col and Row, like 13):";

        internal static string ReadPlayerName()
        {
            string input = Console.ReadLine();

            while (InputChecker.IsValidName(input))
            {
                Console.WriteLine(k_InvalidPlayerName);
                input = Console.ReadLine();
            }

            return input;
        }

        internal static eGameMode ReadGameMode()
        {
            string input = Console.ReadLine();

            while (!InputChecker.IsValidGameMode(input))
            {
                Console.WriteLine(k_InvalidMode);
                input = Console.ReadLine();
            }

            return GameMode.Parse(input);
        }

        internal static void ReadBoardDimensions(out int io_BoardHeight, out int io_BoardWidth)
        {
            do
            {
                Console.WriteLine(k_SelectBoardSize);
                io_BoardHeight = readBoardDimension();
                io_BoardWidth = io_BoardHeight;

                if (!InputChecker.IsValidBoardSize(io_BoardHeight, io_BoardWidth))
                {
                    Console.WriteLine(k_InvalidBoardSize);
                }
            }
            while (!InputChecker.IsValidBoardSize(io_BoardHeight, io_BoardWidth));
        }

        private static int readBoardDimension()
        {
            string input = Console.ReadLine();

            while (!InputChecker.IsDigit(input))
            {
                Console.WriteLine(k_InvalidBoardSize);
                input = Console.ReadLine();
            }

            return int.Parse(input);
        }

        internal static string ReadPlayAgainInstruction()
        {
            string input = Console.ReadLine();

            while (!InputChecker.IsAYesNoAnswer(input, ReverseTicTacToeGameInterface.k_Yes, ReverseTicTacToeGameInterface.k_No))
            {
                Console.WriteLine("Invalid answer. Enter 'y' to play again, or 'n' to Exit");
                input = Console.ReadLine();
            }

            return input;
        }
        // $G$ CSS-999 (-5) Out parameters should start with o_PascaleCased
        internal string readPosition(out int io_Row, out int io_Col, string i_PlayerName, Board i_Board)
        {
            string input;

            io_Row = 0;
            io_Col = 0;
            Console.WriteLine("{0}, {1}", i_PlayerName, k_PickCard);
            input = Console.ReadLine();

            while (!InputChecker.IsAFreeCell(i_Board, input))
            {
                Console.WriteLine(k_InvalidBoardPosition);
                input = Console.ReadLine();
            }

            if (input != ReverseTicTacToeGameInterface.k_TerminateGameSignal)
            {
                io_Row = input[1] - '1';
                io_Col = input[0] - '1';
            }

            return input;
        }
    }
}
