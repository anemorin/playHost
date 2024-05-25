using Itis.Playhost.Api.Contracts.Requests.SubscriptionRequests.PostSubscription;
using MediatR;

namespace Itis.Playhost.Api.Core.Requests.SubscriptionRequests.PostSubscription
{
	/// <summary>
	/// Команда запроса <see cref="PostSubscriptionRequest"/>
	/// </summary>
	public class PostSubscriptionCommand : PostSubscriptionRequest, IRequest<PostSubscriptionResponse>
	{
	}
}