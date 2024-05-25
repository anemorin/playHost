using MediatR;

namespace Itis.Playhost.Api.Core.Requests.GameRequests.DeleteGame
{
	/// <summary>
	/// Запрос удаления сущности "Видеоигра"
	/// </summary>
	public class DeleteGameCommand : IRequest
	{
		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="id">Id сущности</param>
		public DeleteGameCommand(Guid id)
			=> Id = id;

		/// <summary>
		/// Id записи
		/// </summary>
		public Guid Id { get; }
	}
}
