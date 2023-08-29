using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Policy;
using TempProject.Models;

namespace TempProject.Repository
{
    public class BOPRepository : IBOPRepossitory
	{
        Context c;
        public BOPRepository(Context c)
        {
            this.c = c;
        }

        public List<BOP> getall()
        {
            return c.Bop
				.Include(a => a.Rig)
                .Include(a => a.user)
				.Where(a => a.IsDeleted == false)
				.ToList();
        }
    }
}
