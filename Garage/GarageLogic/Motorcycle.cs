namespace Garage_DvirFriedler
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class MotorCycle : Veichle
    {
        private List<Tier> m_Tiers;
        private string m_LicenseType;
        private int m_EngineCapacity;

        public MotorCycle(string i_ModelName, string i_LicenseNumber, string i_LicenseType, int i_EngineCapacity, float[] i_CurrentPrussreArray, string i_TireManufacturer) :
            base(i_ModelName, i_LicenseNumber)
        {
            List<Tier> m_tiers = new List<Tier> { };
            for (int i = 0; i < 2; i++)
            {
                Tier tier = new Tier(i_TireManufacturer, i_CurrentPrussreArray[i], 29);
                m_tiers.Add(tier);
            }

            this.m_Tiers = m_tiers;
            this.m_LicenseType = i_LicenseType;
            this.m_EngineCapacity = i_EngineCapacity;
        }

        public override List<Tier> GetTiers()
        {
            return m_Tiers;
        }

        public override bool IsElectric()
        {
            return this.m_IsElectric;
        }

        public override string ToString()
        {
            StringBuilder fullDetails = new StringBuilder();
            string baseDetails = base.ToString();
            fullDetails.AppendLine(string.Format("{0}", baseDetails));
            fullDetails.AppendLine(string.Format("Licens Type ----- {0}", this.m_LicenseType));
            fullDetails.AppendLine(string.Format("Engine Capacity ----- {0}", this.m_EngineCapacity));

            return fullDetails.ToString();
        }
    }
}
