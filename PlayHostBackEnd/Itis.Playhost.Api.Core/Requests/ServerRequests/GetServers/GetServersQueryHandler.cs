using Bars.ReformaGKH.Sip.Api.Core.Extensions;
using Itis.Playhost.Api.Contracts.Requests.ServerRequests.GetServers;
using Itis.Playhost.Api.Core.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Itis.Playhost.Api.Core.Requests.ServerRequests.GetServers
{
	/// <summary>
	/// Обработчик запроса <see cref="GetServersQuery"/>
	/// </summary>
	public class GetServersQueryHandler : IRequestHandler<GetServersQuery, GetServersResponse>
	{
		private readonly IDbContext _dbContext;

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="dbContext">Контекст БД</param>
		public GetServersQueryHandler(IDbContext dbContext)
			=> _dbContext = dbContext;

		/// <inheritdoc/>
		public async Task<GetServersResponse> Handle(
			GetServersQuery request,
			CancellationToken cancellationToken)
		{
			if (request == null)
				throw new ArgumentNullException(nameof(request));

			var query = _dbContext.Servers;

			var count = await query.CountAsync(cancellationToken);

			var result = await query
				.Select(x => new GetServersResponseItem
				{
					Id = x.Id,
					Name = x.Name,
					Ram = x.Ram,
					MaxUsers = x.MaxUsers,
					Price = x.Price,
				})
				.OrderBy(request)
				.SkipTake(request)
				.ToListAsync(cancellationToken);

			return new GetServersResponse(result, count);
		}
	}
}
