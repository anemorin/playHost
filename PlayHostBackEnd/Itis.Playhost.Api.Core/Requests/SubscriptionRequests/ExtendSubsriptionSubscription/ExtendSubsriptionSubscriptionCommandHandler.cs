using Itis.Playhost.Api.Core.Abstractions;
using Itis.Playhost.Api.Core.Entities;
using Itis.Playhost.Api.Core.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Itis.Playhost.Api.Core.Requests.SubscriptionRequests.ExtendSubsriptionSubscription
{
	/// <summary>
	/// Обработчик запроса <see cref="ExtendSubsriptionSubscriptionCommand"/>
	/// </summary>
	public class ExtendSubsriptionSubscriptionCommandHandler : IRequestHandler<ExtendSubsriptionSubscriptionCommand>
	{
		private readonly IDbContext _dbContext;
		private readonly IUserService _userService;

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="dbContext">Контекст БД</param>
		/// <param name="userService">Сервис для работы с пользователями</param>
		public ExtendSubsriptionSubscriptionCommandHandler(IDbContext dbContext, IUserService userService)
		{
			_dbContext = dbContext;
			_userService = userService;
		}

		/// <inheritdoc/>
		public async Task<Unit> Handle(
			ExtendSubsriptionSubscriptionCommand request,
			CancellationToken cancellationToken)
		{
			if (request is null)
				throw new ArgumentNullException(nameof(request));

			var entity = await _dbContext.Subscriptions
				.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
				?? throw new EntityNotFoundException<Subscription>(request.Id);

			entity.EndDate = entity.EndDate.AddDays(request.DaysToAdd);

			await _dbContext.SaveChangesAsync(cancellationToken);

			return default;
		}
	}
}
