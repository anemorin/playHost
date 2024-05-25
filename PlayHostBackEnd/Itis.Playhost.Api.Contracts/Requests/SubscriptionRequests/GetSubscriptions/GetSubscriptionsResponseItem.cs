namespace Itis.Playhost.Api.Contracts.Requests.SubscriptionRequests.GetSubscriptions
{
	/// <summary>
	/// Подписка для <see cref="GetSubscriptionsResponse"/>
	/// </summary>
	public class GetSubscriptionsResponseItem
	{
		/// <summary>
		/// Идентификатор
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// Цена
		/// </summary>
		public int Price { get; set; }

		/// <summary>
		/// Дата начала
		/// </summary>
		public DateTime StartDate { get; set; }

		/// <summary>
		/// Дата окончания
		/// </summary>
		public DateTime EndDate { get; set; }

		/// <summary>
		/// Сервер
		/// </summary>
		public Guid ServerId { get; set; }

		/// <summary>
		/// Игра
		/// </summary>
		public Guid GameId { get; set; }
	}
}
