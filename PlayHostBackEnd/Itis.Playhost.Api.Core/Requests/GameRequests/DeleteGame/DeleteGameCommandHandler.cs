using Itis.Playhost.Api.Core.Abstractions;
using Itis.Playhost.Api.Core.Entities;
using Itis.Playhost.Api.Core.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Itis.Playhost.Api.Core.Requests.GameRequests.DeleteGame
{
	/// <summary>
	/// Обработчик запроса <see cref="DeleteGameCommand"/>
	/// </summary>
	public class DeleteGameCommandHandler : IRequestHandler<DeleteGameCommand>
	{
		private readonly IDbContext _dbContext;

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="dbContext">Контекст БД</param>
		public DeleteGameCommandHandler(IDbContext dbContext)
			=> _dbContext = dbContext;

		/// <inheritdoc/>
		public async Task<Unit> Handle(
			DeleteGameCommand request,
			CancellationToken cancellationToken)
		{
			if (request == null)
				throw new ArgumentNullException(nameof(request));

			var entity = await _dbContext.Games
				.FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken)
				?? throw new EntityNotFoundException<Game>(request.Id);

			_dbContext.Games.Remove(entity);

			await _dbContext.SaveChangesAsync(cancellationToken);

			return default;
		}
	}
}
