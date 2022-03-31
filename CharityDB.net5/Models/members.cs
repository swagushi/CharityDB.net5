using System.Collections.Generic;

namespace CharityDB.net5.Models
{
    public class members
    {
        public int membersId { get; set; }
        public string membersName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<donations> Donations { get; set; }
    }
}
