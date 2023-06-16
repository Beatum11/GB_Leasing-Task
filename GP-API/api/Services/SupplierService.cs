using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Services
{
    public class SupplierService : IService<Supplier>, ICount
    {
        #region set-up

        private readonly AppDbContext appDbContext;

        public SupplierService(AppDbContext context)
        {
            appDbContext = context;
        }

        #endregion

        #region GET
        public async Task<IEnumerable<Supplier>> GetAll()
        {
            return await appDbContext.Suppliers.ToListAsync();
        }

        public async Task<Supplier> GetById(int id)
        {
            return await appDbContext.Suppliers.FindAsync(id);
        }

        public async Task<Supplier> GetByName(string name)
        {
            return await appDbContext.Suppliers.FirstOrDefaultAsync(s => s.Name == name);
        }

        public async Task<IEnumerable<SupplierOfferCount>> GetTopSuppliers()
        {
            return await appDbContext.Offers
            .Where(o => o.Supplier != null)  
            .GroupBy(o => new { o.Supplier.Id, o.Supplier.Name })  
            .Select(g => new SupplierOfferCount
            {
                SupplierId = g.Key.Id,
                SupplierName = g.Key.Name,
                OfferCount = g.Count()
            })  
            .OrderByDescending(g => g.OfferCount)  
            .Take(3)  
            .ToListAsync();
        }

        #endregion

        #region POST

        public async Task<Supplier> CreateItem(Supplier supplier)
        {
            appDbContext.Suppliers.Add(supplier);
            await appDbContext.SaveChangesAsync();

            return supplier;
        }

        #endregion

        #region PUT
        public async Task UpdateItem(Supplier supplier)
        {
            appDbContext.Entry(supplier).State = EntityState.Modified;
            await appDbContext.SaveChangesAsync();
        }

        #endregion

        #region DELETE

        public async Task DeleteById(int id)
        {
            var supplier = await appDbContext.Suppliers.FindAsync(id);
            appDbContext.Suppliers.Remove(supplier);

            await appDbContext.SaveChangesAsync();
        }

        #endregion
    }
}
