using B21_Ex05.ReverseTicTacToeObjects.GameEvents;

namespace B21_Ex05.ReverseTicTacToeObjects
{
    public class ReverseTicTacToeGame
    {
        internal const int k_MinBoardHeight = 3;
        internal const int k_MaxBoardHeight = 9;
        internal const int k_MinBoardWidth = 3;
        internal const int k_MaxBoardWidth = 9;
        private Board m_Board;
        private int m_NumOfPlays;
        public event GameWonEventHandler GameWonNotifier;
        public event GameTieEventHandler GameTieNotifier;
        public ReverseTicTacToeGame(Board i_Board)
        {
            this.m_Board = i_Board;
            this.m_NumOfPlays = this.m_Board.Height * this.m_Board.Width;
        }

        public Board Board
        {
            get
            {
                return this.m_Board;
            }
            set
            {
                this.m_Board = value;
            }
        }

        public void Turn(int i_Row, int i_Colunm, Sign<char> i_PlayerSign, out bool i_PlayerWon)
        {
            this.m_Board.InsertSign(i_Row, i_Colunm, i_PlayerSign);
            i_PlayerWon = this.isPlayerWon(i_Row, i_Colunm, i_PlayerSign);
            this.m_NumOfPlays--;
            if (i_PlayerWon && this.GameWonNotifier != null)
            {
                this.GameWonNotifier.Invoke(i_PlayerSign.Value);
            }
            else if (this.m_NumOfPlays == 0 && this.GameTieNotifier != null)
            {
                this.GameTieNotifier.Invoke();
            }
        }

        private bool isPlayerWon(int i_Row, int i_Column, Sign<char> i_PlayersSign)
        {
            return diagonalWin(i_Row, i_Column, i_PlayersSign) || crossWin(i_Row, i_Column, i_PlayersSign);
        }

        private bool diagonalWin(int i_Row, int i_Column, Sign<char> i_PlayerSign)
        {
            bool topLeftToBottomRightWin = true;
            bool topRightToBottomLeftWin = true;
            for (int index = 0; index < this.m_Board.Width; index++)
            {
                if (i_PlayerSign.Value != this.m_Board.SignAtIndex(index, index).Value)
                {
                    topLeftToBottomRightWin = false;
                }

                if (i_PlayerSign.Value != this.m_Board.SignAtIndex(index, this.m_Board.Width - 1 - index).Value)
                {
                    topRightToBottomLeftWin = false;
                }
            }

            return topRightToBottomLeftWin || topLeftToBottomRightWin;
        }

        private bool possibleDiagonalWin(int i_Row, int i_Column, Sign<char> i_PlayerSign)
        {
            int topLeftToBottomRightSign = 0;
            int topRightToBottomLeftSign = 0;
            for (int index = 0; index < this.m_Board.Width; index++)
            {
                if (i_PlayerSign.Value != this.m_Board.SignAtIndex(index, index).Value)
                {
                    topLeftToBottomRightSign++;
                }

                if (i_PlayerSign.Value != this.m_Board.SignAtIndex(index, this.m_Board.Width - 1 - index).Value)
                {
                    topRightToBottomLeftSign++;
                }
            }

            return topLeftToBottomRightSign == this.m_Board.Width - 2 || topRightToBottomLeftSign == this.m_Board.Height - 2;
        }

        private bool crossWin(int i_Row, int i_Column, Sign<char> i_PlayerSign)
        {
            bool columnWin = true;
            bool rowWin = true;
            for (int index = 0; index < m_Board.Width; index++)
            {
                if (i_PlayerSign.Value != m_Board.SignAtIndex(i_Row, index).Value)
                {
                    rowWin = false;
                }

                if (i_PlayerSign.Value != m_Board.SignAtIndex(index, i_Column).Value)
                {
                    columnWin = false;
                }
            }

            return rowWin || columnWin;
        }

        private bool possibleCrossWin(int i_Row, int i_Column, Sign<char> i_PlayerSign)
        {
            int columnSign = 0;
            int rowSign = 0;
            for (int index = 0; index < m_Board.Width; index++)
            {
                if (i_PlayerSign.Value == m_Board.SignAtIndex(i_Row, index).Value)
                {
                    columnSign++;
                }

                if (i_PlayerSign.Value == m_Board.SignAtIndex(index, i_Column).Value)
                {
                    rowSign++;
                }
            }

            return columnSign == this.m_Board.Width - 2 || rowSign == this.m_Board.Height - 2;
        }

        private bool onlySignInRowAndColumn(int i_Row, int i_Column, Sign<char> i_PlayerSign)
        {
            bool onlySign = true;
            for (int currentRow = 0; currentRow < m_Board.Height; currentRow++)
            {
                if (m_Board.SignAtIndex(currentRow, i_Column).Value == i_PlayerSign.Value)
                {
                    onlySign = false;
                    break;
                }
            }

            for (int currentColumn = 0; currentColumn < m_Board.Height; currentColumn++)
            {
                if (m_Board.SignAtIndex(i_Row, currentColumn).Value == i_PlayerSign.Value)
                {
                    onlySign = false;
                    break;
                }
            }

            return onlySign;
        }

        private string firstGradeMove(Sign<char> i_PlayerSign, Sign<char> i_EnemySign, out bool i_IsBestMove)
        {
            i_IsBestMove = false;
            int minNumOfEnemySign = m_Board.Width - 2;
            int maxNumOfPlayerSign = 0;
            int bestRowMove = -1;
            int bestColumnMove = -1;
            for (int row = 0; row < m_Board.Height; row++)
            {
                for (int column = 0; column < m_Board.Width; column++)
                {
                    if (possibleDiagonalWin(row, column, i_PlayerSign) || possibleCrossWin(row, column, i_PlayerSign) || !m_Board.IsEmptyCell(row, column))
                    {
                        continue;
                    }

                    int numOfPlayerInRowAndColumn = numOfSignInRowAndColumn(row, column, i_PlayerSign);
                    int numOfEnemyInRowAndColumn = numOfSignInRowAndColumn(row, column, i_EnemySign);
                    if (minNumOfEnemySign >= numOfEnemyInRowAndColumn)
                    {
                        if (!possibleDiagonalWin(row, column, i_EnemySign) && !possibleCrossWin(row, column, i_EnemySign) &&
                            numOfEnemyInRowAndColumn == 0 && numOfPlayerInRowAndColumn >= maxNumOfPlayerSign)
                        {
                            bestRowMove = row;
                            bestColumnMove = column;
                            goto Finish;
                        }
                        else if (!possibleDiagonalWin(row, column, i_EnemySign) && !possibleCrossWin(row, column, i_EnemySign) && numOfPlayerInRowAndColumn >= maxNumOfPlayerSign)
                        {
                            minNumOfEnemySign = numOfEnemyInRowAndColumn;
                            maxNumOfPlayerSign = numOfPlayerInRowAndColumn;
                            bestRowMove = row;
                            bestColumnMove = column;
                        }
                        else if (!possibleDiagonalWin(row, column, i_EnemySign) && !possibleCrossWin(row, column, i_EnemySign))
                        {
                            minNumOfEnemySign = numOfEnemyInRowAndColumn;
                            maxNumOfPlayerSign = numOfPlayerInRowAndColumn;
                            bestRowMove = row;
                            bestColumnMove = column;
                        }
                    }
                }
            }

            Finish:
                string resultMove = "";
                if (bestColumnMove != -1 || bestRowMove != -1)
                {
                    bestColumnMove++;
                    bestRowMove++;
                    resultMove = bestRowMove.ToString() + bestColumnMove.ToString();
                    i_IsBestMove = true;
                }
                return resultMove;
        }

        public string BestMove(Sign<char> i_PlayerSign, Sign<char> i_EnemySign)
        {
            string resultMove;
            int minNumOfEnemySign = m_Board.Width - 2;
            int bestRowMove = -1;
            int bestColumnMove = -1;
            string bestMove = firstGradeMove(i_PlayerSign, i_EnemySign, out bool best);
            if (best)
            {
                resultMove = bestMove;
            }

            for (int row = 0; row < m_Board.Height; row++)
            {
                for (int column = 0; column < m_Board.Width; column++)
                {
                    if(!this.possibleDiagonalWin(row, column, i_PlayerSign)
                       && !this.possibleCrossWin(row, column, i_PlayerSign) && this.m_Board.IsEmptyCell(row, column))
                    {
                        bestColumnMove = column;
                        bestRowMove = row;
                        goto Finish;
                    }
                }
            }

            for (int row = 0; row < this.m_Board.Height; row++)
            {
                for (int column = 0; column < this.m_Board.Width; column++)
                {
                    if (this.m_Board.IsEmptyCell(row, column))
                    {
                        bestColumnMove = column;
                        bestRowMove = row;
                        goto Finish;
                    }
                }
            }

            Finish:
                bestColumnMove++;
                bestRowMove++;
                resultMove = bestRowMove.ToString() + bestColumnMove.ToString();
            return resultMove;
        }

        private int numOfSignInRowAndColumn(int i_Row, int i_Column, Sign<char> i_PlayerSign)
        {
            int numOfSign = 0;
            for (int index = 0; index < m_Board.Height; index++)
            {
                if (m_Board.SignAtIndex(index, i_Column).Value == i_PlayerSign.Value)
                {
                    numOfSign++;
                }

                if (m_Board.SignAtIndex(i_Row, index).Value == i_PlayerSign.Value)
                {
                    numOfSign++;
                }
            }

            return numOfSign;
        }

        public int NumOfPlays
        {
            set
            {
                this.m_NumOfPlays = value;
            }
        }
    }
}
