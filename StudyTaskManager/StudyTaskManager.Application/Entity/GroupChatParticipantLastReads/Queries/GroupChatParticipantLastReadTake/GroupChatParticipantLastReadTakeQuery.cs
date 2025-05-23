﻿using StudyTaskManager.Application.Abstractions.Messaging;
using StudyTaskManager.Domain.Entity.Group.Chat;
using System.Linq.Expressions;

namespace StudyTaskManager.Application.Entity.GroupChatParticipantLastReads.Queries.GroupChatParticipantLastReadTake;
public sealed record GroupChatParticipantLastReadTakeQuery(int StartIndex, int Count,
	Expression<Func<GroupChatParticipantLastRead, bool>>? Predicate) : IQuery<List<GroupChatParticipantLastReadResponse>>;