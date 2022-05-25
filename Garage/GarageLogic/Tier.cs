namespace Garage_DvirFriedler
{
    using System;
    using System.Text;

    public class Tier
    {
        private string m_ManufacturerName;
        private float m_CurrenAirPressure;
        private float m_MaxAirPressure;

        public Tier(string i_ManufacturerName, float i_CurrenAirPressure, float i_MaxAirPressure)
        {
            this.m_ManufacturerName = i_ManufacturerName;
            this.m_CurrenAirPressure = i_CurrenAirPressure;
            this.m_MaxAirPressure = i_MaxAirPressure;
            if (i_CurrenAirPressure > i_MaxAirPressure)
            {
                throw new ArgumentException("Current Air Pressure cant be greater the the max");
            }
        }

        internal bool AddAir(float i_AirPressure)
        {
            if ((this.m_CurrenAirPressure + i_AirPressure) > this.m_MaxAirPressure)
            {
                throw new ValueOutOfRangeException(0, this.m_MaxAirPressure - this.m_CurrenAirPressure);
            }

            this.m_CurrenAirPressure += i_AirPressure;
            return true;
        }

        internal float GetCurrentPressure()
        {
            return m_CurrenAirPressure;
        }

        internal float GetMaxPressure()
        {
            return m_MaxAirPressure;
        }

        public override string ToString()
        {
            StringBuilder fullList = new StringBuilder();
            fullList.AppendLine("Tier Details:");
            fullList.AppendLine(string.Format("Manufacturer Name -----{0}", m_ManufacturerName));
            fullList.AppendLine(string.Format("Current Air Pressure -----{0}", m_CurrenAirPressure));
            fullList.AppendLine(string.Format("Max Air Pressure -----{0}", m_MaxAirPressure));
            fullList.AppendLine();
            return fullList.ToString();
        }
    }
}
