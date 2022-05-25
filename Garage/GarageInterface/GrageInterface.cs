namespace Garage_DvirFriedler
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class GarageInterface
    {
        public static void ShowMenu()
            {
                Console.WriteLine("\nPlease Choose An Option:");
                Console.WriteLine("If you want to add new veichle please press 1.");
                Console.WriteLine("If you want to see the veichles in the grage please press 2.");
                Console.WriteLine("If you want to change the status of a spesific car please press 3.");
                Console.WriteLine("If you want to fill to max the tairs of a spesific car please press 4.");
                Console.WriteLine("If you want to  fual a spesific car please press 5.");
                Console.WriteLine("If you want to  charge a spesific car please press 6.");
                Console.WriteLine("If you want the details of a spesific car please press 7.");
                Console.WriteLine("For exit the Program by press E.");
            }

        public static void AddVeichle(Garage garage)
        {
            Console.Clear();
            List<Tier> tiersList = new List<Tier> { };
            Console.WriteLine("Plese enter your name.");
            string name = Console.ReadLine();
            Console.WriteLine("Plese enter your phone number.");
            string phone = Console.ReadLine();
            int.TryParse(phone, out _);
            if (garage.IsVeichleInGarge(name, phone))
            {
                Console.WriteLine("Your veichle is already in our Garge.");
            }
            else
            {
                Console.WriteLine("Plese enter the veichle Model Name");
                string manufacturerName = Console.ReadLine();
                Console.WriteLine("Plese enter the veichle licenseNumber");
                string licenseNumber = Console.ReadLine();
                int.TryParse(licenseNumber, out _);

                Console.WriteLine("Plese enter a veichle type\nFor Car Press 1.\nFor Motorcycle press 2.\nFor Truck press 3.");
                string carType = Console.ReadLine();
                int intVehicleType;
                int.TryParse(carType, out intVehicleType);

                if (intVehicleType < 1 || 3 < intVehicleType)
                {
                    throw new ValueOutOfRangeException(1, 3);
                }

                Console.WriteLine("Please enter the Tires Manufacturer name");
                string tireManufacturer = Console.ReadLine();

                switch (intVehicleType)
                {
                    case 1:
                        float[] airpresure = AddTiersPressure(4);
                        Console.WriteLine("plese enter the color of the car.\nFor Red press 0.\nFor White press 1.\nFor Green press 2.\nFor Blue press 3.");
                        Car.Color color = Car.SetColorByNumber(int.Parse(Console.ReadLine()));

                        Console.WriteLine("plese enter the number of doors in the car");
                        int numberOfDoors = int.Parse(Console.ReadLine());
                        if (numberOfDoors < 2 || numberOfDoors > 5)
                        {
                            throw new ArgumentException("number of doors has to be between 2 to 5");
                        }

                        Console.WriteLine("Is The car is electric?\nIf yes press 1.\nIf no press 0.");
                        int intIsElectric = int.Parse(Console.ReadLine());

                        switch (intIsElectric)
                        {
                            case 1:

                                Console.WriteLine("Please insert the remaining Battery Time");
                                float remainingBatteryTime = float.Parse(Console.ReadLine());
                                ElectronicCar electronicCar = new ElectronicCar(manufacturerName, licenseNumber, color, numberOfDoors, remainingBatteryTime, airpresure, tireManufacturer);
                                garage.AddVehicle(electronicCar, name, phone);

                                break;

                            case 0:
                                Console.WriteLine("Please insert the current fuel Tank");
                                float currentfuelTankLiters = float.Parse(Console.ReadLine());
                                if (currentfuelTankLiters > 38)
                                {
                                    throw new ValueOutOfRangeException(0, 38);
                                }

                                GasolineCar gasolineCar = new GasolineCar(manufacturerName, licenseNumber, color, numberOfDoors, currentfuelTankLiters, airpresure, tireManufacturer);
                                garage.AddVehicle(gasolineCar, name, phone);
                                break;
                        }

                        break;

                    case 2:

                        airpresure = AddTiersPressure(2);

                        Console.WriteLine("Please  enter your license Type");
                        string licensType = Console.ReadLine();
                        checkLiscenceType(licensType);

                        Console.WriteLine("Please your engine Capacity ");
                        int engineCapacity = int.Parse(Console.ReadLine());

                        Console.WriteLine("Is The motorcycle is electric?\nIf yes press 1.\nIf no press 0.");
                        intIsElectric = int.Parse(Console.ReadLine());

                        switch (intIsElectric)
                        {
                            case 1:
                                Console.WriteLine("Please insert the remaining Battery Time");
                                float remainingBatteryTime = float.Parse(Console.ReadLine());
                                ElectronicMotorCycle electronicMotorCycle = new ElectronicMotorCycle(manufacturerName, licenseNumber, licensType, engineCapacity, remainingBatteryTime, airpresure, tireManufacturer);
                                garage.AddVehicle(electronicMotorCycle, name, phone);

                                break;

                            case 0:
                                Console.WriteLine("Please insert the current fuel Tank");
                                float currentfuelTankLiters = float.Parse(Console.ReadLine());
                                if (currentfuelTankLiters > 6.2)
                                {
                                    throw new ValueOutOfRangeException(0, (float)6.2);
                                }

                                GasolineMotorCycle gasolineMotor = new GasolineMotorCycle(manufacturerName, licenseNumber, licensType, engineCapacity, currentfuelTankLiters, airpresure, tireManufacturer);
                                garage.AddVehicle(gasolineMotor, name, phone);

                                break;
                        }

                        break;

                    case 3:

                        airpresure = AddTiersPressure(16);

                        Console.WriteLine("The truck Refigerat Contents?\nPress 0 for no.\nPress 1 for yes.");
                        int intRefigeratedContents = int.Parse(Console.ReadLine());
                        bool RefigeratedContents = false;
                        if (intRefigeratedContents == 1)
                        {
                            RefigeratedContents = true;
                        }

                        Console.WriteLine("Please enter the trunk Volume");
                        float trunkVolume = float.Parse(Console.ReadLine());

                        Console.WriteLine("Please enter the fuel Tank volume ");
                        float currentfuelTankvolume = float.Parse(Console.ReadLine());

                        Truck truck = new Truck(RefigeratedContents, trunkVolume, manufacturerName, licenseNumber, currentfuelTankvolume, airpresure, tireManufacturer);
                        garage.AddVehicle(truck, name, phone);

                        break;
                }
            }

            Console.WriteLine("Done");
        }

        internal static float[] AddTiersPressure(int numberOfTiers)
        {
            Console.Clear();
            float[] airPresure = new float[numberOfTiers];
            for (int i = 0; i < numberOfTiers; i++)
            {
                Console.WriteLine(string.Format("Please insert the current pressure of the {0} tier", i + 1));
                float.TryParse(Console.ReadLine(), out airPresure[i]);
            }

            return airPresure;
        }

        internal static void checkLiscenceType(string liscenceType)
        {
            Console.Clear();
            if (liscenceType.Equals("A") || liscenceType.Equals("A1") || liscenceType.Equals("B1") || liscenceType.Equals("BB"))
            {
                return;
            }
            else
            {
                throw new ArgumentException(String.Format("There is not a {0} motorcycle liscence type\n(A,A1,B1,BB) ", liscenceType));
            }
        }

        internal static void ShowGargeViechelsByFilter(Garage garage)
        {
            // enter 0 for no filer , 1 for InRepair and so on...
            Console.WriteLine("Enter 0 For No filer.\nEnter 1 for InRepair.\nEnter 2 for Finished Repair.\nPress 3 for paid.");
            string filterInput = Console.ReadLine();
            Console.Clear();
            int filter = 0;
            int.TryParse(filterInput, out filter);
            if (filter < 0 || 3 < filter)
            {
                throw new ValueOutOfRangeException(0, 3);
            }

            string list = garage.ListOfLisenceVehicles(filter);
            Console.WriteLine(list);
        }

        internal static void ChangeGarageStatus(Garage garage)
        {
            Console.WriteLine("Please enter your vehcile lisecne number: ");
            string lisenceNumber = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Enter 0 For No filer, Enter 1 for InRepair, Enter 2 for FinishedRepair and 3 for paid  ");
            string strStatus = Console.ReadLine();
            Console.Clear();
            GarageStatus status;
            GarageStatus.TryParse(strStatus, out status);
            if ((int)status < 0 || 3 < (int)(status))
            {
                throw new ValueOutOfRangeException(0, 3);
            }

            garage.ChangeGarageStatus(lisenceNumber, status);
            Console.WriteLine("Done");
        }

        internal static void InflateAirToMax(Garage garage)
        {
            Console.WriteLine("Please enter your vehcile lisecne number: ");
            string lisenceNumberForAir = Console.ReadLine();
            Console.Clear();
            bool checkAir = garage.SetAirPressureMax(lisenceNumberForAir);
            if (checkAir == false)
            {
                Console.WriteLine("The vechile is not exist in the garage");
                return;
            }

            Console.WriteLine("Tires are set to max air pressure");
        }

        internal static void FuelGazolineVeichle(Garage garage)
        {
            float amountToAdd;
            Console.WriteLine("Please enter your vehcile lisecne number: ");
            string lisenceNumberForFuel = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Please enter your fuel type ");
            string fuelType = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Please enter your the amount of fuel to add ");
            string strAmountFuel = Console.ReadLine();
            Console.Clear();
            float.TryParse(strAmountFuel, out amountToAdd);
            garage.FuelVeichele(lisenceNumberForFuel, fuelType, amountToAdd);
            Console.WriteLine("Veichle has fuled.");
        }

        internal static void ChargeElectricVeichle(Garage garage)
        {
            float amountToAdd;
            Console.WriteLine("Please enter your vehcile lisecne number: ");
            string lisenceNumberForCharge = Console.ReadLine();
            Console.WriteLine("Please enter your the amount of time to add ");
            string strAmountTime = Console.ReadLine();
            float.TryParse(strAmountTime, out amountToAdd);
            garage.ChargeVechile(lisenceNumberForCharge, amountToAdd);
            Console.WriteLine("Veichle has charged.");
        }

        internal static void ShowCarDetails(Garage garage)
        {
            Console.WriteLine("Please enter your vehcile lisecne number: ");
            string fullDetails = "There is no such";
            string lisenceNumberDetails = Console.ReadLine();
            fullDetails = garage.ShowFullDetails(lisenceNumberDetails);
            if (fullDetails.Contains(("There is no such")))
            {
                Console.WriteLine(fullDetails);
            }
            else
            {
                Console.WriteLine(fullDetails);
            }  
        }
    }
}