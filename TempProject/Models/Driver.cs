using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using TempProject.Repository;

namespace TempProject.Models
{
    public class Driver : ISoftDeleteRepository
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
        public string PhoneNumber { get; set; }
        [Column(TypeName = "date")]
        public DateTime LicenceExpireData { get; set; }

        public string LicenceNumber {get; set; }
        public virtual List<JMP> JMPs { get; set; }
    }
}
