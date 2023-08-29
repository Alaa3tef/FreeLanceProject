using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Policy;
using TempProject.Models;

namespace TempProject.Repository
{
    public class PTSMRepository : IPTSMRepository
	{
        Context c;
        public PTSMRepository(Context c)
        {
            this.c = c;
        }

        public List<PTSM> getall()
        {
            return c.PTSMs
				.Include(a => a.Attendances)
				.Include(a => a.Rig)
                .Include(a => a.user)
				.Where(a => a.IsDeleted == false)
				.ToList();
        }
    }
}
