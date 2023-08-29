using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using TempProject.Repository;

namespace TempProject.Models
{
    public class ProblemFacedDuringRigMove: ISoftDeleteRepository
    {

        public int Id { get; set; }

        public string Item { get; set; }  = "Not Found"; 

        public string ProblemDescription { get; set; } = "Not Found";
        public double TimeLostProblem { get; set; } 

        public string RecommendationProblemRepeated { get; set; } = "Not Found";


        [ForeignKey("RigMovePerformance")]
        public int RigMovePerformanceId { get; set; }
        public virtual RigMovePerformance RigMovePerformance { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
    }
}
