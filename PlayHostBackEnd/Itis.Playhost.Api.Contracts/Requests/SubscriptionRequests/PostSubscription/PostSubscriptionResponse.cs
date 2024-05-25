namespace Itis.Playhost.Api.Contracts.Requests.SubscriptionRequests.PostSubscription
{
	/// <summary>
	/// Ответ на запрос <see cref="PostSubscriptionRequest"/>
	/// </summary>
	public class PostSubscriptionResponse
	{
		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="id">Идентификатор созданного обращения</param>
		public PostSubscriptionResponse(Guid id)
			=> SubscriptionId = id;

		/// <summary>
		/// Идентификатор сущности "Подписка"
		/// </summary>
		public Guid SubscriptionId { get; }
	}
}