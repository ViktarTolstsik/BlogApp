using BlogApp.RazorPages.Enums;

namespace BlogApp.RazorPages.Models.ViewModels
{
	public class Notification
	{
		public string Message { get; set; }

		public NotificationType Type { get; set; }
	}
}
