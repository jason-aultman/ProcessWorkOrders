using System.ComponentModel.DataAnnotations;

namespace ProcessWorkOrders.Models
{
    public class Roll
    {
        [Key]
        public int Id { get; set; }
        public double Weight { get; set; }
        public int Number { get; set; }
        public double? Width { get; set; }
        public double? Length { get; set; }
        public int? QuantityPer { get; set; }
        public double? Gauge { get; set; }
        public string Operator { get; set; }
        public int WorkOrderWorkOrderNumber { get; set; }
    }
}