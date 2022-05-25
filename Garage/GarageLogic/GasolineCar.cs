using System;
using System.Collections.Generic;
using System.Text;

namespace Garage_DvirFriedler
{
    public class GasolineCar : Car
    {
        private string m_FuelType;
        private float m_MaxFuelTankLiters;
        private float m_CurrentFuelTankLiters;

        public GasolineCar(string i_ModelName, string i_LicenseNumber, Color i_Color, int i_NumOfDoors, float i_CurrentFuelTankLiters, float[] i_AirPressure, string i_TireManufacturer, bool i_IsElectric = false)
            : base(i_ModelName, i_LicenseNumber, i_IsElectric, i_Color, i_NumOfDoors, i_AirPressure, i_TireManufacturer)
        {   
            this.m_MaxFuelTankLiters = (float)38;
            this.m_FuelType = "Octan95";
            this.m_CurrentFuelTankLiters = i_CurrentFuelTankLiters;
            this.m_EnergyLeft = (int) Math.Round((100 * m_CurrentFuelTankLiters / m_MaxFuelTankLiters));
        }

        public override void AddEnergy(float i_FuelToAdd,String fuleType)
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
            fullDetails.AppendLine(string.Format("Fuel Type ----- {0}", this.m_FuelType));
            fullDetails.AppendLine(string.Format("Max fuel Tank Volume ----- {0}", this.m_MaxFuelTankLiters));
            fullDetails.AppendLine(string.Format("Current Fuel Tank Volume ----- {0}", this.m_CurrentFuelTankLiters));

            return fullDetails.ToString();
        }
    }
}