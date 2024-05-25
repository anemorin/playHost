using Itis.Playhost.Api.Contracts.Requests.ServerRequests.GetServers;
using Itis.Playhost.Api.Core.Models;
using MediatR;

namespace Itis.Playhost.Api.Core.Requests.ServerRequests.GetServers
{
	/// <summary>
	/// Запрос получения списка "Сервер"
	/// </summary>
	public class GetServersQuery
	: GetServersRequest, IRequest<GetServersResponse>, IOrderByQuery, IPaginationQuery
	{ }
}
