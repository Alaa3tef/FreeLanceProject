namespace TempProject.DTO
{
	public class ChangePasswordDTO
	{
		public string id { set; get; }
		public string CurrentPassword { get; set; }
		public string NewPassword { get; set; }
	}
}
