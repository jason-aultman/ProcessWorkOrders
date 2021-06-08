using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessWorkOrders.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }

        public List<WorkOrder> WorkOrders { get; set; } = new List<WorkOrder>();

    }
}
