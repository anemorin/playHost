namespace Itis.Playhost.Api.Core.Entities;

/// <summary>
/// Новость
/// </summary>
public class New : EntityBase
{
	public New(string text, string title)
	{
		Text = text;
		Title = title;
	}

	private New()
	{
	}

	/// <summary>
	/// Текст
	/// </summary>
	public string Text { get; set; }

	/// <summary>
	/// Заголовк
	/// </summary>
	public string Title { get; set; }

	/// <summary>
	/// Дата создания
	/// </summary>
	public DateTime CreatedAt { get; set; }
}
