using Itis.Playhost.Api.Core.Entities;

namespace Itis.Playhost.Api.Core.Exceptions
{
	/// <summary>
	/// Исключение о том, что сущность не найдена
	/// </summary>
	/// <typeparam name="TEntity">Тип сущности</typeparam>
	public class EntityNotFoundException<TEntity>: NotFoundException
	{
		private static readonly IReadOnlyDictionary<Type, string> EntityExceptionTexts = new Dictionary<Type, string>
		{
			[typeof(User)] = "Не найдены пользователи",
		};

		/// <summary>
		/// Исключение о том, что сущность не найдена
		/// </summary>
		/// <param name="id">ИД сушности</param>
		public EntityNotFoundException(Guid id)
			: base($"{EntityException} с идентификатором: {id}.")
		{
		}

		/// <summary>
		/// Исключение о том, что сущность не найдена
		/// </summary>
		/// <param name="ids">ИД сушности</param>
		public EntityNotFoundException(List<Guid> ids)
			: base($"{EntityException} с идентификаторами: {string.Join(", ", ids ?? new List<Guid>())}.")
		{
			if (ids?.Any() != true)
				throw new ArgumentException("Передан некорректный список идентификаторов");
		}

		/// <summary>
		/// Исключение о том, что сущность не найдена
		/// </summary>
		/// <param name="customMessage">Кастомное сообщение</param>
		public EntityNotFoundException(string customMessage)
			: base(customMessage)
		{
		}

		/// <summary>
		/// Текст исключения для типа сущности TEntity
		/// </summary>
		private static string EntityException => EntityExceptionTexts.TryGetValue(typeof(TEntity), out var text)
			? text
			: $"Не найдены {typeof(TEntity).FullName}";
	}
}
