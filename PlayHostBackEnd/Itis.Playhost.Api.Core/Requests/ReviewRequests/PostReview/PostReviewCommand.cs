using Itis.Playhost.Api.Contracts.Requests.ReviewRequests.PostReview;
using MediatR;

namespace Itis.Playhost.Api.Core.Requests.ReviewRequests.PostReview
{
	/// <summary>
	/// Команда запроса <see cref="PostReviewRequest"/>
	/// </summary>
	public class PostReviewCommand : PostReviewRequest, IRequest<PostReviewResponse>
	{
	}
}