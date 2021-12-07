using System.Text;
using System.Collections.Generic;
using Ex03.GarageLogic.Vehicles.VehicleSubParts.SourceOfPower;
using Ex03.GarageLogic.Vehicles.VehicleSubParts.Wheel;

namespace Ex03.GarageLogic.Vehicles
{
    public abstract class Vehicle
    {
        private string m_ModelName;
        private string m_VehicleNumber;
        private PowerSource m_VehiclePowerSource;
        private List<Wheel> m_Wheels;
        private eVehicleStatus m_Status;
        private ePowerSource m_PowerType;
        internal const string k_InvalidUserInputMessage = "The input {0} is invalid";

        public Vehicle(string i_LicenceNumber, string i_ModelName,  PowerSource i_VehiclePowerSource)
        {
            this.m_ModelName = i_ModelName;
            this.m_VehicleNumber = i_LicenceNumber;
            this.m_VehiclePowerSource = i_VehiclePowerSource;
            this.m_Wheels = new List<Wheel>();
            if (i_VehiclePowerSource is GasolinePower)
            {
                this.m_PowerType = ePowerSource.Gasoline;
            }
        }

        public ePowerSource PowerType
        {
            get { return this.m_PowerType; }
            set { this.m_PowerType = value; }
        }

        public void InsertWheel(Wheel i_Wheel)
        {
            this.m_Wheels.Add(i_Wheel);
        }

        public string ToPrint()
        {
            StringBuilder message = new StringBuilder();
            switch(m_PowerType)
            {
                case ePowerSource.Electricity:
                    message.Append("Electic ");
                    break;
                case ePowerSource.Gasoline:
                    message.Append("Gasoline ");
                    break;
            }
            message.Append(this.GetType().Name);

            return message.ToString();
        }


        public void SetWheelsManufacture(string i_Manufactor)
        {
            foreach(Wheel wheel in Wheels)
            {
                wheel.ManufacturerName = i_Manufactor;
            }
        }

        public string ModelName
        {
            get
            {
                return this.m_ModelName;
            }

            set
            {
                this.m_ModelName = value;
            }
        }

        public string VehicleNumber
        {
            get
            {
                return this.m_VehicleNumber;
            }

            set
            {
                this.m_VehicleNumber = value;
            }
        }

        public PowerSource VehiclePower
        {
            get
            {
                return this.m_VehiclePowerSource;
            }

            set
            {
                this.m_VehiclePowerSource = value;
            }
        }

        public List<Wheel> Wheels
        {
            get
            {
                return this.m_Wheels;
            }

            set
            {
                this.m_Wheels = value;
            }
        }

        public eVehicleStatus Status
        {
            get
            {
                return this.m_Status;
            }

            set
            {
                this.m_Status = value;
            }
        }

        public void SetAllWheelsCurrentPressure(float i_CurrentPressure)
        {
            foreach (Wheel wheel in m_Wheels)
            {
                wheel.CurrentAirPressure = i_CurrentPressure;
            }
        }

        public virtual string[] GetSpecificParams
        {
            get { return null; }
            set { }
        }

        public virtual void SetSpecificParam(string i_Original, string i_User)
        {
        }
    }
}
