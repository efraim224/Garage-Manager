using Ex03.GarageLogic.GarageException;

namespace Ex03.GarageLogic.Vehicles.VehicleSubParts.Wheel
{
    public class Wheel
    {
        private const string K_InvalidAirPressure = "Invalid air pressure";
        private readonly float r_MaxAirPressure;
        private string m_ManufacturerName;
        private float m_CurrentAirPressure;

        public Wheel(float i_MaxAirPressure)
        {
            r_MaxAirPressure = i_MaxAirPressure;
        }

        public void AddAir(float i_AirToInsert)
        {
            if(this.m_CurrentAirPressure + i_AirToInsert <= this.r_MaxAirPressure && i_AirToInsert >= 0)
            {
                this.m_CurrentAirPressure += i_AirToInsert;
            }
            else
            {
                throw new ValueOutOfRangeException(r_MaxAirPressure, 0f);
            }
        }

        public void SetAirPressureToMax()
        {
            this.CurrentAirPressure = r_MaxAirPressure;
        }

        public string ManufacturerName
        {
            get { return this.m_ManufacturerName; }
            set { this.m_ManufacturerName = value; }
        }

        public float CurrentAirPressure
        {
            get { return this.m_CurrentAirPressure; }
            set {
                if(value <= this.r_MaxAirPressure && value >= 0)
                {
                    this.m_CurrentAirPressure = value;
                }
                else
                {
                    throw new ValueOutOfRangeException(r_MaxAirPressure, 0f);
                }
            }
        }

        public float MaxAirPressure
        {
            get { return this.r_MaxAirPressure; }
        }

        public override string ToString()
        {
            return string.Format("Manufacturer: {0} - Air pressure: {1}/{2}", m_ManufacturerName, m_CurrentAirPressure, r_MaxAirPressure);
        }
    }
}
