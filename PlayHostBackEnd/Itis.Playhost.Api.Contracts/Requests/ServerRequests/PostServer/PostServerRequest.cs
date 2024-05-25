namespace Itis.Playhost.Api.Contracts.Requests.ServerRequests.PostServer
{
	/// <summary>
	/// Запрос на сохранение сущности "Сервер"
	/// </summary>
	public class PostServerRequest
	{
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