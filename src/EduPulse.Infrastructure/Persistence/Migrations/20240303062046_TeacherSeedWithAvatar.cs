using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EduPulse.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class TeacherSeedWithAvatar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "institutes",
                columns: new[] { "id", "code", "title" },
                values: new object[,]
                {
                    { new Guid("00a049e8-e18f-4127-8541-873c825e8be1"), "КНІ", "Комп'ютерних наук та інформаційних технологій" },
                    { new Guid("153d0be6-5356-4c1a-b027-b73a7e1b63c7"), "ІГДГ", "Геодезії інститут" },
                    { new Guid("1566b26c-f961-468b-a72b-3b49fc676445"), "ІТРЕ", "Телекомунікацій, радіоелектроніки та електронної техніки інститут" },
                    { new Guid("15af0d76-eff4-4142-93e0-b033a440bcf2"), "ІЕСК", "Енергетики та систем керування інститут" },
                    { new Guid("1d835068-57ca-4ed0-a8f3-97984833d9c0"), "ІМФН", "Прикладної математики та фундаментальних наук інститут" },
                    { new Guid("1ff5239b-976d-42c0-b085-7168be458d3a"), "ІХХТ", "Хімії та хімічних технологій інститут" },
                    { new Guid("2693422d-c54a-4f29-9c29-8b1949f23aaf"), "ІБІС", "Будівництва та інженерних систем інститут" },
                    { new Guid("4dc7d217-ec57-4106-8082-25f709d8b0e2"), "ІКТА", "Комп'ютерних технологій, автоматики та метрології інститут" },
                    { new Guid("878019c7-7d3c-4d7c-bc46-02b228d64c3e"), "ІДА", "Адміністрування, державного управління та професійного розвитку інститут" },
                    { new Guid("92b84e89-8bb9-412e-9ef1-5913d9a51e44"), "ІАРД", "Архітектури та дизайну інститут" },
                    { new Guid("a5ec4ec7-9e88-4982-a5c1-3c535f656cc1"), "ІППТ", "Просторового планування та перспективних технологій інститут" },
                    { new Guid("d316c419-1b7a-456d-ba23-39eee0741b5a"), "ІМІТ", "Механічної інженерії та транспорту інститут" },
                    { new Guid("de28407d-90a1-4ecd-8053-80347096d6a2"), "ІСТР", "Сталого розвитку і ім. В.Чорновола інститут" },
                    { new Guid("e2a751d3-ffae-48a2-bfe8-a0af1e47bb1b"), "ІППО", "Права, психології та інноваційної освіти інститут" },
                    { new Guid("e99219e1-752a-4184-b3d1-1eceb8f3860b"), "ІНЕМ", "Економіки і менеджменту інститут" },
                    { new Guid("f5909fa3-a624-4c5b-bf98-d5942656bde1"), "ІГСН", "Гуманітарних та соціальних наук інститут" }
                });

            migrationBuilder.UpdateData(
                table: "teachers",
                keyColumn: "id",
                keyValue: new Guid("af41f834-c0f9-46be-89bf-51708b4adec9"),
                columns: new[] { "avatar", "created_at" },
                values: new object[] { "https://api.dicebear.com/7.x/thumbs/svg?seed=af41f834-c0f9-46be-89bf-51708b4adec9", new DateTimeOffset(new DateTime(2024, 3, 3, 6, 20, 46, 593, DateTimeKind.Unspecified).AddTicks(9811), new TimeSpan(0, 0, 0, 0, 0)) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "institutes",
                keyColumn: "id",
                keyValue: new Guid("00a049e8-e18f-4127-8541-873c825e8be1"));

            migrationBuilder.DeleteData(
                table: "institutes",
                keyColumn: "id",
                keyValue: new Guid("153d0be6-5356-4c1a-b027-b73a7e1b63c7"));

            migrationBuilder.DeleteData(
                table: "institutes",
                keyColumn: "id",
                keyValue: new Guid("1566b26c-f961-468b-a72b-3b49fc676445"));

            migrationBuilder.DeleteData(
                table: "institutes",
                keyColumn: "id",
                keyValue: new Guid("15af0d76-eff4-4142-93e0-b033a440bcf2"));

            migrationBuilder.DeleteData(
                table: "institutes",
                keyColumn: "id",
                keyValue: new Guid("1d835068-57ca-4ed0-a8f3-97984833d9c0"));

            migrationBuilder.DeleteData(
                table: "institutes",
                keyColumn: "id",
                keyValue: new Guid("1ff5239b-976d-42c0-b085-7168be458d3a"));

            migrationBuilder.DeleteData(
                table: "institutes",
                keyColumn: "id",
                keyValue: new Guid("2693422d-c54a-4f29-9c29-8b1949f23aaf"));

            migrationBuilder.DeleteData(
                table: "institutes",
                keyColumn: "id",
                keyValue: new Guid("4dc7d217-ec57-4106-8082-25f709d8b0e2"));

            migrationBuilder.DeleteData(
                table: "institutes",
                keyColumn: "id",
                keyValue: new Guid("878019c7-7d3c-4d7c-bc46-02b228d64c3e"));

            migrationBuilder.DeleteData(
                table: "institutes",
                keyColumn: "id",
                keyValue: new Guid("92b84e89-8bb9-412e-9ef1-5913d9a51e44"));

            migrationBuilder.DeleteData(
                table: "institutes",
                keyColumn: "id",
                keyValue: new Guid("a5ec4ec7-9e88-4982-a5c1-3c535f656cc1"));

            migrationBuilder.DeleteData(
                table: "institutes",
                keyColumn: "id",
                keyValue: new Guid("d316c419-1b7a-456d-ba23-39eee0741b5a"));

            migrationBuilder.DeleteData(
                table: "institutes",
                keyColumn: "id",
                keyValue: new Guid("de28407d-90a1-4ecd-8053-80347096d6a2"));

            migrationBuilder.DeleteData(
                table: "institutes",
                keyColumn: "id",
                keyValue: new Guid("e2a751d3-ffae-48a2-bfe8-a0af1e47bb1b"));

            migrationBuilder.DeleteData(
                table: "institutes",
                keyColumn: "id",
                keyValue: new Guid("e99219e1-752a-4184-b3d1-1eceb8f3860b"));

            migrationBuilder.DeleteData(
                table: "institutes",
                keyColumn: "id",
                keyValue: new Guid("f5909fa3-a624-4c5b-bf98-d5942656bde1"));

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

            migrationBuilder.UpdateData(
                table: "teachers",
                keyColumn: "id",
                keyValue: new Guid("af41f834-c0f9-46be-89bf-51708b4adec9"),
                columns: new[] { "avatar", "created_at" },
                values: new object[] { null, new DateTimeOffset(new DateTime(2024, 3, 3, 6, 17, 4, 421, DateTimeKind.Unspecified).AddTicks(536), new TimeSpan(0, 0, 0, 0, 0)) });
        }
    }
}
