using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EduPulse.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Teachers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_group_entity_teacher_entity_teacher_entity_teachers_id",
                table: "group_entity_teacher_entity");

            migrationBuilder.DropPrimaryKey(
                name: "pk_teacher_entity",
                table: "teacher_entity");

            migrationBuilder.DeleteData(
                table: "institute_entity",
                keyColumn: "id",
                keyValue: new Guid("059d4814-e8f2-4c98-ac66-6b21ce3407e6"));

            migrationBuilder.DeleteData(
                table: "institute_entity",
                keyColumn: "id",
                keyValue: new Guid("1a49ef55-9824-40df-927c-b2f2f96d56bc"));

            migrationBuilder.DeleteData(
                table: "institute_entity",
                keyColumn: "id",
                keyValue: new Guid("39d911b9-970a-4a20-9d42-74ecdef1c1d4"));

            migrationBuilder.DeleteData(
                table: "institute_entity",
                keyColumn: "id",
                keyValue: new Guid("43165619-9640-48b5-9f3d-476bd64d7c1d"));

            migrationBuilder.DeleteData(
                table: "institute_entity",
                keyColumn: "id",
                keyValue: new Guid("46dae0eb-5f4a-4718-840c-728014a37353"));

            migrationBuilder.DeleteData(
                table: "institute_entity",
                keyColumn: "id",
                keyValue: new Guid("52f20b63-9e43-4f67-8eb6-f4ef66fb871a"));

            migrationBuilder.DeleteData(
                table: "institute_entity",
                keyColumn: "id",
                keyValue: new Guid("5993931a-076b-4875-9b3a-7a4ae7f70a6d"));

            migrationBuilder.DeleteData(
                table: "institute_entity",
                keyColumn: "id",
                keyValue: new Guid("60a3ba75-76af-469a-b2fb-e5d49d6ba361"));

            migrationBuilder.DeleteData(
                table: "institute_entity",
                keyColumn: "id",
                keyValue: new Guid("6a2495fe-d488-4ee7-bc20-c5ea3ef44a62"));

            migrationBuilder.DeleteData(
                table: "institute_entity",
                keyColumn: "id",
                keyValue: new Guid("72e38a8c-08ee-4f33-95e6-8a260b32d969"));

            migrationBuilder.DeleteData(
                table: "institute_entity",
                keyColumn: "id",
                keyValue: new Guid("7ba9ee63-aaf3-437c-82c7-a0196997ed22"));

            migrationBuilder.DeleteData(
                table: "institute_entity",
                keyColumn: "id",
                keyValue: new Guid("9c220bb9-b849-4345-b899-f8cb0eb5dc95"));

            migrationBuilder.DeleteData(
                table: "institute_entity",
                keyColumn: "id",
                keyValue: new Guid("a1b14a4b-ac2f-4db0-9623-202f4e3ebc1b"));

            migrationBuilder.DeleteData(
                table: "institute_entity",
                keyColumn: "id",
                keyValue: new Guid("a72e9338-54e8-41f4-b54b-3c09fdfb2e05"));

            migrationBuilder.DeleteData(
                table: "institute_entity",
                keyColumn: "id",
                keyValue: new Guid("c1fbfd2d-7118-4c8d-a95d-518001a217b7"));

            migrationBuilder.DeleteData(
                table: "institute_entity",
                keyColumn: "id",
                keyValue: new Guid("fb2f72f6-7a78-4f30-9560-3705dede7180"));

            migrationBuilder.RenameTable(
                name: "teacher_entity",
                newName: "teachers");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:test_status", "scheduled,opened,closed")
                .OldAnnotation("Npgsql:Enum:test_status", "scheduled,opened,closed")
                .OldAnnotation("Npgsql:Enum:user_role", "teacher,student,admin");

            migrationBuilder.AddPrimaryKey(
                name: "pk_teachers",
                table: "teachers",
                column: "id");

            migrationBuilder.InsertData(
                table: "institute_entity",
                columns: new[] { "id", "code", "title" },
                values: new object[,]
                {
                    { new Guid("11b429a9-0c4e-439a-8e1f-29050711b834"), "ІЕСК", "Енергетики та систем керування інститут" },
                    { new Guid("18145af2-be3c-4aa5-bd4f-5a03a81c0a0d"), "ІППТ", "Просторового планування та перспективних технологій інститут" },
                    { new Guid("19fba6ad-4004-4473-8eb0-a732ec74f37a"), "ІБІС", "Будівництва та інженерних систем інститут" },
                    { new Guid("21d23eeb-211c-448d-a579-e3d9c27c3993"), "КНІ", "Комп'ютерних наук та інформаційних технологій" },
                    { new Guid("25ec0c5a-83b0-445b-9d74-be8dc9d09be3"), "ІАРД", "Архітектури та дизайну інститут" },
                    { new Guid("3bfb8b21-5d35-4e79-933d-3aa43bd60f84"), "ІКТА", "Комп'ютерних технологій, автоматики та метрології інститут" },
                    { new Guid("486e68b1-f5bd-4883-a554-302875122f23"), "ІППО", "Права, психології та інноваційної освіти інститут" },
                    { new Guid("6a59cc1f-62b8-412e-a81e-99b803680faa"), "ІГДГ", "Геодезії інститут" },
                    { new Guid("7a8b43b9-ef9f-4f76-a9a0-98fbb01f8081"), "ІМФН", "Прикладної математики та фундаментальних наук інститут" },
                    { new Guid("7da3338c-b618-4ad0-919c-b8699a8c0c49"), "ІТРЕ", "Телекомунікацій, радіоелектроніки та електронної техніки інститут" },
                    { new Guid("94bc1a39-9a8a-4af8-b683-4eb50fa2a29c"), "ІДА", "Адміністрування, державного управління та професійного розвитку інститут" },
                    { new Guid("94c45bb7-6185-4cb2-a487-ee183e42d947"), "ІСТР", "Сталого розвитку і ім. В.Чорновола інститут" },
                    { new Guid("94f10cc4-14de-4f78-82f0-0bac3b132fb7"), "ІМІТ", "Механічної інженерії та транспорту інститут" },
                    { new Guid("a4836b32-047c-4458-88ab-0ea487fb6133"), "ІНЕМ", "Економіки і менеджменту інститут" },
                    { new Guid("c003fabc-36d6-41bc-a51d-dc757ab3fd31"), "ІГСН", "Гуманітарних та соціальних наук інститут" },
                    { new Guid("fd644263-a201-4577-ab89-7ae92d4ad73e"), "ІХХТ", "Хімії та хімічних технологій інститут" }
                });

            migrationBuilder.AddForeignKey(
                name: "fk_group_entity_teacher_entity_teachers_teachers_id",
                table: "group_entity_teacher_entity",
                column: "teachers_id",
                principalTable: "teachers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_group_entity_teacher_entity_teachers_teachers_id",
                table: "group_entity_teacher_entity");

            migrationBuilder.DropPrimaryKey(
                name: "pk_teachers",
                table: "teachers");

            migrationBuilder.DeleteData(
                table: "institute_entity",
                keyColumn: "id",
                keyValue: new Guid("11b429a9-0c4e-439a-8e1f-29050711b834"));

            migrationBuilder.DeleteData(
                table: "institute_entity",
                keyColumn: "id",
                keyValue: new Guid("18145af2-be3c-4aa5-bd4f-5a03a81c0a0d"));

            migrationBuilder.DeleteData(
                table: "institute_entity",
                keyColumn: "id",
                keyValue: new Guid("19fba6ad-4004-4473-8eb0-a732ec74f37a"));

            migrationBuilder.DeleteData(
                table: "institute_entity",
                keyColumn: "id",
                keyValue: new Guid("21d23eeb-211c-448d-a579-e3d9c27c3993"));

            migrationBuilder.DeleteData(
                table: "institute_entity",
                keyColumn: "id",
                keyValue: new Guid("25ec0c5a-83b0-445b-9d74-be8dc9d09be3"));

            migrationBuilder.DeleteData(
                table: "institute_entity",
                keyColumn: "id",
                keyValue: new Guid("3bfb8b21-5d35-4e79-933d-3aa43bd60f84"));

            migrationBuilder.DeleteData(
                table: "institute_entity",
                keyColumn: "id",
                keyValue: new Guid("486e68b1-f5bd-4883-a554-302875122f23"));

            migrationBuilder.DeleteData(
                table: "institute_entity",
                keyColumn: "id",
                keyValue: new Guid("6a59cc1f-62b8-412e-a81e-99b803680faa"));

            migrationBuilder.DeleteData(
                table: "institute_entity",
                keyColumn: "id",
                keyValue: new Guid("7a8b43b9-ef9f-4f76-a9a0-98fbb01f8081"));

            migrationBuilder.DeleteData(
                table: "institute_entity",
                keyColumn: "id",
                keyValue: new Guid("7da3338c-b618-4ad0-919c-b8699a8c0c49"));

            migrationBuilder.DeleteData(
                table: "institute_entity",
                keyColumn: "id",
                keyValue: new Guid("94bc1a39-9a8a-4af8-b683-4eb50fa2a29c"));

            migrationBuilder.DeleteData(
                table: "institute_entity",
                keyColumn: "id",
                keyValue: new Guid("94c45bb7-6185-4cb2-a487-ee183e42d947"));

            migrationBuilder.DeleteData(
                table: "institute_entity",
                keyColumn: "id",
                keyValue: new Guid("94f10cc4-14de-4f78-82f0-0bac3b132fb7"));

            migrationBuilder.DeleteData(
                table: "institute_entity",
                keyColumn: "id",
                keyValue: new Guid("a4836b32-047c-4458-88ab-0ea487fb6133"));

            migrationBuilder.DeleteData(
                table: "institute_entity",
                keyColumn: "id",
                keyValue: new Guid("c003fabc-36d6-41bc-a51d-dc757ab3fd31"));

            migrationBuilder.DeleteData(
                table: "institute_entity",
                keyColumn: "id",
                keyValue: new Guid("fd644263-a201-4577-ab89-7ae92d4ad73e"));

            migrationBuilder.RenameTable(
                name: "teachers",
                newName: "teacher_entity");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:test_status", "scheduled,opened,closed")
                .Annotation("Npgsql:Enum:user_role", "teacher,student,admin")
                .OldAnnotation("Npgsql:Enum:test_status", "scheduled,opened,closed");

            migrationBuilder.AddPrimaryKey(
                name: "pk_teacher_entity",
                table: "teacher_entity",
                column: "id");

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

            migrationBuilder.AddForeignKey(
                name: "fk_group_entity_teacher_entity_teacher_entity_teachers_id",
                table: "group_entity_teacher_entity",
                column: "teachers_id",
                principalTable: "teacher_entity",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
