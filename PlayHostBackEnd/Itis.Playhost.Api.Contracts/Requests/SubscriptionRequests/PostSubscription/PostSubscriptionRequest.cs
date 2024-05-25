namespace Itis.Playhost.Api.Contracts.Requests.SubscriptionRequests.PostSubscription
{
	/// <summary>
	/// Запрос на сохранение сущности "Подписка"
	/// </summary>
	public class PostSubscriptionRequest
	{
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

		/// <summary>
		/// Пользователь
		/// </summary>
		public Guid UserId { get; set; }
	}
}