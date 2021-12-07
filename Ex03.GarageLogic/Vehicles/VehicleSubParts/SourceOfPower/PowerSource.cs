namespace Ex03.GarageLogic.Vehicles.VehicleSubParts.SourceOfPower
{
    using Ex03.GarageLogic.GarageException;

    public enum ePowerSource
    {
        Electricity,
        Gasoline
    }

    public abstract class PowerSource
    {
        private readonly float r_MaxEnergyVolume;
        private float m_RemainingEnergy;

        public PowerSource(float i_MaxEnergyVolume)
        {
            r_MaxEnergyVolume = i_MaxEnergyVolume;
        }

        public void EnergyToMax()
        {
            this.RemainingEnergy = this.r_MaxEnergyVolume;
        }

        public bool insertEnergyToPowerSource(float i_energyToInsert)
        {
            bool IsInserted = false;

            if(this.MaxEnergyVolume >= RemainingEnergy + i_energyToInsert)
            {
                IsInserted = true;
                this.RemainingEnergy += i_energyToInsert;
            }
            else
            {
                throw new ValueOutOfRangeException(this.MaxEnergyVolume - this.RemainingEnergy, 0);
            }

            return IsInserted;
        }

        public float RemainingEnergy
        {
            get { return this.m_RemainingEnergy; }
            set { this.m_RemainingEnergy = value; }
        }

        public float MaxEnergyVolume
        {
            get { return this.r_MaxEnergyVolume; }
        }
    }
}
