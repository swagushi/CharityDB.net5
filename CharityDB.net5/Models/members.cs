using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CharityDB.net5.Models
{
    public class members
    {
        public int membersId { get; set; }
        [Display(Name ="Member Name"),Required, MaxLength(50)]
        public string membersName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<donations> Donations { get; set; }
    }
}
