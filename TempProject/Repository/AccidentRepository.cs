using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Policy;
using TempProject.Models;

namespace TempProject.Repository
{
    public class AccidentRepository:IAccidentRepository
    {
        Context c;
        public AccidentRepository(Context c)
        {
            this.c = c;
        }

        public List<Accident> getall()
        {
            return c.Accidents
                .Include(a => a.AccidentCauses)
                .Include(a => a.ClassificationOfAccident)
                .Include(a => a.PreventionCategory)
                .Include(a => a.Rig)
                .Include(a => a.TypeOfInjury)
                .Include(a => a.user)
                .Include(a => a.ViolationCategory)
                .Include(a => a.ToolPusherPosition)
                .Include(a=>a.ToolPusherPosition)
                .Include(a => a.QHSEPosition)
                .Include(a => a.QHSEPositionName)
				.Where(a => a.IsDeleted == false)
				.Select(a => new Accident
                {
                    Id = a.Id,
                    Rig = new Rig { Number = a.Rig.Number },
                    TimeOfEvent = a.TimeOfEvent,
                    DateOfEvent = a.DateOfEvent,
                    ClassificationOfAccidentId = a.ClassificationOfAccidentId,
                    TypeOfInjury = new TypeOfInjury { Name = a.TypeOfInjury.Name },
                    ViolationCategory = new ViolationCategory { Name = a.ViolationCategory.Name },
                    AccidentCauses = new AccidentCauses { Name = a.AccidentCauses.Name },
                    PreventionCategory = new PreventionCategory { Name = a.PreventionCategory.Name },
                    ClassificationOfAccident = new ClassificationOfAccident { Name = a.ClassificationOfAccident.Name },
                    QHSEPosition = new QHSEPosition
                    {
                        Name = a.QHSEPosition.Name,
                    },
                    QHSEPositionName = new QHSEPositionName
                    {
                        Name = a.QHSEPositionName.Name,
                    },
                    ToolPusherPosition = new ToolPusherPosition
                    {
                        Name = a.ToolPusherPosition.Name,
                    },
                    ToolPusherPositionName = new ToolPusherPositionName
                    {
                        Name = a.ToolPusherPositionName.Name,
                    },
                    AccidentLocation = a.AccidentLocation,
                    PusherEmpCode = a.PusherEmpCode,
                    QHSEEmpCode= a.QHSEEmpCode,
                    DrillerName = a.DrillerName,
                    DescriptionOfTheEvent = a.DescriptionOfTheEvent,
                    ImmediateActionType = a.ImmediateActionType,
                    DirectCauses = a.DirectCauses,
                    RootCauses = a.RootCauses,
                    Recommendations = a.Recommendations,
                    Pictures = a.Pictures,
                    user = new IdentityUser { UserName = a.user.UserName,Id=a.user.Id }
                }).ToList();
        }
    }
}
