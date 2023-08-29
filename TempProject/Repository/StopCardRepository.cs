using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Policy;
using TempProject.Models;

namespace TempProject.Repository
{
    public class StopCardRepository : IStopCardRepository
    {
        Context c;
        public StopCardRepository(Context c)
        {
            this.c = c;
        }

        public List<StopCardRegister> getall()
        {
            return c.StopCardRegisters
                .Include(s => s.Classification)
                .Include(s => s.ReportedByName)
                .Include(s => s.ReportedByPosition)
                .Include(s => s.TypeOfObservationCategory)
				.Where(a => a.IsDeleted == false)
				.Select(s => new StopCardRegister
                {
                    Id = s.Id,
                    Date = s.Date,
                    Classification = new Classification { Name = s.Classification.Name },
                    ReportedByPosition = new ReportedByPosition { Name = s.ReportedByPosition.Name },
                    ReportedByName = new ReportedByName { Name = s.ReportedByName.Name },
                    TypeOfObservationCategory = new TypeOfObservationCategory { Name = s.TypeOfObservationCategory.Name },
                    Description = s.Description,
                    EmpCode = s.EmpCode,
                    ActionRequired = s.ActionRequired,
                    Status = s.Status,
                    StopWorkAuthorityApplied = s.StopWorkAuthorityApplied,
                    user = new IdentityUser { UserName = s.user.UserName,Id=s.user.Id }
                }).ToList();
        }
    }
}
