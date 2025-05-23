﻿using StudyTaskManager.Domain.Common;
using StudyTaskManager.Domain.DomainEvents;
using StudyTaskManager.Domain.Errors;
using StudyTaskManager.Domain.Shared;
using System;
using System.Text.Json.Serialization;

namespace StudyTaskManager.Domain.Entity.Group
{
    /// <summary>
    /// Приглашение пользователя в группу.
    /// </summary>
    public class GroupInvite : BaseEntity
    {
        /// <summary>
        /// Приватный конструктор для создания объекта <see cref="GroupInvite"/>.
        /// </summary>
        private GroupInvite(Guid senderId, Guid receiverId, Guid groupId) : base()
        {
            SenderId = senderId;
            ReceiverId = receiverId;
            GroupId = groupId;

            DateInvitation = DateTime.UtcNow;
        }

        #region свойства

        /// <summary>
        /// ID отправителя приглашения.
        /// </summary>
        public Guid SenderId { get; }

        /// <summary>
        /// ID получателя приглашения.
        /// </summary>
        public Guid ReceiverId { get; }

        /// <summary>
        /// ID группы, в которую приглашают.
        /// </summary>
        public Guid GroupId { get; }

        /// <summary>
        /// Дата отправки приглашения.
        /// </summary>
        public DateTime DateInvitation { get; }

        /// <summary>
        /// Флаг принятия приглашения (false — не принято, true — принято).
        /// </summary>
        public bool? InvitationAccepted { get; private set; }

        /// <summary>
        /// Отправитель приглашения.
        /// </summary>
        [JsonIgnore]
        public User.User? Sender { get; private set; }

        /// <summary>
        /// Получатель приглашения.
        /// </summary>
        [JsonIgnore]
        public User.User? Receiver { get; private set; }

        /// <summary>
        /// Группа, в которую приглашают.
        /// </summary>
        [JsonIgnore]
        public Group? Group { get; private set; }

        #endregion

        /// <summary>
        /// Метод для принятия приглашения.
        /// </summary>
        public Result AcceptInvite()
        {
            if (InvitationAccepted != null)
                if (InvitationAccepted == true)
                    return Result.Failure(PersistenceErrors.GroupInvite.Accepted);
                else
                    return Result.Failure(PersistenceErrors.GroupInvite.Declined);

            InvitationAccepted = true;

            RaiseDomainEvent(new GroupInviteAcceptedDomainEvent(ReceiverId, GroupId));

            return Result.Success();
        }

        /// <summary>
        /// Метод для отклонения приглашения.
        /// </summary>
        public Result DeclineInvite()
        {
            if (InvitationAccepted != null)
                if (InvitationAccepted == true)
                    return Result.Failure(PersistenceErrors.GroupInvite.Accepted);
                else
                    return Result.Failure(PersistenceErrors.GroupInvite.Declined);

            InvitationAccepted = false;

            RaiseDomainEvent(new GroupInviteDeclinedDomainEvent(ReceiverId, GroupId));

            return Result.Success();
        }

        /// <summary>
        /// Создает новое приглашение.
        /// </summary>
        public static Result<GroupInvite> Create(User.User sender, User.User receiver, Group group)
        {
            var gi = new GroupInvite(sender.Id, receiver.Id, group.Id)
            {
                Sender = sender,
                Receiver = receiver,
                Group = group
            };

            gi.RaiseDomainEvent(new GroupInviteCreatedDomainEvent(gi.GroupId, gi.ReceiverId));

            return Result.Success(gi);
        }
    }
}
