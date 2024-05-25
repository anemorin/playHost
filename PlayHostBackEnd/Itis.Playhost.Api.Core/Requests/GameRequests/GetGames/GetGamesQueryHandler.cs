using Bars.ReformaGKH.Sip.Api.Core.Extensions;
using Itis.Playhost.Api.Contracts.Requests.GameRequests.GetGames;
using Itis.Playhost.Api.Core.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Itis.Playhost.Api.Core.Requests.GameRequests.GetGames
{
	/// <summary>
	/// Обработчик запроса <see cref="GetGamesQuery"/>
	/// </summary>
	public class GetGamesQueryHandler : IRequestHandler<GetGamesQuery, GetGamesResponse>
	{
		private readonly IDbContext _dbContext;

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="dbContext">Контекст БД</param>
		public GetGamesQueryHandler(IDbContext dbContext)
			=> _dbContext = dbContext;

		/// <inheritdoc/>
		public async Task<GetGamesResponse> Handle(
			GetGamesQuery request,
			CancellationToken cancellationToken)
		{
			if (request == null)
				throw new ArgumentNullException(nameof(request));

			var query = _dbContext.Games;

			var count = await query.CountAsync(cancellationToken);

			var result = await query
				.Select(x => new GetGamesResponseItem
				{
					Id = x.Id,
					Image = x.Image,
					Name = x.Name,
					Price = x.Price,
				})
				.OrderBy(request)
				.SkipTake(request)
				.ToListAsync(cancellationToken);

			return new GetGamesResponse(result, count);
		}
	}
}
