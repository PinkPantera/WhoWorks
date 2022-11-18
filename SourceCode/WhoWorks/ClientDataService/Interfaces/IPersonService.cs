using ClientDataService.Models;

namespace ClientDataService.Interfaces
{
    public interface IPersonService
    {
        Task<IEnumerable<PersonModel>> GetAllAsync();
        Task<PersonModel> UpdateAsync(PersonModel personModel);
        Task<PersonModel> CreateAsync(PersonModel personModel);
        Task DeleteAsync(PersonModel personModel);
    }
}
