using ShoppingAPI_Jueves_2025.DAL.Entities;
using WebAPI.DAL.Entities;
namespace WebAPI.Domain.Interfaces
{
    public interface IStateService
    {
        Task<IEnumerable<State>> GetStatesAsync();
        Task<Country> GetStateByIdAsync(Guid id);
        Task<Country> CreateStateAsync(State state);
        Task<Country> EditStateAsync(State state);
        Task<Country> DeleteStateAsync(Guid id);
    }
}
