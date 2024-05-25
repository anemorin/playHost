using Itis.Playhost.Api.Core.Exceptions;

namespace Itis.Playhost.Api.Core.Entities;

/// <summary>
/// Обзор
/// </summary>
public class Review : EntityBase
{
	private User _user;

	public Review(int rate, Guid userId)
	{
		Rate = rate;
		UserId = userId;
	}

	private Review()
	{
	}

	/// <summary>
	/// ОЦенка от 1 до 5
	/// </summary>
	public int Rate { get; set; }

	/// <summary>
	/// Дата создания
	/// </summary>
	public DateTime CreatedAt { get; set; }

	/// <summary>
	/// Пользователь
	/// </summary>
	public Guid UserId { get; set; }

	/// <summary>
	/// Пользователь
	/// </summary>
	public User User
	{
		get => _user;
		set => _user = value ?? throw new RequiredFieldIsEmpty(nameof(User));
	}
}
