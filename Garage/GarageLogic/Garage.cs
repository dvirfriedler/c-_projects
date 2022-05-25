namespace Garage_DvirFriedler
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Garage
    {
        private List<GarageVeichle> m_GarageVechiles;

        public Garage()
        {
            m_GarageVechiles = new List<GarageVeichle>();
        }

        public bool IsVeichleInGarge(string i_OwnerName, string i_PhoneNumber)
        {
            bool check = false;
            foreach (GarageVeichle garageVeichle in m_GarageVechiles)
            {
                if (garageVeichle.GetOnwerName().Equals(i_OwnerName) && garageVeichle.GetPhoneNumber().Equals(i_PhoneNumber))
                {
                    check = true;
                }
            }

            return check;
        }

        public void AddVehicle(Veichle i_Veichle, string i_OwnerName, string i_PhoneNumber)
        {
            GarageVeichle garageVeichle = new GarageVeichle(i_Veichle, i_OwnerName, i_PhoneNumber);
            m_GarageVechiles.Add(garageVeichle);
        }

        public string ListOfLisenceVehicles(int i_Filter)
        {
            string toString = string.Empty;
            StringBuilder listOfVeicheles = new StringBuilder();
            listOfVeicheles.AppendLine("\nList Of Veichels: ");
            if (m_GarageVechiles.Count == 0)
            {
                listOfVeicheles.AppendLine("The garage has no cars");
                toString = listOfVeicheles.ToString();
            }
            else
            {
                foreach (GarageVeichle garageVeichle in m_GarageVechiles)
                {
                    Veichle veichle = garageVeichle.GetVeichle();
                    if (i_Filter != 0)
                    {
                        if ((int)garageVeichle.GetGarageStatus() == i_Filter)
                        {
                            listOfVeicheles.AppendLine(veichle.GetLisenceNumber());
                        }

                        continue;
                    }

                    listOfVeicheles.AppendLine(veichle.GetLisenceNumber());
                }

                toString = listOfVeicheles.ToString();
            }

            return toString;
        }

        public GarageVeichle GetGarageVeichleByLisence(string i_LisenceNumber)
        {
            foreach (GarageVeichle garageVeichle in m_GarageVechiles)
            {
                Veichle veichle = garageVeichle.GetVeichle();
                if (veichle.GetLisenceNumber().Equals(i_LisenceNumber))
                {
                    return garageVeichle;
                }
            }

            throw new ArgumentException("Vechile is not exist");
        }

        public bool ChangeGarageStatus(string i_LisenceNumber, GarageStatus i_NewStatus)
        {
            GarageVeichle garageVeichle = GetGarageVeichleByLisence(i_LisenceNumber);
            bool isStatusChanged = false;
            if (garageVeichle != null)
            {
                garageVeichle.SetGarageStatus(i_NewStatus);
                isStatusChanged = true;
            }

            return isStatusChanged;
        }

        public bool SetAirPressureMax(string i_LisenceNumber)
        {
            bool isStatusChanged = true;
            GarageVeichle garageVeichle = GetGarageVeichleByLisence(i_LisenceNumber);
            if (garageVeichle == null)
            {
                isStatusChanged = false;
            }
            else
            {
                Veichle veichle = garageVeichle.GetVeichle();
                List<Tier> tiers = veichle.GetTiers();
                foreach (Tier tire in tiers)
                {
                    float currentAirPressure = tire.GetCurrentPressure();
                    float maxAirPressure = tire.GetMaxPressure();
                    float airToAdd = maxAirPressure - currentAirPressure;
                    tire.AddAir(airToAdd);
                }
            }

            return isStatusChanged;
        }

        public void FuelVeichele(string i_LisenceNumber, string i_FuelType, float i_AmountToAdd)
        {
            GarageVeichle garageVeichle = GetGarageVeichleByLisence(i_LisenceNumber);
            Veichle veichle = garageVeichle.GetVeichle();
            if (veichle.IsElectric() == true)
            {
                throw new ArgumentException("Vechile is not fule type");
            }
            else
            {
                veichle.AddEnergy(i_AmountToAdd,i_FuelType);
            }  
        }

        public void ChargeVechile(string i_LisenceNumber, float i_AmountToAdd)
        {
            GarageVeichle garageVeichle = GetGarageVeichleByLisence(i_LisenceNumber);
            Veichle veichle = garageVeichle.GetVeichle();
            if (veichle.IsElectric() == false)
            {
                throw new ArgumentException("Vechile is not electric type");
            }
            else
            {
             veichle.AddEnergy(i_AmountToAdd);         
            }
        }

        public string ShowFullDetails(string i_LicenseNumber)
        {
            string strFullList = string.Empty;
            StringBuilder fullList = new StringBuilder();
            GarageVeichle garageVeichle = this.GetGarageVeichleByLisence(i_LicenseNumber);
            if (garageVeichle == null)
            {
                strFullList = "There is no such car in the garage with the number: " + i_LicenseNumber;
            }
            else
            {
                Veichle veichle = garageVeichle.GetVeichle();
                fullList.AppendLine(string.Format("Owner Name ----- {0}", garageVeichle.GetOnwerName()));
                fullList.AppendLine(string.Format("Vechile Status at the Garage ----- {0}", garageVeichle.GarageStatusToString()));
                fullList.Append(veichle.ToString());
                strFullList = fullList.ToString();
            }

            return strFullList;
        }
    }
}
