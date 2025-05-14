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
            try
            {
                var countries = await _context.Countries.ToListAsync();
                return countries;
            }
            catch (DbUpdateException DbUpdateException)
            {
                throw new Exception(DbUpdateException.InnerException?.Message ?? DbUpdateException.Message);
            }

        }

        public async Task<Country> GetCountryByIdAsync(Guid id)
        {
            try
            {
                var country = await _context.Countries.FirstOrDefaultAsync(c => c.Id == id);
                return country;
            }
            catch (DbUpdateException DbUpdateException)
            {
                throw new Exception(DbUpdateException.InnerException?.Message ?? DbUpdateException.Message);
            }

        }

        public async Task<Country> CreateCountryAsync(Country country)
        {
            try
            {
                country.Id = Guid.NewGuid();
                country.CreatedDate = DateTime.Now;
                _context.Countries.Add(country); // el Add() crea el objeto en el contexto de la BD
                await _context.SaveChangesAsync(); // guarda el pais en la tabla Country
                return country;
            }
            catch (DbUpdateException DbUpdateException)
            {
                throw new Exception(DbUpdateException.InnerException?.Message ?? DbUpdateException.Message);
            }
        }

        public async Task<Country> EditCountryAsync(Country country)
        {
            try
            {
                country.ModifiedDate = DateTime.Now;
                _context.Countries.Update(country);
                await _context.SaveChangesAsync();
                return country;
            }
            catch (DbUpdateException DbUpdateException)
            {
                throw new Exception(DbUpdateException.InnerException?.Message ?? DbUpdateException.Message);
            }
        }

        public async Task<Country> DeleteCountryAsync(Guid id)
        {
            try
            {
                var country = await GetCountryByIdAsync(id);

                if (country == null)
                {
                    return null;
                }

                _context.Countries.Remove(country);
                await _context.SaveChangesAsync();
                return country;
            }
            catch (DbUpdateException DbUpdateException)
            {
                throw new Exception(DbUpdateException.InnerException?.Message ?? DbUpdateException.Message);
            }
        }
    }
}
