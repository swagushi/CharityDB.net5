using System.Collections.Generic;

namespace CharityDB.net5.Models
{
    public class donations
    {
        public int donationsID { get; set; }
        public string donationName { get; set; }
        public int donationPrice { get; set; } 
        public string donationDescription { get; set; }
        public int TransactionID { get; set; }
        public string TransactionName { get; set; }
        public string Banktype { get; set; }
        public int AccountNumber { get; set; }

    }
}
