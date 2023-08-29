using System.ComponentModel;
using TempProject.Models;

namespace TempProject.DTO
{
    public class PassengerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string? Telephone { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

    }
}
