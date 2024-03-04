namespace Kindergarden_Models
{
    public class Kids
    {
        private int kidId;
        private string firstKidName;
        private string lastKidName;   
        
        public int KidId
        {
            get { return kidId; }
            set { kidId = value; }
        }
        public string FirstKidName
        {
            get { return firstkidName; }
            set { firstkidName = value; }
        }
        public string LastKidName
        {
            get { return lastKidName; }
            set { lastKidName = value; }
        }

    }
}
