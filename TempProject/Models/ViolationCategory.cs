using System.ComponentModel;
using TempProject.Repository;

namespace TempProject.Models
{
	public class ViolationCategory: ISoftDeleteRepository
    {
		public int Id { get; set; }
		public string Name { get; set; }

		[DefaultValue(false)]
		public bool IsDeleted { get; set; }
		public virtual List<Accident> Accidents { get; set; }

	}
}
