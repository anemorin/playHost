namespace Itis.Playhost.Api.Contracts.Requests.NewRequests.PostNew
{
	/// <summary>
	/// Ответ на запрос <see cref="PostNewRequest"/>
	/// </summary>
	public class PostNewResponse
	{
		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="id">Идентификатор созданного обращения</param>
		public PostNewResponse(Guid id)
			=> NewId = id;

		/// <summary>
		/// Идентификатор сущности "Новость"
		/// </summary>
		public Guid NewId { get; }
	}
}