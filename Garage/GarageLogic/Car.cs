namespace Garage_DvirFriedler
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Car : Veichle
    {
        public enum Color
        {
            Red = 0, 
            White = 1,
            Green = 2,
            Blue = 3
        }

        private List<Tier> m_Tiers;
        private Color m_Color;
        private int m_NumOfDoors;

        public Car(string i_ModelName, string i_LicenseNumber, bool i_IsElectric, Color i_Color, int i_numOfDoors, float[] i_AirPressure, string i_TireManufacturer)
            : base(i_ModelName, i_LicenseNumber)
        {
            this.m_Tiers = new List<Tier> { };
            for (int i = 0; i < 4; i++)
            {
                Tier tier = new Tier(i_TireManufacturer, i_AirPressure[i], 29);
                m_Tiers.Add(tier);
            }

            this.m_Color = i_Color;
            this.m_NumOfDoors = i_numOfDoors;
        }

        public static Color SetColorByNumber(int i_ColorNumber)
        {
            Color carColor=0;

            switch (i_ColorNumber)
            {
                case 0:
                    carColor = Color.Red;
                    break;

                case 1:
                    carColor = Color.White;
                    break;
                case 2:
                    carColor = Color.Green;
                    break;
                case 3:
                    carColor = Color.Blue;
                    break;
            }

            if (i_ColorNumber > 3)
            {
                throw new ValueOutOfRangeException(0, 3);
            }

            return carColor;
        }

        public override bool IsElectric()
        {
            return this.m_IsElectric;
        }

        public override List<Tier> GetTiers()
        {
            return m_Tiers;
        }

        public override string ToString()
        {
            StringBuilder TruckDetails = new StringBuilder();
            string baseDetails = base.ToString();
            TruckDetails.AppendLine(string.Format("{0}", baseDetails));
            TruckDetails.AppendLine(string.Format("Color ----- {0}", this.m_Color));
            TruckDetails.AppendLine(string.Format("Number Of Doors ----- {0}", this.m_NumOfDoors));
            return TruckDetails.ToString();
        }
    }
}
