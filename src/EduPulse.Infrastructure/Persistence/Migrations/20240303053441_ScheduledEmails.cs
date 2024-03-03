using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EduPulse.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ScheduledEmails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "institutes",
                keyColumn: "id",
                keyValue: new Guid("2415b863-d4c6-43ed-8c79-0706c9e4b90f"));

            migrationBuilder.DeleteData(
                table: "institutes",
                keyColumn: "id",
                keyValue: new Guid("25c00b2b-25cb-4a96-b51a-40c947d84fe9"));

            migrationBuilder.DeleteData(
                table: "institutes",
                keyColumn: "id",
                keyValue: new Guid("2be46ae3-4dde-46cb-bffa-6d2e15935e85"));

            migrationBuilder.DeleteData(
                table: "institutes",
                keyColumn: "id",
                keyValue: new Guid("48ebf6e4-edaa-4d24-8f69-b6a9c8ec384b"));

            migrationBuilder.DeleteData(
                table: "institutes",
                keyColumn: "id",
                keyValue: new Guid("5caa07c6-842b-4f5f-a353-4a6493d3ef26"));

            migrationBuilder.DeleteData(
                table: "institutes",
                keyColumn: "id",
                keyValue: new Guid("75dc8846-eced-4dbd-b3ec-c6e41bbbf11f"));

            migrationBuilder.DeleteData(
                table: "institutes",
                keyColumn: "id",
                keyValue: new Guid("7c474bce-c795-4712-9e8a-be11b747ac2f"));

            migrationBuilder.DeleteData(
                table: "institutes",
                keyColumn: "id",
                keyValue: new Guid("882db9a3-c578-4c71-86b2-fa795883f751"));

            migrationBuilder.DeleteData(
                table: "institutes",
                keyColumn: "id",
                keyValue: new Guid("9afda503-e2a7-4339-ba32-00057615706f"));

            migrationBuilder.DeleteData(
                table: "institutes",
                keyColumn: "id",
                keyValue: new Guid("9ecab6b8-48c2-45bc-bbf6-08ec88fdb34b"));

            migrationBuilder.DeleteData(
                table: "institutes",
                keyColumn: "id",
                keyValue: new Guid("9f2c16f5-325b-4a09-b283-0b1f14647402"));

            migrationBuilder.DeleteData(
                table: "institutes",
                keyColumn: "id",
                keyValue: new Guid("9fdf00b6-727e-49dc-a9da-f98eea388cc2"));

            migrationBuilder.DeleteData(
                table: "institutes",
                keyColumn: "id",
                keyValue: new Guid("a6a74f55-087f-489e-9f77-8870390f6f25"));

            migrationBuilder.DeleteData(
                table: "institutes",
                keyColumn: "id",
                keyValue: new Guid("c31516c2-6d76-4e6a-98f8-2ff5e364cc86"));

            migrationBuilder.DeleteData(
                table: "institutes",
                keyColumn: "id",
                keyValue: new Guid("e666b9f1-e04d-4655-adce-a81e35947e1b"));

            migrationBuilder.DeleteData(
                table: "institutes",
                keyColumn: "id",
                keyValue: new Guid("f2ba3629-0d65-42e2-a5ca-19b8b120c52e"));

            migrationBuilder.AddColumn<int>(
                name: "points",
                table: "user_answers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "group_id",
                table: "tests",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "scheduled_emails",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    sends_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    recipient = table.Column<string>(type: "text", nullable: false),
                    subject = table.Column<string>(type: "text", nullable: false),
                    text = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_scheduled_emails", x => x.id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "scheduled_emails");

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

            migrationBuilder.DropColumn(
                name: "points",
                table: "user_answers");

            migrationBuilder.DropColumn(
                name: "group_id",
                table: "tests");

            migrationBuilder.InsertData(
                table: "institutes",
                columns: new[] { "id", "code", "title" },
                values: new object[,]
                {
                    { new Guid("2415b863-d4c6-43ed-8c79-0706c9e4b90f"), "ІНЕМ", "Економіки і менеджменту інститут" },
                    { new Guid("25c00b2b-25cb-4a96-b51a-40c947d84fe9"), "ІППО", "Права, психології та інноваційної освіти інститут" },
                    { new Guid("2be46ae3-4dde-46cb-bffa-6d2e15935e85"), "ІМІТ", "Механічної інженерії та транспорту інститут" },
                    { new Guid("48ebf6e4-edaa-4d24-8f69-b6a9c8ec384b"), "ІППТ", "Просторового планування та перспективних технологій інститут" },
                    { new Guid("5caa07c6-842b-4f5f-a353-4a6493d3ef26"), "ІСТР", "Сталого розвитку і ім. В.Чорновола інститут" },
                    { new Guid("75dc8846-eced-4dbd-b3ec-c6e41bbbf11f"), "ІГСН", "Гуманітарних та соціальних наук інститут" },
                    { new Guid("7c474bce-c795-4712-9e8a-be11b747ac2f"), "ІЕСК", "Енергетики та систем керування інститут" },
                    { new Guid("882db9a3-c578-4c71-86b2-fa795883f751"), "ІКТА", "Комп'ютерних технологій, автоматики та метрології інститут" },
                    { new Guid("9afda503-e2a7-4339-ba32-00057615706f"), "ІАРД", "Архітектури та дизайну інститут" },
                    { new Guid("9ecab6b8-48c2-45bc-bbf6-08ec88fdb34b"), "ІТРЕ", "Телекомунікацій, радіоелектроніки та електронної техніки інститут" },
                    { new Guid("9f2c16f5-325b-4a09-b283-0b1f14647402"), "ІХХТ", "Хімії та хімічних технологій інститут" },
                    { new Guid("9fdf00b6-727e-49dc-a9da-f98eea388cc2"), "ІМФН", "Прикладної математики та фундаментальних наук інститут" },
                    { new Guid("a6a74f55-087f-489e-9f77-8870390f6f25"), "КНІ", "Комп'ютерних наук та інформаційних технологій" },
                    { new Guid("c31516c2-6d76-4e6a-98f8-2ff5e364cc86"), "ІБІС", "Будівництва та інженерних систем інститут" },
                    { new Guid("e666b9f1-e04d-4655-adce-a81e35947e1b"), "ІГДГ", "Геодезії інститут" },
                    { new Guid("f2ba3629-0d65-42e2-a5ca-19b8b120c52e"), "ІДА", "Адміністрування, державного управління та професійного розвитку інститут" }
                });
        }
    }
}
