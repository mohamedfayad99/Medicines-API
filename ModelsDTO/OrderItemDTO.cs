using EMedicineBE.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMedicineBE.ModelsDTO
{
    public class OrderItemDTO
    {
        public int OrderId { get; set; }
        public int MedicineId { get; set; }
        public decimal Quantity { get; set; }
    }
}
