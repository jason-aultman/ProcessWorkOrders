using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessWorkOrders.Models
{
    public class WorkOrder
    {
        [Key]
        public int WorkOrderNumber { get; set; }
        public string InventoryItemNumber { get; set; }
        public string Description { get; set; }
        public string CustomerName { get; set; }
        public double Quantity { get; set; }
        public string ExtrusionInstruction { get; set; }
        public string? PrintingInstruction { get; set; }
        public string? PrintingUri { get; set; }
        public string? VentingUri { get; set; }
        public string LabelingInstruction {get; set;}
        public int WorkCenter { get; set; }
        public string? Notes { get; set; }
        public int SalesOrderNumber { get; set; }
        public DateTime DateNeeded { get; set; }
        public DateTime DateCreated { get; set; }
        public double RunSpeed { get; set; }
        public string Construction { get; set; }
        public bool IsFda { get; set; }

        public List<Roll> Rolls { get; set; } = new List<Roll>();
    }
}
