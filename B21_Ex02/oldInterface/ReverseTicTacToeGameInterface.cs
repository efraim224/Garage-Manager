using B21_Ex05.ReverseTicTacToeObjects;
//using Ex02.ConsoleUtils;
using System;
using System.Threading;

namespace B21_Ex05.ReverseTicTacToeInterface
{
    public class ReverseTicTacToeGameInterface
    {
        private const string k_WelcomeMessage = "Welcome! Let's Play TicTacToe!";
        private const string k_SelectGameModeMessage = "Please select a game mod: 1 - player vs player, 2 - player vs computer";
        private const string k_GetPlayerNameMessage = "Please, enter your name:";
        private const string k_CurrentPlayerTurnMessage = "{0}'s turn";
        private const string k_QuitGameMessage = "You decided to quit the game, Bye Bye! (Press 'Enter' to close)";
        private const string k_TerminateGameInstruction = "You may enter 'Q' at any point to quit the game.";
        private const string k_GameOverTie = "GAME OVER!, It's a tie.";
        private const string k_WinnerCongrats = "GAME OVER!, The winner is: {0} !!!";
        private const string k_PlayAgainMessage = "Would you like to play again? [y/n]";
        private const string k_PickAPositionMessage = "Pick a position (row and col)";
        private const string k_InvalidBoardPosition = "Wrong position! please try again";
        private const string k_CellIsNotEmpty = "Cell in not emptry. please re-enter";
        private const string k_PlayerWonThisRound = "{0} won this round";
        private const string k_TieForThisRound = "No winners this round, you got a tie!";
        private const string k_GreetSecondPlayer = "Now for the socend player";
        internal const string k_No = "n";
        internal const string k_Yes = "y";
        internal const string k_TerminateGameSignal = "Q";
        internal const char k_FirstPlayerSign = 'X';
        internal const char k_SecondPlayerSign = 'O';
        private bool m_GameIsTerminated = false;
        private Board m_Board;
        private Player m_Player1;
        private Player m_Player2;
        private Player m_CurrentPlayer;
        private bool m_PlayAgain;
        private ReverseTicTacToeGame m_Game;
        private int m_BoardHeight;
        private int m_BoardWidth;
        internal const int k_InputLength = 2;
/*
        internal void Start()
        {
            initializeGame();
        }

        // $G$ CSS-999 (-5) Public/Internal methods should start with an uppercase letter
        public void initializeGame()
        {
            Console.WriteLine(k_WelcomeMessage);
            m_Player1 = playerLoader(new Sign<char>(k_FirstPlayerSign));
            eGameMode mode = gameModeLoader();
            m_PlayAgain = true;
            setBoard();

            if (mode == eGameMode.PlayerVsPlayer)
            {
                m_Player2 = playerLoader(new Sign<char>(k_SecondPlayerSign));
            }
            else
            {
                m_Player2 = new Player(new Sign<char>(k_SecondPlayerSign)); // AI player
            }

            this.m_Game = new ReverseTicTacToeGame(m_Board);
            while (m_PlayAgain)
            {
                m_PlayAgain = false;
                newGame();
            }
        }

        private void newGame()
        {
            play();
        }

        private void play()
        {
            int numberOfCellsLeft = m_Board.Height * m_Board.Width;

            m_CurrentPlayer = m_Player1;
            m_Board.CleanBoard();
            m_Board = new Board(this.m_BoardHeight, this.m_BoardWidth);
            this.m_Game.Board = m_Board;
            printBoard();
            while (numberOfCellsLeft > 0)
            {
                string playerMove = askPlayerForMove(out bool readSucceed);
                if (readSucceed && !m_GameIsTerminated)
                {
                    bool currentPlayerWon;
                    Console.WriteLine(playerMove);
                    int row = playerMove[0] - '1';
                    int col = playerMove[1] - '1';
                    this.m_Game.Turn(row, col, m_CurrentPlayer.Sign, out currentPlayerWon);
                    if (currentPlayerWon)
                    {
                        switchPlayers();
                        m_CurrentPlayer.PlayerScore++;
                        printBoard();
                        Console.Write(k_PlayerWonThisRound, m_CurrentPlayer.Name);
                        break;
                    }
                    else
                    {
                        numberOfCellsLeft--;
                        switchPlayers();
                    }
                }
                else
                {
                    break;
                }

                printBoard();
            }

            if (numberOfCellsLeft == 0)
            {
                Console.WriteLine(k_TieForThisRound);
            }

            gameOver();
        }

        private void setBoard()
        {
            InputReader.ReadBoardDimensions(out this.m_BoardHeight, out this.m_BoardWidth);
            m_Board = new Board(this.m_BoardHeight, this.m_BoardWidth);
        }

        private string askPlayerForMove(out bool o_ReadSucceed)
        {
            string cellPosition;

            Console.WriteLine(k_CurrentPlayerTurnMessage, m_CurrentPlayer.Name);
            if (m_CurrentPlayer.IsAI)
            {
                Thread.Sleep(1000);
                cellPosition = computerMove();
                o_ReadSucceed = true;
            }
            else
            {
                cellPosition = readPlayerMove(out o_ReadSucceed);
            }

            return cellPosition;
        }

        private string computerMove()
        {
            return this.m_Game.BestMove(m_Player2.Sign, m_Player1.Sign);
        }

        private string readPlayerMove(out bool o_ReadSucceed)
        {
            string cellPosition = readCardPosition();

            while (cellPosition != k_TerminateGameSignal && !InputChecker.IsAFreeCell(m_Board, cellPosition))
            {
                Console.WriteLine(k_CellIsNotEmpty);
                cellPosition = readCardPosition();
            }

            o_ReadSucceed = cellPosition != k_TerminateGameSignal;
            m_GameIsTerminated = cellPosition == k_TerminateGameSignal;

            return cellPosition;
        }

        private string readCardPosition()
        {
            Console.WriteLine("{0}, {1}", m_CurrentPlayer.Name, k_PickAPositionMessage);
            string input = Console.ReadLine();

            while (!InputChecker.IsValidTurn(input, m_Board))
            {
                Console.WriteLine(k_InvalidBoardPosition);
                input = Console.ReadLine();
            }

            return input;
        }


        private void gameOver()
        {
            string input;

            if (m_GameIsTerminated)
            {
                Console.WriteLine(k_QuitGameMessage);
                Console.ReadLine();
            }
            else
            {
                if (m_Player1.PlayerScore == m_Player2.PlayerScore)
                {
                    Console.WriteLine(k_GameOverTie);
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine(k_WinnerCongrats, getWinner());
                }

                Console.WriteLine(k_PlayAgainMessage);
                input = InputReader.ReadPlayAgainInstruction();

                if (input == k_Yes)
                {
                    m_PlayAgain = true;
                }
                else if (input == k_No)
                {
                    Console.WriteLine(k_QuitGameMessage);
                    Console.ReadLine();
                }
            }
        }

        private string getWinner()
        {
            string winnerName;

            if (m_Player1.PlayerScore > m_Player2.PlayerScore)
            {
                winnerName = m_Player1.Name;
            }
            else
            {
                winnerName = m_Player2.Name;
            }

            return winnerName;
        }

        private void printBoard()
        {
            //Screen.Clear();
            Console.WriteLine(k_TerminateGameInstruction);
            printScores();
            m_Board.ShowBoard();
        }

        private void printScores()
        {
            Console.WriteLine("Score balance: {0} : {1}  |  {2} : {3}", m_Player1.Name, m_Player1.PlayerScore, m_Player2.Name, m_Player2.PlayerScore);
            Console.WriteLine();
        }

        private eGameMode gameModeLoader()
        {
            Console.WriteLine(k_SelectGameModeMessage);

            return InputReader.ReadGameMode();
        }

        private Player playerLoader(Sign<char> i_PlayerSign)
        {
            if (i_PlayerSign.Value == k_SecondPlayerSign)
            {
                Console.WriteLine(k_GreetSecondPlayer);
            }

            Console.WriteLine(k_GetPlayerNameMessage);
            string playerName = InputReader.ReadPlayerName();

            return new Player(playerName, i_PlayerSign);
        }

        private void switchPlayers()
        {
            m_CurrentPlayer = m_CurrentPlayer == m_Player1 ? m_Player2 : m_Player1;
        }*/
    }
}
