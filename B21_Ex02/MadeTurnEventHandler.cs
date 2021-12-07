using B21_Ex05.ReverseTicTacToeObjects;

namespace B21_Ex05.GameEvents
{
    public delegate void MadeTurnEventHandler(int i_Row, int i_Column, Sign<char> i_Sign);
}