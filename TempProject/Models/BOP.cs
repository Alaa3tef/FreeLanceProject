using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using TempProject.Repository;

namespace TempProject.Models
{
    public class BOP:ISoftDeleteRepository
    {
        public int Id { get; set; }

        [ForeignKey("Rig")]
        public int RigId { get; set; }

        public virtual Rig Rig { get; set; }


        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public int ECDC { get; set; }

        public int Client { get; set; }

        public int Service { get; set; }

        public int Visitors { get; set; }
        public int Catering { get; set; }
        public int WatchMen { get; set; }

        public int inspection { get; set; }
        public int Rental { get; set; }
        public int Other { get; set; }

        public int ManPower{ get; set; }

        public int TotalManHours { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        [ForeignKey("user")]
        public string UserId { set; get; }

        public virtual IdentityUser user { get; set; }

    }
}
