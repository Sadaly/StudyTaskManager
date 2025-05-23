﻿using StudyTaskManager.Domain.Common;
using StudyTaskManager.Domain.DomainEvents;
using StudyTaskManager.Domain.Shared;
using StudyTaskManager.Domain.ValueObjects;

namespace StudyTaskManager.Domain.Entity.Group.Task
{
    /// <summary>
    /// Обновление задачи в группе.
    /// </summary>
    public class GroupTaskUpdate : BaseEntityWithID
    {
        private GroupTaskUpdate(Guid id, Guid creatorId, Guid taskId) : base(id)
        {
            CreatorId = creatorId;
            TaskId = taskId;
            DateCreated = DateTime.UtcNow;
        }
        private GroupTaskUpdate(Guid id, Guid creatorId, Guid taskId, Content content) : this(id, creatorId, taskId)
        {
            Content = content;
        }

        #region свойства

        /// <summary>
        /// Id создателя апдейта.
        /// </summary>
        public Guid CreatorId { get; }

        /// <summary>
        /// Id задачи.
        /// </summary>
        public Guid TaskId { get; }

        /// <summary>
        /// Дата создания апдейта.
        /// </summary>
        public DateTime DateCreated { get; }

        /// <summary>
        /// Содержание обновления задачи.
        /// </summary>
        public Content Content { get; private set; } = null!;

        /// <summary>
        /// Ссылка на создателя апдейта.
        /// </summary>
        public User.User? Creator { get; private set; }

        /// <summary>
        /// Ссылка на задачу.
        /// </summary>
        public GroupTask? Task { get; private set; }

        #endregion

        /// <summary>
        /// Создает новое обновление задачи.
        /// </summary>
        public static Result<GroupTaskUpdate> Create(User.User creator, GroupTask task, Content content)
        {
            var gtu = new GroupTaskUpdate(Guid.Empty, creator.Id, task.Id, content)
            {
                Creator = creator,
                Task = task
            };

            gtu.RaiseDomainEvent(new GroupTaskUpdateCreatedDomainEvent(gtu.Id));

            return Result.Success(gtu);
        }

        /// <summary>
        /// Обновляет содержание задачи.
        /// </summary>
        public Result UpdateContent(Content newContent)
        {
            Content = newContent;

            RaiseDomainEvent(new GroupTaskUpdateUpdatedDomainEvent(this.Id));

            return Result.Success();
        }
    }
}
