using System.ComponentModel;

namespace TempProject.Repository
{
    public interface ISoftDeleteRepository
    {

         public int Id { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
    }
}
