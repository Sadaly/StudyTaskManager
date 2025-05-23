﻿using StudyTaskManager.Application.Abstractions.Messaging;
using StudyTaskManager.Domain.Abstractions.Repositories;
using StudyTaskManager.Domain.Entity.User.Chat;
using StudyTaskManager.Domain.Shared;

namespace StudyTaskManager.Application.Entity.PersonalMessages.Queries.PersonalMessageGetById
{
    public sealed class PersonalMessageGetByIdQueryHandler : IQueryHandler<PersonalMessageGetByIdQuery, PersonalMessageResponse>
    {
        private readonly IPresonalMessageRepository _presonalMessageRepository;

        public PersonalMessageGetByIdQueryHandler(IPresonalMessageRepository presonalMessageRepository)
        {
            _presonalMessageRepository = presonalMessageRepository;
        }

        public async Task<Result<PersonalMessageResponse>> Handle(PersonalMessageGetByIdQuery request, CancellationToken cancellationToken)
        {
            var message = await _presonalMessageRepository.GetByIdAsync(request.PersonalMessageId, cancellationToken);
            if (message.IsFailure) return Result.Failure<PersonalMessageResponse>(message);

            return new PersonalMessageResponse(message.Value);
        }
    }
}
