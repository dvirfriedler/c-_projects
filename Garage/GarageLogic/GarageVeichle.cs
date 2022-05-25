namespace Garage_DvirFriedler
{
    public enum GarageStatus
    {
        InRepair = 1,
        FinishedRepair = 2,
        Paid = 3
    }

    public class GarageVeichle
    {
        private Veichle m_Veichle;
        private string m_OwnerName;
        private string m_PhoneNumber;
        private GarageStatus m_GarageStatus;

        internal GarageVeichle(Veichle i_Veichle, string i_OwnerName, string i_PhoneNumber)
        {
            this.m_Veichle = i_Veichle;
            this.m_OwnerName = i_OwnerName;
            this.m_PhoneNumber = i_PhoneNumber;
            this.m_GarageStatus = GarageStatus.InRepair;
        }

        internal Veichle GetVeichle()
        {
            return this.m_Veichle;
        }

        internal string GetOnwerName()
        {
            return this.m_OwnerName;
        }

        internal string GetPhoneNumber()
        {
            return this.m_PhoneNumber;
        }

        internal GarageStatus GetGarageStatus()
        {
            return this.m_GarageStatus; 
        }

        internal string GarageStatusToString()
        {
            GarageStatus status = this.m_GarageStatus;
            string strStatus=string.Empty;
            switch ((int)status)
            {
                case 1:
                    strStatus =  "In Repair";
                    break;
                case 2:
                    strStatus =  "Finished Repair";
                    break;
                case 3:
                    strStatus =  "Paid";
                    break;
            }

            return strStatus;
        }

        internal void SetGarageStatus(GarageStatus i_GarageStatus)
        {
            this.m_GarageStatus = i_GarageStatus;
        }
    }
}