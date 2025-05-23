﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudyTaskManager.Domain.Entity.Group.Chat;
using System.Numerics;

namespace StudyTaskManager.Persistence.Configurations
{
    class GroupChatParticipantLastReadConfiguration : IEntityTypeConfiguration<GroupChatParticipantLastRead>
    {
        public void Configure(EntityTypeBuilder<GroupChatParticipantLastRead> builder)
        {
            builder.ToTable(TableNames.GroupChatParticipantLastRead);

            builder.HasKey(gcp => new { gcp.GroupChatId, gcp.UserId, gcp.LastReadMessageId }); // Составной ключ

            builder
                .HasOne(gcplr => gcplr.GroupChat)
                .WithMany()
                .HasForeignKey(gcplr => gcplr.GroupChatId)
                .OnDelete(DeleteBehavior.NoAction);
            builder
                .HasOne(gcplr => gcplr.User)
                .WithMany()
                .HasForeignKey(gcplr => gcplr.UserId)
                .OnDelete(DeleteBehavior.NoAction);
            builder
                .HasOne(gcplr => gcplr.ReadMessage)
                .WithMany()
                .HasForeignKey(gcplr => new { gcplr.GroupChatId, gcplr.LastReadMessageId })
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
