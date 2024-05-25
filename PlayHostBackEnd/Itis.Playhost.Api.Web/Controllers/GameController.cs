using Itis.Playhost.Api.Contracts.Requests.GameRequests.GetGames;
using Itis.Playhost.Api.Contracts.Requests.GameRequests.PostGame;
using Itis.Playhost.Api.Core.Requests.GameRequests.DeleteGame;
using Itis.Playhost.Api.Core.Requests.GameRequests.GetGames;
using Itis.Playhost.Api.Core.Requests.GameRequests.PostGame;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Itis.Playhost.Api.Web.Controllers
{
	/// <summary>
	/// Контроллер сущности "Видеоигра"
	/// </summary>
	public class GameController : BaseController
	{
		/// <summary>
		/// Получить список сущностей по фильтру
		/// </summary>
		/// <param name="mediator">Медиатор CQRS</param>
		/// <param name="request">Запрос</param>
		/// <param name="cancellationToken">Токен отмены запроса</param>
		/// <returns>Список сущностей</returns>
		[HttpGet]
		public async Task<GetGamesResponse> GetAsync(
			[FromServices] IMediator mediator,
			[FromQuery] GetGamesRequest request,
			CancellationToken cancellationToken) =>
			await mediator.Send(
				request == null
					? new GetGamesQuery()
					: new GetGamesQuery
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
		public async Task<PostGameResponse> CreateAsync(
			[FromServices] IMediator mediator,
			[FromBody] PostGameRequest request,
			CancellationToken cancellationToken)
		{
			if (request is null)
				throw new ArgumentNullException(nameof(request));

			return await mediator.Send(
				new PostGameCommand()
				{
					Image = request.Image,
					Name = request.Name,
					Price = request.Price,
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
			=> await mediator.Send(new DeleteGameCommand(id), cancellationToken);
	}
}
