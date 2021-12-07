using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using B21_Ex05.ReverseTicTacToeObjects;

namespace B21_Ex05.FormInterface
{
    public class ReverseTicTacToeSettingsForm : Form
    {
        private Button m_StartButton;
        private Label m_Player1Label;
        private Label m_RowsLabel;
        private Label m_ColsLabel;
        private Label m_BoardSizeLabel;
        private TextBox m_FirstPlayerNameTextBox;
        private TextBox m_SecondPlayerNameTextBox;
        private CheckBox m_SecondPlayerEnableCheckBox;
        private NumericUpDown m_NumOfRows;
        private NumericUpDown m_NumOfCols;
        private Label m_PlayersLabel;
        private const string k_ComputerString = "[Computer]";
        private const string k_InsertANameMessage = "You must insert a name for the {0} player";
        private eGameMode m_GameMod; 

        public ReverseTicTacToeSettingsForm()
        {
            InitializeComponent();
            initializeGameMode();
        }

        private void initializeGameMode()
        {
            m_GameMod = eGameMode.PlayerVsAI;
        }

        private void InitializeComponent()
        {
            this.m_StartButton = new Button();
            this.m_PlayersLabel = new Label();
            this.m_Player1Label = new Label();
            this.m_RowsLabel = new Label();
            this.m_ColsLabel = new Label();
            this.m_BoardSizeLabel = new Label();
            this.m_FirstPlayerNameTextBox = new TextBox();
            this.m_SecondPlayerNameTextBox = new TextBox();
            this.m_SecondPlayerEnableCheckBox = new CheckBox();
            this.m_NumOfRows = new NumericUpDown();
            this.m_NumOfCols = new NumericUpDown();
            ((ISupportInitialize)(this.m_NumOfRows)).BeginInit();
            ((ISupportInitialize)(this.m_NumOfCols)).BeginInit();
            this.SuspendLayout();
            // 
            // m_StartButton
            // 
            this.m_StartButton.Location = new Point(12, 284);
            this.m_StartButton.Name = "m_StartButton";
            this.m_StartButton.Size = new Size(466, 34);
            this.m_StartButton.TabIndex = 0;
            this.m_StartButton.Text = "Start!";
            this.m_StartButton.UseVisualStyleBackColor = true;
            this.m_StartButton.Click += this.m_StartButton_Click;
            // 
            // m_PlayersLabel
            // 
            this.m_PlayersLabel.AutoSize = true;
            this.m_PlayersLabel.Location = new Point(52, 42);
            this.m_PlayersLabel.Name = "m_PlayersLabel";
            this.m_PlayersLabel.Size = new Size(59, 17);
            this.m_PlayersLabel.TabIndex = 1;
            this.m_PlayersLabel.Text = "Players:";
            // 
            // m_Player1Label
            // 
            this.m_Player1Label.AutoSize = true;
            this.m_Player1Label.Location = new Point(91, 80);
            this.m_Player1Label.Name = "m_Player1Label";
            this.m_Player1Label.Size = new Size(64, 17);
            this.m_Player1Label.TabIndex = 2;
            this.m_Player1Label.Text = "Player 1:";
            // 
            // m_RowsLabel
            // 
            this.m_RowsLabel.AutoSize = true;
            this.m_RowsLabel.Location = new Point(117, 231);
            this.m_RowsLabel.Name = "m_RowsLabel";
            this.m_RowsLabel.Size = new Size(46, 17);
            this.m_RowsLabel.TabIndex = 6;
            this.m_RowsLabel.Text = "Rows:";
            // 
            // m_ColsLabel
            // 
            this.m_ColsLabel.AutoSize = true;
            this.m_ColsLabel.Location = new Point(343, 231);
            this.m_ColsLabel.Name = "m_ColsLabel";
            this.m_ColsLabel.Size = new Size(39, 17);
            this.m_ColsLabel.TabIndex = 8;
            this.m_ColsLabel.Text = "Cols:";
            // 
            // m_BoardSizeLabel
            // 
            this.m_BoardSizeLabel.AutoSize = true;
            this.m_BoardSizeLabel.Location = new Point(52, 205);
            this.m_BoardSizeLabel.Name = "m_BoardSizeLabel";
            this.m_BoardSizeLabel.Size = new Size(81, 17);
            this.m_BoardSizeLabel.TabIndex = 10;
            this.m_BoardSizeLabel.Text = "Board Size:";
            // 
            // m_FirstPlayerNameTextBox
            // 
            this.m_FirstPlayerNameTextBox.Location = new Point(241, 77);
            this.m_FirstPlayerNameTextBox.Name = "m_FirstPlayerNameTextBox";
            this.m_FirstPlayerNameTextBox.Size = new Size(219, 22);
            this.m_FirstPlayerNameTextBox.TabIndex = 11;
            // 
            // m_SecondPlayerNameTextBox
            // 
            this.m_SecondPlayerNameTextBox.Enabled = false;
            this.m_SecondPlayerNameTextBox.Location = new Point(241, 125);
            this.m_SecondPlayerNameTextBox.Name = "m_SecondPlayerNameTextBox";
            this.m_SecondPlayerNameTextBox.Size = new Size(219, 22);
            this.m_SecondPlayerNameTextBox.TabIndex = 13;
            this.m_SecondPlayerNameTextBox.Text = "[Computer]";
            // 
            // m_SecondPlayerEnableCheckBox
            // 
            this.m_SecondPlayerEnableCheckBox.AutoSize = true;
            this.m_SecondPlayerEnableCheckBox.Location = new Point(94, 127);
            this.m_SecondPlayerEnableCheckBox.Name = "m_SecondPlayerEnableCheckBox";
            this.m_SecondPlayerEnableCheckBox.Size = new Size(86, 21);
            this.m_SecondPlayerEnableCheckBox.TabIndex = 14;
            this.m_SecondPlayerEnableCheckBox.Text = "Player 2:";
            this.m_SecondPlayerEnableCheckBox.UseVisualStyleBackColor = true;
            this.m_SecondPlayerEnableCheckBox.CheckedChanged += this.checkBox1_CheckedChanged;
            // 
            // m_NumOfRows
            // 
            this.m_NumOfRows.Location = new Point(192, 226);
            this.m_NumOfRows.Maximum = ReverseTicTacToeGame.k_MaxBoardHeight;
            this.m_NumOfRows.Minimum = ReverseTicTacToeGame.k_MinBoardHeight;
            this.m_NumOfRows.Name = "m_NumOfRows";
            this.m_NumOfRows.Size = new Size(41, 22);
            this.m_NumOfRows.TabIndex = 15;
            this.m_NumOfRows.Value = ReverseTicTacToeGame.k_MinBoardHeight;
            this.m_NumOfRows.ValueChanged += this.m_NumOfRows_ValueChanged;
            // 
            // m_NumOfCols
            // 
            this.m_NumOfCols.Location = new Point(419, 226);
            this.m_NumOfCols.Maximum = ReverseTicTacToeGame.k_MaxBoardWidth;
            this.m_NumOfCols.Minimum = ReverseTicTacToeGame.k_MinBoardWidth;
            this.m_NumOfCols.Name = "m_NumOfCols";
            this.m_NumOfCols.Size = new Size(41, 22);
            this.m_NumOfCols.TabIndex = 16;
            this.m_NumOfCols.Value = ReverseTicTacToeGame.k_MinBoardWidth;
            this.m_NumOfCols.ValueChanged += this.m_NumOfCols_ValueChanged;
            // 
            // ReverseTicTacToeSettingsForm
            // 
            this.ClientSize = new Size(490, 341);
            this.Controls.Add(this.m_NumOfCols);
            this.Controls.Add(this.m_NumOfRows);
            this.Controls.Add(this.m_SecondPlayerEnableCheckBox);
            this.Controls.Add(this.m_SecondPlayerNameTextBox);
            this.Controls.Add(this.m_FirstPlayerNameTextBox);
            this.Controls.Add(this.m_BoardSizeLabel);
            this.Controls.Add(this.m_ColsLabel);
            this.Controls.Add(this.m_RowsLabel);
            this.Controls.Add(this.m_Player1Label);
            this.Controls.Add(this.m_PlayersLabel);
            this.Controls.Add(this.m_StartButton);
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.Name = "ReverseTicTacToeSettingsForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Game Settings";
            ((ISupportInitialize)(this.m_NumOfRows)).EndInit();
            ((ISupportInitialize)(this.m_NumOfCols)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox secondPlayerCheckBox = sender as CheckBox;

            if (secondPlayerCheckBox.CheckState == CheckState.Checked)
            {
                this.m_GameMod = eGameMode.PlayerVsPlayer;
                this.m_SecondPlayerNameTextBox.Enabled = true;
                this.m_SecondPlayerNameTextBox.Text = "";
            }
            else if (secondPlayerCheckBox.CheckState == CheckState.Unchecked)
            {
                this.m_GameMod = eGameMode.PlayerVsAI;
                this.m_SecondPlayerNameTextBox.Enabled = false;
                this.m_SecondPlayerNameTextBox.Text = k_ComputerString;
            }
        }

        public string GetFirstPlayerName
        {
            get { return this.m_FirstPlayerNameTextBox.Text; }
        }

        public string GetSecondPlayerName
        {
            get { return this.m_SecondPlayerNameTextBox.Text; }
        }

        public eGameMode GetGameMod
        {
            get { return this.m_GameMod; }
        }

        public int NumOfRowsAndColumn
        {
            get { return (int)this.m_NumOfRows.Value; }
        }

        private void m_NumOfRows_ValueChanged(object sender, EventArgs e)
        {
            this.m_NumOfCols.Value = ((NumericUpDown)sender).Value;
        }

        private void m_NumOfCols_ValueChanged(object sender, EventArgs e)
        {
            this.m_NumOfRows.Value = ((NumericUpDown)sender).Value;
        }

        private void m_StartButton_Click(object sender, EventArgs e)
        {
            if(!isValidName(m_FirstPlayerNameTextBox.Text))
            {
                this.m_FirstPlayerNameTextBox.Text = "";
                MessageBox.Show(string.Format(k_InsertANameMessage, "first"));
            }
            else if(this.m_SecondPlayerEnableCheckBox.Checked && !isValidName(m_SecondPlayerNameTextBox.Text))
            {
                this.m_SecondPlayerNameTextBox.Text = "";
                MessageBox.Show(string.Format(k_InsertANameMessage, "second"));
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool isValidName(string i_PlayerName)
        {
            bool isValidName = true;

            if (i_PlayerName.Replace(" ", string.Empty).Length == 0)
            {
                isValidName = false;
            }

            return isValidName;
        }
    }
}
