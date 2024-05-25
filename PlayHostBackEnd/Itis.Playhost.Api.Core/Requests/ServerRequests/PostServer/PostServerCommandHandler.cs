using Itis.Playhost.Api.Contracts.Requests.ServerRequests.PostServer;
using Itis.Playhost.Api.Core.Abstractions;
using Itis.Playhost.Api.Core.Entities;
using MediatR;

namespace Itis.Playhost.Api.Core.Requests.ServerRequests.PostServer
{
	/// <summary>
	/// Обработчик запроса <see cref="PostServerCommand"/>
	/// </summary>
	public class PostServerCommandHandler : IRequestHandler<PostServerCommand, PostServerResponse>
	{
		private readonly IDbContext _dbContext;

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="dbContext">Контекст БД</param>
		public PostServerCommandHandler(IDbContext dbContext)
			=> _dbContext = dbContext;

		/// <inheritdoc/>
		public async Task<PostServerResponse> Handle(
			PostServerCommand request,
			CancellationToken cancellationToken)
		{
			if (request is null)
				throw new ArgumentNullException(nameof(request));

			var entity = new Server(
				name: request.Name,
				ram: request.Ram,
				maxUsers: request.MaxUsers,
				price: request.Price);

			_dbContext.Servers.Add(entity);
			await _dbContext.SaveChangesAsync(cancellationToken);

			return new PostServerResponse(entity.Id);
		}
	}
}
