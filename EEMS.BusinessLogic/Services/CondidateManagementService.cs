using EEMS.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEMS.BusinessLogic.Services
{
    public class CondidateManagementService : ICondidateManagementService
    {
        public ICondidatesService CondidatesService { get;}
        public CondidateManagementService(ICondidatesService condidatesService)
        {
            CondidatesService = condidatesService;
        }
    }
}
