using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using TempProject.Models;

namespace TempProject.DTO
{
    public class ProblemFacedDuringRigMoveDTO
    {
        public int Id { get; set; }

        public string Item { get; set; }

        public string ProblemDescription { get; set; }

        public double TimeLostProblem { get; set; }

        public string RecommendationProblemRepeated { get; set; }


       
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
    }
}
