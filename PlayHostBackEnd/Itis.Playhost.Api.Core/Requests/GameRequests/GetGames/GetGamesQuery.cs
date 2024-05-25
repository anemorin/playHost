using Itis.Playhost.Api.Contracts.Requests.GameRequests.GetGames;
using Itis.Playhost.Api.Core.Models;
using MediatR;

namespace Itis.Playhost.Api.Core.Requests.GameRequests.GetGames
{
	/// <summary>
	/// Запрос получения списка "Видеоигра"
	/// </summary>
	public class GetGamesQuery
	: GetGamesRequest, IRequest<GetGamesResponse>, IOrderByQuery, IPaginationQuery
	{ }
}
