namespace B21_Ex05.ReverseTicTacToeObjects
{
    public class Player
    { 
        private const string k_AIPlayerName = "Computer";
        private readonly string r_Name;
        private readonly bool r_IsAI;
        private int m_Score;

        private readonly Sign<char> r_PlayerSign;

        public Player(string i_PlayerName, Sign<char> i_PlayerSign)
        {
            r_Name = i_PlayerName;
            r_IsAI = false;
            r_PlayerSign = i_PlayerSign;
        }

        public Player(Sign<char> i_PlayerSign) // Creating AI player
        {
            r_Name = k_AIPlayerName;
            r_IsAI = true;
            r_PlayerSign = i_PlayerSign;
        }

        public string Name
        {
            get
            {
                return this.r_Name;
            }
        }

        public Sign<char> Sign
        {
            get
            {
                return this.r_PlayerSign;
            }
        }

        public bool IsAI
        {
            get
            {
                return this.r_IsAI;
            }
        }

        public int PlayerScore
        {
            get
            {
                return this.m_Score;
            }

            set
            {
                this.m_Score = value;
            }
        }
    }
}
