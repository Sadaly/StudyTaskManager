﻿using StudyTaskManager.Application.Abstractions.Messaging;
using StudyTaskManager.Domain.Abstractions.Repositories;
using StudyTaskManager.Domain.Shared;

namespace StudyTaskManager.Application.Entity.GroupInvites.Queries.GroupInviteGetByGroupAndUser
{
    public class GroupInviteGetByGroupAndUserQueryHandler : IQueryHandler<GroupInviteGetByGroupAndUserQuery, GroupInviteResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IGroupRepository _groupRepository;
        private readonly IGroupInviteRepository _groupInviteRepository;

        public GroupInviteGetByGroupAndUserQueryHandler(IUserRepository userRepository, IGroupRepository groupRepository, IGroupInviteRepository groupInviteRepository)
        {
            _userRepository = userRepository;
            _groupRepository = groupRepository;
            _groupInviteRepository = groupInviteRepository;
        }

        public async Task<Result<GroupInviteResponse>> Handle(GroupInviteGetByGroupAndUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.ReceiverId, cancellationToken);
            if (user.IsFailure) return Result.Failure<GroupInviteResponse>(user);

            var group = await _groupRepository.GetByIdAsync(request.GroupId, cancellationToken);
            if (group.IsFailure) return Result.Failure<GroupInviteResponse>(group);

            var invite = await _groupInviteRepository.GetByUserAndGropu(user.Value, group.Value, cancellationToken);
            if (invite.IsFailure) return Result.Failure<GroupInviteResponse>(invite);

            return Result.Success(new GroupInviteResponse(invite.Value));
        }
    }
}
