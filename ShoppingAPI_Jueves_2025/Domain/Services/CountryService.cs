using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using ShoppingAPI_Jueves_2025.DAL;
using ShoppingAPI_Jueves_2025.DAL.Entities;
using WebAPI.Domain.Interfaces;
namespace WebAPI.Domain.Services

{
    public class CountryService : ICountryService
    {
        private readonly DataBaseContext _context;
        public CountryService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Country>> GetCountriesAsync()
        {
            return await _context.Countries.ToListAsync();
        }

        public Task<Country> GetCountryByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Country> CreateCountryAsync(Country country)
        {
            throw new NotImplementedException();
        }

        public Task<Country> EditCountryAsync(Country country)
        {
            throw new NotImplementedException();
        }

        public Task<Country> DeleteCountryAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
