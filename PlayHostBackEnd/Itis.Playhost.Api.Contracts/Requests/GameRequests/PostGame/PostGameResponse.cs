namespace Itis.Playhost.Api.Contracts.Requests.GameRequests.PostGame
{
	/// <summary>
	/// Ответ на запрос <see cref="PostGameRequest"/>
	/// </summary>
	public class PostGameResponse
	{
		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="id">Идентификатор созданного обращения</param>
		public PostGameResponse(Guid id)
			=> GameId = id;

		/// <summary>
		/// Идентификатор сущности "Видеоигра"
		/// </summary>
		public Guid GameId { get; }
	}
}