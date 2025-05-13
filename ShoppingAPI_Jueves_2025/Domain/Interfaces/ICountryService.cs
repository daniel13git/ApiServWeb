using ShoppingAPI_Jueves_2025.DAL.Entities;
namespace WebAPI.Domain.Interfaces
{
    public interface ICountryService
    {
        Task<IEnumerable<Country>> GetCountriesAsync(); // firma del metodo
        Task<Country> CreateCountryAsync(Country country);
        Task<Country> GetCountryByIdAsync(Guid id);
        Task<Country> EditCountryAsync(Country country);
        Task<Country> DeleteCountryAsync(Guid id);
    }
}
