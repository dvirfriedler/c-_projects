namespace Garage_DvirFriedler
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Truck : Veichle
    {
        private List<Tier> m_Tiers;
        private bool m_IsRefigeratedContents;
        private float m_TrunkVolume;
        private string m_FuelType;
        private float m_MaxFuelTankLiters;
        private float m_CurrentFuelTankLiters;

        public Truck(bool i_IsRefigeratedContents, float i_TrunkVolume, string i_ModelName, string i_LicenseNumber, float i_CurrentFuelTankvolume, float[] i_CurrentPrusreArray, string i_TireManufacturer, bool i_IsElectric = false) :
            base(i_ModelName, i_LicenseNumber)
        {
            List<Tier> m_tiers = new List<Tier> { };
            for (int i = 0; i < 16; i++)
            {
                Tier tier = new Tier(i_TireManufacturer, i_CurrentPrusreArray[i], 24);
                m_tiers.Add(tier);
            }

            this.m_FuelType = "Soler";
            this.m_MaxFuelTankLiters = 120;
            this.m_CurrentFuelTankLiters = i_CurrentFuelTankvolume;
            this.m_Tiers = m_tiers;
            this.m_IsRefigeratedContents = i_IsRefigeratedContents;
            this.m_TrunkVolume = i_TrunkVolume;
            this.m_EnergyLeft = 100 * (int)(m_CurrentFuelTankLiters / m_MaxFuelTankLiters);
        }

        public override string GetFuelType()
        {
            return this.m_FuelType;
        }

        public override List<Tier> GetTiers()
        {
            return m_Tiers;
        }

        public override void AddEnergy(float i_FuelToAdd, String fuleType)
        {
            if ((i_FuelToAdd + this.m_CurrentFuelTankLiters) > this.m_MaxFuelTankLiters)
            {
                throw new ValueOutOfRangeException(0, this.m_MaxFuelTankLiters - this.m_CurrentFuelTankLiters);
            }

            if (!fuleType.Equals(this.m_FuelType))
            {
                throw new ArgumentException("wrong fuel type");
            }

            this.m_CurrentFuelTankLiters += i_FuelToAdd;
            this.m_EnergyLeft = (int)Math.Round((100 * m_CurrentFuelTankLiters / m_MaxFuelTankLiters));
        }

        public override string ToString()
        {
            StringBuilder fullDetails = new StringBuilder();
            string baseDetails = base.ToString();
            fullDetails.AppendLine(string.Format("{0}", baseDetails));
            fullDetails.AppendLine(string.Format("Refigerated Contents ----- {0}", this.m_IsRefigeratedContents));
            fullDetails.AppendLine(string.Format("Trunk Volume ----- {0}", this.m_TrunkVolume));
            fullDetails.AppendLine(string.Format("Fuel Type ----- {0}", this.m_FuelType));
            fullDetails.AppendLine(string.Format("Max fuel Tank Volume ----- {0}", this.m_MaxFuelTankLiters));
            fullDetails.AppendLine(string.Format("Current Fuel Tank Volume ----- {0}", this.m_CurrentFuelTankLiters));
            return fullDetails.ToString();
        }
    }
}
