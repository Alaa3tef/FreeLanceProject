using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace TempProject.DTO
{
	public class LoginDTO
	{
		[MinLength(1)]
		public string UserName { get; set; }

		[MinLength(6)]
		public string Password { get; set; }
	}
}
