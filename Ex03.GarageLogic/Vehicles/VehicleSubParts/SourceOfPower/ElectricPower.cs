using Ex03.GarageLogic.Garage;
using Ex03.GarageLogic.GarageException;

namespace Ex03.GarageLogic.Vehicles.VehicleSubParts.SourceOfPower
{
    public class ElectricPower : PowerSource
    {
        public ElectricPower(float i_MaxBatteryVolume) : base(i_MaxBatteryVolume)
        {
        }

        public void Recharge(float i_ChargingAmount)
        {
            float electricityToBeCharged = i_ChargingAmount + this.RemainingEnergy;
            if(electricityToBeCharged > this.MaxEnergyVolume || i_ChargingAmount < 0)
            {
                throw new ValueOutOfRangeException(this.MaxEnergyVolume, GarageVehicleList.k_MinimalVolume);
            }
            else
            {
                this.RemainingEnergy = electricityToBeCharged;
            }
        }
    }
}
