using Bars.ReformaGKH.Sip.Api.Core.Extensions;
using Itis.Playhost.Api.Contracts.Requests.SubscriptionRequests.GetSubscriptions;
using Itis.Playhost.Api.Core.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Itis.Playhost.Api.Core.Requests.SubscriptionRequests.GetSubscriptions
{
	/// <summary>
	/// Обработчик запроса <see cref="GetSubscriptionsQuery"/>
	/// </summary>
	public class GetSubscriptionsQueryHandler : IRequestHandler<GetSubscriptionsQuery, GetSubscriptionsResponse>
	{
		private readonly IDbContext _dbContext;

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="dbContext">Контекст БД</param>
		public GetSubscriptionsQueryHandler(IDbContext dbContext)
			=> _dbContext = dbContext;

		/// <inheritdoc/>
		public async Task<GetSubscriptionsResponse> Handle(
			GetSubscriptionsQuery request,
			CancellationToken cancellationToken)
		{
			if (request == null)
				throw new ArgumentNullException(nameof(request));

			var query = _dbContext.Subscriptions;

			var count = await query.CountAsync(cancellationToken);

			var result = await query
				.Select(x => new GetSubscriptionsResponseItem
				{
					Id = x.Id,
					Price = x.Price,
					StartDate = x.StartDate,
					EndDate = x.EndDate,
					ServerId = x.ServerId,
					GameId = x.GameId,
				})
				.OrderBy(request)
				.SkipTake(request)
				.ToListAsync(cancellationToken);

			return new GetSubscriptionsResponse(result, count);
		}
	}
}
