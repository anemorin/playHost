using Bars.ReformaGKH.Sip.Api.Core.Extensions;
using Itis.Playhost.Api.Contracts.Requests.ReviewRequests.GetReviews;
using Itis.Playhost.Api.Core.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Itis.Playhost.Api.Core.Requests.ReviewRequests.GetReviews
{
	/// <summary>
	/// Обработчик запроса <see cref="GetReviewsQuery"/>
	/// </summary>
	public class GetReviewsQueryHandler : IRequestHandler<GetReviewsQuery, GetReviewsResponse>
	{
		private readonly IDbContext _dbContext;

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="dbContext">Контекст БД</param>
		public GetReviewsQueryHandler(IDbContext dbContext)
			=> _dbContext = dbContext;

		/// <inheritdoc/>
		public async Task<GetReviewsResponse> Handle(
			GetReviewsQuery request,
			CancellationToken cancellationToken)
		{
			if (request == null)
				throw new ArgumentNullException(nameof(request));

			var query = _dbContext.Reviews;

			var count = await query.CountAsync(cancellationToken);

			var result = await query
				.Select(x => new GetReviewsResponseItem
				{
					Id = x.Id,
					Rate = x.Rate,
					CreatedAt = x.CreatedAt,
				})
				.OrderBy(request)
				.SkipTake(request)
				.ToListAsync(cancellationToken);

			return new GetReviewsResponse(result, count);
		}
	}
}
