using Itis.Playhost.Api.Contracts.Requests.GameRequests.PostGame;
using MediatR;

namespace Itis.Playhost.Api.Core.Requests.GameRequests.PostGame
{
	/// <summary>
	/// Команда запроса <see cref="PostGameRequest"/>
	/// </summary>
	public class PostGameCommand : PostGameRequest, IRequest<PostGameResponse>
	{
	}
}