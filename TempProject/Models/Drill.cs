using System.ComponentModel;
using TempProject.Repository;

namespace TempProject.Models
{
    public class Drill : ISoftDeleteRepository
    {
        public int Id { get; set; }

        public string DrillType { get; set; }

		[DefaultValue(false)]
		public bool IsDeleted { get; set; }

	}
}
