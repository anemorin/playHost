using Itis.Playhost.Api.Core.Abstractions;

namespace Itis.Playhost.Api.Core.Entities;

public class EntityBase : IEntity
{
    /// <summary>
    /// ИД сущности
    /// </summary>
    public Guid Id { get; set; }
}