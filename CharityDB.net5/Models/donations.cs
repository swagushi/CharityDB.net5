using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CharityDB.net5.Models
{
    public class donations
    {
        public int donationsID { get; set; }
        public string UserID { get; set; }
        public string donationName { get; set; }
        public int donationPrice { get; set; } 
        public string donationDescription { get; set; }
        public int TransactionID { get; set; }
        public string TransactionName { get; set; }
        public string Banktype { get; set; }
        public int AccountNumber { get; set; }

    }
}
