﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudyTaskManager.Domain.Entity.Group.Task;
using StudyTaskManager.Domain.ValueObjects;

namespace StudyTaskManager.Persistence.Configurations
{
    class GroupTaskConfiguration : IEntityTypeConfiguration<GroupTask>
    {
        public void Configure(EntityTypeBuilder<GroupTask> builder)
        {
            builder.ToTable(TableNames.GroupTask);

            builder.HasKey(gt => gt.Id);

            builder
                .HasOne(gt => gt.Group)
                .WithMany()
                .HasForeignKey(gt => gt.GroupId);
            builder
                .HasOne(gt => gt.Parent)
                .WithMany()
                .HasForeignKey(gt => gt.ParentId);
            builder
                .HasOne(gt => gt.ResponsibleUser)
                .WithMany()
                .HasForeignKey(gt => gt.ResponsibleUserId);
            builder
                .HasOne(gt => gt.Status)
                .WithMany()
                .HasForeignKey(gt => gt.StatusId)
                .IsRequired(false);

            // Конфигурация OwnedType
            builder.OwnsOne(gt => gt.Description);
        }
    }
}
