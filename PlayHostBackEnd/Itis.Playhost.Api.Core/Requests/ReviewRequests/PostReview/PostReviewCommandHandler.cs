using Itis.Playhost.Api.Contracts.Requests.ReviewRequests.PostReview;
using Itis.Playhost.Api.Core.Abstractions;
using Itis.Playhost.Api.Core.Entities;
using Itis.Playhost.Api.Core.Exceptions;
using MediatR;

namespace Itis.Playhost.Api.Core.Requests.ReviewRequests.PostReview
{
	/// <summary>
	/// Обработчик запроса <see cref="PostReviewCommand"/>
	/// </summary>
	public class PostReviewCommandHandler : IRequestHandler<PostReviewCommand, PostReviewResponse>
	{
		private readonly IDbContext _dbContext;
		private readonly IUserService _userService;

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="dbContext">Контекст БД</param>
		/// <param name="userService">Сервис работы с пользователями</param>
		public PostReviewCommandHandler(IDbContext dbContext, IUserService userService)
		{
			_dbContext = dbContext;
			_userService = userService;
		}

		/// <inheritdoc/>
		public async Task<PostReviewResponse> Handle(
			PostReviewCommand request,
			CancellationToken cancellationToken)
		{
			if (request is null)
				throw new ArgumentNullException(nameof(request));

			var user = await _userService.FindUserByIdAsync(request.UserId) ??
			           throw new EntityNotFoundException<Entities.User>(nameof(request.UserId));

			var entity = new Review(
				rate: request.Rate,
				userId: request.UserId);

			_dbContext.Reviews.Add(entity);
			await _dbContext.SaveChangesAsync(cancellationToken);

			return new PostReviewResponse(entity.Id);
		}
	}
}
