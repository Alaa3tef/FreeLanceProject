using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using TempProject.Models;

namespace TempProject.DTO.ResponseDTO
{
    public class RigPerformanceResponseDTO
    {
        public int Id { set; get; }

        public int RigNumber { set; get; }

        public string UserName { set; get; }

        public string OldWellName { set; get; }
        public string NewWellName { set; get; }
        public double MoveDistance { set; get; }

        public TimeSpan ReleaseTime { get; set; }

        public TimeSpan AcceptanceTime { set; get; }

        [Column(TypeName = "date")]
        public DateTime ReleaseDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime AcceptanceDate { get; set; }

        public double ActualMoveTime { set; get; }

        public double DieselConsumed { set; get; }

        public string TargetArchived { set; get; }
        public double BudgetTargetTotalDay { set; get; }

        public double BudgetTargetTotalMoney { set; get; }


        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        public List<ProblemFacedDuringRigMoveDTO> ProblemFacedDuringRigMoveDTOs = new List<ProblemFacedDuringRigMoveDTO>();
    }
}
