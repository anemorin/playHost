namespace Itis.Playhost.Api.Contracts.Requests.ServerRequests.GetServers
{
	/// <summary>
	/// Сервер для <see cref="GetServersResponse"/>
	/// </summary>
	public class GetServersResponseItem
	{
		/// <summary>
		/// Идентификатор
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// Название
		/// </summary>
		public string Name { get; set; } = default!;

		/// <summary>
		/// Количество оперативной памяти
		/// </summary>
		public int Ram { get; set; }

		/// <summary>
		/// Максимальное количество пользователей
		/// </summary>
		public int MaxUsers { get; set; }

		/// <summary>
		/// Цена
		/// </summary>
		public int Price { get; set; }
	}
}
