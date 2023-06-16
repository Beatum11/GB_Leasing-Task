using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OffersController : ControllerBase
    {
        #region Set-up

        private readonly IService<Offer> _offerService;
        private readonly IService<Supplier> _supplierService;
        private readonly ISearch _offerSearchService;

        public OffersController(IService<Offer> offerService,
                                IService<Supplier> supplierService,
                                ISearch offerSearchService)
        {
            _offerService = offerService;
            _supplierService = supplierService;
            _offerSearchService = offerSearchService;
        }

        #endregion

        #region GET

        // GET: api/Offers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Offer>>> GetOffers()
        {
            var offers = await _offerService.GetAll();
            return offers == null ? NotFound() : Ok(offers);
        }

        // GET: api/Offers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Offer>> GetOffer(int id)
        {
            var offer = await _offerService.GetById(id);
            return offer == null ? NotFound() : offer;
        }

        [HttpGet("search/{searchTerm}")]
        public async Task<ActionResult<IEnumerable<Offer>>> SearchOffers(string searchTerm)
        {
            var offers = await _offerSearchService.SearchOffers(searchTerm);
            return Ok(offers);
        }

        #endregion

        #region POST

        // POST: api/Offers
        [HttpPost]
        public async Task<ActionResult<Offer>> PostOffer(Offer offer)
        {
            offer.Supplier = await _supplierService.GetByName(offer.Supplier.Name);
            offer.RegistrationDate = DateTime.Now;

            var newOffer = await _offerService.CreateItem(offer);

            return newOffer == null ? NotFound()
            : CreatedAtAction(nameof(GetOffer), new { id = newOffer.Id }, newOffer);
        }

        #endregion

        #region PUT

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOffer(int id, Offer offer)
        {
            if (id != offer.Id)
            {
                return BadRequest();
            }
            else
            {
                await _offerService.UpdateItem(offer);
                return NoContent();
            }
        }

        #endregion

        #region DELETE

        // DELETE: api/Offers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOffer(int id)
        {
            await _offerService.DeleteById(id);
            return NoContent();
        }


        #endregion
    }
}
