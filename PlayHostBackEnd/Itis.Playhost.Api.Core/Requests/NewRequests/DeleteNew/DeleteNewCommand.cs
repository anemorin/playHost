using MediatR;

namespace Itis.Playhost.Api.Core.Requests.NewRequests.DeleteNew
{
	/// <summary>
	/// Запрос удаления сущности "Новость"
	/// </summary>
	public class DeleteNewCommand : IRequest
	{
		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="id">Id сущности</param>
		public DeleteNewCommand(Guid id)
			=> Id = id;

		/// <summary>
		/// Id записи
		/// </summary>
		public Guid Id { get; }
	}
}
