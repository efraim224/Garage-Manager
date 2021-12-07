using Ex03.GarageLogic.Vehicles;
using Ex03.GarageLogic.Vehicles.Car;
using Ex03.GarageLogic.Vehicles.Motorcycle;
using Ex03.GarageLogic.Vehicles.Truck;
using Ex03.GarageLogic.Vehicles.VehicleSubParts.SourceOfPower;

namespace Ex03.GarageLogic.Garage
{
    public class GarageVehicleList
    {
        public static string[] VehicleList = 
            { 
        "Gasoline Motorcycle",
        "Electrical Motorcycle",
        "Gasoline Car",
        "Electric Car",
        "Truck"
            };
        
        // Supported Motorcycle Properties
        public const int k_MotorcycleNumOfWheels = 2;
        public const eGasolineType k_MotorcycleAllowedGasolineType = eGasolineType.Octan98;
        public const float k_GasolineMotorcycleMaxTankVolume = 6f;
        public const float k_ElectricMotorcycleMaxBatteryVolume = 1.8f;
        public const int k_MotorcycleMaxWheelAirPressure = 30;

        // Supported Car Properties
        public const int k_CarNumOfWheels = 4;
        public const int k_CarMaxNumOfDoors = 5;
        public const int k_CarMinNumOfDoors = 2;
        public const eGasolineType k_CarAllowedGasolineType = eGasolineType.Octan95;
        public const float k_GasolineCarMaxTankVolume = 45f;
        public const float k_ElectricCarMaxBatteryVolume = 3.2f;
        public const int k_CarMaxWheelAirPressure = 32;

        // Supported Truck Properties
        public const int k_TruckNumOfWheels = 16;
        public const eGasolineType k_TruckAllowedGasolineType = eGasolineType.Soler;
        public const float k_TruckMaxTankVolume = 120f;
        public const int k_TruckMaxWheelAirPressure = 26;

        public const float k_MinimalVolume = 0f;

        public static Vehicle CreateVehicle(eSupportedVehicles i_vehicleType, string i_VehicleLicenceNumber, string i_modelName)
        {
            Vehicle newVehicle = null;

            switch (i_vehicleType)
            {
                case eSupportedVehicles.ElectricalMotorcycle:
                    newVehicle = new Motorcycle(i_VehicleLicenceNumber, i_modelName, new ElectricPower(k_ElectricCarMaxBatteryVolume));
                    break;
                case eSupportedVehicles.GasolineMotorcycle:
                    newVehicle = new Motorcycle(i_VehicleLicenceNumber, i_modelName, new GasolinePower(k_MotorcycleAllowedGasolineType, k_GasolineMotorcycleMaxTankVolume));
                    break;
                case eSupportedVehicles.ElectricCar:
                    newVehicle = new Car(i_VehicleLicenceNumber, i_modelName, new ElectricPower(k_ElectricCarMaxBatteryVolume));
                    break;
                case eSupportedVehicles.GasolineCar:
                    newVehicle = new Car(i_VehicleLicenceNumber, i_modelName, new GasolinePower(k_CarAllowedGasolineType, k_GasolineCarMaxTankVolume));
                    break;
                case eSupportedVehicles.Truck:
                    newVehicle = new Truck(i_VehicleLicenceNumber, i_modelName, new GasolinePower(k_TruckAllowedGasolineType, k_TruckMaxTankVolume));
                    break;
            }

            return newVehicle;
        }
    }

    public enum eSupportedVehicles
    {
        GasolineMotorcycle,
        ElectricalMotorcycle,
        GasolineCar,
        ElectricCar,
        Truck,
    }
}
