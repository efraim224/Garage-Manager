using System.Collections.Generic;
using Ex03.GarageLogic.Vehicles.VehicleSubParts.SourceOfPower;
using Ex03.GarageLogic.Vehicles;
using Ex03.GarageLogic.Vehicles.VehicleSubParts.Wheel;

namespace Ex03.GarageLogic.Garage
{
    public class Garage
    {
        private const string k_CustomerNotFoundMessage = "Costumer who's license number is {0} not found in garage";
        private Dictionary<string, GarageCustomer> m_CustomerList;

        public Garage()
        {
            this.m_CustomerList = new Dictionary<string, GarageCustomer>();
        }

        public void AddCustomer(GarageCustomer i_GarageCustomer)
        {
            m_CustomerList.Add(i_GarageCustomer.VehicleLicenseNumber, i_GarageCustomer);
        }
        
        public bool IsVehicleInGarage(string i_VehicleLicenseNumber)
        {
            bool inGarage = m_CustomerList.ContainsKey(i_VehicleLicenseNumber);

            return inGarage;
        }

        public void RefuelGasolineVehicle(string i_VehicleLicence, eGasolineType i_GasolineType, float i_Amount)
        {
            if(m_CustomerList.TryGetValue(i_VehicleLicence, out GarageCustomer customer))
            {
                GasolinePower gasolineToBeRefuel = (GasolinePower)customer.Vehicle.VehiclePower;
                gasolineToBeRefuel.Refuel(i_Amount, i_GasolineType);
            }
            else
            {
                string message = string.Format(k_CustomerNotFoundMessage, i_VehicleLicence);
                throw new KeyNotFoundException(message);
            }
        }

        public void RechargeElectricVehicle(string i_VehicleLicence, float i_Amount)
        {
            if (m_CustomerList.TryGetValue(i_VehicleLicence, out GarageCustomer customer))
            {
                ElectricPower electricityToRecharge = (ElectricPower)customer.Vehicle.VehiclePower;
                electricityToRecharge.Recharge(i_Amount);
            }
            else
            {
                string message = string.Format(k_CustomerNotFoundMessage, i_VehicleLicence);
                throw new KeyNotFoundException(message);
            }
        }

        public void ChangeVehicleStatus(string i_VehicleLicence, eVehicleStatus i_NewVehicleStatus)
        {
            if(m_CustomerList.TryGetValue(i_VehicleLicence, out GarageCustomer customer))
            {
                customer.VehicleStatus = i_NewVehicleStatus;
            }
            else
            {
                string message = string.Format(k_CustomerNotFoundMessage, i_VehicleLicence);
                throw new KeyNotFoundException(message);
            }
        }

        public void InflateAllWheelToMax(string i_VehicleLicense)
        {
            if(m_CustomerList.TryGetValue(i_VehicleLicense, out GarageCustomer customer))
            {
                Vehicle vehicle = m_CustomerList[i_VehicleLicense].Vehicle;
                foreach (Wheel wheel in vehicle.Wheels)
                    {
                        wheel.SetAirPressureToMax();
                    }   
            }
            else
            {
                string message = string.Format(k_CustomerNotFoundMessage, i_VehicleLicense);
                throw new KeyNotFoundException(message);
            }
        }

        public string VehicleParameters(string i_CarLicence)
        {
            string.Format("");
            return base.ToString();
        }

        public Dictionary<string, GarageCustomer> CustomerList
        {
            get
            {
                return this.m_CustomerList;
            }
        }
    }
}
