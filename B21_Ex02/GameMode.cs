namespace B21_Ex05.ReverseTicTacToeObjects
{
    internal class GameMode
    {
        private static eGameMode s_GameMode;

        public static eGameMode Parse(string i_PlayerMode)
        {
            switch (i_PlayerMode)
            {
                case "1":
                    s_GameMode = eGameMode.PlayerVsPlayer;
                    break;

                case "2":
                    s_GameMode = eGameMode.PlayerVsAI;
                    break;
            }

            return s_GameMode;
        }
    }
}
