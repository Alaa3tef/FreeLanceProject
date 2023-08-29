using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Policy;
using TempProject.Models;

namespace TempProject.Repository
{
    public class JMPRepository : IJMPRepository
    {
        Context c;
        public JMPRepository(Context c)
        {
            this.c = c;
        }

        public List<JMP> getall()
        {
            return c.JMPs
                .Include(a => a.comminucationMethod)
                .Include(a => a.DriverName)
                .Include(a => a.RouteName)
                .Include(a => a.user)
                .Include(a => a.Vehicle)
                .Include(a => a.jMP_Passengers).ThenInclude(a=>a.Passenger)
                .Include(a => a.user).Where(a => a.IsDeleted == false).ToList();
        }
    }
}
