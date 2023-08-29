using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TempProject.Models;

namespace TempProject.Repository
{
    public class RigMovePerformanceRepository : IRigMovePerformanceRepository
    {
        Context c;
        public RigMovePerformanceRepository(Context c)
        {
            this.c = c;
        }

       

        List<RigMovePerformance> IRigMovePerformanceRepository.getall()
        {
            return c.RigMovePerformances
                .Include(a => a.problemFacedDuringRigMoves)

                .Include(a => a.Rig)

                .Include(a => a.user)

                .Where(a => a.IsDeleted == false).ToList();
               
        }
    }
}
