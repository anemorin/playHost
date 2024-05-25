using Itis.Playhost.Api.Contracts.Enums;

namespace Itis.Playhost.Api.Contracts.Requests.SubscriptionRequests.GetSubscriptions
{
	/// <summary>
	/// Запрос получения списка "Подписка"
	/// </summary>
	public class GetSubscriptionsRequest
	{
		private int _pageNumber;
		private int _pageSize;
		private string? _orderBy;

		/// <summary>
		/// Конструктор
		/// </summary>
		public GetSubscriptionsRequest()
		{
			_pageNumber = PaginationDefaults.PageNumber;
			_pageSize = PaginationDefaults.PageSize;
			_orderBy = nameof(GetSubscriptionsResponseItem.Id);
		}

		/// <summary>
		/// Номер страницы, начиная с 1
		/// </summary>
		public int PageNumber { get => _pageNumber; set => _pageNumber = value > 0 ? value : PaginationDefaults.PageNumber; }

		/// <summary>
		/// Размер страницы
		/// </summary>
		public int PageSize { get => _pageSize; set => _pageSize = value > 0 ? value : PaginationDefaults.PageSize; }

		/// <summary>
		/// Поле сортировки
		/// </summary>
		public string? OrderBy
		{
			get => _orderBy;
			set => _orderBy = string.IsNullOrEmpty(value)
				? nameof(GetSubscriptionsResponseItem.Id)
				: value;
		}

		/// <summary>
		/// Сортировка по возрастанию
		/// </summary>
		public bool IsAscending { get; set; }
	}
}