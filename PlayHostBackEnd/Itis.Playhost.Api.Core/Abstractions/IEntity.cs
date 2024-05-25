﻿namespace Itis.Playhost.Api.Core.Abstractions;

/// <summary>
/// Интерфейс сущности в БД
/// </summary>
public interface IEntity
{
    /// <summary>
    /// Id сущности
    /// </summary>
    public Guid Id { get; set; }
}