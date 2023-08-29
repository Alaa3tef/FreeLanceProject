namespace TempProject.DTO.Notification
{
	public interface IArrivalNotificationHub
	{
		public Task SendMessage2(ArrivalNotification notification);
	}
}
