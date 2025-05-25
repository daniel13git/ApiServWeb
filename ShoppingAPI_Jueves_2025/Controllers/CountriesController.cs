using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ShoppingAPI_Jueves_2025.DAL.Entities;
using System.Diagnostics.Metrics;
using WebAPI.Domain.Interfaces;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")] // nombre inicial de la ruta en el navegador (URL o Path)  [ ]
    [ApiController]
    public class CountriesController : Controller
    {
        private readonly ICountryService _countryService;
        public CountriesController(ICountryService countryService) {    
            _countryService = countryService;
        }


        // Creacion del controlador Get

        [HttpGet, ActionName("Get")]
        [Route ("GetAll")]

        public async Task<ActionResult<IEnumerable<Country>>> GetCountriesAsync()
        {
            var countries = await _countryService.GetCountriesAsync();

            if (countries == null || !countries.Any())
            {
                return NotFound();
            }
            return Ok(countries);
        }


        // Creacion del controlador GetById

        [HttpGet, ActionName("Get")]
        [Route("GetById/{id}")]

        public async Task<ActionResult<Country>> GetCountryByIdAsync(Guid id)
        {
            var country = await _countryService.GetCountryByIdAsync(id);

            if (country == null ) return NotFound(); // Error 404

            return Ok(country); // Ok 200
        }



        // Creacion del controlador Create (Post)

        [HttpPost, ActionName("Create")]
        [Route("Create")]

        public async Task<ActionResult<Country>> CreateCountryAsync(Country country)
        {
            try
            {
                var newCountry = await _countryService.CreateCountryAsync(country);
                if (newCountry == null) return NotFound();
                return Ok(newCountry);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} ya existe", country.Name));               
                return Conflict(ex.Message);
            }
        }



        // Creacion del controlador Update (put)

        [HttpPut, ActionName("Edit")]
        [Route("Edit")]

        public async Task<ActionResult<Country>> EditCountryAsync(Country country)
        {
            try
            {
                var editedCountry = await _countryService.EditCountryAsync(country);
                if (editedCountry == null) return NotFound();
                return Ok(editedCountry);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} ya existe", country.Name));
                return Conflict(ex.Message);
            }
        }



        // Creacion del controlador Delete (put)

        [HttpDelete, ActionName("Delete")]
        [Route("Delete")]

        public async Task<ActionResult<Country>> DeleteCountryAsync(Guid id)
        {         
            if (id == null) return BadRequest();
            var deletedCountry = await _countryService.DeleteCountryAsync(id);
            if (deletedCountry == null) return NotFound();
            return Ok(deletedCountry);         
        }
    }
}
