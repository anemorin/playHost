namespace Itis.Playhost.Api.Contracts.Requests.ReviewRequests.PostReview
{
	/// <summary>
	/// Запрос на сохранение сущности "Обзор"
	/// </summary>
	public class PostReviewRequest
	{
		/// <summary>
		/// Оценка от 1 до 5
		/// </summary>
		public int Rate { get; set; }

		/// <summary>
		/// Id пользователя
		/// </summary>
		public Guid UserId { get; set; }
	}
}