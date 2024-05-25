namespace Itis.Playhost.Api.Contracts.Requests.GameRequests.GetGames
{
	/// <summary>
	/// Видеоигра для <see cref="GetGamesResponse"/>
	/// </summary>
	public class GetGamesResponseItem
	{
		/// <summary>
		/// Идентификатор
		/// </summary>
		public Guid Id { get; set; }

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
