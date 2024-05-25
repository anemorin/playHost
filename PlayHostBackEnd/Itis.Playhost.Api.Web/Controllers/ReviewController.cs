using Itis.Playhost.Api.Contracts.Requests.ReviewRequests.GetReviews;
using Itis.Playhost.Api.Contracts.Requests.ReviewRequests.PostReview;
using Itis.Playhost.Api.Core.Requests.ReviewRequests.GetReviews;
using Itis.Playhost.Api.Core.Requests.ReviewRequests.PostReview;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Itis.Playhost.Api.Web.Controllers
{
	/// <summary>
	/// Контроллер сущности "Обзор"
	/// </summary>
	public class ReviewController : BaseController
	{
		/// <summary>
		/// Получить список сущностей по фильтру
		/// </summary>
		/// <param name="mediator">Медиатор CQRS</param>
		/// <param name="request">Запрос</param>
		/// <param name="cancellationToken">Токен отмены запроса</param>
		/// <returns>Список сущностей</returns>
		[HttpGet]
		public async Task<GetReviewsResponse> GetAsync(
			[FromServices] IMediator mediator,
			[FromQuery] GetReviewsRequest request,
			CancellationToken cancellationToken) =>
			await mediator.Send(
				request == null
					? new GetReviewsQuery()
					: new GetReviewsQuery
					{
						PageNumber = request.PageNumber,
						PageSize = request.PageSize,
						OrderBy = request.OrderBy,
						IsAscending = request.IsAscending,
					},
				cancellationToken);
		/// <summary>
		/// Создание новой записи
		/// </summary>
		/// <param name="mediator">Медиатор CQRS</param>
		/// <param name="request">Запрос</param>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <returns>Идентификатор созданной записи</returns>
		[HttpPost]
		public async Task<PostReviewResponse> CreateAsync(
			[FromServices] IMediator mediator,
			[FromBody] PostReviewRequest request,
			CancellationToken cancellationToken)
		{
			if (request is null)
				throw new ArgumentNullException(nameof(request));

			return await mediator.Send(
				new PostReviewCommand()
				{
					Rate = request.Rate,
					UserId = request.UserId,
				},
				cancellationToken);
		}
	}
}
