﻿using StudyTaskManager.Application.Abstractions.Messaging;
using StudyTaskManager.Domain.Abstractions.Repositories;
using StudyTaskManager.Domain.Shared;
using StudyTaskManager.Domain.ValueObjects;

namespace StudyTaskManager.Application.Entity.Users.Queries.UserGetByUsername
{
    internal sealed class UserGetByUsernameQueryHandler : IQueryHandler<UserGetByUsernameQuery, UserResponse>
    {
        private readonly IUserRepository _userRepository;

        public UserGetByUsernameQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<UserResponse>> Handle(UserGetByUsernameQuery request, CancellationToken cancellationToken)
        {
            var usernameResult = Username.Create(request.Username);
            if (usernameResult.IsFailure) return Result.Failure<UserResponse>(usernameResult.Error);

            var userResult = await _userRepository.GetByUsernameAsync(usernameResult.Value, cancellationToken);
            if (userResult.IsFailure) return Result.Failure<UserResponse>(userResult.Error);

            var response = new UserResponse(userResult.Value);

            return response;
        }
    }
}
