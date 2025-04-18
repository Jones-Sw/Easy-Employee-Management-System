using EEMS.DataAccess.Models;

namespace EEMS.BusinessLogic.Interfaces
{
    public interface ICondidateManagementService
    {
     ICondidatesService CondidatesService { get; }
    }
}
