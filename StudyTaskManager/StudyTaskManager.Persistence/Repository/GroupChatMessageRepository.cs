﻿using StudyTaskManager.Domain.Abstractions.Repositories;
using StudyTaskManager.Domain.Entity.Group.Chat;
using StudyTaskManager.Domain.Entity.User;
using StudyTaskManager.Domain.Errors;
using StudyTaskManager.Domain.Shared;

namespace StudyTaskManager.Persistence.Repository
{
    public class GroupChatMessageRepository : Generic.TRepository<GroupChatMessage>, IGroupChatMessageRepository
    {
        public GroupChatMessageRepository(AppDbContext dbContext) : base(dbContext) { }

        #region verification
        protected override async Task<Result> VerificationBeforeAddingAsync(GroupChatMessage entity, CancellationToken cancellationToken)
        {
            Result<User> sender = await GetFromDBAsync<User>(entity.SenderId, PersistenceErrors.User.IdEmpty, PersistenceErrors.User.NotFound, cancellationToken);
            if (sender.IsFailure) { return sender; }

            Result<GroupChat> groupChat = await GetFromDBAsync<GroupChat>(entity.GroupChatId, PersistenceErrors.GroupChat.IdEmpty, PersistenceErrors.GroupChat.NotFound, cancellationToken);
            if (groupChat.IsFailure) { return groupChat; }

            if (!groupChat.Value.IsPublic)
            {
                Result<GroupChatParticipant> groupChatParticipant = await GetFromDBAsync<GroupChatParticipant>(
                    gcp =>
                        gcp.GroupChatId == entity.GroupChatId &&
                        gcp.UserId == entity.SenderId
                    , PersistenceErrors.GroupChatParticipant.NotFound
                    , cancellationToken);
                if (groupChatParticipant.IsFailure) { return Result.Failure(groupChatParticipant.Error); }
            }

            Result<GroupChatMessage> res = await GetFromDBAsync(
                gcm =>
                    gcm.SenderId == entity.SenderId &&
                    gcm.GroupChatId == entity.GroupChatId
                , PersistenceErrors.GroupChatMessage.NotFound
                , cancellationToken);
            if (res.IsSuccess) { return Result.Failure(PersistenceErrors.GroupChatMessage.AlreadyExist); }
            return Result.Success();
        }

        protected override async Task<Result> VerificationBeforeUpdateAsync(GroupChatMessage entity, CancellationToken cancellationToken)
        {
            Result<GroupChat> groupChat = await GetFromDBAsync<GroupChat>(entity.GroupChatId, PersistenceErrors.GroupChat.IdEmpty, PersistenceErrors.GroupChat.NotFound, cancellationToken);
            if (groupChat.IsFailure) { return groupChat; }

            Result<GroupChatMessage> res = await GetFromDBAsync(
                gcm =>
                    gcm.Ordinal == entity.Ordinal &&
                    gcm.GroupChatId == entity.GroupChatId
                , PersistenceErrors.GroupChatMessage.NotFound
                , cancellationToken);
            return res;
        }

        protected override async Task<Result> VerificationBeforeRemoveAsync(GroupChatMessage entity, CancellationToken cancellationToken)
        {
            Result<GroupChatMessage> res = await GetFromDBAsync(
                gcm =>
                    gcm.SenderId == entity.SenderId &&
                    gcm.GroupChatId == entity.GroupChatId
                , PersistenceErrors.GroupChatMessage.NotFound
                , cancellationToken);
            return res;
        }
        #endregion

        public async Task<Result<GroupChatMessage>> GetMessageAsync(Guid groupChatId, ulong ordinal, CancellationToken cancellationToken)
        {
            return await GetFromDBAsync(
                gcm =>
                    gcm.Ordinal == ordinal &&
                    gcm.GroupChatId == groupChatId
                , PersistenceErrors.GroupChatMessage.NotFound
                , cancellationToken);
        }

        public async Task<Result<List<GroupChatMessage>>> GetMessagesByGroupChatIdAsync(Guid groupChatId, CancellationToken cancellationToken)
        {
            var groupChat = await GetFromDBAsync<GroupChat>(
                groupChatId,
                PersistenceErrors.GroupChat.IdEmpty,
                PersistenceErrors.GroupChat.NotFound,
                cancellationToken);
            if (groupChat.IsFailure) return Result.Failure<List<GroupChatMessage>>(groupChat);

            return await GetAllAsync(
                x => x.GroupChatId == groupChatId,
                cancellationToken);
        }
        public async Task<Result<List<GroupChatMessage>>> GetMessagesByGroupChatIdAsync(
            int startIndex, int count, Guid groupChatId, CancellationToken cancellationToken)
        {
            var groupChat = await GetFromDBAsync<GroupChat>(
                groupChatId,
                PersistenceErrors.GroupChat.IdEmpty,
                PersistenceErrors.GroupChat.NotFound,
                cancellationToken);
            if (groupChat.IsFailure) return Result.Failure<List<GroupChatMessage>>(groupChat);

            return await GetFromDBWhereAsync(
                startIndex,
                count,
                gcm => gcm.GroupChatId == groupChatId,
                cancellationToken);
        }

        public async Task<Result<List<GroupChatMessage>>> GetMessagesBySenderIdAsync(Guid senderId, CancellationToken cancellationToken)
        {
            var sender = await GetFromDBAsync<GroupChat>(senderId,
                PersistenceErrors.User.IdEmpty,
                PersistenceErrors.User.NotFound,
                cancellationToken);
            if (sender.IsFailure) return Result.Failure<List<GroupChatMessage>>(sender);

            return await GetAllAsync(
                x => x.SenderId == senderId,
                cancellationToken);
        }
        public async Task<Result<List<GroupChatMessage>>> GetMessagesBySenderIdAsync(
            int startIndex, int count, Guid senderId, CancellationToken cancellationToken)
        {
            var sender = await GetFromDBAsync<GroupChat>(senderId,
                PersistenceErrors.User.IdEmpty,
                PersistenceErrors.User.NotFound,
                cancellationToken);
            if (sender.IsFailure) return Result.Failure<List<GroupChatMessage>>(sender);

            return await GetFromDBWhereAsync(
                startIndex,
                count,
                gcm => gcm.SenderId == senderId,
                cancellationToken);
        }
    }
}
