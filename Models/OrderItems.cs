using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EMedicineBE.Models
{
    public class OrderItems
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int MedicineId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal Quantity { get; set; }
        public decimal TotalPrice { get; set;}
        [ForeignKey("OrderId")]
        [JsonIgnore]
        public Orders order { get; set; }
        [ForeignKey("MedicineId")]
        [JsonIgnore]
        public Medicines Medicine { get; set; }
       
    }
}
