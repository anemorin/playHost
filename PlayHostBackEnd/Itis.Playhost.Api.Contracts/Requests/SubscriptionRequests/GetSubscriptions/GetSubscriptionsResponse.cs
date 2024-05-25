namespace Itis.Playhost.Api.Contracts.Requests.SubscriptionRequests.GetSubscriptions
{
	/// <summary>
	/// Ответ на запрос получения сущности "Подписка"
	/// </summary>
	public class GetSubscriptionsResponse
	{
		/// <summary>
		/// Конструктор
		/// </summary>
		public GetSubscriptionsResponse()
		{
		}

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="entities">Список сущностей</param>
		/// <param name="totalCount">Общее количество сущностей</param>
		public GetSubscriptionsResponse(List<GetSubscriptionsResponseItem> entities, int totalCount)
		{
			Entities = entities;
			TotalCount = totalCount;
		}

		/// <summary>
		/// Список сущностей
		/// </summary>
		public List<GetSubscriptionsResponseItem> Entities { get; set; } = default!;

		/// <summary>
		/// Общее количество сущностей
		/// </summary>
		public int TotalCount { get; set; }
	}
}