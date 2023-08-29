using Microsoft.AspNetCore.SignalR;

namespace TempProject.Hubs
{
	public class TestHub : Hub
	{
		public async void Test()
		{
			string name = "ITI";

			await Clients.All.SendAsync("NewCommentNotify",name);
		}

		public override Task OnConnectedAsync()
		{
			return base.OnConnectedAsync();
		}
	}
}
