using Itis.Playhost.Api.Contracts.Requests.SubscriptionRequests.PostSubscription;
using Itis.Playhost.Api.Core.Abstractions;
using Itis.Playhost.Api.Core.Entities;
using Itis.Playhost.Api.Core.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Itis.Playhost.Api.Core.Requests.SubscriptionRequests.PostSubscription
{
	/// <summary>
	/// Обработчик запроса <see cref="PostSubscriptionCommand"/>
	/// </summary>
	public class PostSubscriptionCommandHandler : IRequestHandler<PostSubscriptionCommand, PostSubscriptionResponse>
	{
		private readonly IDbContext _dbContext;
		private readonly IUserService _userService;

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="dbContext">Контекст БД</param>
		/// <param name="userService">Сервис для работы с пользователями</param>
		public PostSubscriptionCommandHandler(IDbContext dbContext, IUserService userService)
		{
			_dbContext = dbContext;
			_userService = userService;
		}

		/// <inheritdoc/>
		public async Task<PostSubscriptionResponse> Handle(
			PostSubscriptionCommand request,
			CancellationToken cancellationToken)
		{
			if (request is null)
				throw new ArgumentNullException(nameof(request));

			var server = await _dbContext.Servers
				.FirstOrDefaultAsync(x => x.Id == request.ServerId, cancellationToken: cancellationToken)
				?? throw new EntityNotFoundException<Server>(request.ServerId);

			var game = await _dbContext.Games
				.FirstOrDefaultAsync(x => x.Id == request.GameId, cancellationToken: cancellationToken)
				?? throw new EntityNotFoundException<Game>(request.GameId);

			var user = await _userService.FindUserByIdAsync(request.UserId) 
				?? throw new EntityNotFoundException<Entities.User>(nameof(request.UserId));

			var entity = new Subscription(
				price: request.Price,
				startDate: request.StartDate,
				endDate: request.EndDate,
				server: server,
				game: game,
				userId: request.UserId);

			_dbContext.Subscriptions.Add(entity);
			await _dbContext.SaveChangesAsync(cancellationToken);

			return new PostSubscriptionResponse(entity.Id);
		}
	}
}
