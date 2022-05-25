namespace Garage_DvirFriedler
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class GasolineMotorCycle : MotorCycle
    {
        private string m_FuelType;
        private float m_MaxFuelTankLiters;
        private float m_CurrentFuelTankLiters;

        public GasolineMotorCycle(string i_ModelName, string i_LicenseNumber, string i_LicensType, int i_EngineCapacity, float i_CurrentFuelTankLiters, float[] i_CurrentPrusreArray, string i_TireManufacturer) :
            base(i_ModelName, i_LicenseNumber, i_LicensType, i_EngineCapacity, i_CurrentPrusreArray, i_TireManufacturer)
        {
            this.m_FuelType = "Octan98";
            this.m_MaxFuelTankLiters = (float)6.2;
            this.m_CurrentFuelTankLiters = i_CurrentFuelTankLiters;
            this.m_EnergyLeft = (int)Math.Round((100 * m_CurrentFuelTankLiters / m_MaxFuelTankLiters));
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

        public override string GetFuelType()
        {
            return this.m_FuelType;
        }

        public override string ToString()
        {
            StringBuilder fullDetails = new StringBuilder();
            string baseDetails = base.ToString();
            fullDetails.AppendLine(string.Format("{0}", baseDetails));
            fullDetails.AppendLine(string.Format("fuel Type ----- {0}", this.m_FuelType));
            fullDetails.AppendLine(string.Format("Max Fuel Tank Liters ----- {0}", this.m_MaxFuelTankLiters));
            fullDetails.AppendLine(string.Format("Current Fuel Tank Liters ----- {0}", this.m_CurrentFuelTankLiters));
            return fullDetails.ToString();
        }
    }
}
