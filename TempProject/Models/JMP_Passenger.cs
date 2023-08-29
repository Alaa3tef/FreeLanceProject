using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using TempProject.Repository;

namespace TempProject.Models
{
    public class JMP_Passenger : ISoftDeleteRepository
    {
        public int Id { get; set; }


        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        [ForeignKey("Passenger")]
        public int PassengerID { get; set; }
        [ForeignKey("JMP")]
        public int JMPID { get; set; }


        public virtual JMP JMP { get; set; }
        public virtual Passenger Passenger { get; set; }
    }
}
