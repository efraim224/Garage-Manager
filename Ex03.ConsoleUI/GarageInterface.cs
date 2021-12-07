using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic.Garage;
using Ex03.GarageLogic.Vehicles;
using Ex03.GarageLogic.Vehicles.VehicleSubParts.SourceOfPower;
using Ex03.GarageLogic.Vehicles.VehicleSubParts.Wheel;

namespace Ex03.ConsoleUI
{
    public class GarageInterface
    {

        private const string k_LicenceNumberRequest = "Enter The licence number of the Vehicle: ";
        private const string k_InvalidInput = "Please try again: ";
        private const string k_ChooseTypeVehicleToAdd = "What kind of vehicle you want to enter: ";
        private const string k_VehicleAlreadyInGarage = "Vehicle with this licence number already exist. Vehicle moved to repiar"; 
        private const string k_RequestModelName = "Enter the vehicle model name: ";
        private const string k_PhoneNumberRequest = "Enter the costumer phone number: ";
        private const string k_ExitMsg = "Until next time. bye! (press 'Enter' to exit)";
        private const string k_vehicleNotInGarage = "Vehicle with this license number does not exist in our garage";
        private const string k_ReturunToMainMenu = "Press 'enter' to return to main menu";
        private const string k_VehicleIsRefueled = "Your vehicle has been refueled";
        private const string k_VehicleIsRecharged = "Your vehicle has been recharged";
        private const string k_RequestCostumerNameForVehicle = "What is the costumer name?";
        private const string k_WheelsFullAir = "Wheels were infalted to maximum";
        private const string k_CurrentVehiclesInGarage = "Current vehicles in garage are: ";
        private const string k_TheGarageIsEmpty = "There are no vehicles in the garage at the moment! ";
        private const string k_QuantityToEnter = "Enter the quantity: ";
        private const string k_TypeOfState = "What state would you like the vehicle to be? ";
        private const string k_VehicleStateChanged = "The vehicle state changed";
        private const string k_NotAcceptableQuantity = "The quantity you have entered is not valid";
        private const string K_NoRefuelElectricVehicle = "The vehicle is electric!, you cant fuel it!!!";
        private const string K_NoRechargeGasolineVehicle = "The vehicle is on gasoline!, you cant charge it!!!";
        private const string k_ChooseGasolineType = "Choose the type of gas to fill: ";
        private const string k_RequestAirPressure = "Enter wheels current air pressure: ";
        private const string k_InvalidGasType = "Invalid gas type!. Cant refuel with that type";
        private const string k_ManufactorName = "Enter Wheels manufacturer: ";
        private const string k_RequestCurrentEnergy = "Enter the current amout of {0} left in the vehicle";
        private const string k_CurrentAcceptableRangeMessage = "Acceptable quantity is between {0} and {1}";
        private const string k_FilteringVehiclesInGarage = 
            @"
Choose the Filtering: 
[0] InRepair
[1] Repaired
[2] Payed
[3] All

";
        private const string k_WelcomeMsg = 
@"Welcome to the garage! 
What would you like to do today?";

        private const string k_MainMenu = 
            @"
[1] Insert new vehicle
[2] Display current vehicles in garage
[3] Change vehicle state
[4] Inflate vehicle's wheels to maximum
[5] Refuel gasoline vehicle 
[6] Recharge electrical vehicle
[7] Display vehicle's stats
[8] Exit garage

";
        
        private static Garage s_MainGarage;
        private static eMenuOptions m_MainMenu0ption = eMenuOptions.MainMenu;

        public static void StartGarage()
        {
            s_MainGarage = new Garage();
            while (true)
            {
                Console.Clear();
                chooseMainMenuOption(m_MainMenu0ption);
                switch (m_MainMenu0ption)
                {
                    case eMenuOptions.MainMenu:
                        break;
                    case eMenuOptions.AddVehicle:
                        addVehicle();
                        break;
                    case eMenuOptions.ShowCurrentVehicle:
                        currentVehicleInGarage();
                        break;
                    case eMenuOptions.ChangeVehicleState:
                        changeCurrentVehicleState();
                        break;
                    case eMenuOptions.InsertMaxAir:
                        menuMaxAirWheels();
                        break;
                    case eMenuOptions.Refuel:
                        refuelVehicle();
                        break;
                    case eMenuOptions.Recharge:
                        rechargeVehicle();
                        break;
                    case eMenuOptions.VehicleStat:
                        getVehicleStats();
                        break;
                    case eMenuOptions.Exit:
                        m_MainMenu0ption = eMenuOptions.Exit;
                        exit();
                        break;
                }

                if (m_MainMenu0ption == eMenuOptions.Exit)
                {
                    break;
                }
                
                Console.WriteLine();
                Console.WriteLine(k_ReturunToMainMenu);
                Console.ReadLine();
                m_MainMenu0ption = eMenuOptions.MainMenu;
            }
        }

        private static void refuelVehicle()
        {
            string licenseNum = requestLicenceNumber();
            if (isVehicleInGarage(licenseNum))
            {
                Vehicle currentVehicle = getVehicleByLicense(licenseNum);
                if (currentVehicle.PowerType == ePowerSource.Gasoline)
                {
                    eGasolineType inputGasolineType = getGasolineType();
                    GasolinePower currentPower = (GasolinePower)currentVehicle.VehiclePower;
                    if (currentPower.GasolineType == inputGasolineType)
                    {
                        float quantityToRefuel = getQuantity(currentVehicle);
                        bool acceptableQuantity = isAcceptableQuantity(quantityToRefuel, currentVehicle);
                        while (!acceptableQuantity)
                        {
                            Console.WriteLine(k_InvalidInput);
                            Console.WriteLine(k_NotAcceptableQuantity);
                            Console.WriteLine(k_CurrentAcceptableRangeMessage, 0, currentVehicle.VehiclePower.MaxEnergyVolume - currentVehicle.VehiclePower.RemainingEnergy);
                            quantityToRefuel = getQuantity(currentVehicle);
                            acceptableQuantity = isAcceptableQuantity(quantityToRefuel, currentVehicle);
                        }

                        currentVehicle.VehiclePower.insertEnergyToPowerSource(quantityToRefuel);
                        Console.WriteLine(k_VehicleIsRefueled);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine(k_InvalidGasType);
                        Console.WriteLine("your gas type is {0} and you tried to refuel with {1}", currentPower.GasolineType, inputGasolineType);
                    }
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine(K_NoRefuelElectricVehicle);
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine(k_vehicleNotInGarage);
            }
        }

        private static float requestCurrentEnergy(Vehicle i_Vehicle)
        {
            Console.Clear();
            Console.WriteLine(k_RequestCurrentEnergy, i_Vehicle.PowerType.ToString());
            float quantity = getQuantity(i_Vehicle);
            bool acceptableQuantity = isAcceptableQuantity(quantity, i_Vehicle);
            while (!acceptableQuantity)
            {
                Console.WriteLine(k_NotAcceptableQuantity);
                Console.WriteLine(k_CurrentAcceptableRangeMessage, 0, i_Vehicle.VehiclePower.MaxEnergyVolume - i_Vehicle.VehiclePower.RemainingEnergy);
                quantity = getQuantity(i_Vehicle);
                acceptableQuantity = isAcceptableQuantity(quantity, i_Vehicle);
            }

            return quantity;
        }

        private static void printGasType()
        {
            string[] enumArray = Enum.GetNames(typeof(eGasolineType));
            for (int i = 0; i < enumArray.Length; i++)
            {
                Console.WriteLine("[{0}] {1}", i, enumArray[i]);
            }
        }

        private static eGasolineType getGasolineType()
        {
            Console.Clear();
            Console.WriteLine(k_ChooseGasolineType);
            printGasType();
            string inputType = Console.ReadLine();
            eGasolineType type;
            bool validType = InputValidator.IsValidGasType(inputType, out type);
            while (!validType) 
            {
                Console.Clear();
                Console.WriteLine(k_InvalidInput);
                Console.WriteLine(k_ChooseGasolineType);
                inputType = Console.ReadLine();
                validType = InputValidator.IsValidGasType(inputType, out type);
            }

            return type;
        }

        private static bool isAcceptableQuantity(float i_Quantity, Vehicle i_Vehicle)
        {
            bool valid = false;
            float max = i_Vehicle.VehiclePower.MaxEnergyVolume;
            float current = i_Vehicle.VehiclePower.RemainingEnergy;
            if (i_Quantity + current <= max && i_Quantity >= 0)
            {
                valid = true;
            }

            return valid;
        }

        private static void rechargeVehicle()
        {
            string license = requestLicenceNumber();
            if (isVehicleInGarage(license))
            {
                Vehicle currentVehicle = getVehicleByLicense(license);
                if (currentVehicle.PowerType == ePowerSource.Electricity)
                {
                    float quantityToRecharge = getQuantity(currentVehicle);
                    bool acceptableQuantity = isAcceptableQuantity(quantityToRecharge, currentVehicle);
                    while (!acceptableQuantity)
                    {
                        Console.WriteLine(k_InvalidInput);
                        Console.WriteLine(k_NotAcceptableQuantity);
                        Console.WriteLine(
                            "acceptable quantity is between {0} and {1}",
                            0,
                            currentVehicle.VehiclePower.MaxEnergyVolume - currentVehicle.VehiclePower.RemainingEnergy);
                        quantityToRecharge = getQuantity(currentVehicle);
                        acceptableQuantity = isAcceptableQuantity(quantityToRecharge, currentVehicle);
                    }

                    currentVehicle.VehiclePower.insertEnergyToPowerSource(quantityToRecharge);
                    Console.WriteLine(k_VehicleIsRecharged);
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine(K_NoRechargeGasolineVehicle);
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine(k_vehicleNotInGarage);
            }
        }

        private static GarageCustomer getCustomerByLicense(string i_License)
        {
            GarageCustomer costumerByLicense = s_MainGarage.CustomerList[i_License];
            return costumerByLicense;
        }

        private static float getQuantity(Vehicle i_Vehicle)
        {
            Console.WriteLine(k_QuantityToEnter);
            string inputStr = Console.ReadLine();
            float quantity;
            bool isNum = InputValidator.IsValidFloat(i_Vehicle, inputStr, out quantity);
            while (!isNum)
            {
                Console.WriteLine(k_InvalidInput);
                Console.WriteLine(k_QuantityToEnter);
                inputStr = Console.ReadLine();
                isNum = InputValidator.IsValidFloat(i_Vehicle, inputStr, out quantity);
            }

            return quantity;
        }

        private static void insertEnergyToPowerSource(Vehicle i_VehicleToRecharge, float i_Quantity)
        {
            i_VehicleToRecharge.VehiclePower.insertEnergyToPowerSource(i_Quantity);
        }

        private static void getVehicleStats()
        {
            string license = requestLicenceNumber();
            if (!isVehicleInGarage(license))
            {
                Console.Clear();
                Console.WriteLine(k_vehicleNotInGarage);
            }
            else
            {
                GarageCustomer customer = getCustomerByLicense(license);
                Console.WriteLine(customer.ToString());
                Console.WriteLine();
            }
        }

        private static void chooseMainMenuOption(eMenuOptions i_Options)
        {
            m_MainMenu0ption = (eMenuOptions)requestMainManuOption();
        }
 
        private static Vehicle getVehicleByLicense(string i_License)
        {
            return s_MainGarage.CustomerList[i_License].Vehicle;
        }

        private static void exit()
        {
            Console.Clear();
            Console.WriteLine(k_ExitMsg);
            Console.ReadLine();
        }

        private static int requestAirPressure(Vehicle i_Vehicle)
        {
            int airPressure;
            Console.Clear();
            Console.WriteLine(k_RequestAirPressure);
            string inputAirPressure = Console.ReadLine();
            bool valid = InputValidator.IsValidAirPressure(inputAirPressure, i_Vehicle, out airPressure);
            while (!valid) 
            {
                Console.Clear();
                Console.WriteLine(k_InvalidInput);
                Console.WriteLine(k_CurrentAcceptableRangeMessage, 0, i_Vehicle.Wheels[0].MaxAirPressure);
                Console.WriteLine(k_RequestAirPressure);
                inputAirPressure = Console.ReadLine();
                valid = InputValidator.IsValidAirPressure(inputAirPressure, i_Vehicle, out airPressure);
            }

            return airPressure;
        }

        private static void addVehicle()
        {
            Console.Clear();
            string licenseNum = requestLicenceNumber();
            if(isVehicleInGarage(licenseNum))
            {
                Console.Clear();
                Console.WriteLine(k_VehicleAlreadyInGarage);
                s_MainGarage.CustomerList[licenseNum].Vehicle.Status = eVehicleStatus.InRepair;
            }
            else
            {
                string modelName = requestModelName();
                Vehicle newVehicle = createVehicle(modelName, licenseNum);
                newVehicle.VehiclePower.RemainingEnergy = requestCurrentEnergy(newVehicle);
                int airPressureInWheels = requestAirPressure(newVehicle);
                string manufacture = requestManifactureName();
                newVehicle.SetWheelsManufacture(manufacture);
                bool successInPar = setDifferentVehicleProperties(newVehicle);
                while (!successInPar)
                {
                    Console.WriteLine(k_InvalidInput);
                    successInPar = setDifferentVehicleProperties(newVehicle);
                }
                newVehicle.SetAllWheelsCurrentPressure(airPressureInWheels);
                string ownerName = requestOwnerName();
                string phoneNumber = requestPhoneNumber();
                GarageCustomer costumer = new GarageCustomer(ownerName, phoneNumber, newVehicle);
                s_MainGarage.AddCustomer(costumer);
                Console.WriteLine("the vehicle has entered the garage with license number {0}", licenseNum);
            }
        }

        private static bool setDifferentVehicleProperties(Vehicle i_vehicle)
        {
            bool isValidInput = true;
            string[] specificParams = i_vehicle.GetSpecificParams;
            try
            {
                for(int i = 0; i < specificParams.Length; i++)
                {
                    Console.WriteLine(string.Format("Please enter {0}", specificParams[i]));
                    string answer = Console.ReadLine();
                    i_vehicle.SetSpecificParam(specificParams[i], answer);
                }
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception.Message);
                isValidInput = false;
            }
            
            return isValidInput;
        }

        private static Vehicle createVehicle(string i_ModelName, string i_LicenseNum)
        {
            eSupportedVehicles vehicleType = requestVehicleType();
            Vehicle newVehicle = GarageVehicleList.CreateVehicle(vehicleType, i_LicenseNum, i_ModelName);
            return newVehicle;
        }

        private static eSupportedVehicles requestVehicleType()
        {
            Console.Clear();
            Console.WriteLine(k_ChooseTypeVehicleToAdd);
            printAcceptedTypes();
            string vehicleType = Console.ReadLine();
            eSupportedVehicles type;
            bool isValidType = InputValidator.IsValiVehicleType(vehicleType, out type);
            while (!isValidType)
            {
                Console.WriteLine(k_InvalidInput);
                Console.WriteLine(k_ChooseTypeVehicleToAdd);
                vehicleType = Console.ReadLine();
                isValidType = InputValidator.IsValiVehicleType(vehicleType, out type);
            }

            return type;
        }

        private static void printAcceptedTypes()
        {
            for(int i = 0; i < GarageVehicleList.VehicleList.Length; i++)
            {
                Console.WriteLine("[{0}] {1}", i, GarageVehicleList.VehicleList[i]);
            }
        }

        private static string requestPhoneNumber()
        {
            Console.Clear();
            Console.WriteLine(k_PhoneNumberRequest);
            string modelName = Console.ReadLine();
            bool valid = InputValidator.isOnlyDigits(modelName);
            while (!valid)
            {
                Console.Clear();
                Console.WriteLine(k_InvalidInput);
                Console.WriteLine(k_PhoneNumberRequest);
                modelName = Console.ReadLine();
                valid = InputValidator.isOnlyDigits(modelName);
            }

            return modelName;
        }

        private static string requestManifactureName()
        {
            Console.Clear();
            Console.WriteLine(k_ManufactorName);
            string manifacturName = Console.ReadLine();
            bool valid = InputValidator.isOnlyLetters(manifacturName);
            while (!valid)
            {
                Console.Clear();
                Console.WriteLine(k_InvalidInput);
                Console.WriteLine(k_ManufactorName);
                manifacturName = Console.ReadLine();
                valid = InputValidator.isOnlyLetters(manifacturName);
            }

            return manifacturName;
        }

        private static string requestModelName()
        {
            Console.Clear();
            Console.WriteLine(k_RequestModelName);
            string modelName = Console.ReadLine();
            bool valid = InputValidator.isOnlyDigitOrLetter(modelName);
            while (!valid)
            {
                Console.Clear();
                Console.WriteLine(k_InvalidInput);
                Console.WriteLine(k_RequestModelName);
                modelName = Console.ReadLine();
                valid = InputValidator.isOnlyDigitOrLetter(modelName);
            }

            return modelName;
        }

        private static string requestOwnerName()
        {
            Console.Clear();
            Console.WriteLine(k_RequestCostumerNameForVehicle);
            string modelName = Console.ReadLine();
            bool valid = InputValidator.isOnlyLetters(modelName);
            while (!valid)
            {
                Console.Clear();
                Console.WriteLine(k_InvalidInput);
                Console.WriteLine(k_RequestCostumerNameForVehicle);
                modelName = Console.ReadLine();
                valid = InputValidator.isOnlyLetters(modelName);
            }

            return modelName;
        }

        private static string requestLicenceNumber()
        {
            Console.Clear();
            Console.WriteLine(k_LicenceNumberRequest);
            string licenseNum = Console.ReadLine();
            bool valid = InputValidator.isOnlyDigitOrLetter(licenseNum);
            while (!valid)
            {
                Console.Clear();
                Console.WriteLine(k_InvalidInput);
                Console.WriteLine(k_LicenceNumberRequest);
                licenseNum = Console.ReadLine();
                valid = InputValidator.isOnlyDigitOrLetter(licenseNum);
            }

            return licenseNum;
        }

        private static void currentVehicleInGarage()
        {
            Console.Clear();
            Console.WriteLine(k_CurrentVehiclesInGarage);
            Console.WriteLine();
            if (s_MainGarage.CustomerList.Count == 0)
            {
                Console.WriteLine(k_TheGarageIsEmpty);
            }
            else
            {
                int numChosen = requestFilter();
                switch (numChosen)
                {
                    case 0:
                        Console.WriteLine("vehicles in-repair: ");
                        foreach(GarageCustomer customer in s_MainGarage.CustomerList.Values)
                        {
                            if(customer.VehicleStatus == eVehicleStatus.InRepair)
                            {
                                Console.WriteLine(customer.Vehicle.VehicleNumber);
                            }
                        }

                        break;
                    case 1:
                        Console.WriteLine("vehicles repaired : ");
                        foreach(GarageCustomer customer in s_MainGarage.CustomerList.Values)
                        {
                            if(customer.VehicleStatus == eVehicleStatus.Repaired)
                            {
                                Console.WriteLine(customer.Vehicle.VehicleNumber);
                            }
                        }

                        break;
                    case 2:
                        Console.WriteLine("vehicles Payed : ");
                        foreach (GarageCustomer customer in s_MainGarage.CustomerList.Values)
                        {
                            if (customer.VehicleStatus == eVehicleStatus.Payed)
                            {
                                Console.WriteLine(customer.Vehicle.VehicleNumber);
                            }
                        }

                        break;
                    case 3:
                        Console.WriteLine("all vehicles in garage: ");
                        foreach (GarageCustomer customer in s_MainGarage.CustomerList.Values)
                        {
                            Console.WriteLine(customer.Vehicle.VehicleNumber);
                        }

                        break;
                }
            }
        }

        private static int requestFilter()
        {
            Console.Clear();
            Console.WriteLine(k_FilteringVehiclesInGarage);
            string numInput = Console.ReadLine();
            int choseNum;
            bool validNumFilter = InputValidator.IsValidFilter(numInput, out choseNum);
            while (!validNumFilter) 
            {
                Console.Clear();
                Console.WriteLine(k_InvalidInput);
                Console.WriteLine(k_FilteringVehiclesInGarage); 
                numInput = Console.ReadLine(); 
                validNumFilter = InputValidator.IsValidFilter(numInput, out choseNum);
            }

            return choseNum;
        }

        private static eVehicleStatus requestVehicleStatus()
        {
            Console.WriteLine(k_TypeOfState);
            showPossibleVehicleStatus();
            string input = Console.ReadLine();
            eVehicleStatus vehicleStatus;
            bool validVehicleStatus = InputValidator.IsValidVehicleStatus(input, out vehicleStatus);
            while (!validVehicleStatus)
            {
                Console.Clear();
                Console.WriteLine(k_InvalidInput);
                Console.WriteLine(k_TypeOfState);
                showPossibleVehicleStatus();
                input = Console.ReadLine();
                validVehicleStatus = InputValidator.IsValidVehicleStatus(input, out vehicleStatus);
            }

            return vehicleStatus;
        }

        private static void showPossibleVehicleStatus()
        {
            eVehicleStatus[] vehicleStatusArray = (eVehicleStatus[])Enum.GetValues(typeof(eVehicleStatus));
            for (int i = 0; i < vehicleStatusArray.Length; i++)
            {
                Console.WriteLine("[{0}] {1}", i, vehicleStatusArray[i]);
            }
        }

        private static void changeCurrentVehicleState()
        {
            string license = requestLicenceNumber();
            if (isVehicleInGarage(license))
            {
                eVehicleStatus newStatus = requestVehicleStatus();
                Vehicle currentVehicle = getVehicleByLicense(license);
                GarageCustomer customer = getCustomerByLicense(license);
                customer.VehicleStatus = newStatus;
                currentVehicle.Status = newStatus;
                Console.WriteLine(k_VehicleStateChanged);
            }
            else
            {
                Console.WriteLine(k_InvalidInput);
                Console.WriteLine(k_vehicleNotInGarage);
            }
        }

        private static void menuMaxAirWheels()
        {
            string license = requestLicenceNumber();
            if (isVehicleInGarage(license))
            {
                Vehicle currentVehicle = getVehicleByLicense(license);
                insertMaxAirWheels(currentVehicle);
                Console.WriteLine(k_WheelsFullAir);
            }
            else
            {
                Console.WriteLine(k_InvalidInput);
                Console.WriteLine(k_vehicleNotInGarage);
            }
        }

        private static void insertMaxAirWheels(Vehicle i_VehicleToInsert)
        {
            foreach (Wheel wheelInVehicle in i_VehicleToInsert.Wheels)
            {
                wheelInVehicle.CurrentAirPressure = wheelInVehicle.MaxAirPressure;
            }
        }

        private static int requestMainManuOption()
        {
            bool validMenuOption;
            Console.WriteLine(k_WelcomeMsg);
            Console.WriteLine(k_MainMenu);
            string inputStr = Console.ReadLine();
            int menuOption = InputValidator.IsValidInputForMainManu(inputStr, out validMenuOption);
            while (!validMenuOption)
            {
                Console.Clear();
                Console.WriteLine(k_InvalidInput);
                Console.WriteLine(k_MainMenu);
                inputStr = Console.ReadLine();
                menuOption = InputValidator.IsValidInputForMainManu(inputStr, out validMenuOption);
            }

            return menuOption;
        }

        private static void showVehicleStats(Vehicle i_Vehicle)
        {
            Console.WriteLine(i_Vehicle.ToString());
        }

        private static bool isVehicleInGarage(string i_Licence)
        {
            return s_MainGarage.CustomerList.ContainsKey(i_Licence);
        }
    }
}
