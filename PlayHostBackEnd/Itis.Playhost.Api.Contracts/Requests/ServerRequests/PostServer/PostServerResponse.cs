namespace Itis.Playhost.Api.Contracts.Requests.ServerRequests.PostServer
{
	/// <summary>
	/// Ответ на запрос <see cref="PostServerRequest"/>
	/// </summary>
	public class PostServerResponse
	{
		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="id">Идентификатор созданного обращения</param>
		public PostServerResponse(Guid id)
			=> ServerId = id;

		/// <summary>
		/// Идентификатор сущности "Сервер"
		/// </summary>
		public Guid ServerId { get; }
	}
}