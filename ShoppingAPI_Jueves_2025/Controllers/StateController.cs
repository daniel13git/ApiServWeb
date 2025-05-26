using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ShoppingAPI_Jueves_2025.DAL.Entities;
using System.Diagnostics.Metrics;
using WebAPI.DAL.Entities;
using WebAPI.Domain.Interfaces;
using WebAPI.Domain.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")] // nombre inicial de la ruta en el navegador (URL o Path)  [ ]
    [ApiController]
    public class StatesController : Controller
    {
        private readonly IStateService _stateService;
        public StatesController(IStateService stateService)
        {
            _stateService = stateService;
        }


        // Creacion del controlador Get

        [HttpGet, ActionName("Get")]
        [Route("GetAll")]

        public async Task<ActionResult<IEnumerable<State>>> GetStatesAsync()
        {
            var states = await _stateService.GetStatesAsync();

            if (states == null || !states.Any())
            {
                return NotFound();
            }
            return Ok(states);
        }



        // Creacion del controlador GetById

        [HttpGet, ActionName("Get")]
        [Route("GetById/{id}")]

        public async Task<ActionResult<State>> GetStateByIdAsync(Guid id)
        {
            var state = await _stateService.GetStateByIdAsync(id);

            if (state == null) return NotFound(); // Error 404

            return Ok(state); // Ok 200
        }



        // Creacion del controlador Create (Post)

        [HttpPost, ActionName("Create")]
        [Route("Create")]

        public async Task<ActionResult<State>> CreateStateAsync(State state)
        {
            try
            {
                var newState = await _stateService.CreateStateAsync(state);
                if (newState == null) return NotFound();
                return Ok(newState);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} ya existe", state.Name));
                return Conflict(ex.Message);
            }
        }




        // Creacion del controlador Update (put)

        [HttpPut, ActionName("Edit")]
        [Route("Edit")]

        public async Task<ActionResult<State>> EditStateAsync(State state)
        {
            try
            {
                var editedState = await _stateService.EditStateAsync(state);
                if (editedState == null) return NotFound();
                return Ok(editedState);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} ya existe", state.Name));
                return Conflict(ex.Message);
            }
        }




        // Creacion del controlador Delete (put)

        [HttpDelete, ActionName("Delete")]
        [Route("Delete")]

        public async Task<ActionResult<State>> DeleteStateAsync(Guid id)
        {
            if (id == null) return BadRequest();
            var deletedState = await _stateService.DeleteStateAsync(id);
            if (deletedState == null) return NotFound();
            return Ok(deletedState);
        }

    }
}
