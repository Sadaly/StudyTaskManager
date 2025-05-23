﻿using StudyTaskManager.Application.Abstractions.Messaging;
using StudyTaskManager.Domain.Abstractions;
using StudyTaskManager.Domain.Abstractions.Repositories;
using StudyTaskManager.Domain.Shared;

namespace StudyTaskManager.Application.Entity.GroupRoles.Commands.GroupRoleUpdatePermissions
{
    public class GroupRoleUpdatePermissionsCommandHandler : ICommandHandler<GroupRoleUpdatePermissionsCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGroupRoleRepository _groupRoleRepository;

        public GroupRoleUpdatePermissionsCommandHandler(IUnitOfWork unitOfWork, IGroupRoleRepository groupRoleRepository)
        {
            _unitOfWork = unitOfWork;
            _groupRoleRepository = groupRoleRepository;
        }

        public async Task<Result> Handle(GroupRoleUpdatePermissionsCommand request, CancellationToken cancellationToken)
        {
            var role = await _groupRoleRepository.GetByIdAsync(request.Id, cancellationToken);
            if (role.IsFailure) return role;

            var updatePermissions = role.Value.UpdatePermissions(
                request.CanCreateTasks,
                request.CanManageRoles,
                request.CanCreateTaskUpdates,
                request.CanChangeTaskUpdates,
                request.CanInviteUsers);
            if (updatePermissions.IsFailure) return updatePermissions;

            var updateDB = await _groupRoleRepository.UpdateAsync(role.Value, cancellationToken);
            if (updateDB.IsFailure) return updateDB;

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
