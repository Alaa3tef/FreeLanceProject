using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using TempProject.Models;

namespace TempProject.DTO
{
	public class RigMovePerformanceDTO
	{

		public int Id { set; get; }

		public int RigId { set; get; }

		public string UserId { set; get; }

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

        public string? Item1 { get; set; }

        public string? ProblemDescription1 { get; set; }

        public double? TimeLostProblem1 { get; set; }

        public string? RecommendationProblemRepeated1 { get; set; }

        public string? Item2 { get; set; }

        public string? ProblemDescription2 { get; set; }

        public double? TimeLostProblem2 { get; set; }

        public string? RecommendationProblemRepeated2 { get; set; }

        public string? Item3 { get; set; }

        public string? ProblemDescription3 { get; set; }

        public double? TimeLostProblem3 { get; set; }

        public string? RecommendationProblemRepeated3 { get; set; }


        public string? Item4 { get; set; }

        public string? ProblemDescription4 { get; set; }

        public double? TimeLostProblem4 { get; set; }

        public string? RecommendationProblemRepeated4 { get; set; }


        public string? Item5 { get; set; }

        public string? ProblemDescription5 { get; set; }

        public double? TimeLostProblem5 { get; set; }

        public string? RecommendationProblemRepeated5 { get; set; }

    }
}
