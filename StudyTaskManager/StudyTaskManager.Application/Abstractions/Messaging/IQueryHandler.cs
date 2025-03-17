﻿using MediatR;
using StudyTaskManager.Domain.Shared;

namespace StudyTaskManager.Application.Abstractions.Messaging
{
    /// <summary>
    /// Обработчик запроса
    /// </summary>
    /// <typeparam name="TQuery">Запрос</typeparam>
    /// <typeparam name="TResponse">Возвращаемое значение</typeparam>
    public interface IQueryHandler<TQuery, TResponse>
    : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
    {
    }
}
