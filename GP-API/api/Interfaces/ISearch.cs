using api.Models;

namespace api.Interfaces
{
    public interface ISearch
    {
        Task<IEnumerable<Offer>> SearchOffers(string searchTerm);
    }
}
