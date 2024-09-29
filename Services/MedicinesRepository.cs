using AutoMapper;
using EMedicineBE.Controllers;
using EMedicineBE.DBContext;
using EMedicineBE.Exceptions;
using EMedicineBE.Models;
using EMedicineBE.ModelsDTO;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EMedicineBE.Services
{
    public class MedicinesRepository : IMedicinesRepository
    {
 
        private readonly ApplicationDB _applicationDB1;
        private readonly ILogger<MedicinesController> _logger;
        private readonly IMapper _mapper;

        public MedicinesRepository(ApplicationDB applicationDB1, ILogger<MedicinesController> logger,IMapper mapper)
        {
            _applicationDB1 = applicationDB1;
            _logger = logger;
            _mapper = mapper;
        }
        private bool IsValidMedicineDTO(MedicinesDTO dto)
        {
            // Name must not be null or empty
            if (string.IsNullOrEmpty(dto.Name))
            {
                _logger.LogWarning("Medicine name is required.");
                return false;
            }

            // Manufacturer must not be null or empty
            if (string.IsNullOrEmpty(dto.Manufuctarer))
            {
                _logger.LogWarning("Manufacturer is required.");
                return false;
            }

            // UnitPrice must be a positive value
            if (dto.UnitPrice <= 0)
            {
                _logger.LogWarning("UnitPrice must be greater than zero.");
                return false;
            }

            // Discount must be between 0 and 100
            if (dto.Discount < 0 || dto.Discount > 100)
            {
                _logger.LogWarning("Discount must be between 0 and 100.");
                return false;
            }

            // Quantity must be a positive integer
            if (dto.Quantity < 0)
            {
                _logger.LogWarning("Quantity must be greater than or equal zero.");
                return false;
            }

            // Expiration date must be in the future
            if (dto.ExpDate <= DateTime.Now)
            {
                _logger.LogWarning("Expiration date must be in the future.");
                return false;
            }

            // ImageUrl should be a valid URL (if provided)
            if (!string.IsNullOrEmpty(dto.ImageUrl) && !Uri.IsWellFormedUriString(dto.ImageUrl, UriKind.Absolute))
            {
                _logger.LogWarning("ImageUrl must be a valid URL.");
                return false;
            }

            // Status must be a valid value (e.g., 0 for inactive, 1 for active)
            if (dto.Status < 0 || dto.Status > 1)
            {
                _logger.LogWarning("Status must be either 0 (inactive) or 1 (active).");
                return false;
            }

            // Type must not be null or empty
            if (string.IsNullOrEmpty(dto.Type))
            {
                _logger.LogWarning("Type is required.");
                return false;
            }

            return true;
        }


        public async Task<IEnumerable<Medicines>> GetMedicinesAsync()
        {
            var medicines = await _applicationDB1.medicines.Include(c => c.Carts).
                                  Include(o=>o.OrdersItems).ToListAsync();
            if (medicines == null)
            {
                _logger.LogError("Not Found Medicines");
                return null;
            }
            _logger.LogInformation("Returnning all medicines");
            return medicines;
        }
        public async Task<Medicines> GetMedicine(string? name)
        {
            if (name == null )
            {
                _logger.LogError("Invalid name");
                throw new ArgumentException("Invalid name. Please enter a valid name.");
            }
            var medicine = await _applicationDB1.medicines.Include(c => c.Carts)
                                 .Include(o => o.OrdersItems).FirstOrDefaultAsync(m => m.Name.ToLower() == name.ToLower());
            if (medicine == null)
            {
                _logger.LogWarning($"medicine with name {name} not found.");
                throw new NotFoundException($"medicine with name {name} not found.");

            }
            return medicine;
        }
        public async Task<MedicinesDTO> AddMedicine(MedicinesDTO medicinesDTO)
        {
            // Validate the DTO (if applicable)
            if (!IsValidMedicineDTO(medicinesDTO))
            {
                _logger.LogWarning("Invalid MedicinesDTO provided.");
                throw new ArgumentException("Invalid MedicinesDTO provided.");
            }
            var existingMedicine = await _applicationDB1.medicines
                 .FirstOrDefaultAsync(m => m.Name.ToLower() == medicinesDTO.Name.ToLower());

            if (existingMedicine != null)
            {
                _logger.LogWarning($"A medicine with the name '{medicinesDTO.Name}' already exists.");
                return null;
            }
            var Addmedicines = _mapper.Map<Medicines>(medicinesDTO);
            _applicationDB1.medicines.Add(Addmedicines);
            await _applicationDB1.SaveChangesAsync();
            _logger.LogInformation($"the City that have id {Addmedicines.ID} is created");
            return medicinesDTO;
        }

        public async Task<MedicinesDTO> UpdateMedicine(string? name, MedicinesDTO medicinesDTO)
        {
            if (name == null)
            {
                _logger.LogWarning("Please Enter Correct name!!");
                throw new ArgumentException("Invalid name. Please enter a valid name.");
            }
            // Validate the DTO (if applicable)
            if (!IsValidMedicineDTO(medicinesDTO))
            {
                _logger.LogWarning("Invalid MedicinesDTO provided.");
                throw new ArgumentException("Invalid MedicinesDTO provided.");
            }
            var updatedmedicine = await _applicationDB1.medicines.FirstOrDefaultAsync(m => m.Name.ToLower() == name.ToLower());
            if (updatedmedicine == null)
            {
                _logger.LogWarning($"medicine with name {name} not found.");
                throw new NotFoundException($"medicine with name {name} not found.");
            }
            var existingMedicine = await _applicationDB1.medicines
                 .FirstOrDefaultAsync(m => m.Name.ToLower() == medicinesDTO.Name.ToLower() && m.ID !=updatedmedicine.ID);

            if (existingMedicine != null)
            {
                _logger.LogWarning($"A medicine with the name '{medicinesDTO.Name}' already exists.");
                return null;
            }
            _mapper.Map(medicinesDTO,updatedmedicine);
            _applicationDB1.medicines.Update(updatedmedicine);
            await _applicationDB1.SaveChangesAsync();
            _logger.LogInformation($"Medicines with name {name} is updated");
            return medicinesDTO;

        }
        public async Task DeleteMedicine(string? name)
        {
            if (name == null)
            {
                _logger.LogWarning("Please Enter Correct name!!");
                throw new ArgumentException("Invalid name. Please enter a valid name.");
            }
            var deletedmedicine = await _applicationDB1.medicines.FirstOrDefaultAsync(m => m.Name.ToLower() == name.ToLower());
            if (deletedmedicine == null)
            {
                _logger.LogWarning($"medicine with name {name} not found.");
                throw new NotFoundException($"medicine with name {name} not found.");
            }
            _applicationDB1.medicines.Remove(deletedmedicine);
            await _applicationDB1.SaveChangesAsync();
        }

        public async Task<Cart> AddToCart(CartDTO cartDTO)
        {
            var medicine = await _applicationDB1.medicines.FirstOrDefaultAsync(u => u.ID == cartDTO.MedicineId);
            if (medicine == null)
            {
                _logger.LogWarning($"medicine with id {cartDTO.MedicineId} not found.");
                throw new NotFoundException($"medicine with id {cartDTO.MedicineId} not found.");
            }

            // Verify that the Medicine exists
            var user =await _applicationDB1.users.FirstOrDefaultAsync(u => u.ID == cartDTO.UserId);
            if (user == null)
            {
                _logger.LogWarning($"user with id {cartDTO.UserId} not found.");
                throw new NotFoundException($"user with id {cartDTO.UserId} not found.");
            }
            var cart= _mapper.Map<Cart>(cartDTO);
            cart.UnitPrice=medicine.UnitPrice;
            cart.Dicount = medicine.Discount;
            cart.TotalPrice = (medicine.UnitPrice - medicine.Discount) * cartDTO.Quantity;
            _applicationDB1.carts.Add(cart);
            await _applicationDB1.SaveChangesAsync();
            _logger.LogInformation($"Added to Cart Done....");
            return cart;
        }
        public async Task<Orders> PlaseOrder(Orders order)
        {
            if (order == null || order.UserId == 0 || order.orderItems == null || !order.orderItems.Any())
            {
                _logger.LogWarning("Invalid Order provided.");
                throw new ArgumentException("Invalid order data.");
            }
            order.OrderNo = Guid.NewGuid().ToString();
            foreach (var item in order.orderItems)
            {
                item.TotalPrice += (item.UnitPrice - item.Discount) * item.Quantity;
            }
            order.OrderTotal = order.orderItems.Sum(item => item.TotalPrice);
            // Calculate the total order amount
            //  order.OrderTotal = order.orderItems.Sum(item => item.Quantity * item.UnitPrice);

            // Set initial order status
            order.OrderStatus = "Pending";

            _applicationDB1.orders.Add(order);
            await _applicationDB1.SaveChangesAsync();
            _logger.LogInformation("Order Added");
            return order;

        }

        public async Task<ICollection<OrderItems>> OrderList()
        {
            var orders = await _applicationDB1.orderItems.ToListAsync();
            return orders;
        }

    }


}
