using System;
using Ex03.GarageLogic.Garage;
using Ex03.GarageLogic.GarageException;

namespace Ex03.GarageLogic.Vehicles.VehicleSubParts.SourceOfPower
{
    public class GasolinePower : PowerSource
    {
        private readonly eGasolineType r_GasolineType;
        private const string k_WrongGasolineUsedMessage = "Wrong gasoline type was used. Please insert {0} instead of {1}";

        public GasolinePower(eGasolineType i_GasolineType, float i_MaxGasolineVolume) : base(i_MaxGasolineVolume)
        {
            r_GasolineType = i_GasolineType;
        }

        public void Refuel(float i_RefuelAmount, eGasolineType i_FuelType)
        {
            if(r_GasolineType != i_FuelType)
            {
                string errorMessage = string.Format(k_WrongGasolineUsedMessage, r_GasolineType, i_FuelType);
                throw new ArgumentException(errorMessage);
            }
            else
            {
                float fuelToBeAdded = i_RefuelAmount + this.RemainingEnergy;

                if(fuelToBeAdded > this.MaxEnergyVolume)
                {
                    throw new ValueOutOfRangeException(this.MaxEnergyVolume, GarageVehicleList.k_MinimalVolume);
                }
                else
                {
                    base.RemainingEnergy = i_RefuelAmount;
                }
            }
        }

        public eGasolineType GasolineType
        {
            get { return this.r_GasolineType; }
        }
    }
}
