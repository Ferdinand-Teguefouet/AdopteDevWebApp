using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdopteDevWebApp.Models.Contract
{
    public class GetContract
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public Decimal Price { get; set; }
        public DateTime DeadLine { get; set; }
    }
}
