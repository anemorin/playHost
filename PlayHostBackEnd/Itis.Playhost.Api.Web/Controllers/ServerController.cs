using Itis.Playhost.Api.Contracts.Requests.ServerRequests.GetServers;
using Itis.Playhost.Api.Contracts.Requests.ServerRequests.PostServer;
using Itis.Playhost.Api.Core.Requests.ServerRequests.DeleteServer;
using Itis.Playhost.Api.Core.Requests.ServerRequests.GetServers;
using Itis.Playhost.Api.Core.Requests.ServerRequests.PostServer;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Itis.Playhost.Api.Web.Controllers
{
	/// <summary>
	/// Контроллер сущности "Сервер"
	/// </summary>
	public class ServerController : BaseController
	{
		/// <summary>
		/// Получить список сущностей по фильтру
		/// </summary>
		/// <param name="mediator">Медиатор CQRS</param>
		/// <param name="request">Запрос</param>
		/// <param name="cancellationToken">Токен отмены запроса</param>
		/// <returns>Список сущностей</returns>
		[HttpGet]
		public async Task<GetServersResponse> GetAsync(
			[FromServices] IMediator mediator,
			[FromQuery] GetServersRequest request,
			CancellationToken cancellationToken) =>
			await mediator.Send(
				request == null
					? new GetServersQuery()
					: new GetServersQuery
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
		public async Task<PostServerResponse> CreateAsync(
			[FromServices] IMediator mediator,
			[FromBody] PostServerRequest request,
			CancellationToken cancellationToken)
		{
			if (request is null)
				throw new ArgumentNullException(nameof(request));

			return await mediator.Send(
				new PostServerCommand()
				{
					Name = request.Name,
					Ram = request.Ram,
					MaxUsers = request.MaxUsers,
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
			=> await mediator.Send(new DeleteServerCommand(id), cancellationToken);
	}
}
