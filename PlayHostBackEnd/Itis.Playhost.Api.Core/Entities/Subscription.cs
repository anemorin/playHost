using Itis.Playhost.Api.Core.Exceptions;

namespace Itis.Playhost.Api.Core.Entities;

/// <summary>
/// Подписка
/// </summary>
public class Subscription : EntityBase
{
	private Server _server;
	private Game _game;
	private User _user;

	public Subscription(Server server, Game game, Guid userId, int price, DateTime startDate, DateTime endDate)
	{
		Server = server;
		Game = game;
		UserId = userId;
		Price = price;
		StartDate = startDate;
		EndDate = endDate;
	}

	private Subscription()
	{
	}

	/// <summary>
	/// Цена
	/// </summary>
	public int Price { get; set; }

	/// <summary>
	/// Дата начала
	/// </summary>
	public DateTime StartDate { get; set; }

	/// <summary>
	/// Дата окончания
	/// </summary>
	public DateTime EndDate { get; set; }

	/// <summary>
	/// Сервер
	/// </summary>
	public Guid ServerId { get; set; }

	/// <summary>
	/// Игра
	/// </summary>
	public Guid GameId { get; set; }

	/// <summary>
	/// Пользователь
	/// </summary>
	public Guid UserId { get; set; }

	/// <summary>
	/// Сервер
	/// </summary>
	public Server Server
	{
		get => _server;
		set => _server = value ?? throw new RequiredFieldIsEmpty(nameof(Game));
	}

	/// <summary>
	/// Игра
	/// </summary>
	public Game Game
	{
		get => _game;
		set => _game = value ?? throw new RequiredFieldIsEmpty(nameof(Game));
	}

	/// <summary>
	/// Пользователь
	/// </summary>
	public User User
	{
		get => _user;
		set => _user = value ?? throw new RequiredFieldIsEmpty(nameof(Game));
	}
}
