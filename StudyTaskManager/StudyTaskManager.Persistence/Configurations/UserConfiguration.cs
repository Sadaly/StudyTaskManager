﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudyTaskManager.Domain.Entity.User;
using StudyTaskManager.Domain.ValueObjects;

namespace StudyTaskManager.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(TableNames.User);

            // Приватный ключ
            builder.HasKey(user => user.Id);
            // Внешний ключ для роли
            builder
                .HasOne(user => user.SystemRole)
                .WithMany()
                .HasForeignKey(user => user.SystemRoleId);

            builder.Ignore(user => user.PersonalChats);

            // Конфигурация PhoneNumber как owned-типа
            builder.OwnsOne(user => user.PhoneNumber, phone =>
            {
                phone.Property(p => p.Value);  // Маппим Value в столбец PhoneNumber_Value
            });

            builder.Navigation(user => user.PhoneNumber).IsRequired(false);
        }
    }
}
