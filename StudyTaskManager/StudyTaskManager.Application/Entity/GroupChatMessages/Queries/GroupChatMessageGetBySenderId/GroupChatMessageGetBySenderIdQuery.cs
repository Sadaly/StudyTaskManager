﻿using StudyTaskManager.Application.Abstractions.Messaging;

namespace StudyTaskManager.Application.Entity.GroupChatMessages.Queries.GroupChatMessageGetBySenderId;
public sealed record GroupChatMessageGetBySenderIdQuery(Guid SenderId) : IQuery<GroupChatMessageListResponse>;