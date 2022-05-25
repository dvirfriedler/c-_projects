using System;
using System.Collections.Generic;
using System.Text;

namespace Garage_DvirFriedler
{
    public class ElectronicCar : Car
    {
        private float m_RemainingBatteryTime;
        private float m_MaxBatteryTime;

        public ElectronicCar(string i_ModelName, string i_LicenseNumber, Color i_Color, int i_NumOfDoors, float i_RemainingBatteryTime, float[] i_AirPrussure, string i_TireManufacturer)
            : base(i_ModelName, i_LicenseNumber, true, i_Color, i_NumOfDoors, i_AirPrussure, i_TireManufacturer)
        {
            this.m_IsElectric = true;
            this.m_RemainingBatteryTime = i_RemainingBatteryTime;
            this.m_MaxBatteryTime = (float)3.3;
            this.m_RemainingBatteryTime = i_RemainingBatteryTime;
            this.m_EnergyLeft = (int) Math.Round((100 * (m_RemainingBatteryTime / m_MaxBatteryTime)));
        }

        public override void AddEnergy(float i_EnergyToAdd, string type = null)
        {
            if ((i_EnergyToAdd + this.m_RemainingBatteryTime) > this.m_MaxBatteryTime)
            {
                throw new ValueOutOfRangeException(0, this.m_MaxBatteryTime - this.m_RemainingBatteryTime);
            }

            this.m_RemainingBatteryTime += i_EnergyToAdd;
            this.m_EnergyLeft = (int)Math.Round((100 * (m_RemainingBatteryTime / m_MaxBatteryTime)));
        }

        public override string ToString()
        {
            StringBuilder fullDetails = new StringBuilder();
            string baseDetails = base.ToString();
            fullDetails.AppendLine(string.Format("{0}", baseDetails));
            fullDetails.AppendLine(string.Format("Remaining Battery Time ----- {0}", this.m_RemainingBatteryTime));
            fullDetails.AppendLine(string.Format("Max Battery Time ----- {0}", this.m_MaxBatteryTime));
            return fullDetails.ToString();
        }
    }
}