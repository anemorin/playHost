namespace Itis.Playhost.Api.Core.Entities;

/// <summary>
/// Сервер
/// </summary>
public class Server : EntityBase
{
	public Server(
		string name,
		int ram,
		int maxUsers,
		int price)
	{
		Name = name;
		Ram = ram;
		MaxUsers = maxUsers;
		Price = price;
		Subscriptions = new List<Subscription>();
	}

	private Server()
	{
	}

	/// <summary>
	/// Название
	/// </summary>
	public string Name { get; set; }

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

	/// <summary>
	/// Подписки
	/// </summary>
	public IReadOnlyList<Subscription>? Subscriptions { get; set; }
}
