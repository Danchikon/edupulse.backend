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
                .Annotation("Npgsql:Enum:test_status", "scheduled,opened,closed")
                .Annotation("Npgsql:Enum:user_role", "teacher,student,admin");

            migrationBuilder.CreateTable(
                name: "institute_entity",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    code = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_institute_entity", x => x.id);
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
                name: "teacher_entity",
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
                    table.PrimaryKey("pk_teacher_entity", x => x.id);
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
                        name: "fk_groups_institute_entity_institute_id",
                        column: x => x.institute_id,
                        principalTable: "institute_entity",
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
                name: "group_entity_teacher_entity",
                columns: table => new
                {
                    groups_id = table.Column<Guid>(type: "uuid", nullable: false),
                    teachers_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_group_entity_teacher_entity", x => new { x.groups_id, x.teachers_id });
                    table.ForeignKey(
                        name: "fk_group_entity_teacher_entity_groups_groups_id",
                        column: x => x.groups_id,
                        principalTable: "groups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_group_entity_teacher_entity_teacher_entity_teachers_id",
                        column: x => x.teachers_id,
                        principalTable: "teacher_entity",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "student_entity",
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
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    subject_entity_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_student_entity", x => x.id);
                    table.ForeignKey(
                        name: "fk_student_entity_groups_group_id",
                        column: x => x.group_id,
                        principalTable: "groups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_student_entity_subjects_subject_entity_id",
                        column: x => x.subject_entity_id,
                        principalTable: "subjects",
                        principalColumn: "id");
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
                table: "institute_entity",
                columns: new[] { "id", "code", "title" },
                values: new object[,]
                {
                    { new Guid("059d4814-e8f2-4c98-ac66-6b21ce3407e6"), "ІГДГ", "Геодезії інститут" },
                    { new Guid("1a49ef55-9824-40df-927c-b2f2f96d56bc"), "ІГСН", "Гуманітарних та соціальних наук інститут" },
                    { new Guid("39d911b9-970a-4a20-9d42-74ecdef1c1d4"), "ІХХТ", "Хімії та хімічних технологій інститут" },
                    { new Guid("43165619-9640-48b5-9f3d-476bd64d7c1d"), "ІКТА", "Комп'ютерних технологій, автоматики та метрології інститут" },
                    { new Guid("46dae0eb-5f4a-4718-840c-728014a37353"), "КНІ", "Комп'ютерних наук та інформаційних технологій" },
                    { new Guid("52f20b63-9e43-4f67-8eb6-f4ef66fb871a"), "ІППО", "Права, психології та інноваційної освіти інститут" },
                    { new Guid("5993931a-076b-4875-9b3a-7a4ae7f70a6d"), "ІАРД", "Архітектури та дизайну інститут" },
                    { new Guid("60a3ba75-76af-469a-b2fb-e5d49d6ba361"), "ІСТР", "Сталого розвитку і ім. В.Чорновола інститут" },
                    { new Guid("6a2495fe-d488-4ee7-bc20-c5ea3ef44a62"), "ІТРЕ", "Телекомунікацій, радіоелектроніки та електронної техніки інститут" },
                    { new Guid("72e38a8c-08ee-4f33-95e6-8a260b32d969"), "ІППТ", "Просторового планування та перспективних технологій інститут" },
                    { new Guid("7ba9ee63-aaf3-437c-82c7-a0196997ed22"), "ІНЕМ", "Економіки і менеджменту інститут" },
                    { new Guid("9c220bb9-b849-4345-b899-f8cb0eb5dc95"), "ІДА", "Адміністрування, державного управління та професійного розвитку інститут" },
                    { new Guid("a1b14a4b-ac2f-4db0-9623-202f4e3ebc1b"), "ІЕСК", "Енергетики та систем керування інститут" },
                    { new Guid("a72e9338-54e8-41f4-b54b-3c09fdfb2e05"), "ІБІС", "Будівництва та інженерних систем інститут" },
                    { new Guid("c1fbfd2d-7118-4c8d-a95d-518001a217b7"), "ІМФН", "Прикладної математики та фундаментальних наук інститут" },
                    { new Guid("fb2f72f6-7a78-4f30-9560-3705dede7180"), "ІМІТ", "Механічної інженерії та транспорту інститут" }
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
                name: "ix_group_entity_teacher_entity_teachers_id",
                table: "group_entity_teacher_entity",
                column: "teachers_id");

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
                name: "ix_student_entity_email",
                table: "student_entity",
                column: "email")
                .Annotation("Npgsql:IndexMethod", "btree");

            migrationBuilder.CreateIndex(
                name: "ix_student_entity_full_name",
                table: "student_entity",
                column: "full_name")
                .Annotation("Npgsql:IndexMethod", "btree");

            migrationBuilder.CreateIndex(
                name: "ix_student_entity_group_id",
                table: "student_entity",
                column: "group_id");

            migrationBuilder.CreateIndex(
                name: "ix_student_entity_subject_entity_id",
                table: "student_entity",
                column: "subject_entity_id");

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
                name: "group_entity_teacher_entity");

            migrationBuilder.DropTable(
                name: "student_entity");

            migrationBuilder.DropTable(
                name: "question_entity");

            migrationBuilder.DropTable(
                name: "teacher_entity");

            migrationBuilder.DropTable(
                name: "groups");

            migrationBuilder.DropTable(
                name: "subjects");

            migrationBuilder.DropTable(
                name: "tests");

            migrationBuilder.DropTable(
                name: "institute_entity");
        }
    }
}
