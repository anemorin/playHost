using Itis.Playhost.Api.Contracts.Requests.SubscriptionRequests.ExtendSubsriptionSubscription;
using MediatR;

namespace Itis.Playhost.Api.Core.Requests.SubscriptionRequests.ExtendSubsriptionSubscription
{
	/// <summary>
	/// Запрос на изменение сущности "Подписка"
	/// </summary>
	public class ExtendSubsriptionSubscriptionCommand : ExtendSubsriptionSubscriptionRequest, IRequest
	{

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="id">Id сущности</param>
		public ExtendSubsriptionSubscriptionCommand(Guid id)
			=> Id = id;

		/// <summary>
		/// Id записи
		/// </summary>
		public Guid Id { get; }
	}
}
