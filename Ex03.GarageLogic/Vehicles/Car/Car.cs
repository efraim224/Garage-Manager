using System;
using Ex03.GarageLogic.Vehicles.VehicleSubParts.SourceOfPower;
using Ex03.GarageLogic.Garage;
using Ex03.GarageLogic.Vehicles.VehicleSubParts.Wheel;

namespace Ex03.GarageLogic.Vehicles.Car
{
    public class Car : Vehicle
    {
        private const string k_NumberOfDoorString = "the number of doors:";
        private const string k_CarColorString = "car color: [0] Red, [1] Silver, [2] White, [3] Black";
        private int m_NumOfDoors;
        private eCarColor m_carColor;
        private string[] m_SpecificParams = { k_CarColorString, k_NumberOfDoorString };

        public Car(string i_LicenceNumber, string i_ModelName, PowerSource i_VehiclePowerSource) : base(i_LicenceNumber, i_ModelName, i_VehiclePowerSource)
        {
            /*this.m_NumOfDoors = i_NumOfDoors;*/
            for(int i = 0; i < GarageVehicleList.k_CarNumOfWheels; i++)
            {
                this.InsertWheel(new Wheel(GarageVehicleList.k_CarMaxWheelAirPressure));
            }
        }

        public int NumOfDoors
        {
            get { return this.m_NumOfDoors; }
            set { this.m_NumOfDoors = value; }
        }

        public eCarColor CarColor
        {
            get { return this.m_carColor; }
            set { this.m_carColor = value; }
        }

        public override string[] GetSpecificParams
        {
            get { return this.m_SpecificParams; }
        }

        public override void SetSpecificParam(string i_originalParam, string i_userAns)
        {
            switch(i_originalParam)
            {
                case k_CarColorString:
                    
                    if(Enum.TryParse<eCarColor>(i_userAns, out eCarColor carColor) && Enum.IsDefined(typeof(eCarColor), carColor))
                    {
                        this.m_carColor = carColor;
                    }
                    else
                    {
                        throw new ArgumentException(string.Format(k_InvalidUserInputMessage, i_userAns));
                    }

                    break;
                
                case k_NumberOfDoorString:
                    if(int.TryParse(i_userAns, out int numOfDoors) && (numOfDoors <= GarageVehicleList.k_CarMaxNumOfDoors && numOfDoors >= GarageVehicleList.k_CarMinNumOfDoors))
                    {
                        m_NumOfDoors = numOfDoors;
                    }
                    else
                    {
                        throw new ArgumentException(string.Format(k_InvalidUserInputMessage, i_userAns));
                    }

                    break;
            }
        }

        public override string ToString()
        {
            return string.Format(
@"Number of doors:            {0}
Car color:                  {1}",
m_NumOfDoors,
m_carColor);
        }
    }
}
