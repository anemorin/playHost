namespace Itis.Playhost.Api.Contracts.Requests.ServerRequests.GetServers
{
	/// <summary>
	/// Ответ на запрос получения сущности "Сервер"
	/// </summary>
	public class GetServersResponse
	{
		/// <summary>
		/// Конструктор
		/// </summary>
		public GetServersResponse()
		{
		}

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="entities">Список сущностей</param>
		/// <param name="totalCount">Общее количество сущностей</param>
		public GetServersResponse(List<GetServersResponseItem> entities, int totalCount)
		{
			Entities = entities;
			TotalCount = totalCount;
		}

		/// <summary>
		/// Список сущностей
		/// </summary>
		public List<GetServersResponseItem> Entities { get; set; } = default!;

		/// <summary>
		/// Общее количество сущностей
		/// </summary>
		public int TotalCount { get; set; }
	}
}