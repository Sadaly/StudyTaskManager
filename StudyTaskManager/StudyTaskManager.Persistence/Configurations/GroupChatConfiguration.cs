﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudyTaskManager.Domain.Entity.Group.Chat;
using StudyTaskManager.Domain.ValueObjects;

namespace StudyTaskManager.Persistence.Configurations
{
    class GroupChatConfiguration : IEntityTypeConfiguration<GroupChat>
    {
        public void Configure(EntityTypeBuilder<GroupChat> builder)
        {
            builder.ToTable(TableNames.GroupChat);

            builder.HasKey(gc => gc.Id);

            builder
                .HasOne(gc => gc.Group)
                .WithMany()
                .HasForeignKey(gc => gc.GroupId);
        }
    }
}
