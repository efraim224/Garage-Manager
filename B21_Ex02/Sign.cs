namespace B21_Ex05.ReverseTicTacToeObjects
{
    public struct Sign<T>
    {
        private T m_Value;

        
        public Sign(T i_Value)
        {
            this.m_Value = i_Value;
        }

        public T Value
        {
            get
            {
                return this.m_Value;
            }

            set
            {
                this.m_Value = value;
            }
        }
    }
}
