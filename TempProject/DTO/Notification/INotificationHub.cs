namespace TempProject.DTO.Notification
{
	public interface INotificationHub
	{
		public Task SendMessage(Notification notification);
	}
}
