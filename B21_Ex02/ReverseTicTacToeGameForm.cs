using System.Windows.Forms;
using B21_Ex05.ReverseTicTacToeObjects;
using System.Drawing;
using System;

namespace B21_Ex05.FormInterface
{


    public class ReverseTicTacToeGameForm : Form
    {
        private ReverseTicTacToeSettingsForm m_SettingsForm;
        private Label m_FirstPlayerLabel;
        private Label m_SecondPlayerLabel;
        private int m_FirstPlayerScore;
        private int m_SecondPlayerScore;
        private TicTacToeButton[,] m_ButtonMatrix;
        private int m_NumOfRowsOrColumnInGame;
        private const int k_ButtonSize = 50;
        private const int k_PaddingBetweenButtons = 5;
        private const int k_SidePadding = 10;
        private const string k_GameName = "Reverse Tic Tac Toe";
        private const string k_TieMessage = "Tie! {0} Would you like to play another round?";
        private const string k_WinMessage = "The winner is {0}!{1} Would you like to play another round";
        private const string k_WinTitle = "A Win!";
        private const string k_TieTitle = "A Tie!";
        private ReverseTicTacToeGame m_Game;
        private Player m_CurrentPlayer;
        private eGameMode m_GameMode;
        private Player m_FirstPlayer;
        private Player m_SecondPlayer;
        DialogResult m_SettingFormResult;

        public ReverseTicTacToeGameForm()
        {
            initializeComponent();
            initializeGameComponent();
        }

        private void initializeGameComponent()
        {
            this.m_Game = new ReverseTicTacToeGame(new Board(this.m_NumOfRowsOrColumnInGame, this.m_NumOfRowsOrColumnInGame));
            this.m_GameMode = this.m_SettingsForm.GetGameMod;
            Sign<char> firstPlayerSign = new Sign<char>('X');
            this.m_FirstPlayer = new Player(this.m_SettingsForm.GetFirstPlayerName, firstPlayerSign);
            Sign<char> secondPlayerSign = new Sign<char>('O');
            this.m_SecondPlayer = this.m_GameMode == eGameMode.PlayerVsPlayer
                                      ? new Player(this.m_SettingsForm.GetSecondPlayerName, secondPlayerSign)
                                      : new Player(secondPlayerSign);
            this.m_CurrentPlayer = this.m_FirstPlayer;
            this.m_Game.GameWonNotifier += this.gameWin;
            this.m_Game.GameTieNotifier += this.gameTie;
        }

        public void Play()
        {
            if (this.GetSettingFormResult != DialogResult.Cancel)
            {
                this.ShowDialog();
            }
        }

        private void gameWin(char i_Value)
        {
            Player playerWin;
            if (this.m_FirstPlayer.Sign.Value == i_Value)
            {
                playerWin = this.m_SecondPlayer;
                this.m_SecondPlayerScore++;
            }
            else
            {
                playerWin = this.m_FirstPlayer;
                this.m_FirstPlayerScore++;
            }
            this.initializeScore();
            string congrats = string.Format(
                k_WinMessage,
                playerWin.Name,
                Environment.NewLine);

            DialogResult result = MessageBox.Show(congrats, k_WinTitle, MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                this.Close();
            }

            if (result == DialogResult.Yes)
            {
                setNewGame();
            }
        }

        private void gameTie()
        {
            string congrats = string.Format(
                k_TieMessage,
                Environment.NewLine);
            DialogResult result = MessageBox.Show(congrats, k_TieTitle, MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                this.Close();
            }

            if (result == DialogResult.Yes)
            {
                this.setNewGame();
            }
        }

        private void setNewGame()
        {
            this.m_Game.NumOfPlays = this.m_NumOfRowsOrColumnInGame * this.m_NumOfRowsOrColumnInGame;
            for (int i = 0; i < this.m_NumOfRowsOrColumnInGame; i++)
            {
                for (int j = 0; j < this.m_NumOfRowsOrColumnInGame; j++)
                {
                    this.m_ButtonMatrix[i, j].Enabled = true;
                    this.m_ButtonMatrix[i, j].Text = "";
                    this.m_Game.Board = new Board(this.m_NumOfRowsOrColumnInGame, this.m_NumOfRowsOrColumnInGame);
                }
            }
        }

        private void initializeComponent()
        {
            this.m_SettingsForm = new ReverseTicTacToeSettingsForm();
            m_SettingFormResult = m_SettingsForm.ShowDialog();
            this.m_NumOfRowsOrColumnInGame = this.m_SettingsForm.NumOfRowsAndColumn;
            int widthSize = 2 * k_SidePadding + this.m_NumOfRowsOrColumnInGame * (k_ButtonSize + k_PaddingBetweenButtons) + 15;
            int heightSize = widthSize + 40;
            this.Size = new Size(widthSize, heightSize);
            this.m_ButtonMatrix = new TicTacToeButton[this.m_NumOfRowsOrColumnInGame, this.m_NumOfRowsOrColumnInGame];
            this.createButtons(this.m_NumOfRowsOrColumnInGame, this.ClientSize);
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.StartPosition = FormStartPosition.CenterScreen;
            // text box for first player
            this.m_FirstPlayerLabel = new Label();
            this.m_FirstPlayerLabel.Location = new Point(20, this.ClientSize.Height - 20);
            // text box for second player
            this.m_SecondPlayerLabel = new Label();
            this.m_SecondPlayerLabel.Location = new Point(this.Width / 2, this.ClientSize.Height - 20);
            this.initializeScore();
            this.Controls.Add(this.m_FirstPlayerLabel);
            this.Controls.Add(this.m_SecondPlayerLabel);
            this.Text = k_GameName;
            
        }

        private void initializeScore()
        {
            string firstPlayerText = string.Format(
                "{0}: {1}",
                this.m_SettingsForm.GetFirstPlayerName,
                this.m_FirstPlayerScore);
            string secondPlayerText = string.Format(
                "{0}: {1}",
                this.m_SettingsForm.GetSecondPlayerName,
                this.m_SecondPlayerScore);
            this.m_FirstPlayerLabel.Text = firstPlayerText;
            this.m_SecondPlayerLabel.Text = secondPlayerText;
        }
        private void createButtons(int i_NumOfRows, Size i_Size)
        {
            int currentButtonWidth = k_SidePadding;
            int currentButtonHeight = k_SidePadding;
            for (int row = 0; row < i_NumOfRows; row++)
            {
                for (int column = 0; column < i_NumOfRows; column++)
                {
                    TicTacToeButton currentButton = new TicTacToeButton();
                    currentButton.Size = new Size(k_ButtonSize, k_ButtonSize);
                    currentButton.Location = new Point(currentButtonWidth, currentButtonHeight);
                    this.Controls.Add(currentButton);
                    this.m_ButtonMatrix[row, column] = currentButton;
                    currentButton.Row = row;
                    currentButton.Column = column;
                    currentButton.Click += this.Button_OnClick;
                    currentButtonWidth += k_PaddingBetweenButtons + k_ButtonSize;
                }

                currentButtonWidth = 10;
                currentButtonHeight += k_PaddingBetweenButtons + k_ButtonSize;
            }
        }

        private void Button_OnClick(object i_Sender, EventArgs i_E)
        {
            if (this.m_GameMode == eGameMode.PlayerVsAI)
            {
                TicTacToeButton currentButton = i_Sender as TicTacToeButton;
                this.m_Game.Board.MadeTurn += this.changeButtonValue;
                this.m_Game.Turn(currentButton.Row, currentButton.Column, this.m_CurrentPlayer.Sign, out bool won);
                this.m_Game.Board.MadeTurn -= this.changeButtonValue;
                string bestMove = this.m_Game.BestMove(this.m_SecondPlayer.Sign, this.m_FirstPlayer.Sign);
                makeAiTurn(bestMove, this.m_SecondPlayer.Sign);
            }
            else
            {
                TicTacToeButton currentButton = i_Sender as TicTacToeButton;
                this.m_Game.Board.MadeTurn += this.changeButtonValue;
                this.m_Game.Turn(currentButton.Row, currentButton.Column, this.m_CurrentPlayer.Sign, out bool won);
                this.m_Game.Board.MadeTurn -= this.changeButtonValue;
            }
        }

        
        private void makeAiTurn(string i_BestMove, Sign<char> i_Sign)
        {
            int row = i_BestMove[0] - '1';
            int col = i_BestMove[1] - '1';
            this.m_Game.Board.MadeTurn += this.changeButtonValue;
            this.m_Game.Turn(row, col, i_Sign, out bool won);
            this.m_Game.Board.MadeTurn -= this.changeButtonValue;
        }

        private void changeButtonValue(int i_Row, int i_Column, Sign<char> i_Sign)
        {
            string str = "" + i_Sign.Value;
            this.m_ButtonMatrix[i_Row, i_Column].Text = str;
            this.m_ButtonMatrix[i_Row, i_Column].Enabled = false;
            if (this.m_CurrentPlayer == this.m_FirstPlayer)
            {
                this.m_CurrentPlayer = this.m_SecondPlayer;
            }
            else
            {
                this.m_CurrentPlayer = this.m_FirstPlayer;
            }
        }

        public DialogResult GetSettingFormResult
        {
            get { return this.m_SettingFormResult; }
        }
    }
}
