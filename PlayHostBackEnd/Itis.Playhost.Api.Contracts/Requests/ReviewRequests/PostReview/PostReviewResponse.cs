namespace Itis.Playhost.Api.Contracts.Requests.ReviewRequests.PostReview
{
	/// <summary>
	/// Ответ на запрос <see cref="PostReviewRequest"/>
	/// </summary>
	public class PostReviewResponse
	{
		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="id">Идентификатор созданного обращения</param>
		public PostReviewResponse(Guid id)
			=> ReviewId = id;

		/// <summary>
		/// Идентификатор сущности "Обзор"
		/// </summary>
		public Guid ReviewId { get; }
	}
}