using Itis.Playhost.Api.Contracts.Requests.SubscriptionRequests.GetSubscriptions;
using Itis.Playhost.Api.Core.Models;
using MediatR;

namespace Itis.Playhost.Api.Core.Requests.SubscriptionRequests.GetSubscriptions
{
	/// <summary>
	/// Запрос получения списка "Подписка"
	/// </summary>
	public class GetSubscriptionsQuery
	: GetSubscriptionsRequest, IRequest<GetSubscriptionsResponse>, IOrderByQuery, IPaginationQuery
	{ }
}
