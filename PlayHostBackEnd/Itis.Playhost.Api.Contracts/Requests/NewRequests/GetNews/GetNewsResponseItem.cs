namespace Itis.Playhost.Api.Contracts.Requests.NewRequests.GetNews
{
	/// <summary>
	/// Новость для <see cref="GetNewsResponse"/>
	/// </summary>
	public class GetNewsResponseItem
	{
		/// <summary>
		/// Идентификатор
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// Текст
		/// </summary>
		public string Text { get; set; } = default!;

		/// <summary>
		/// Заголовк
		/// </summary>
		public string Title { get; set; } = default!;

		/// <summary>
		/// Дата создания
		/// </summary>
		public DateTime CreatedAt { get; set; }
	}
}
