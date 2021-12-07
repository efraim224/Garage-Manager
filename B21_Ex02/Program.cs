using B21_Ex05.FormInterface;

namespace B21_Ex05
{
    public class Program
    {
        public static void Main()
        {
            playTicTacToeGame();
        }   

        private static void playTicTacToeGame()
        {
            ReverseTicTacToeGameForm game = new ReverseTicTacToeGameForm();
            game.Play();
        }
    }
}
