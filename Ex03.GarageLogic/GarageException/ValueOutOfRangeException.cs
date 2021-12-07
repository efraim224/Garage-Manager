using System;

namespace Ex03.GarageLogic.GarageException
{
    public class ValueOutOfRangeException : Exception
    {
        private readonly float r_MaxRangeValue;
        private readonly float r_MinRangeValue;
        private const string k_ExceptionMessage = "Value out of the range {0} : {1}";

        public ValueOutOfRangeException(float i_MaxRangeValue, float i_MinRangeValue) : base(string.Format(k_ExceptionMessage, i_MinRangeValue, i_MaxRangeValue))
        {
            this.r_MaxRangeValue = i_MaxRangeValue;
            this.r_MinRangeValue = i_MinRangeValue;
        }

        public float MaxValue
        {
            get { return this.r_MaxRangeValue; }
        }

        public float MinValue
        {
            get { return this.r_MinRangeValue; }
        }
    }
}

