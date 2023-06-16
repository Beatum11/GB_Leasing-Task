using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Services
{
    public class OfferService : IService<Offer>, ISearch
    {
        #region set-up

        private readonly AppDbContext appDbContext;

        public OfferService(AppDbContext context)
        {
            appDbContext = context;
        }

        #endregion

        #region GET
        public async Task<IEnumerable<Offer>> GetAll()
        {
            return await appDbContext.Offers.Include(o => o.Supplier).ToListAsync();
        }

        public async Task<Offer> GetById(int id)
        {
            return await appDbContext.Offers.Include(o => o.Supplier).SingleOrDefaultAsync(o => o.Id == id);
        }

        public async Task<IEnumerable<Offer>> SearchOffers(string searchTerm)
        {
            return await appDbContext.Offers
                .Where(o => o.Brand.Contains(searchTerm)
                            || o.Model.Contains(searchTerm)
                            || o.Supplier.Name.Contains(searchTerm))
                .Include(o => o.Supplier).ToListAsync();
        }

        public async Task<Offer> GetByName(string name)
        {
            return await appDbContext.Offers.FirstOrDefaultAsync(o => o.Brand == name);
        }

        #endregion

        #region POST

        public async Task<Offer> CreateItem(Offer offer)
        {
            appDbContext.Offers.Add(offer);
            await appDbContext.SaveChangesAsync();

            return offer;
        }

        #endregion

        #region PUT
        public async Task UpdateItem(Offer offer)
        {
            appDbContext.Entry(offer).State = EntityState.Modified;
            await appDbContext.SaveChangesAsync();
        }

        #endregion

        #region DELETE

        public async Task DeleteById(int id)
        {
            var offer = await appDbContext.Offers.FindAsync(id);
            appDbContext.Offers.Remove(offer);

            await appDbContext.SaveChangesAsync();
        }

        #endregion
    }
}
