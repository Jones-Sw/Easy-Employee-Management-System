using EEMS.DataAccess.Models;


namespace EEMS.BusinessLogic.Interfaces
{
     public interface ICondidatesService
    {
        Task<IEnumerable<Condidate>> GetAsync();
        Task<Condidate> GetAsync(int id);
        Task<int> AddAsync(Condidate condidate);
        Task DeleteAsync(int id);
        Task UpdateAsync(Condidate condidate);
    }
}
