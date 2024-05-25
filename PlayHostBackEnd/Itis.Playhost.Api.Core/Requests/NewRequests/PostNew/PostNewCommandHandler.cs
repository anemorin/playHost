using Itis.Playhost.Api.Contracts.Requests.NewRequests.PostNew;
using Itis.Playhost.Api.Core.Abstractions;
using Itis.Playhost.Api.Core.Entities;
using MediatR;

namespace Itis.Playhost.Api.Core.Requests.NewRequests.PostNew
{
	/// <summary>
	/// Обработчик запроса <see cref="PostNewCommand"/>
	/// </summary>
	public class PostNewCommandHandler : IRequestHandler<PostNewCommand, PostNewResponse>
	{
		private readonly IDbContext _dbContext;

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="dbContext">Контекст БД</param>
		public PostNewCommandHandler(IDbContext dbContext)
			=> _dbContext = dbContext;

		/// <inheritdoc/>
		public async Task<PostNewResponse> Handle(
			PostNewCommand request,
			CancellationToken cancellationToken)
		{
			if (request is null)
				throw new ArgumentNullException(nameof(request));
			

			var entity = new New(
				text: request.Text,
				title: request.Title);

			await _dbContext.News.AddAsync(entity, cancellationToken);

			await _dbContext.SaveChangesAsync(cancellationToken);

			return new PostNewResponse(entity.Id);
		}
	}
}
