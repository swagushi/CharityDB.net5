using System.Collections.Generic;

namespace CharityDB.net5.Models
{
    public class items
    {
        public int itemsId { get; set; }
        public string clothes { get; set; }
        public string food { get; set; }
        public ICollection<donations> donations { get; set; }
    }
}
