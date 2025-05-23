﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using StudyTaskManager.Persistence;

#nullable disable

namespace StudyTaskManager.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("StudyTaskManager.Domain.Entity.Group.Chat.GroupChat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("DeleteFlag")
                        .HasColumnType("boolean");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsPublic")
                        .HasColumnType("boolean");

                    b.ComplexProperty<Dictionary<string, object>>("Name", "StudyTaskManager.Domain.Entity.Group.Chat.GroupChat.Name#Title", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text");
                        });

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("GroupChat", (string)null);
                });

            modelBuilder.Entity("StudyTaskManager.Domain.Entity.Group.Chat.GroupChatMessage", b =>
                {
                    b.Property<Guid>("GroupChatId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Ordinal")
                        .HasColumnType("numeric(20,0)");

                    b.Property<bool>("DeleteFlag")
                        .HasColumnType("boolean");

                    b.Property<Guid>("SenderId")
                        .HasColumnType("uuid");

                    b.HasKey("GroupChatId", "Ordinal");

                    b.HasIndex("SenderId");

                    b.ToTable("GroupChatMessage", (string)null);
                });

            modelBuilder.Entity("StudyTaskManager.Domain.Entity.Group.Chat.GroupChatParticipant", b =>
                {
                    b.Property<Guid>("GroupChatId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<bool>("DeleteFlag")
                        .HasColumnType("boolean");

                    b.HasKey("GroupChatId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("GroupChatParticipant", (string)null);
                });

            modelBuilder.Entity("StudyTaskManager.Domain.Entity.Group.Chat.GroupChatParticipantLastRead", b =>
                {
                    b.Property<Guid>("GroupChatId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("LastReadMessageId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<bool>("DeleteFlag")
                        .HasColumnType("boolean");

                    b.HasKey("GroupChatId", "UserId", "LastReadMessageId");

                    b.HasIndex("UserId");

                    b.HasIndex("GroupChatId", "LastReadMessageId");

                    b.ToTable("GroupChatParticipantLastRead", (string)null);
                });

            modelBuilder.Entity("StudyTaskManager.Domain.Entity.Group.Group", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("DefaultRoleId")
                        .HasColumnType("uuid");

                    b.Property<bool>("DeleteFlag")
                        .HasColumnType("boolean");

                    b.ComplexProperty<Dictionary<string, object>>("Title", "StudyTaskManager.Domain.Entity.Group.Group.Title#Title", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text");
                        });

                    b.HasKey("Id");

                    b.HasIndex("DefaultRoleId");

                    b.ToTable("Group", (string)null);
                });

            modelBuilder.Entity("StudyTaskManager.Domain.Entity.Group.GroupInvite", b =>
                {
                    b.Property<Guid>("ReceiverId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("uuid");

                    b.Property<bool>("DeleteFlag")
                        .HasColumnType("boolean");

                    b.Property<bool?>("InvitationAccepted")
                        .HasColumnType("boolean");

                    b.Property<Guid>("SenderId")
                        .HasColumnType("uuid");

                    b.HasKey("ReceiverId", "GroupId");

                    b.HasIndex("GroupId");

                    b.HasIndex("SenderId");

                    b.ToTable("GroupInvite", (string)null);
                });

            modelBuilder.Entity("StudyTaskManager.Domain.Entity.Group.GroupRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("CanChangeTaskUpdates")
                        .HasColumnType("boolean");

                    b.Property<bool>("CanCreateTaskUpdates")
                        .HasColumnType("boolean");

                    b.Property<bool>("CanCreateTasks")
                        .HasColumnType("boolean");

                    b.Property<bool>("CanInviteUsers")
                        .HasColumnType("boolean");

                    b.Property<bool>("CanManageRoles")
                        .HasColumnType("boolean");

                    b.Property<bool>("DeleteFlag")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("GroupId")
                        .HasColumnType("uuid");

                    b.ComplexProperty<Dictionary<string, object>>("Title", "StudyTaskManager.Domain.Entity.Group.GroupRole.Title#Title", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text");
                        });

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("GroupRole", (string)null);
                });

            modelBuilder.Entity("StudyTaskManager.Domain.Entity.Group.Task.GroupTask", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Deadline")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("DeleteFlag")
                        .HasColumnType("boolean");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ResponsibleId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ResponsibleUserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("StatusId")
                        .HasColumnType("uuid");

                    b.ComplexProperty<Dictionary<string, object>>("HeadLine", "StudyTaskManager.Domain.Entity.Group.Task.GroupTask.HeadLine#Title", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text");
                        });

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("ParentId");

                    b.HasIndex("ResponsibleUserId");

                    b.HasIndex("StatusId");

                    b.ToTable("GroupTask", (string)null);
                });

            modelBuilder.Entity("StudyTaskManager.Domain.Entity.Group.Task.GroupTaskStatus", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("CanBeUpdated")
                        .HasColumnType("boolean");

                    b.Property<bool>("DeleteFlag")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("GroupId")
                        .HasColumnType("uuid");

                    b.ComplexProperty<Dictionary<string, object>>("Name", "StudyTaskManager.Domain.Entity.Group.Task.GroupTaskStatus.Name#Title", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text");
                        });

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("GroupTaskStatus", (string)null);
                });

            modelBuilder.Entity("StudyTaskManager.Domain.Entity.Group.Task.GroupTaskUpdate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CreatorId")
                        .HasColumnType("uuid");

                    b.Property<bool>("DeleteFlag")
                        .HasColumnType("boolean");

                    b.Property<Guid>("TaskId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("TaskId");

                    b.ToTable("GroupTaskUpdate", (string)null);
                });

            modelBuilder.Entity("StudyTaskManager.Domain.Entity.Group.UserInGroup", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateEntered")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("DeleteFlag")
                        .HasColumnType("boolean");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("UserId", "GroupId");

                    b.HasIndex("GroupId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserInGroup", (string)null);
                });

            modelBuilder.Entity("StudyTaskManager.Domain.Entity.User.BlockedUserInfo", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<bool>("DeleteFlag")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("PrevRoleId")
                        .HasColumnType("uuid");

                    b.HasKey("UserId");

                    b.HasIndex("PrevRoleId");

                    b.ToTable("BlockedUserInfo", (string)null);
                });

            modelBuilder.Entity("StudyTaskManager.Domain.Entity.User.Chat.PersonalChat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("DeleteFlag")
                        .HasColumnType("boolean");

                    b.Property<Guid>("User1Id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("User2Id")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasAlternateKey("User1Id", "User2Id");

                    b.HasIndex("User2Id");

                    b.ToTable("PersonalChat", (string)null);
                });

            modelBuilder.Entity("StudyTaskManager.Domain.Entity.User.Chat.PersonalMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateWriten")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("DeleteFlag")
                        .HasColumnType("boolean");

                    b.Property<bool>("Is_Read_By_Other_User")
                        .HasColumnType("boolean");

                    b.Property<Guid>("PersonalChatId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SenderId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PersonalChatId");

                    b.HasIndex("SenderId");

                    b.ToTable("PersonalMessage", (string)null);
                });

            modelBuilder.Entity("StudyTaskManager.Domain.Entity.User.SystemRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("CanBlockUsers")
                        .HasColumnType("boolean");

                    b.Property<bool>("CanChangeSystemRoles")
                        .HasColumnType("boolean");

                    b.Property<bool>("CanDeleteChats")
                        .HasColumnType("boolean");

                    b.Property<bool>("CanViewPeoplesGroups")
                        .HasColumnType("boolean");

                    b.Property<bool>("DeleteFlag")
                        .HasColumnType("boolean");

                    b.ComplexProperty<Dictionary<string, object>>("Name", "StudyTaskManager.Domain.Entity.User.SystemRole.Name#Title", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text");
                        });

                    b.HasKey("Id");

                    b.ToTable("SystemRole", (string)null);
                });

            modelBuilder.Entity("StudyTaskManager.Domain.Entity.User.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("DeleteFlag")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsEmailVerifed")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsPhoneNumberVerifed")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("SystemRoleId")
                        .HasColumnType("uuid");

                    b.ComplexProperty<Dictionary<string, object>>("Email", "StudyTaskManager.Domain.Entity.User.User.Email#Email", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("PasswordHash", "StudyTaskManager.Domain.Entity.User.User.PasswordHash#PasswordHash", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("Username", "StudyTaskManager.Domain.Entity.User.User.Username#Username", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text");
                        });

                    b.HasKey("Id");

                    b.HasIndex("SystemRoleId");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("StudyTaskManager.Persistence.Outbox.OutboxMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Error")
                        .HasColumnType("text");

                    b.Property<DateTime>("OccurredOnUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("ProcessedOnUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("OutboxMessages", (string)null);
                });

            modelBuilder.Entity("StudyTaskManager.Domain.Entity.Group.Chat.GroupChat", b =>
                {
                    b.HasOne("StudyTaskManager.Domain.Entity.Group.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");
                });

            modelBuilder.Entity("StudyTaskManager.Domain.Entity.Group.Chat.GroupChatMessage", b =>
                {
                    b.HasOne("StudyTaskManager.Domain.Entity.Group.Chat.GroupChat", "GroupChat")
                        .WithMany("GroupChatMessages")
                        .HasForeignKey("GroupChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudyTaskManager.Domain.Entity.User.User", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("StudyTaskManager.Domain.ValueObjects.Content", "Content", b1 =>
                        {
                            b1.Property<Guid>("GroupChatMessageGroupChatId")
                                .HasColumnType("uuid");

                            b1.Property<decimal>("GroupChatMessageOrdinal")
                                .HasColumnType("numeric(20,0)");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("GroupChatMessageGroupChatId", "GroupChatMessageOrdinal");

                            b1.ToTable("GroupChatMessage");

                            b1.WithOwner()
                                .HasForeignKey("GroupChatMessageGroupChatId", "GroupChatMessageOrdinal");
                        });

                    b.Navigation("Content")
                        .IsRequired();

                    b.Navigation("GroupChat");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("StudyTaskManager.Domain.Entity.Group.Chat.GroupChatParticipant", b =>
                {
                    b.HasOne("StudyTaskManager.Domain.Entity.Group.Chat.GroupChat", "GroupChat")
                        .WithMany("GroupChatParticipants")
                        .HasForeignKey("GroupChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudyTaskManager.Domain.Entity.User.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GroupChat");

                    b.Navigation("User");
                });

            modelBuilder.Entity("StudyTaskManager.Domain.Entity.Group.Chat.GroupChatParticipantLastRead", b =>
                {
                    b.HasOne("StudyTaskManager.Domain.Entity.Group.Chat.GroupChat", "GroupChat")
                        .WithMany()
                        .HasForeignKey("GroupChatId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("StudyTaskManager.Domain.Entity.User.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("StudyTaskManager.Domain.Entity.Group.Chat.GroupChatMessage", "ReadMessage")
                        .WithMany()
                        .HasForeignKey("GroupChatId", "LastReadMessageId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("GroupChat");

                    b.Navigation("ReadMessage");

                    b.Navigation("User");
                });

            modelBuilder.Entity("StudyTaskManager.Domain.Entity.Group.Group", b =>
                {
                    b.HasOne("StudyTaskManager.Domain.Entity.Group.GroupRole", "DefaultRole")
                        .WithMany()
                        .HasForeignKey("DefaultRoleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.OwnsOne("StudyTaskManager.Domain.ValueObjects.Content", "Description", b1 =>
                        {
                            b1.Property<Guid>("GroupId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("GroupId");

                            b1.ToTable("Group");

                            b1.WithOwner()
                                .HasForeignKey("GroupId");
                        });

                    b.Navigation("DefaultRole");

                    b.Navigation("Description");
                });

            modelBuilder.Entity("StudyTaskManager.Domain.Entity.Group.GroupInvite", b =>
                {
                    b.HasOne("StudyTaskManager.Domain.Entity.Group.Group", "Group")
                        .WithMany("GroupInvites")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudyTaskManager.Domain.Entity.User.User", "Receiver")
                        .WithMany()
                        .HasForeignKey("ReceiverId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("StudyTaskManager.Domain.Entity.User.User", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("Receiver");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("StudyTaskManager.Domain.Entity.Group.GroupRole", b =>
                {
                    b.HasOne("StudyTaskManager.Domain.Entity.Group.Group", "Group")
                        .WithMany("GroupRoles")
                        .HasForeignKey("GroupId");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("StudyTaskManager.Domain.Entity.Group.Task.GroupTask", b =>
                {
                    b.HasOne("StudyTaskManager.Domain.Entity.Group.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudyTaskManager.Domain.Entity.Group.Task.GroupTask", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId");

                    b.HasOne("StudyTaskManager.Domain.Entity.User.User", "ResponsibleUser")
                        .WithMany()
                        .HasForeignKey("ResponsibleUserId");

                    b.HasOne("StudyTaskManager.Domain.Entity.Group.Task.GroupTaskStatus", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");

                    b.OwnsOne("StudyTaskManager.Domain.ValueObjects.Content", "Description", b1 =>
                        {
                            b1.Property<Guid>("GroupTaskId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("GroupTaskId");

                            b1.ToTable("GroupTask");

                            b1.WithOwner()
                                .HasForeignKey("GroupTaskId");
                        });

                    b.Navigation("Description")
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("Parent");

                    b.Navigation("ResponsibleUser");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("StudyTaskManager.Domain.Entity.Group.Task.GroupTaskStatus", b =>
                {
                    b.HasOne("StudyTaskManager.Domain.Entity.Group.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId");

                    b.OwnsOne("StudyTaskManager.Domain.ValueObjects.Content", "Description", b1 =>
                        {
                            b1.Property<Guid>("GroupTaskStatusId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("GroupTaskStatusId");

                            b1.ToTable("GroupTaskStatus");

                            b1.WithOwner()
                                .HasForeignKey("GroupTaskStatusId");
                        });

                    b.Navigation("Description")
                        .IsRequired();

                    b.Navigation("Group");
                });

            modelBuilder.Entity("StudyTaskManager.Domain.Entity.Group.Task.GroupTaskUpdate", b =>
                {
                    b.HasOne("StudyTaskManager.Domain.Entity.User.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudyTaskManager.Domain.Entity.Group.Task.GroupTask", "Task")
                        .WithMany()
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("StudyTaskManager.Domain.ValueObjects.Content", "Content", b1 =>
                        {
                            b1.Property<Guid>("GroupTaskUpdateId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("GroupTaskUpdateId");

                            b1.ToTable("GroupTaskUpdate");

                            b1.WithOwner()
                                .HasForeignKey("GroupTaskUpdateId");
                        });

                    b.Navigation("Content")
                        .IsRequired();

                    b.Navigation("Creator");

                    b.Navigation("Task");
                });

            modelBuilder.Entity("StudyTaskManager.Domain.Entity.Group.UserInGroup", b =>
                {
                    b.HasOne("StudyTaskManager.Domain.Entity.Group.Group", "Group")
                        .WithMany("UsersInGroup")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudyTaskManager.Domain.Entity.Group.GroupRole", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudyTaskManager.Domain.Entity.User.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("StudyTaskManager.Domain.Entity.User.BlockedUserInfo", b =>
                {
                    b.HasOne("StudyTaskManager.Domain.Entity.User.SystemRole", "PrevRole")
                        .WithMany()
                        .HasForeignKey("PrevRoleId");

                    b.HasOne("StudyTaskManager.Domain.Entity.User.User", "User")
                        .WithOne()
                        .HasForeignKey("StudyTaskManager.Domain.Entity.User.BlockedUserInfo", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PrevRole");

                    b.Navigation("User");
                });

            modelBuilder.Entity("StudyTaskManager.Domain.Entity.User.Chat.PersonalChat", b =>
                {
                    b.HasOne("StudyTaskManager.Domain.Entity.User.User", "User1")
                        .WithMany("PersonalChatsAsUser1")
                        .HasForeignKey("User1Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("StudyTaskManager.Domain.Entity.User.User", "User2")
                        .WithMany("PersonalChatsAsUser2")
                        .HasForeignKey("User2Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User1");

                    b.Navigation("User2");
                });

            modelBuilder.Entity("StudyTaskManager.Domain.Entity.User.Chat.PersonalMessage", b =>
                {
                    b.HasOne("StudyTaskManager.Domain.Entity.User.Chat.PersonalChat", "PersonalChat")
                        .WithMany("Messages")
                        .HasForeignKey("PersonalChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudyTaskManager.Domain.Entity.User.User", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("StudyTaskManager.Domain.ValueObjects.Content", "Content", b1 =>
                        {
                            b1.Property<Guid>("PersonalMessageId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("PersonalMessageId");

                            b1.ToTable("PersonalMessage");

                            b1.WithOwner()
                                .HasForeignKey("PersonalMessageId");
                        });

                    b.Navigation("Content")
                        .IsRequired();

                    b.Navigation("PersonalChat");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("StudyTaskManager.Domain.Entity.User.User", b =>
                {
                    b.HasOne("StudyTaskManager.Domain.Entity.User.SystemRole", "SystemRole")
                        .WithMany()
                        .HasForeignKey("SystemRoleId");

                    b.OwnsOne("StudyTaskManager.Domain.ValueObjects.PhoneNumber", "PhoneNumber", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("UserId");

                            b1.ToTable("User");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("PhoneNumber");

                    b.Navigation("SystemRole");
                });

            modelBuilder.Entity("StudyTaskManager.Domain.Entity.Group.Chat.GroupChat", b =>
                {
                    b.Navigation("GroupChatMessages");

                    b.Navigation("GroupChatParticipants");
                });

            modelBuilder.Entity("StudyTaskManager.Domain.Entity.Group.Group", b =>
                {
                    b.Navigation("GroupInvites");

                    b.Navigation("GroupRoles");

                    b.Navigation("UsersInGroup");
                });

            modelBuilder.Entity("StudyTaskManager.Domain.Entity.User.Chat.PersonalChat", b =>
                {
                    b.Navigation("Messages");
                });

            modelBuilder.Entity("StudyTaskManager.Domain.Entity.User.User", b =>
                {
                    b.Navigation("PersonalChatsAsUser1");

                    b.Navigation("PersonalChatsAsUser2");
                });
#pragma warning restore 612, 618
        }
    }
}
