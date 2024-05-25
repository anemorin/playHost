namespace Itis.Playhost.Api.Contracts.Requests.NewRequests.GetNews
{
	/// <summary>
	/// Ответ на запрос получения сущности "Новость"
	/// </summary>
	public class GetNewsResponse
	{
		/// <summary>
		/// Конструктор
		/// </summary>
		public GetNewsResponse()
		{
		}

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="entities">Список сущностей</param>
		/// <param name="totalCount">Общее количество сущностей</param>
		public GetNewsResponse(List<GetNewsResponseItem> entities, int totalCount)
		{
			Entities = entities;
			TotalCount = totalCount;
		}

		/// <summary>
		/// Список сущностей
		/// </summary>
		public List<GetNewsResponseItem> Entities { get; set; } = default!;

		/// <summary>
		/// Общее количество сущностей
		/// </summary>
		public int TotalCount { get; set; }
	}
}