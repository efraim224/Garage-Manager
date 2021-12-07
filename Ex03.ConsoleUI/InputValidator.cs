using System;
using System.Collections.Generic;
using Ex03.GarageLogic.Garage;
using Ex03.GarageLogic.Vehicles;
using Ex03.GarageLogic.Vehicles.VehicleSubParts.SourceOfPower;
using Ex03.GarageLogic.Vehicles.VehicleSubParts.Wheel;

namespace Ex03.ConsoleUI
{
    public class InputValidator
    {
        public static bool IsValidFilter(string i_NumStr, out int i_Num)
        {
            bool validInput = false;
            bool validNum = int.TryParse(i_NumStr, out i_Num);
            if (validNum)
            {
                if (i_Num > -1 && i_Num < 4)
                {
                    validInput = true;
                }
            }

            return validInput;
        }

        public static bool IsValidAirPressure(string i_Input, Vehicle i_Vehicle, out int i_airPressure)
        {
            bool valid = true;
            bool isNum = int.TryParse(i_Input, out i_airPressure);
            if (isNum)
            {
                List<Wheel> wheels = i_Vehicle.Wheels;
                foreach (Wheel wheel in wheels)
                {
                    if (wheel.MaxAirPressure < i_airPressure  || i_airPressure < 0)
                    {
                        valid = false;
                        break;
                    }
                }
            } 

            return valid && isNum;
        }

        public static bool IsValidGasType(string i_InputType, out eGasolineType io_Type)
        {
            int answer;
            bool isValid = int.TryParse(i_InputType, out answer);
            io_Type = 0;
            
            if (isValid)
            {
                if (answer > -1 && answer < 4)
                {
                    io_Type = (eGasolineType)answer;
                }
            }

            return isValid;
        }

        public static bool IsValidVehicleStatus(string i_Input, out eVehicleStatus io_StatusNumber)
        {
            bool isValid = false;
            bool isNum = eVehicleStatus.TryParse(i_Input, out io_StatusNumber);
            if(isNum)
            {
                isValid = true;
            }

            return isValid;
        }

        public static bool IsValiVehicleType(string i_Input, out eSupportedVehicles o_TypeOfVehicle)
        {
            o_TypeOfVehicle = 0;
            bool isValid = false;
            int chosenNum;
            bool validNum = int.TryParse(i_Input, out chosenNum);
            if (validNum) 
            { 
                if (Enum.IsDefined(typeof(eSupportedVehicles), chosenNum))
                {
                    isValid = true;
                    o_TypeOfVehicle = (eSupportedVehicles)chosenNum;
                }
            }

            return isValid;
        }

        public static int IsValidInputForMainManu(string i_Input, out bool o_Option)
        {
            o_Option = int.TryParse(i_Input, out int inputAsNum);
            if(o_Option)
            {
                if(inputAsNum < 1 && inputAsNum > 8)
                {
                    o_Option = false;
                }
            }

            return inputAsNum;
        }

        public static bool IsValidFloat(Vehicle i_Vehicle, string i_Input, out float io_number)
        {
            io_number = -1;
            bool success = float.TryParse(i_Input, out io_number);
            if (!success && io_number >= 0)
            {
                io_number = -1;
            }

            return success;
        }

        public static bool isValidEnergy(Vehicle i_Vehicle, string i_Input, out float io_EnergyToEnter)
        {
            bool isValidNum = float.TryParse(i_Input, out io_EnergyToEnter);
            bool isValidInput = false;
            if (isValidNum)
            {
                float maxEnergy = i_Vehicle.VehiclePower.MaxEnergyVolume;
                float currentEnergy = i_Vehicle.VehiclePower.RemainingEnergy;
                if(currentEnergy + io_EnergyToEnter <= maxEnergy)
                {
                    isValidInput = true;
                    i_Vehicle.VehiclePower.insertEnergyToPowerSource(io_EnergyToEnter);
                    isValidInput = true;
                }
            }

            return isValidInput;
        }

        public static bool isOnlyDigitOrLetter(string i_Word)
        {
            bool answer = !string.IsNullOrEmpty(i_Word);
            foreach (char letter in i_Word)
            {
                if (!char.IsLetterOrDigit(letter) && letter != ' ')
                {
                    answer = false;
                    break;
                }
            }

            return answer;
        }

        public static bool isOnlyLetters(string i_Word)
        {
            bool answer = !string.IsNullOrEmpty(i_Word);
            foreach (char letter in i_Word)
            {
                if (!char.IsLetter(letter) && letter != ' ')
                {
                    answer = false;
                    break;
                }
            }

            return answer;
        }

        public static bool isOnlyDigits(string i_Word)
        {
            bool answer = !string.IsNullOrEmpty(i_Word);
            foreach (char letter in i_Word)
            {
                if (!char.IsDigit(letter))
                {
                    answer = false;
                    break;
                }
            }

            return answer;
        }
    }
}
