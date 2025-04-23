﻿using StudyTaskManager.Application.Abstractions.Messaging;
using StudyTaskManager.Domain.Abstractions.Repositories;
using StudyTaskManager.Domain.Shared;

namespace StudyTaskManager.Application.Entity.Users.Queries.GetUserById
{
    internal sealed class UsersGetAllQueryHandler : IQueryHandler<UsersGetAllQuery, List<UserResponse>>
    {
        private readonly IUserRepository _userRepository;

        public UsersGetAllQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<List<UserResponse>>> Handle(UsersGetAllQuery request, CancellationToken cancellationToken)
        {
            var users = request.Predicate == null
                ? await _userRepository.GetAllAsync(cancellationToken)
                : await _userRepository.GetAllAsync(request.Predicate, cancellationToken);

            if (users.IsFailure) return Result.Failure<List<UserResponse>>(users.Error);

            var listRes = users.Value.Select(u => new UserResponse(u)).ToList();

            return listRes;
        }
    }
}