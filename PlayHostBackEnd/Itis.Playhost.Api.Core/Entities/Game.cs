namespace Itis.Playhost.Api.Core.Entities;

/// <summary>
/// Видеоигра
/// </summary>
public class Game : EntityBase
{
	public Game(string image, string name, int price)
	{
		Image = image;
		Name = name;
		Price = price;
		Subscriptions = new List<Subscription>();
	}

	private Game()
	{
	}

	/// <summary>
	/// Url картинки
	/// </summary>
	public string Image { get; set; }

	/// <summary>
	/// Название игры
	/// </summary>
	public string Name { get; set; }

	/// <summary>
	/// Цена игры
	/// </summary>
	public int Price { get; set; }

	/// <summary>
	/// Подписки
	/// </summary>
	public IReadOnlyList<Subscription>? Subscriptions { get; set; }
}
