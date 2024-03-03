using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EduPulse.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class TeacherSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "institutes",
                keyColumn: "id",
                keyValue: new Guid("00c396d4-5338-4ea8-ba9d-483af0deecaa"));

            migrationBuilder.DeleteData(
                table: "institutes",
                keyColumn: "id",
                keyValue: new Guid("2032d6dc-4c57-4088-a689-57798ab2efd6"));

            migrationBuilder.DeleteData(
                table: "institutes",
                keyColumn: "id",
                keyValue: new Guid("32c1b447-499c-4273-a1e2-23c0ee105778"));

            migrationBuilder.DeleteData(
                table: "institutes",
                keyColumn: "id",
                keyValue: new Guid("45570d7f-2761-4267-a791-87ed507ba92d"));

            migrationBuilder.DeleteData(
                table: "institutes",
                keyColumn: "id",
                keyValue: new Guid("61c6bf2c-c3aa-411e-b56a-23d9b5474926"));

            migrationBuilder.DeleteData(
                table: "institutes",
                keyColumn: "id",
                keyValue: new Guid("7e3471f0-acd8-4071-bc66-42af7652e458"));

            migrationBuilder.DeleteData(
                table: "institutes",
                keyColumn: "id",
                keyValue: new Guid("7fd7e4b6-97f3-4af6-ab23-63f5a5fba61e"));

            migrationBuilder.DeleteData(
                table: "institutes",
                keyColumn: "id",
                keyValue: new Guid("87a2be5d-3f14-4e90-8845-5e208032f610"));

            migrationBuilder.DeleteData(
                table: "institutes",
                keyColumn: "id",
                keyValue: new Guid("9853ac32-cb2b-441e-b7f5-92985fbcca88"));

            migrationBuilder.DeleteData(
                table: "institutes",
                keyColumn: "id",
                keyValue: new Guid("b2a2321c-105e-4bf1-b9bd-79c1cfa5a46a"));

            migrationBuilder.DeleteData(
                table: "institutes",
                keyColumn: "id",
                keyValue: new Guid("c2ab88f6-c31c-46e0-916b-0ce6635a3dc5"));

            migrationBuilder.DeleteData(
                table: "institutes",
                keyColumn: "id",
                keyValue: new Guid("c4005fd9-f65f-4c67-9120-6db8f7447b88"));

            migrationBuilder.DeleteData(
                table: "institutes",
                keyColumn: "id",
                keyValue: new Guid("d202e245-7605-4e3c-9119-04bb78f0e20c"));

            migrationBuilder.DeleteData(
                table: "institutes",
                keyColumn: "id",
                keyValue: new Guid("e565ea93-708b-4697-aef8-75f71e31fa65"));

            migrationBuilder.DeleteData(
                table: "institutes",
                keyColumn: "id",
                keyValue: new Guid("e7c5fded-c2d9-438d-b03c-1fd9b4e91169"));

            migrationBuilder.DeleteData(
                table: "institutes",
                keyColumn: "id",
                keyValue: new Guid("fca0e19a-7987-4f47-92b8-a93798e35623"));

            migrationBuilder.InsertData(
                table: "institutes",
                columns: new[] { "id", "code", "title" },
                values: new object[,]
                {
                    { new Guid("3e9ebd2c-c992-4f56-8292-5402bd9d5a03"), "ІНЕМ", "Економіки і менеджменту інститут" },
                    { new Guid("426aaec1-2265-41b3-90f8-350051e3af2d"), "ІППТ", "Просторового планування та перспективних технологій інститут" },
                    { new Guid("453d2d2a-e500-4b12-a7dc-0c91b9ac5b3d"), "ІКТА", "Комп'ютерних технологій, автоматики та метрології інститут" },
                    { new Guid("49a1ee2e-bfb3-464a-b5e7-13747a9411cb"), "КНІ", "Комп'ютерних наук та інформаційних технологій" },
                    { new Guid("4cdc205d-af15-45aa-8f6f-737cc74c9959"), "ІБІС", "Будівництва та інженерних систем інститут" },
                    { new Guid("6938cc71-84db-4b2b-9cc0-220f00000a83"), "ІСТР", "Сталого розвитку і ім. В.Чорновола інститут" },
                    { new Guid("6ff00f2d-d08a-48dc-bc2e-7af5ce46ebdd"), "ІППО", "Права, психології та інноваційної освіти інститут" },
                    { new Guid("7d99ecfd-1eb8-470d-9812-19ba0673149b"), "ІЕСК", "Енергетики та систем керування інститут" },
                    { new Guid("c6f8a182-e442-430c-97ac-73b59ed47d40"), "ІМІТ", "Механічної інженерії та транспорту інститут" },
                    { new Guid("c75455eb-90a1-462e-99c0-4d3810815b98"), "ІДА", "Адміністрування, державного управління та професійного розвитку інститут" },
                    { new Guid("d885527d-246b-452a-b3be-a49deacbcfd5"), "ІАРД", "Архітектури та дизайну інститут" },
                    { new Guid("e58765b1-10b3-4524-9776-0d28119ad3e2"), "ІХХТ", "Хімії та хімічних технологій інститут" },
                    { new Guid("ed164c5f-62f0-4211-8d10-969cf768e182"), "ІГСН", "Гуманітарних та соціальних наук інститут" },
                    { new Guid("f41e1c0f-21b4-4e8d-93c6-1076cb6a2634"), "ІГДГ", "Геодезії інститут" },
                    { new Guid("f8f3ae00-bd14-477c-96b9-ec3af790bb26"), "ІТРЕ", "Телекомунікацій, радіоелектроніки та електронної техніки інститут" },
                    { new Guid("fec6e117-3a45-4cfb-8031-688f3210a101"), "ІМФН", "Прикладної математики та фундаментальних наук інститут" }
                });

            migrationBuilder.InsertData(
                table: "teachers",
                columns: new[] { "id", "avatar", "created_at", "email", "full_name", "password_hash" },
                values: new object[] { new Guid("af41f834-c0f9-46be-89bf-51708b4adec9"), null, new DateTimeOffset(new DateTime(2024, 3, 3, 6, 17, 4, 421, DateTimeKind.Unspecified).AddTicks(536), new TimeSpan(0, 0, 0, 0, 0)), "daniel.hrovinsky@gmail.com", "Daniel Hrovinsky", "thj3yNIF3ZKC1UziLTuSh7CsSUTT/yR1nvu83Fx9oek=" });

            migrationBuilder.CreateIndex(
                name: "ix_tests_group_id",
                table: "tests",
                column: "group_id");

            migrationBuilder.AddForeignKey(
                name: "fk_tests_groups_group_id",
                table: "tests",
                column: "group_id",
                principalTable: "groups",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_tests_groups_group_id",
                table: "tests");

            migrationBuilder.DropIndex(
                name: "ix_tests_group_id",
                table: "tests");

            migrationBuilder.DeleteData(
                table: "institutes",
                keyColumn: "id",
                keyValue: new Guid("3e9ebd2c-c992-4f56-8292-5402bd9d5a03"));

            migrationBuilder.DeleteData(
                table: "institutes",
                keyColumn: "id",
                keyValue: new Guid("426aaec1-2265-41b3-90f8-350051e3af2d"));

            migrationBuilder.DeleteData(
                table: "institutes",
                keyColumn: "id",
                keyValue: new Guid("453d2d2a-e500-4b12-a7dc-0c91b9ac5b3d"));

            migrationBuilder.DeleteData(
                table: "institutes",
                keyColumn: "id",
                keyValue: new Guid("49a1ee2e-bfb3-464a-b5e7-13747a9411cb"));

            migrationBuilder.DeleteData(
                table: "institutes",
                keyColumn: "id",
                keyValue: new Guid("4cdc205d-af15-45aa-8f6f-737cc74c9959"));

            migrationBuilder.DeleteData(
                table: "institutes",
                keyColumn: "id",
                keyValue: new Guid("6938cc71-84db-4b2b-9cc0-220f00000a83"));

            migrationBuilder.DeleteData(
                table: "institutes",
                keyColumn: "id",
                keyValue: new Guid("6ff00f2d-d08a-48dc-bc2e-7af5ce46ebdd"));

            migrationBuilder.DeleteData(
                table: "institutes",
                keyColumn: "id",
                keyValue: new Guid("7d99ecfd-1eb8-470d-9812-19ba0673149b"));

            migrationBuilder.DeleteData(
                table: "institutes",
                keyColumn: "id",
                keyValue: new Guid("c6f8a182-e442-430c-97ac-73b59ed47d40"));

            migrationBuilder.DeleteData(
                table: "institutes",
                keyColumn: "id",
                keyValue: new Guid("c75455eb-90a1-462e-99c0-4d3810815b98"));

            migrationBuilder.DeleteData(
                table: "institutes",
                keyColumn: "id",
                keyValue: new Guid("d885527d-246b-452a-b3be-a49deacbcfd5"));

            migrationBuilder.DeleteData(
                table: "institutes",
                keyColumn: "id",
                keyValue: new Guid("e58765b1-10b3-4524-9776-0d28119ad3e2"));

            migrationBuilder.DeleteData(
                table: "institutes",
                keyColumn: "id",
                keyValue: new Guid("ed164c5f-62f0-4211-8d10-969cf768e182"));

            migrationBuilder.DeleteData(
                table: "institutes",
                keyColumn: "id",
                keyValue: new Guid("f41e1c0f-21b4-4e8d-93c6-1076cb6a2634"));

            migrationBuilder.DeleteData(
                table: "institutes",
                keyColumn: "id",
                keyValue: new Guid("f8f3ae00-bd14-477c-96b9-ec3af790bb26"));

            migrationBuilder.DeleteData(
                table: "institutes",
                keyColumn: "id",
                keyValue: new Guid("fec6e117-3a45-4cfb-8031-688f3210a101"));

            migrationBuilder.DeleteData(
                table: "teachers",
                keyColumn: "id",
                keyValue: new Guid("af41f834-c0f9-46be-89bf-51708b4adec9"));

            migrationBuilder.InsertData(
                table: "institutes",
                columns: new[] { "id", "code", "title" },
                values: new object[,]
                {
                    { new Guid("00c396d4-5338-4ea8-ba9d-483af0deecaa"), "ІБІС", "Будівництва та інженерних систем інститут" },
                    { new Guid("2032d6dc-4c57-4088-a689-57798ab2efd6"), "ІППТ", "Просторового планування та перспективних технологій інститут" },
                    { new Guid("32c1b447-499c-4273-a1e2-23c0ee105778"), "ІТРЕ", "Телекомунікацій, радіоелектроніки та електронної техніки інститут" },
                    { new Guid("45570d7f-2761-4267-a791-87ed507ba92d"), "ІНЕМ", "Економіки і менеджменту інститут" },
                    { new Guid("61c6bf2c-c3aa-411e-b56a-23d9b5474926"), "ІХХТ", "Хімії та хімічних технологій інститут" },
                    { new Guid("7e3471f0-acd8-4071-bc66-42af7652e458"), "ІДА", "Адміністрування, державного управління та професійного розвитку інститут" },
                    { new Guid("7fd7e4b6-97f3-4af6-ab23-63f5a5fba61e"), "ІЕСК", "Енергетики та систем керування інститут" },
                    { new Guid("87a2be5d-3f14-4e90-8845-5e208032f610"), "ІГДГ", "Геодезії інститут" },
                    { new Guid("9853ac32-cb2b-441e-b7f5-92985fbcca88"), "КНІ", "Комп'ютерних наук та інформаційних технологій" },
                    { new Guid("b2a2321c-105e-4bf1-b9bd-79c1cfa5a46a"), "ІППО", "Права, психології та інноваційної освіти інститут" },
                    { new Guid("c2ab88f6-c31c-46e0-916b-0ce6635a3dc5"), "ІАРД", "Архітектури та дизайну інститут" },
                    { new Guid("c4005fd9-f65f-4c67-9120-6db8f7447b88"), "ІКТА", "Комп'ютерних технологій, автоматики та метрології інститут" },
                    { new Guid("d202e245-7605-4e3c-9119-04bb78f0e20c"), "ІГСН", "Гуманітарних та соціальних наук інститут" },
                    { new Guid("e565ea93-708b-4697-aef8-75f71e31fa65"), "ІМІТ", "Механічної інженерії та транспорту інститут" },
                    { new Guid("e7c5fded-c2d9-438d-b03c-1fd9b4e91169"), "ІСТР", "Сталого розвитку і ім. В.Чорновола інститут" },
                    { new Guid("fca0e19a-7987-4f47-92b8-a93798e35623"), "ІМФН", "Прикладної математики та фундаментальних наук інститут" }
                });
        }
    }
}
