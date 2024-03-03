﻿// <auto-generated />
using System;
using EduPulse.Domain.Enums;
using EduPulse.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EduPulse.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(EduPulseDbContext))]
    partial class EduPulseDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "test_status", new[] { "scheduled", "opened", "closed" });
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EduPulse.Domain.Entities.AnswerEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid?>("QuestionEntityId")
                        .HasColumnType("uuid")
                        .HasColumnName("question_entity_id");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("value");

                    b.HasKey("Id")
                        .HasName("pk_answer_entity");

                    b.HasIndex("QuestionEntityId")
                        .HasDatabaseName("ix_answer_entity_question_entity_id");

                    b.ToTable("answer_entity", (string)null);
                });

            modelBuilder.Entity("EduPulse.Domain.Entities.GroupEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<Guid>("InstituteId")
                        .HasColumnType("uuid")
                        .HasColumnName("institute_id");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("pk_groups");

                    b.HasIndex("InstituteId")
                        .HasDatabaseName("ix_groups_institute_id");

                    b.HasIndex("Title")
                        .HasDatabaseName("ix_groups_title");

                    NpgsqlIndexBuilderExtensions.HasMethod(b.HasIndex("Title"), "btree");

                    b.ToTable("groups", (string)null);
                });

            modelBuilder.Entity("EduPulse.Domain.Entities.InstituteEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("code");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("pk_institutes");

                    b.ToTable("institutes", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("c75455eb-90a1-462e-99c0-4d3810815b98"),
                            Code = "ІДА",
                            Title = "Адміністрування, державного управління та професійного розвитку інститут"
                        },
                        new
                        {
                            Id = new Guid("d885527d-246b-452a-b3be-a49deacbcfd5"),
                            Code = "ІАРД",
                            Title = "Архітектури та дизайну інститут"
                        },
                        new
                        {
                            Id = new Guid("4cdc205d-af15-45aa-8f6f-737cc74c9959"),
                            Code = "ІБІС",
                            Title = "Будівництва та інженерних систем інститут"
                        },
                        new
                        {
                            Id = new Guid("f41e1c0f-21b4-4e8d-93c6-1076cb6a2634"),
                            Code = "ІГДГ",
                            Title = "Геодезії інститут"
                        },
                        new
                        {
                            Id = new Guid("ed164c5f-62f0-4211-8d10-969cf768e182"),
                            Code = "ІГСН",
                            Title = "Гуманітарних та соціальних наук інститут"
                        },
                        new
                        {
                            Id = new Guid("3e9ebd2c-c992-4f56-8292-5402bd9d5a03"),
                            Code = "ІНЕМ",
                            Title = "Економіки і менеджменту інститут"
                        },
                        new
                        {
                            Id = new Guid("7d99ecfd-1eb8-470d-9812-19ba0673149b"),
                            Code = "ІЕСК",
                            Title = "Енергетики та систем керування інститут"
                        },
                        new
                        {
                            Id = new Guid("49a1ee2e-bfb3-464a-b5e7-13747a9411cb"),
                            Code = "КНІ",
                            Title = "Комп'ютерних наук та інформаційних технологій"
                        },
                        new
                        {
                            Id = new Guid("453d2d2a-e500-4b12-a7dc-0c91b9ac5b3d"),
                            Code = "ІКТА",
                            Title = "Комп'ютерних технологій, автоматики та метрології інститут"
                        },
                        new
                        {
                            Id = new Guid("c6f8a182-e442-430c-97ac-73b59ed47d40"),
                            Code = "ІМІТ",
                            Title = "Механічної інженерії та транспорту інститут"
                        },
                        new
                        {
                            Id = new Guid("6ff00f2d-d08a-48dc-bc2e-7af5ce46ebdd"),
                            Code = "ІППО",
                            Title = "Права, психології та інноваційної освіти інститут"
                        },
                        new
                        {
                            Id = new Guid("fec6e117-3a45-4cfb-8031-688f3210a101"),
                            Code = "ІМФН",
                            Title = "Прикладної математики та фундаментальних наук інститут"
                        },
                        new
                        {
                            Id = new Guid("426aaec1-2265-41b3-90f8-350051e3af2d"),
                            Code = "ІППТ",
                            Title = "Просторового планування та перспективних технологій інститут"
                        },
                        new
                        {
                            Id = new Guid("6938cc71-84db-4b2b-9cc0-220f00000a83"),
                            Code = "ІСТР",
                            Title = "Сталого розвитку і ім. В.Чорновола інститут"
                        },
                        new
                        {
                            Id = new Guid("f8f3ae00-bd14-477c-96b9-ec3af790bb26"),
                            Code = "ІТРЕ",
                            Title = "Телекомунікацій, радіоелектроніки та електронної техніки інститут"
                        },
                        new
                        {
                            Id = new Guid("e58765b1-10b3-4524-9776-0d28119ad3e2"),
                            Code = "ІХХТ",
                            Title = "Хімії та хімічних технологій інститут"
                        });
                });

            modelBuilder.Entity("EduPulse.Domain.Entities.QuestionEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("CorrectAnswerId")
                        .HasColumnType("uuid")
                        .HasColumnName("correct_answer_id");

                    b.Property<int>("Points")
                        .HasColumnType("integer")
                        .HasColumnName("points");

                    b.Property<Guid?>("TestEntityId")
                        .HasColumnType("uuid")
                        .HasColumnName("test_entity_id");

                    b.Property<Guid>("TestId")
                        .HasColumnType("uuid")
                        .HasColumnName("test_id");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("pk_question_entity");

                    b.HasIndex("TestEntityId")
                        .HasDatabaseName("ix_question_entity_test_entity_id");

                    b.ToTable("question_entity", (string)null);
                });

            modelBuilder.Entity("EduPulse.Domain.Entities.ScheduledEmailEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Recipient")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("recipient");

                    b.Property<DateTimeOffset>("SendsAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("sends_at");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("subject");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("text");

                    b.HasKey("Id")
                        .HasName("pk_scheduled_emails");

                    b.ToTable("scheduled_emails", (string)null);
                });

            modelBuilder.Entity("EduPulse.Domain.Entities.StudentEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<int>("Age")
                        .HasColumnType("integer")
                        .HasColumnName("age");

                    b.Property<string>("Avatar")
                        .HasColumnType("text")
                        .HasColumnName("avatar");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("full_name");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("uuid")
                        .HasColumnName("group_id");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password_hash");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("phone_number");

                    b.HasKey("Id")
                        .HasName("pk_students");

                    b.HasIndex("Email")
                        .HasDatabaseName("ix_students_email");

                    NpgsqlIndexBuilderExtensions.HasMethod(b.HasIndex("Email"), "btree");

                    b.HasIndex("FullName")
                        .HasDatabaseName("ix_students_full_name");

                    NpgsqlIndexBuilderExtensions.HasMethod(b.HasIndex("FullName"), "btree");

                    b.HasIndex("GroupId")
                        .HasDatabaseName("ix_students_group_id");

                    b.ToTable("students", (string)null);
                });

            modelBuilder.Entity("EduPulse.Domain.Entities.SubjectEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("pk_subjects");

                    b.ToTable("subjects", (string)null);
                });

            modelBuilder.Entity("EduPulse.Domain.Entities.TeacherEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Avatar")
                        .HasColumnType("text")
                        .HasColumnName("avatar");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("full_name");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password_hash");

                    b.HasKey("Id")
                        .HasName("pk_teachers");

                    b.ToTable("teachers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("af41f834-c0f9-46be-89bf-51708b4adec9"),
                            CreatedAt = new DateTimeOffset(new DateTime(2024, 3, 3, 6, 17, 4, 421, DateTimeKind.Unspecified).AddTicks(536), new TimeSpan(0, 0, 0, 0, 0)),
                            Email = "daniel.hrovinsky@gmail.com",
                            FullName = "Daniel Hrovinsky",
                            PasswordHash = "thj3yNIF3ZKC1UziLTuSh7CsSUTT/yR1nvu83Fx9oek="
                        });
                });

            modelBuilder.Entity("EduPulse.Domain.Entities.TeacherGroupEntity", b =>
                {
                    b.Property<Guid>("GroupId")
                        .HasColumnType("uuid")
                        .HasColumnName("group_id");

                    b.Property<Guid>("TeacherId")
                        .HasColumnType("uuid")
                        .HasColumnName("teacher_id");

                    b.HasKey("GroupId", "TeacherId")
                        .HasName("pk_teacher_groups");

                    b.HasIndex("TeacherId")
                        .HasDatabaseName("ix_teacher_groups_teacher_id");

                    b.ToTable("teacher_groups", (string)null);
                });

            modelBuilder.Entity("EduPulse.Domain.Entities.TeacherSubjectEntity", b =>
                {
                    b.Property<Guid>("SubjectId")
                        .HasColumnType("uuid")
                        .HasColumnName("subject_id");

                    b.Property<Guid>("TeacherId")
                        .HasColumnType("uuid")
                        .HasColumnName("teacher_id");

                    b.HasKey("SubjectId", "TeacherId")
                        .HasName("pk_teacher_subjects");

                    b.HasIndex("TeacherId")
                        .HasDatabaseName("ix_teacher_subjects_teacher_id");

                    b.ToTable("teacher_subjects", (string)null);
                });

            modelBuilder.Entity("EduPulse.Domain.Entities.TestEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTimeOffset>("ClosesAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("closes_at");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("uuid")
                        .HasColumnName("group_id");

                    b.Property<DateTimeOffset>("OpensAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("opens_at");

                    b.Property<TestStatus>("Status")
                        .HasColumnType("test_status")
                        .HasColumnName("status");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("pk_tests");

                    b.HasIndex("GroupId")
                        .HasDatabaseName("ix_tests_group_id");

                    b.HasIndex("Title")
                        .HasDatabaseName("ix_tests_title");

                    NpgsqlIndexBuilderExtensions.HasMethod(b.HasIndex("Title"), "btree");

                    b.ToTable("tests", (string)null);
                });

            modelBuilder.Entity("EduPulse.Domain.Entities.UserAnswerEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("CorrectValue")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("correct_value");

                    b.Property<int>("Points")
                        .HasColumnType("integer")
                        .HasColumnName("points");

                    b.Property<Guid>("QuestionId")
                        .HasColumnType("uuid")
                        .HasColumnName("question_id");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uuid")
                        .HasColumnName("student_id");

                    b.Property<Guid>("TestId")
                        .HasColumnType("uuid")
                        .HasColumnName("test_id");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("value");

                    b.HasKey("Id")
                        .HasName("pk_user_answers");

                    b.ToTable("user_answers", (string)null);
                });

            modelBuilder.Entity("EduPulse.Infrastructure.Entities.CentrifugoOutboxEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Method")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("method");

                    b.Property<int>("Partition")
                        .HasColumnType("integer")
                        .HasColumnName("partition");

                    b.Property<string>("Payload")
                        .IsRequired()
                        .HasColumnType("jsonb")
                        .HasColumnName("payload");

                    b.HasKey("Id")
                        .HasName("pk_centrifugo_outbox");

                    b.ToTable("centrifugo_outbox", null, t =>
                        {
                            t.ExcludeFromMigrations();
                        });
                });

            modelBuilder.Entity("GroupEntitySubjectEntity", b =>
                {
                    b.Property<Guid>("GroupsId")
                        .HasColumnType("uuid")
                        .HasColumnName("groups_id");

                    b.Property<Guid>("SubjectsId")
                        .HasColumnType("uuid")
                        .HasColumnName("subjects_id");

                    b.HasKey("GroupsId", "SubjectsId")
                        .HasName("pk_group_entity_subject_entity");

                    b.HasIndex("SubjectsId")
                        .HasDatabaseName("ix_group_entity_subject_entity_subjects_id");

                    b.ToTable("group_entity_subject_entity", (string)null);
                });

            modelBuilder.Entity("EduPulse.Domain.Entities.AnswerEntity", b =>
                {
                    b.HasOne("EduPulse.Domain.Entities.QuestionEntity", null)
                        .WithMany("Answers")
                        .HasForeignKey("QuestionEntityId")
                        .HasConstraintName("fk_answer_entity_question_entity_question_entity_id");
                });

            modelBuilder.Entity("EduPulse.Domain.Entities.GroupEntity", b =>
                {
                    b.HasOne("EduPulse.Domain.Entities.InstituteEntity", "Institute")
                        .WithMany()
                        .HasForeignKey("InstituteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_groups_institutes_institute_id");

                    b.Navigation("Institute");
                });

            modelBuilder.Entity("EduPulse.Domain.Entities.QuestionEntity", b =>
                {
                    b.HasOne("EduPulse.Domain.Entities.TestEntity", null)
                        .WithMany("Questions")
                        .HasForeignKey("TestEntityId")
                        .HasConstraintName("fk_question_entity_tests_test_entity_id");
                });

            modelBuilder.Entity("EduPulse.Domain.Entities.StudentEntity", b =>
                {
                    b.HasOne("EduPulse.Domain.Entities.GroupEntity", "Group")
                        .WithMany("Students")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_students_groups_group_id");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("EduPulse.Domain.Entities.TeacherGroupEntity", b =>
                {
                    b.HasOne("EduPulse.Domain.Entities.GroupEntity", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_teacher_groups_groups_group_id");

                    b.HasOne("EduPulse.Domain.Entities.TeacherEntity", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_teacher_groups_teachers_teacher_id");

                    b.Navigation("Group");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("EduPulse.Domain.Entities.TeacherSubjectEntity", b =>
                {
                    b.HasOne("EduPulse.Domain.Entities.SubjectEntity", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_teacher_subjects_subjects_subject_id");

                    b.HasOne("EduPulse.Domain.Entities.TeacherEntity", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_teacher_subjects_teachers_teacher_id");

                    b.Navigation("Subject");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("EduPulse.Domain.Entities.TestEntity", b =>
                {
                    b.HasOne("EduPulse.Domain.Entities.GroupEntity", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_tests_groups_group_id");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("GroupEntitySubjectEntity", b =>
                {
                    b.HasOne("EduPulse.Domain.Entities.GroupEntity", null)
                        .WithMany()
                        .HasForeignKey("GroupsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_group_entity_subject_entity_groups_groups_id");

                    b.HasOne("EduPulse.Domain.Entities.SubjectEntity", null)
                        .WithMany()
                        .HasForeignKey("SubjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_group_entity_subject_entity_subjects_subjects_id");
                });

            modelBuilder.Entity("EduPulse.Domain.Entities.GroupEntity", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("EduPulse.Domain.Entities.QuestionEntity", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("EduPulse.Domain.Entities.TestEntity", b =>
                {
                    b.Navigation("Questions");
                });
#pragma warning restore 612, 618
        }
    }
}
