using Itis.Playhost.Api.Core.Abstractions;
using Itis.Playhost.Api.Core.Entities;
using Itis.Playhost.Api.Core.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Itis.Playhost.Api.Core.Requests.NewRequests.DeleteNew
{
	/// <summary>
	/// Обработчик запроса <see cref="DeleteNewCommand"/>
	/// </summary>
	public class DeleteNewCommandHandler : IRequestHandler<DeleteNewCommand>
	{
		private readonly IDbContext _dbContext;

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="dbContext">Контекст БД</param>
		public DeleteNewCommandHandler(IDbContext dbContext)
			=> _dbContext = dbContext;

		/// <inheritdoc/>
		public async Task<Unit> Handle(
			DeleteNewCommand request,
			CancellationToken cancellationToken)
		{
			if (request == null)
				throw new ArgumentNullException(nameof(request));

			var entity = await _dbContext.News
				.FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken)
				?? throw new EntityNotFoundException<New>(request.Id);

			_dbContext.News.Remove(entity);

			await _dbContext.SaveChangesAsync(cancellationToken);

			return default;
		}
	}
}
