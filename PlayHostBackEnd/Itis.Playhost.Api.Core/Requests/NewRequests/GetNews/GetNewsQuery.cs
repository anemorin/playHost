using Itis.Playhost.Api.Contracts.Requests.NewRequests.GetNews;
using Itis.Playhost.Api.Core.Models;
using MediatR;

namespace Itis.Playhost.Api.Core.Requests.NewRequests.GetNews
{
	/// <summary>
	/// Запрос получения списка "Новость"
	/// </summary>
	public class GetNewsQuery
	: GetNewsRequest, IRequest<GetNewsResponse>, IOrderByQuery, IPaginationQuery
	{ }
}
