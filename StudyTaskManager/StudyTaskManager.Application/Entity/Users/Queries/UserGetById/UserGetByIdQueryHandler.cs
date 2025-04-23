﻿using StudyTaskManager.Application.Abstractions.Messaging;
using StudyTaskManager.Domain.Abstractions.Repositories;
using StudyTaskManager.Domain.Shared;

namespace StudyTaskManager.Application.Entity.Users.Queries.GetUserById
{
    internal sealed class UserGetByIdQueryHandler : IQueryHandler<UserGetByIdQuery, UserResponse>
    {
        private readonly IUserRepository _userRepository;

        public UserGetByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<UserResponse>> Handle(UserGetByIdQuery request, CancellationToken cancellationToken)
        {
            var userResult = await _userRepository.GetByIdAsync(request.UserId, cancellationToken);
            if (userResult.IsFailure) return Result.Failure<UserResponse>(userResult.Error);

            var response = new UserResponse(userResult.Value);

            return response;
        }
    }
}
