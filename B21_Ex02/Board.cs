using System.Collections.Generic;
using B21_Ex05.ReverseTicTacToeObjects.GameEvents;

namespace B21_Ex05.ReverseTicTacToeObjects
{
    public class Board
    {
        private readonly int r_Width;
        private readonly int r_Height;
        public event MadeTurnEventHandler MadeTurn;

        private readonly Sign<char>[,] r_Matrix;

        public Board(int i_Height, int i_Width)
        {
            this.r_Width = i_Width;
            this.r_Height = i_Height;
            this.r_Matrix = fillMatrixWithSign();
        }

        private List<Sign<char>> createBoardCells()
        {
            List<Sign<char>> signList = new List<Sign<char>>();
            int numOfSign = this.Width * this.Height;
            for (int i = 0; i < numOfSign; i++)
            {
                char valueOfSign = ' ';
                signList.Add(new Sign<char>(valueOfSign));
            }

            return signList;
        }

        private Sign<char>[,] fillMatrixWithSign()
        {
            Sign<char>[,] signMatrix = new Sign<char>[this.Height, this.Height];
            List<Sign<char>> signList = createBoardCells();

            for (int row = 0; row < this.Height; row++)
            {
                for (int column = 0; column < this.Width; column++)
                {
                    signMatrix[row, column] = signList[0];
                    signList.RemoveAt(0);
                }
            }

            return signMatrix;
        }


        public void InsertSign(int i_RowIndex, int i_ColumnIndex, Sign<char> i_Sign)
        {
            this.r_Matrix[i_RowIndex, i_ColumnIndex] = i_Sign;
            if(MadeTurn != null)
            {
                this.MadeTurn.Invoke(i_RowIndex, i_ColumnIndex, i_Sign);
            }
        }

        internal Sign<char> SignAtIndex(int i_Row, int i_Column)
        {
            Sign<char> sign = new Sign<char>(' ');
            if (i_Row < this.Width && i_Row >= 0 && i_Column >= 0 && i_Column < this.Height)
            {
                sign = this.r_Matrix[i_Row, i_Column];
            }

            return sign;
        }

        public void CleanBoard()
        {
            this.fillMatrixWithSign();
        }

        public bool IsEmptyCell(int i_Row, int i_Column)
        {
            return this.SignAtIndex(i_Row, i_Column).Value == ' ';
        }

        public int Width
        {
            get
            {
                return this.r_Width;
            }
        }

        public int Height
        {
            get
            {
                return this.r_Height;
            }
        }
    }
}
