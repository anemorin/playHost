using Itis.Playhost.Api.Core.Abstractions;
using Itis.Playhost.Api.Core.Entities;
using Itis.Playhost.Api.Core.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Itis.Playhost.Api.Core.Requests.ServerRequests.DeleteServer
{
	/// <summary>
	/// Обработчик запроса <see cref="DeleteServerCommand"/>
	/// </summary>
	public class DeleteServerCommandHandler : IRequestHandler<DeleteServerCommand>
	{
		private readonly IDbContext _dbContext;

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="dbContext">Контекст БД</param>
		public DeleteServerCommandHandler(IDbContext dbContext)
			=> _dbContext = dbContext;

		/// <inheritdoc/>
		public async Task<Unit> Handle(
			DeleteServerCommand request,
			CancellationToken cancellationToken)
		{
			if (request == null)
				throw new ArgumentNullException(nameof(request));

			var entity = await _dbContext.Servers
				.FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken)
				?? throw new EntityNotFoundException<Server>(request.Id);

			_dbContext.Servers.Remove(entity);

			await _dbContext.SaveChangesAsync(cancellationToken);

			return default;
		}
	}
}
