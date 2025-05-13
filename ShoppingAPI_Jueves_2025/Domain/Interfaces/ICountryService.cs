using ShoppingAPI_Jueves_2025.DAL.Entities;
namespace WebAPI.Domain.Interfaces
{
    public interface ICountryService
    {
        // firma de los metodos
        Task<IEnumerable<Country>> GetCountriesAsync();
        Task<Country> GetCountryByIdAsync(Guid id);
        Task<Country> CreateCountryAsync(Country country);
        Task<Country> EditCountryAsync(Country country);
        Task<Country> DeleteCountryAsync(Guid id);
    }
}
