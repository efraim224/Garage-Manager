using B21_Ex05.ReverseTicTacToeInterface;

namespace B21_Ex05.ReverseTicTacToeObjects
{
    public class InputChecker
    {
        private const string k_PlayerVsPlayerMode = "1";
        private const string k_PlayerVsComputerMode = "2";

        public static bool IsValidBoardSize(int i_BoardHeight, int i_BoardWidth)
        {
            bool validSize = i_BoardHeight <= ReverseTicTacToeGame.k_MaxBoardHeight || i_BoardHeight >= ReverseTicTacToeGame.k_MinBoardHeight ||
                            i_BoardWidth <= ReverseTicTacToeGame.k_MaxBoardWidth || i_BoardWidth >= ReverseTicTacToeGame.k_MinBoardWidth;

            return validSize;
        }

        public static bool IsValidName(string i_NameStr)
        {
            return string.IsNullOrEmpty(i_NameStr);
        }

        public static bool IsValidTurn(string i_TurnStr, Board i_Board)
        {
            bool validBoardPosition = false;

            if (i_TurnStr == ReverseTicTacToeGameInterface.k_TerminateGameSignal)
            {
                validBoardPosition = true;
            }
            else
            {
                if (isValidPosition(i_TurnStr))
                {
                    int rowPosition = i_TurnStr[0] - '1';
                    int colPosition = i_TurnStr[1] - '1';
                    bool validRow = rowPosition >= 0 && rowPosition < i_Board.Height;
                    bool validCol = colPosition >= 0 && colPosition < i_Board.Width;
                    validBoardPosition = validRow && validCol;
                }
            }

            return validBoardPosition;
        }

        private static bool isValidPosition(string i_Position)
        {
            bool valid =
            (i_Position.Length == ReverseTicTacToeGameInterface.k_InputLength) &&
            char.IsDigit(i_Position[0]) &&
            char.IsDigit(i_Position[1]);

            return valid;
        }

        internal static bool IsValidGameMode(string i_Mode)
        {
            return i_Mode.Equals(k_PlayerVsPlayerMode) || i_Mode.Equals(k_PlayerVsComputerMode);
        }

        internal static bool IsDigit(string i_Input)
        {
            bool isDigit = (i_Input.Length == 1) && char.IsDigit(i_Input[0]);

            return isDigit;
        }

        public static bool IsAYesNoAnswer(string i_String, string i_Yes, string i_No)
        {
            bool isYesOrNo = (i_String == i_Yes) || (i_String == i_No);

            return isYesOrNo;
        }

        public static bool IsAFreeCell(Board i_Board, string i_PlayerPosition)
        {
            int row = i_PlayerPosition[0] - '1';
            int column = i_PlayerPosition[1] - '1';

            return i_Board.IsEmptyCell(row, column);
        }
    }
}
