using MediatR;

namespace Itis.Playhost.Api.Core.Requests.SubscriptionRequests.DeleteSubscription
{
	/// <summary>
	/// Запрос удаления сущности "Подписка"
	/// </summary>
	public class DeleteSubscriptionCommand : IRequest
	{
		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="id">Id сущности</param>
		public DeleteSubscriptionCommand(Guid id)
			=> Id = id;

		/// <summary>
		/// Id записи
		/// </summary>
		public Guid Id { get; }
	}
}
