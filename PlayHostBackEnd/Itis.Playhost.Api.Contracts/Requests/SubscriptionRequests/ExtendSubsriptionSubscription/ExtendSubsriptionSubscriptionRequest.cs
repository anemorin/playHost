namespace Itis.Playhost.Api.Contracts.Requests.SubscriptionRequests.ExtendSubsriptionSubscription
{
	/// <summary>
	/// Команда на изменение списка "Подписка"
	/// </summary>
	public class ExtendSubsriptionSubscriptionRequest
	{
		/// <summary>
		/// Дней для добавления
		/// </summary>
		public int DaysToAdd { get; set; }
	}
}