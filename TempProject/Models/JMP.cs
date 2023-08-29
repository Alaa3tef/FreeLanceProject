using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using TempProject.Enum;
using TempProject.Repository;

namespace TempProject.Models
{
    public class JMP : ISoftDeleteRepository
    {
        public int Id { get; set; }

        public int JournyNumber { get; set; }

        public string? NightDrivingReason { get; set; }

        public string? QHSEManagerMustApprove { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public string Destination { get; set; }

        public string Company { get; set; }

        public double SpeedLimit { get; set; }

        public double Distance  { get; set; }
        public string PurposeOfJourny { get; set; }
         
        public string ReachBeforeDark { get; set; }

        [ForeignKey("comminucationMethod")]
        public int CommunicationID { get; set; }

        public virtual ComminucationMethod comminucationMethod { get; set; }

        public string JournyManagerName { get; set; }
        public string ManagerNumber { get; set; }

        [ForeignKey("DriverName")]
        public int DriverNameId { get; set; }

        public string InspectionVechile { get; set; }

        public string Status { get; set; }


        public virtual Driver DriverName { get; set; }

      //  public string PhoneNumber { get; set; }

        [Column(TypeName = "date")]
        public DateTime DepartureDate { get; set; }


        public double Time { get; set; }

        [ForeignKey("Vehicle")]
        public int VehicleId { get; set; }

        public virtual Vehicle Vehicle { get; set; }

        [Column(TypeName = "date")]
        public DateTime EstimatedArriveDate { get; set; }

        public TimeSpan EstimatedArriveTime { get; set; }

        public string RestLocationNames { get; set; }

        [ForeignKey("RouteName")]
        public int RouteNameID { get; set; }

        public virtual RouteName RouteName { get; set; }

        public virtual List<JMP_Passenger> jMP_Passengers { get; set; }

        [ForeignKey("user")]
        public string userID { get; set; }
        public virtual IdentityUser user { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

		public DateTime EnterTime { get; set; }

		public NotifyStatus notifyStatus { get; set; }

        public DateTime ArrivalTime { get; set; }

		[DefaultValue(false)]
		public bool ArrivalStatus { get; set; }

    }
}
