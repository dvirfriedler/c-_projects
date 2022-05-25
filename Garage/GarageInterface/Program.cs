namespace Garage_DvirFriedler
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            string strInput = "Q";
            int intInput = 0;
            Garage garage = new Garage();
            Console.WriteLine("Welcome to the Garage");
            while (true)
            {
                while (strInput.Equals("Q"))
                {
                    GarageInterface.ShowMenu();
                    strInput = Console.ReadLine();
                    Console.Clear();
                    if (strInput.Equals("E"))
                    {
                        break;
                    }

                    intInput = int.Parse(strInput);
                    if (intInput < 1 || intInput > 7)
                    {
                        throw new ValueOutOfRangeException(1, 7);
                    }
                }

                if (strInput.Equals("E"))
                {
                    break;
                }
  
                switch (intInput)
                {
                    case 1:
                        GarageInterface.AddVeichle(garage);
                        break;
                    case 2:
                        GarageInterface.ShowGargeViechelsByFilter(garage);
                        break;
                    case 3:
                        GarageInterface.ChangeGarageStatus(garage);
                        break;
                    case 4:
                        GarageInterface.InflateAirToMax(garage);
                        break;
                    case 5:
                        GarageInterface.FuelGazolineVeichle(garage);

                        break;
                    case 6:
                        GarageInterface.ChargeElectricVeichle(garage);
                        break;
                    case 7:
                        GarageInterface.ShowCarDetails(garage);
                        break;
                }

                Console.WriteLine("Press enter to see the manu.");
                Console.ReadLine();
                Console.Clear();

                strInput = "Q";
            }
        }
    }
}