using Itis.Playhost.Api.Contracts.Requests.NewRequests.PostNew;
using MediatR;

namespace Itis.Playhost.Api.Core.Requests.NewRequests.PostNew
{
	/// <summary>
	/// Команда запроса <see cref="PostNewRequest"/>
	/// </summary>
	public class PostNewCommand : PostNewRequest, IRequest<PostNewResponse>
	{
	}
}