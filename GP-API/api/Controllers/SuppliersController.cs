using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        #region Set-up

        private readonly IService<Supplier> _supplierService;
        private readonly ICount _supplierCountService;

        public SuppliersController(IService<Supplier> supplierService, ICount supplierCountService)
        {
            _supplierService = supplierService;
            _supplierCountService = supplierCountService;
        }

        #endregion

        #region GET

        // GET: api/Suppliers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Supplier>>> GetSuppliers()
        {
           var suppliers = await _supplierService.GetAll();
           return suppliers == null ? NotFound() : Ok(suppliers);
        }

        // GET: api/Suppliers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Supplier>> GetSupplier(int id)
        {
            var supplier = await _supplierService.GetById(id);
            return supplier == null ? NotFound() : supplier;
        }

        //GET: api/Suppliers/topCount
        [HttpGet("topCount")]
        public async Task<ActionResult<IEnumerable<SupplierOfferCount>>> GetTopSuppliers()
        {
            var topSuppliers = await _supplierCountService.GetTopSuppliers();
            return Ok(topSuppliers);
        }

        #endregion

        #region POST

        // POST: api/Suppliers
        [HttpPost]
        public async Task<ActionResult<Supplier>> PostSupplier(Supplier supplier)
        {
            supplier.CreatedDate = DateTime.Now;

            var newSupplier = await _supplierService.CreateItem(supplier);

            return newSupplier == null ? NotFound() 
            : CreatedAtAction(nameof(GetSupplier), new { id = newSupplier.Id }, newSupplier);
        }

        #endregion

        #region PUT

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSupplier(int id, Supplier supplier)
        {
            if (id != supplier.Id)
            {
                return BadRequest();
            }
            else
            {
                await _supplierService.UpdateItem(supplier);
                return NoContent();
            }
        }

        #endregion

        #region DELETE

        // DELETE: api/Suppliers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupplier(int id)
        {
            await _supplierService.DeleteById(id);
            return NoContent();
        }


            #endregion
    }
}
