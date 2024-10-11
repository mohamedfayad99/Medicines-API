using EMedicineBE.Models;
using EMedicineBE.ModelsDTO;

namespace EMedicineBE.Services
{
    public interface IMedicinesRepository
    {
        Task<IEnumerable<Medicines>> GetMedicinesAsync();
        Task<Medicines> GetMedicine(string? name);
        Task<MedicinesDTO> AddMedicine(MedicinesDTO medicinesDTO);

        Task<MedicinesDTO> UpdateMedicine(string? name, MedicinesDTO medicinesDTO);
        Task DeleteMedicine(string? name);
        Task<Cart> AddToCart(CartDTO cartDTO);
        Task<Orders> PlaseOrder(OrderItemDTO orders);
        Task<ICollection<OrderItems>> OrderList();
    }
}
