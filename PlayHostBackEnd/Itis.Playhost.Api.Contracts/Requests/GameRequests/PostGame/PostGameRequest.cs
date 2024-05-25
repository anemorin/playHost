namespace Itis.Playhost.Api.Contracts.Requests.GameRequests.PostGame
{
	/// <summary>
	/// Запрос на сохранение сущности "Видеоигра"
	/// </summary>
	public class PostGameRequest
	{
		/// <summary>
		/// Url картинки
		/// </summary>
		public string Image { get; set; } = default!;

		/// <summary>
		/// Название игры
		/// </summary>
		public string Name { get; set; } = default!;

		/// <summary>
		/// Цена игры
		/// </summary>
		public int Price { get; set; }
	}
}