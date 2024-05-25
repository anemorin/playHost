using MediatR;

namespace Itis.Playhost.Api.Core.Requests.ServerRequests.DeleteServer
{
	/// <summary>
	/// Запрос удаления сущности "Сервер"
	/// </summary>
	public class DeleteServerCommand : IRequest
	{
		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="id">Id сущности</param>
		public DeleteServerCommand(Guid id)
			=> Id = id;

		/// <summary>
		/// Id записи
		/// </summary>
		public Guid Id { get; }
	}
}
