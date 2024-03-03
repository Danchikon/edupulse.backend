using System;
using EduPulse.Domain.Enums;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EduPulse.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:test_status", "scheduled,opened,closed");

            migrationBuilder.CreateTable(
                name: "institutes",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    code = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_institutes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "subjects",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_subjects", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "teachers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    full_name = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    password_hash = table.Column<string>(type: "text", nullable: false),
                    avatar = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_teachers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tests",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    status = table.Column<TestStatus>(type: "test_status", nullable: false),
                    opens_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    closes_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tests", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "groups",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    institute_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_groups", x => x.id);
                    table.ForeignKey(
                        name: "fk_groups_institutes_institute_id",
                        column: x => x.institute_id,
                        principalTable: "institutes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "teacher_subjects",
                columns: table => new
                {
                    subject_id = table.Column<Guid>(type: "uuid", nullable: false),
                    teacher_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_teacher_subjects", x => new { x.subject_id, x.teacher_id });
                    table.ForeignKey(
                        name: "fk_teacher_subjects_subjects_subject_id",
                        column: x => x.subject_id,
                        principalTable: "subjects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_teacher_subjects_teachers_teacher_id",
                        column: x => x.teacher_id,
                        principalTable: "teachers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "question_entity",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    correct_answer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    test_entity_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_question_entity", x => x.id);
                    table.ForeignKey(
                        name: "fk_question_entity_tests_test_entity_id",
                        column: x => x.test_entity_id,
                        principalTable: "tests",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "group_entity_subject_entity",
                columns: table => new
                {
                    groups_id = table.Column<Guid>(type: "uuid", nullable: false),
                    subjects_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_group_entity_subject_entity", x => new { x.groups_id, x.subjects_id });
                    table.ForeignKey(
                        name: "fk_group_entity_subject_entity_groups_groups_id",
                        column: x => x.groups_id,
                        principalTable: "groups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_group_entity_subject_entity_subjects_subjects_id",
                        column: x => x.subjects_id,
                        principalTable: "subjects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    phone_number = table.Column<string>(type: "text", nullable: false),
                    full_name = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    age = table.Column<int>(type: "integer", nullable: false),
                    password_hash = table.Column<string>(type: "text", nullable: false),
                    avatar = table.Column<string>(type: "text", nullable: true),
                    group_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_students", x => x.id);
                    table.ForeignKey(
                        name: "fk_students_groups_group_id",
                        column: x => x.group_id,
                        principalTable: "groups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "teacher_groups",
                columns: table => new
                {
                    group_id = table.Column<Guid>(type: "uuid", nullable: false),
                    teacher_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_teacher_groups", x => new { x.group_id, x.teacher_id });
                    table.ForeignKey(
                        name: "fk_teacher_groups_groups_group_id",
                        column: x => x.group_id,
                        principalTable: "groups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_teacher_groups_teachers_teacher_id",
                        column: x => x.teacher_id,
                        principalTable: "teachers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "answer_entity",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    value = table.Column<string>(type: "text", nullable: false),
                    question_entity_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_answer_entity", x => x.id);
                    table.ForeignKey(
                        name: "fk_answer_entity_question_entity_question_entity_id",
                        column: x => x.question_entity_id,
                        principalTable: "question_entity",
                        principalColumn: "id");
                });

            migrationBuilder.InsertData(
                table: "institutes",
                columns: new[] { "id", "code", "title" },
                values: new object[,]
                {
                    { new Guid("17f2161b-eb53-4314-b32a-4a489c788b44"), "ІППТ", "Просторового планування та перспективних технологій інститут" },
                    { new Guid("1e992a4d-9dec-4576-93a8-2dc038e916ce"), "КНІ", "Комп'ютерних наук та інформаційних технологій" },
                    { new Guid("23c3d117-b0bd-44ac-b79f-9f881260537c"), "ІХХТ", "Хімії та хімічних технологій інститут" },
                    { new Guid("4930041c-ce0e-4b59-9caf-938e2afbe84c"), "ІНЕМ", "Економіки і менеджменту інститут" },
                    { new Guid("4d0fb2a3-5c2d-48af-93a5-c585536bb9ae"), "ІЕСК", "Енергетики та систем керування інститут" },
                    { new Guid("54880322-70f3-4373-96e4-fbc92020d4d1"), "ІТРЕ", "Телекомунікацій, радіоелектроніки та електронної техніки інститут" },
                    { new Guid("5c2d66d6-4018-4daf-a8c1-1d784d2ffcc1"), "ІМІТ", "Механічної інженерії та транспорту інститут" },
                    { new Guid("5fb0be5a-bb70-472d-b9e4-a24cc867b853"), "ІМФН", "Прикладної математики та фундаментальних наук інститут" },
                    { new Guid("64ce574c-b23d-4571-b445-16675e98edd7"), "ІГСН", "Гуманітарних та соціальних наук інститут" },
                    { new Guid("6a3e53f5-ae3b-4a92-8167-7e3ffb643c9b"), "ІАРД", "Архітектури та дизайну інститут" },
                    { new Guid("77c0eead-3166-4813-8205-4f8168136882"), "ІСТР", "Сталого розвитку і ім. В.Чорновола інститут" },
                    { new Guid("838188cd-c3e1-44ba-aadc-7161e9559ef6"), "ІППО", "Права, психології та інноваційної освіти інститут" },
                    { new Guid("a3123b16-be65-405e-b1c4-3b1969e80988"), "ІГДГ", "Геодезії інститут" },
                    { new Guid("bf0ea459-1011-49e6-bc65-0ebd9e5f8b0c"), "ІКТА", "Комп'ютерних технологій, автоматики та метрології інститут" },
                    { new Guid("db7c95a1-b470-4a7d-8a01-a2e944dee190"), "ІБІС", "Будівництва та інженерних систем інститут" },
                    { new Guid("ea358f17-8bf4-40d0-8012-a53e58539e76"), "ІДА", "Адміністрування, державного управління та професійного розвитку інститут" }
                });

            migrationBuilder.CreateIndex(
                name: "ix_answer_entity_question_entity_id",
                table: "answer_entity",
                column: "question_entity_id");

            migrationBuilder.CreateIndex(
                name: "ix_group_entity_subject_entity_subjects_id",
                table: "group_entity_subject_entity",
                column: "subjects_id");

            migrationBuilder.CreateIndex(
                name: "ix_groups_institute_id",
                table: "groups",
                column: "institute_id");

            migrationBuilder.CreateIndex(
                name: "ix_groups_title",
                table: "groups",
                column: "title")
                .Annotation("Npgsql:IndexMethod", "btree");

            migrationBuilder.CreateIndex(
                name: "ix_question_entity_test_entity_id",
                table: "question_entity",
                column: "test_entity_id");

            migrationBuilder.CreateIndex(
                name: "ix_students_email",
                table: "students",
                column: "email")
                .Annotation("Npgsql:IndexMethod", "btree");

            migrationBuilder.CreateIndex(
                name: "ix_students_full_name",
                table: "students",
                column: "full_name")
                .Annotation("Npgsql:IndexMethod", "btree");

            migrationBuilder.CreateIndex(
                name: "ix_students_group_id",
                table: "students",
                column: "group_id");

            migrationBuilder.CreateIndex(
                name: "ix_teacher_groups_teacher_id",
                table: "teacher_groups",
                column: "teacher_id");

            migrationBuilder.CreateIndex(
                name: "ix_teacher_subjects_teacher_id",
                table: "teacher_subjects",
                column: "teacher_id");

            migrationBuilder.CreateIndex(
                name: "ix_tests_title",
                table: "tests",
                column: "title")
                .Annotation("Npgsql:IndexMethod", "btree");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "answer_entity");

            migrationBuilder.DropTable(
                name: "group_entity_subject_entity");

            migrationBuilder.DropTable(
                name: "students");

            migrationBuilder.DropTable(
                name: "teacher_groups");

            migrationBuilder.DropTable(
                name: "teacher_subjects");

            migrationBuilder.DropTable(
                name: "question_entity");

            migrationBuilder.DropTable(
                name: "groups");

            migrationBuilder.DropTable(
                name: "subjects");

            migrationBuilder.DropTable(
                name: "teachers");

            migrationBuilder.DropTable(
                name: "tests");

            migrationBuilder.DropTable(
                name: "institutes");
        }
    }
}
