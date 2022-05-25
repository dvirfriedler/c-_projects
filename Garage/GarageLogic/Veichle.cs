using System;
using System.Collections.Generic;
using System.Text;

namespace Garage_DvirFriedler
{
    public class Veichle
    {   
         public enum GarageStatus
            {
            NotInGarage = 0,
            InRepair = 1,
            FinishedRepair = 2,
            Paid = 3
            }

        private string m_ModelName;
        private string m_LicenseNumber;
        protected bool m_IsElectric;
        private List<Tier> m_Tiers;
        protected int m_EnergyLeft;

        public Veichle(string i_ModelName, string m_LicenseNumber, List<Tier> m_Tiers = null)
        {
            this.m_ModelName = i_ModelName;
            this.m_LicenseNumber = m_LicenseNumber;
            this.m_IsElectric = false;
            this.m_Tiers = m_Tiers;
            this.m_EnergyLeft = 0; 
        }

        public string GetLisenceNumber()
        {
            return this.m_LicenseNumber;
        }

        public virtual List<Tier> GetTiers()
        {
            return m_Tiers;
        }

        public string GetManufacturerName()
        {
            return this.m_ModelName;
        }

        public virtual bool IsElectric()
        {
            return this.m_IsElectric;
        }

        public virtual void AddEnergy(float eneregyToAdd, String FuelType="")
        {
            return;
        }

        public virtual string GetFuelType()
        {
            return "";
        }

        public override string ToString()
        {
            StringBuilder fullDetails = new StringBuilder();
            fullDetails.AppendLine(string.Format("Nubmer Lisence ----- {0}", this.m_LicenseNumber));
            fullDetails.AppendLine(string.Format("Model Name ----- {0}", this.m_ModelName));
            fullDetails.AppendLine(string.Format("Energy Left ----- {0}%", this.m_EnergyLeft));
            fullDetails.AppendLine();
            int countTire = 1;
            foreach (Tier tire in this.GetTiers())
            {
                fullDetails.AppendLine(string.Format("Tire number {0} : ", countTire));
                fullDetails.Append(tire.ToString());
                countTire += 1;
            }

            return fullDetails.ToString();
        }
    }
}