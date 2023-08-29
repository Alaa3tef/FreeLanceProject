using System.ComponentModel;
using System.Runtime.Serialization;
using TempProject.Repository;

namespace TempProject.Models
{
    public class Passenger: ISoftDeleteRepository
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string? Telephone { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        [IgnoreDataMember]
        public virtual List<JMP_Passenger> jMP_Passengers { get; set; }

    }
}
