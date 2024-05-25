using Itis.Playhost.Api.Contracts.Requests.NewRequests.GetNews;
using Itis.Playhost.Api.Contracts.Requests.NewRequests.PostNew;
using Itis.Playhost.Api.Core.Requests.NewRequests.DeleteNew;
using Itis.Playhost.Api.Core.Requests.NewRequests.GetNews;
using Itis.Playhost.Api.Core.Requests.NewRequests.PostNew;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Itis.Playhost.Api.Web.Controllers
{
	/// <summary>
	/// Контроллер сущности "Новость"
	/// </summary>
	public class NewController : BaseController
	{
		/// <summary>
		/// Получить список сущностей по фильтру
		/// </summary>
		/// <param name="mediator">Медиатор CQRS</param>
		/// <param name="request">Запрос</param>
		/// <param name="cancellationToken">Токен отмены запроса</param>
		/// <returns>Список сущностей</returns>
		[HttpGet]
		public async Task<GetNewsResponse> GetAsync(
			[FromServices] IMediator mediator,
			[FromQuery] GetNewsRequest request,
			CancellationToken cancellationToken) =>
			await mediator.Send(
				request == null
					? new GetNewsQuery()
					: new GetNewsQuery
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
		public async Task<PostNewResponse> CreateAsync(
			[FromServices] IMediator mediator,
			[FromBody] PostNewRequest request,
			CancellationToken cancellationToken)
		{
			if (request is null)
				throw new ArgumentNullException(nameof(request));

			return await mediator.Send(
				new PostNewCommand()
				{
					Text = request.Text,
					Title = request.Title,
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
			=> await mediator.Send(new DeleteNewCommand(id), cancellationToken);
	}
}
