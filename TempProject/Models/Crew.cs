using System.ComponentModel;
using TempProject.Repository;

namespace TempProject.Models
{
    public class Crew : ISoftDeleteRepository
    {
        public int Id { get; set; }

        public string CrewName { get; set; }

		[DefaultValue(false)]
		public bool IsDeleted { get; set; }

	}
}
