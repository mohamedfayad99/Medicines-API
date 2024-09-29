using EMedicineBE.Exceptions;
using EMedicineBE.Models;
using EMedicineBE.ModelsDTO;
using EMedicineBE.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMedicineBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicinesController : BaseController
    {
        private readonly IConfiguration _configuration;
        private readonly IMedicinesRepository _medicinesRepository;

        public MedicinesController(IConfiguration configuration,IMedicinesRepository medicinesRepository)
        {
            _configuration = configuration;
            _medicinesRepository = medicinesRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Medicines>>> GetAllMedicines()
        {
            var medicines = await _medicinesRepository.GetMedicinesAsync();
            if (medicines == null)
            {
                return NotFound("No Found Any Medicine!!");
            }
            return Ok(medicines);
        }

        [HttpGet("{name?}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Medicines>> GetMedicine(string? name)
        {
            var medicines = await _medicinesRepository.GetMedicine(name);
            return Ok(medicines);
        }

        [HttpPost("Addmedicines")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult> Addmedicines(MedicinesDTO medicinesDTO )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(medicinesDTO);
            }
            var addedMedicine = await _medicinesRepository.AddMedicine(medicinesDTO);

            if (addedMedicine == null)
            {
                // If the medicine already exists, return a 409 Conflict response
                return Conflict($"A medicine with the name '{medicinesDTO.Name}' already exists.");
            }

            return CreatedAtAction(nameof(GetMedicine),new{name=addedMedicine.Name}, addedMedicine);
        }

        [HttpPut("updatemedicines/{name?}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult> UpdateMedicine(string? name, MedicinesDTO medicinesDTO)
        {
            var updatedmedicine=await _medicinesRepository.UpdateMedicine(name , medicinesDTO);
            if (updatedmedicine == null)
            {
                // If the medicine already exists, return a 409 Conflict response
                return Conflict($"A medicine with the name '{medicinesDTO.Name}' already exists.");
            }
            return Ok(updatedmedicine);
        }

        [HttpDelete("deltemedicine/{name?}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteMedicine(string? name)
        {
            try
            {
                await _medicinesRepository.DeleteMedicine(name);
                return NoContent(); // 204 No Content
            }
            catch (NotFoundException ex)
            {
                return NotFound($"no found medicine with name {name}"); // 404 Not Found
            }
        }

        [HttpPost("addtocart")]
        public async Task<ActionResult> addToCart([FromBody]CartDTO cartDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid cartDTO provided");
            }
            var cart = await _medicinesRepository.AddToCart(cartDTO);
            if(cart == null)
            {
                return BadRequest("");
            }
            return CreatedAtAction(nameof(addToCart), new {id=cart.ID},cart);
        }

        [HttpPost("placeOrder")]
        public async Task<ActionResult> placeOrder([FromBody]Orders orders)
        {
            var order = await _medicinesRepository.PlaseOrder(orders);
            if(order == null) {
                return BadRequest();
            }
            return Ok(new { OrderId = order.ID, Message = "Order placed successfully!" });
        }

        [HttpGet("orderList")]
        public async Task<ActionResult> orderList()
        {
            var order = await _medicinesRepository.OrderList();
            if(order == null)
            {
                return BadRequest("");
            }
            return Ok(order);
        }
    }
}
