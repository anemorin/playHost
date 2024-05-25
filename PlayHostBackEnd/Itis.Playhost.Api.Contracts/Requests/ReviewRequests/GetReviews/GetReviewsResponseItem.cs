namespace Itis.Playhost.Api.Contracts.Requests.ReviewRequests.GetReviews
{
	/// <summary>
	/// Обзор для <see cref="GetReviewsResponse"/>
	/// </summary>
	public class GetReviewsResponseItem
	{
		/// <summary>
		/// Идентификатор
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// ОЦенка от 1 до 5
		/// </summary>
		public int Rate { get; set; }

		/// <summary>
		/// Дата создания
		/// </summary>
		public DateTime CreatedAt { get; set; }
	}
}
