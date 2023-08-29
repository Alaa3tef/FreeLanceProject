using System.ComponentModel;
using TempProject.Repository;

namespace TempProject.Models
{
	public class Rig: ISoftDeleteRepository
    {
		public int Id { get; set; }
		public int Number { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
        public virtual List<Accident> Accidents { get; set; }
        public virtual List<RigMovePerformance> RigMovePerformances { get; set; }
    }
}
