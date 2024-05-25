using Itis.Playhost.Api.Contracts.Requests.GameRequests.PostGame;
using Itis.Playhost.Api.Core.Abstractions;
using Itis.Playhost.Api.Core.Entities;
using MediatR;

namespace Itis.Playhost.Api.Core.Requests.GameRequests.PostGame
{
	/// <summary>
	/// Обработчик запроса <see cref="PostGameCommand"/>
	/// </summary>
	public class PostGameCommandHandler : IRequestHandler<PostGameCommand, PostGameResponse>
	{
		private readonly IDbContext _dbContext;

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="dbContext">Контекст БД</param>
		public PostGameCommandHandler(IDbContext dbContext)
			=> _dbContext = dbContext;

		/// <inheritdoc/>
		public async Task<PostGameResponse> Handle(
			PostGameCommand request,
			CancellationToken cancellationToken)
		{
			if (request is null)
				throw new ArgumentNullException(nameof(request));

			var entity = new Game(
				image: request.Image,
				name: request.Name,
				price: request.Price);

			_dbContext.Games.Add(entity);
			await _dbContext.SaveChangesAsync(cancellationToken);

			return new PostGameResponse(entity.Id);
		}
	}
}
