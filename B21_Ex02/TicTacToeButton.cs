namespace B21_Ex05.FormInterface
{
    using System.Windows.Forms;

    class TicTacToeButton : Button
    {
        private Button m_Button;
        private int m_Row;
        private int m_Column;

        public TicTacToeButton() : base()
        {
        }

        public int Row
        {
            get
            {
                return this.m_Row;
            }
            set
            {
                this.m_Row = value;
            }
        }
        public int Column
        {
            get
            {
                return this.m_Column;
            }
            set
            {
                this.m_Column = value;
            }
        }
    }
}
