using Itis.Playhost.Api.Contracts.Requests.SubscriptionRequests.ExtendSubsriptionSubscription;
using Itis.Playhost.Api.Contracts.Requests.SubscriptionRequests.GetSubscriptions;
using Itis.Playhost.Api.Contracts.Requests.SubscriptionRequests.PostSubscription;
using Itis.Playhost.Api.Core.Constants;
using Itis.Playhost.Api.Core.Requests.SubscriptionRequests.DeleteSubscription;
using Itis.Playhost.Api.Core.Requests.SubscriptionRequests.ExtendSubsriptionSubscription;
using Itis.Playhost.Api.Core.Requests.SubscriptionRequests.GetSubscriptions;
using Itis.Playhost.Api.Core.Requests.SubscriptionRequests.PostSubscription;
using Itis.Playhost.Api.Web.Attributes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Itis.Playhost.Api.Web.Controllers
{
	/// <summary>
	/// Контроллер сущности "Подписка"
	/// </summary>
	public class SubscriptionController : BaseController
	{
		/// <summary>
		/// Получить список сущностей по фильтру
		/// </summary>
		/// <param name="mediator">Медиатор CQRS</param>
		/// <param name="request">Запрос</param>
		/// <param name="cancellationToken">Токен отмены запроса</param>
		/// <returns>Список сущностей</returns>
		[HttpGet]
		[Policy(PolicyConstants.IsDefaultUser)]
		public async Task<GetSubscriptionsResponse> GetAsync(
			[FromServices] IMediator mediator,
			[FromQuery] GetSubscriptionsRequest request,
			CancellationToken cancellationToken) =>
			await mediator.Send(
				request == null
					? new GetSubscriptionsQuery(CurrentUserId)
					: new GetSubscriptionsQuery(CurrentUserId)
					{
						PageNumber = request.PageNumber,
						PageSize = request.PageSize,
						OrderBy = request.OrderBy,
						IsAscending = request.IsAscending,
					},
				cancellationToken);
		
		/// <summary>
		/// Обновление записи
		/// </summary>
		/// <param name="mediator">Медиатор CQRS</param>
		/// <param name="id">Идентификатор</param>
		/// <param name="request">Запрос</param>
		/// <param name="cancellationToken">Токен отмены запроса</param>
		[HttpPut("{id}")]
		public async Task ExtendSubsriptionAsync(
			[FromServices] IMediator mediator,
			[FromRoute] Guid id,
			[FromBody] ExtendSubsriptionSubscriptionRequest request,
			CancellationToken cancellationToken)
		{
			if (request is null)
				throw new ArgumentNullException(nameof(request));

			await mediator.Send(
				new ExtendSubsriptionSubscriptionCommand(id)
				{
					DaysToAdd = request.DaysToAdd,
				},
				cancellationToken);
		}
		/// <summary>
		/// Удалить сущность по идентификатору
		/// </summary>
		/// <param name="mediator">Медиатор CQRS</param>
		/// <param name="id">Идентификатор</param>
		/// <param name="cancellationToken">Токен отмены запроса</param>
		/// <returns>Сущность</returns>
		[HttpDelete("{id}")]
		public async Task DeleteAsync(
			[FromServices] IMediator mediator,
			[FromRoute] Guid id,
			CancellationToken cancellationToken)
			=> await mediator.Send(new DeleteSubscriptionCommand(id), cancellationToken);
		/// <summary>
		/// Создание новой записи
		/// </summary>
		/// <param name="mediator">Медиатор CQRS</param>
		/// <param name="request">Запрос</param>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <returns>Идентификатор созданной записи</returns>
		[HttpPost]
		public async Task<PostSubscriptionResponse> CreateAsync(
			[FromServices] IMediator mediator,
			[FromBody] PostSubscriptionRequest request,
			CancellationToken cancellationToken)
		{
			if (request is null)
				throw new ArgumentNullException(nameof(request));

			return await mediator.Send(
				new PostSubscriptionCommand()
				{
					Price = request.Price,
					StartDate = request.StartDate,
					EndDate = request.EndDate,
					ServerId = request.ServerId,
					GameId = request.GameId,
					UserId = request.UserId,
				},
				cancellationToken);
		}
	}
}
