namespace Itis.Playhost.Api.Contracts.Requests.GameRequests.GetGames
{
	/// <summary>
	/// Ответ на запрос получения сущности "Видеоигра"
	/// </summary>
	public class GetGamesResponse
	{
		/// <summary>
		/// Конструктор
		/// </summary>
		public GetGamesResponse()
		{
		}

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="entities">Список сущностей</param>
		/// <param name="totalCount">Общее количество сущностей</param>
		public GetGamesResponse(List<GetGamesResponseItem> entities, int totalCount)
		{
			Entities = entities;
			TotalCount = totalCount;
		}

		/// <summary>
		/// Список сущностей
		/// </summary>
		public List<GetGamesResponseItem> Entities { get; set; } = default!;

		/// <summary>
		/// Общее количество сущностей
		/// </summary>
		public int TotalCount { get; set; }
	}
}