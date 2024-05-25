using Itis.Playhost.Api.Contracts.Requests.ServerRequests.PostServer;
using MediatR;

namespace Itis.Playhost.Api.Core.Requests.ServerRequests.PostServer
{
	/// <summary>
	/// Команда запроса <see cref="PostServerRequest"/>
	/// </summary>
	public class PostServerCommand : PostServerRequest, IRequest<PostServerResponse>
	{
	}
}