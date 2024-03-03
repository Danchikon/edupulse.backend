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
                    teacher_id = table.Column<Guid>(type: "uuid", nullable: false),
                    groups_id = table.Column<Guid>(type: "uuid", nullable: false),
                    group_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_teacher_groups", x => new { x.groups_id, x.teacher_id });
                    table.ForeignKey(
                        name: "fk_teacher_groups_groups_groups_id",
                        column: x => x.groups_id,
                        principalTable: "groups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_teacher_groups_subjects_group_id",
                        column: x => x.group_id,
                        principalTable: "subjects",
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
                    { new Guid("001e781e-deae-479d-ac8a-589fb3144cde"), "КНІ", "Комп'ютерних наук та інформаційних технологій" },
                    { new Guid("0fe6ed77-682c-4d67-affc-19d8998fbc3b"), "ІКТА", "Комп'ютерних технологій, автоматики та метрології інститут" },
                    { new Guid("1b9eec26-df7d-497f-b421-436173c116ed"), "ІНЕМ", "Економіки і менеджменту інститут" },
                    { new Guid("234cbd67-3de3-4481-934a-bc02546575d7"), "ІГСН", "Гуманітарних та соціальних наук інститут" },
                    { new Guid("28139249-e9d8-42c7-80d3-c92e239e41bc"), "ІГДГ", "Геодезії інститут" },
                    { new Guid("3700d110-c1f2-40b1-b4c2-1d3633a6419e"), "ІАРД", "Архітектури та дизайну інститут" },
                    { new Guid("40ce2ccb-e0da-4a8e-80a1-f2cf5d324739"), "ІППО", "Права, психології та інноваційної освіти інститут" },
                    { new Guid("5735002f-87eb-4615-bc0b-e707307ac782"), "ІППТ", "Просторового планування та перспективних технологій інститут" },
                    { new Guid("5b13f774-3097-47e2-bbec-fb97bda64995"), "ІХХТ", "Хімії та хімічних технологій інститут" },
                    { new Guid("5be2eedb-52f5-49ff-852f-7af9b64116f1"), "ІДА", "Адміністрування, державного управління та професійного розвитку інститут" },
                    { new Guid("817dce9c-ff78-477b-8cea-4d2d7fa7fff4"), "ІТРЕ", "Телекомунікацій, радіоелектроніки та електронної техніки інститут" },
                    { new Guid("8d26d7a0-9e42-4e49-99a4-cd9fd0f6ca45"), "ІМФН", "Прикладної математики та фундаментальних наук інститут" },
                    { new Guid("b1a1c978-62c9-4629-bb59-75a2c585ba4c"), "ІЕСК", "Енергетики та систем керування інститут" },
                    { new Guid("b3441ade-2df3-47df-9015-c4d629339b9d"), "ІСТР", "Сталого розвитку і ім. В.Чорновола інститут" },
                    { new Guid("d228800c-170d-4db8-b3a1-03771990b950"), "ІБІС", "Будівництва та інженерних систем інститут" },
                    { new Guid("f0ab9474-cb0f-4361-84d9-1c7fdca0770c"), "ІМІТ", "Механічної інженерії та транспорту інститут" }
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
                name: "ix_teacher_groups_group_id",
                table: "teacher_groups",
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
