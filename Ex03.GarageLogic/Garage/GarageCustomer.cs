using System.Text;
using Ex03.GarageLogic.Vehicles;
using Ex03.GarageLogic.Vehicles.VehicleSubParts.Wheel;

namespace Ex03.GarageLogic.Garage
{
    public class GarageCustomer
    {
        private string m_CustumerName;
        private string m_PhoneNumber;
        private Vehicle m_Vehicle;
        private eVehicleStatus m_VehicleStatus;

        public GarageCustomer(string i_CustumerName, string i_PhoneNumber, Vehicle i_Vehicle)
        {
            this.m_CustumerName = i_CustumerName;
            this.m_PhoneNumber = i_PhoneNumber;
            this.m_Vehicle = i_Vehicle;
            this.m_VehicleStatus = eVehicleStatus.InRepair;
        }

        public string VehicleLicenseNumber
        {
            get { return this.Vehicle.VehicleNumber; }
        }

        public eVehicleStatus VehicleStatus
        {
            get { return this.m_VehicleStatus; }
            set
            {
                this.m_VehicleStatus = value;
                this.Vehicle.Status = value;
            }
        }

        public override string ToString()
        {
            StringBuilder wheelsToString = new StringBuilder();
            int wheelIndex = 1;
            foreach (Wheel wheel in m_Vehicle.Wheels)
            {
                wheelsToString.AppendFormat("Wheel number {0} - {1}", wheelIndex, wheel.ToString());
                wheelsToString.AppendLine();
                wheelIndex++;
            }

            float currentEnergy = ((m_Vehicle.VehiclePower.RemainingEnergy / m_Vehicle.VehiclePower.MaxEnergyVolume) * 100);
            
            return string.Format(
@"Vehicle Number:             {0}
Model:                      {1}
Status:                     {2}
Costumer's name:            {3}
Costumer's phone number:    {4}
Current Energy:             {5}% - {6}
{7}
Wheels:
{8}
",
m_Vehicle.VehicleNumber,
m_Vehicle.ModelName,
m_VehicleStatus,
m_CustumerName,
m_PhoneNumber,
currentEnergy,
m_Vehicle.PowerType,
m_Vehicle.ToString(),
wheelsToString);
        }

        public Vehicle Vehicle
        {
            get
            {
                return this.m_Vehicle;
            }
        }
    }
}
