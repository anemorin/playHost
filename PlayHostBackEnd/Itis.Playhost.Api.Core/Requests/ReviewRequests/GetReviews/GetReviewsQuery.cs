using Itis.Playhost.Api.Contracts.Requests.ReviewRequests.GetReviews;
using Itis.Playhost.Api.Core.Models;
using MediatR;

namespace Itis.Playhost.Api.Core.Requests.ReviewRequests.GetReviews
{
	/// <summary>
	/// Запрос получения списка "Обзор"
	/// </summary>
	public class GetReviewsQuery
	: GetReviewsRequest, IRequest<GetReviewsResponse>, IOrderByQuery, IPaginationQuery
	{ }
}
