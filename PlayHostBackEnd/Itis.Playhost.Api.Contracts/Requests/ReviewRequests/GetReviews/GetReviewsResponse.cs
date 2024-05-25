namespace Itis.Playhost.Api.Contracts.Requests.ReviewRequests.GetReviews
{
	/// <summary>
	/// Ответ на запрос получения сущности "Обзор"
	/// </summary>
	public class GetReviewsResponse
	{
		/// <summary>
		/// Конструктор
		/// </summary>
		public GetReviewsResponse()
		{
		}

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="entities">Список сущностей</param>
		/// <param name="totalCount">Общее количество сущностей</param>
		public GetReviewsResponse(List<GetReviewsResponseItem> entities, int totalCount)
		{
			Entities = entities;
			TotalCount = totalCount;
		}

		/// <summary>
		/// Список сущностей
		/// </summary>
		public List<GetReviewsResponseItem> Entities { get; set; } = default!;

		/// <summary>
		/// Общее количество сущностей
		/// </summary>
		public int TotalCount { get; set; }
	}
}