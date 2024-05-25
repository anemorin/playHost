using Itis.Playhost.Api.Core.Abstractions;
using Itis.Playhost.Api.Core.Entities;
using Itis.Playhost.Api.Core.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Itis.Playhost.Api.Core.Requests.SubscriptionRequests.DeleteSubscription
{
	/// <summary>
	/// Обработчик запроса <see cref="DeleteSubscriptionCommand"/>
	/// </summary>
	public class DeleteSubscriptionCommandHandler : IRequestHandler<DeleteSubscriptionCommand>
	{
		private readonly IDbContext _dbContext;

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="dbContext">Контекст БД</param>
		public DeleteSubscriptionCommandHandler(IDbContext dbContext)
			=> _dbContext = dbContext;

		/// <inheritdoc/>
		public async Task<Unit> Handle(
			DeleteSubscriptionCommand request,
			CancellationToken cancellationToken)
		{
			if (request == null)
				throw new ArgumentNullException(nameof(request));

			var entity = await _dbContext.Subscriptions
				.FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken)
				?? throw new EntityNotFoundException<Subscription>(request.Id);

			_dbContext.Subscriptions.Remove(entity);

			await _dbContext.SaveChangesAsync(cancellationToken);

			return default;
		}
	}
}
