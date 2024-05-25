namespace Itis.Playhost.Api.Contracts.Requests.NewRequests.PostNew
{
	/// <summary>
	/// Запрос на сохранение сущности "Новость"
	/// </summary>
	public class PostNewRequest
	{
		/// <summary>
		/// Текст
		/// </summary>
		public string Text { get; set; } = default!;

		/// <summary>
		/// Заголовк
		/// </summary>
		public string Title { get; set; } = default!;
	}
}