using System;
using Ex03.GarageLogic.Garage;
using Ex03.GarageLogic.Vehicles.VehicleSubParts.Wheel;
using Ex03.GarageLogic.Vehicles.VehicleSubParts.SourceOfPower;

namespace Ex03.GarageLogic.Vehicles.Truck
{
    public class Truck : Vehicle
    {
        private const string k_MaxCargoWeightString = "max cargo volume";
        private const string k_ContainDangerousMaterialsString = "if the truck contains dangerous materials: [1]yes, [2]no";
        private const string k_YesSign = "1";
        private const string k_NoSign = "2";
        private bool m_ContainDangerousMaterials;
        private float m_MaxCargoWeight;
        private string[] m_SpecificParams = { k_MaxCargoWeightString, k_ContainDangerousMaterialsString };

        public Truck(string i_LicenceNumber, string i_ModelName, PowerSource i_VehiclePowerSource) : base(i_LicenceNumber, i_ModelName, i_VehiclePowerSource)
        {
            for(int i = 0; i < GarageVehicleList.k_TruckNumOfWheels; i++)
            {
                this.InsertWheel(new Wheel(GarageVehicleList.k_TruckMaxWheelAirPressure));
            }
        }

        public bool ContainDangerousMaterials
        {
            get
            {
                return this.m_ContainDangerousMaterials;
            }

            set
            {
                this.m_ContainDangerousMaterials = value;
            }
        }

        public float MaxCargoWeight
        {
            get
            {
                return this.m_MaxCargoWeight;
            }

            set
            {
                this.m_MaxCargoWeight = value;
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
                case k_MaxCargoWeightString:
                    if(int.TryParse(i_userAns, out int maxCargo) && maxCargo >= 0)
                    {
                        this.m_MaxCargoWeight = maxCargo;
                    }
                    else
                    {
                        throw new ArgumentException(string.Format(k_InvalidUserInputMessage, i_userAns));
                    }

                    break;
                case k_ContainDangerousMaterialsString:
                    if(isAYesOrNo(i_userAns))
                    {
                        switch(i_userAns)
                        {
                            case k_YesSign:
                                m_ContainDangerousMaterials = true;
                                break;
                            case k_NoSign:
                                m_ContainDangerousMaterials = false;
                                break;
                        }
                    }
                    else
                    {
                        throw new ArgumentException(string.Format(k_InvalidUserInputMessage, i_userAns));
                    }

                    break;
            }
        }

        private bool isAYesOrNo(string i_ToBeChecked)
        {
            bool isValidYesOrNo = false;
            
            if(i_ToBeChecked == k_YesSign || i_ToBeChecked == k_NoSign)
            {
                isValidYesOrNo = true;
            }

            return isValidYesOrNo;
        }

        public override string ToString()
        {
            return string.Format(
@"Maximum Load:               {0}
Carrying hazards:           {1}",
m_MaxCargoWeight,
m_ContainDangerousMaterials);
        }
    }
}
