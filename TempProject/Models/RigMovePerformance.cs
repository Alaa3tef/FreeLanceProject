using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using TempProject.Repository;
using Microsoft.AspNetCore.Identity;

namespace TempProject.Models
{
	public class RigMovePerformance:ISoftDeleteRepository
	{
		public int Id { set; get; }

        [ForeignKey("Rig")]
        public int RigId { set; get; }

        public virtual Rig Rig { get; set; }

        [ForeignKey("user")]
        public string UserId { set; get; }

        public virtual IdentityUser user { get; set; }

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
		

		public virtual List<ProblemFacedDuringRigMove>? problemFacedDuringRigMoves { get; set; }

    }
}
