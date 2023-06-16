using api.Models;

namespace api.Interfaces
{
    public interface ICount
    {
        Task<IEnumerable<SupplierOfferCount>> GetTopSuppliers();
    }
}
