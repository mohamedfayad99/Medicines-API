using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EMedicineBE.Models
{
    public class Cart
    {
        public int ID { get; set; }
        public int UserId { get; set; }
        public int MedicineId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Dicount { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        [ForeignKey("UserId")]
        [JsonIgnore]
        public Users User { get; set; }
        [ForeignKey("MedicineId")]
        [JsonIgnore]
        public Medicines Medicine { get; set; }



    }
}
