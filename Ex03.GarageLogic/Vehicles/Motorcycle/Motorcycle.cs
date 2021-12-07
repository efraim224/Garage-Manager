using System;
using Ex03.GarageLogic.Garage;
using Ex03.GarageLogic.Vehicles.VehicleSubParts.Wheel;
using Ex03.GarageLogic.Vehicles.VehicleSubParts.SourceOfPower;

namespace Ex03.GarageLogic.Vehicles.Motorcycle
{
    public class Motorcycle : Vehicle
    {
        private const string k_MotorcycleDrivingLicenceString = "license Type: [1]A, [2]AA, [3]B1 [4]BB";
        private const string k_MotorcycleEngineVolumeString = "engine Volume";
        private int m_EngineVolume;
        private eMotorcycleDriverLicenceType m_driverLicenceType;
        private string[] m_SpecificParams = { k_MotorcycleDrivingLicenceString, k_MotorcycleEngineVolumeString };

        public Motorcycle(string i_LicenceNumber, string i_ModelName, PowerSource i_VehiclePowerSource) : base(i_LicenceNumber, i_ModelName, i_VehiclePowerSource)
        {
            for(int i = 0; i < GarageVehicleList.k_MotorcycleNumOfWheels; i++)
            {
                this.InsertWheel(new Wheel(GarageVehicleList.k_MotorcycleMaxWheelAirPressure));
            }
        }

        public override string[] GetSpecificParams
        {
            get { return m_SpecificParams; }
        }

        public override void SetSpecificParam(string i_originalParam, string i_userAns)
        {
            switch(i_originalParam)
            {
                case k_MotorcycleDrivingLicenceString:
                    if(Enum.TryParse<eMotorcycleDriverLicenceType>(i_userAns, out eMotorcycleDriverLicenceType license) && Enum.IsDefined(typeof(eMotorcycleDriverLicenceType), license))
                    {
                        this.m_driverLicenceType = license;
                    }
                    else
                    {
                        throw new ArgumentException(string.Format(k_InvalidUserInputMessage, i_userAns));
                    }

                    break;
                case k_MotorcycleEngineVolumeString:
                    if(int.TryParse(i_userAns, out int engineVolume) && (engineVolume >= 0))
                    {
                        m_EngineVolume = engineVolume;
                    }
                    else
                    {
                        throw new ArgumentException(string.Format(k_InvalidUserInputMessage, i_userAns));
                    }

                    break;
            }
        }

        public int EngineVolume
        {
            get
            {
                return this.m_EngineVolume;
            }

            set
            {
                this.m_EngineVolume = value;
            }
        }

        public eMotorcycleDriverLicenceType DriverLicenceType
        {
            get
            {
                return this.m_driverLicenceType;
            }

            set
            {
                this.m_driverLicenceType = value;
            }
        }

        public override string ToString()
        {
            return string.Format(
@"Driving Licence type:       {0}
Engine volume:              {1}",
m_driverLicenceType,
m_EngineVolume);
        }
    }
}
