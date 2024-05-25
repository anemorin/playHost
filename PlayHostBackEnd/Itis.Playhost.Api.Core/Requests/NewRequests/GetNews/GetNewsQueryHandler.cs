using Bars.ReformaGKH.Sip.Api.Core.Extensions;
using Itis.Playhost.Api.Contracts.Requests.NewRequests.GetNews;
using Itis.Playhost.Api.Core.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Itis.Playhost.Api.Core.Requests.NewRequests.GetNews
{
	/// <summary>
	/// Обработчик запроса <see cref="GetNewsQuery"/>
	/// </summary>
	public class GetNewsQueryHandler : IRequestHandler<GetNewsQuery, GetNewsResponse>
	{
		private readonly IDbContext _dbContext;

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="dbContext">Контекст БД</param>
		public GetNewsQueryHandler(IDbContext dbContext)
			=> _dbContext = dbContext;

		/// <inheritdoc/>
		public async Task<GetNewsResponse> Handle(
			GetNewsQuery request,
			CancellationToken cancellationToken)
		{
			if (request == null)
				throw new ArgumentNullException(nameof(request));

			var query = _dbContext.News;

			var count = await query.CountAsync(cancellationToken);

			var result = await query
				.Select(x => new GetNewsResponseItem
				{
					Id = x.Id,
					Text = x.Text,
					Title = x.Title,
					CreatedAt = x.CreatedAt,
				})
				.OrderBy(request)
				.SkipTake(request)
				.ToListAsync(cancellationToken);

			return new GetNewsResponse(result, count);
		}
	}
}
