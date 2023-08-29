using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using TempProject.Models;

namespace TempProject.DTO
{
    public class JMP_PassengerDTO
    {
        public int Id { get; set; }


        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        [ForeignKey("Passenger")]
        public int PassengerID { get; set; }
        [ForeignKey("JMP")]
        public int JMPID { get; set; }


    }
}
