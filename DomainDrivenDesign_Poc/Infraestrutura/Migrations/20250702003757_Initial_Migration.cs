using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DomainDrivenDesign_Poc.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Initial_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "RichDomain");

            migrationBuilder.CreateTable(
                name: "Student",
                schema: "RichDomain",
                columns: table => new
                {
                    full_name = table.Column<string>(type: "varchar(150)", nullable: false),
                    email = table.Column<string>(type: "varchar(150)", nullable: false),
                    document = table.Column<string>(type: "varchar(150)", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subscription",
                schema: "RichDomain",
                columns: table => new
                {
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    expire_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    last_updateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    subscription_type = table.Column<byte>(type: "tinyint", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subscription_Student_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "RichDomain",
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                schema: "RichDomain",
                columns: table => new
                {
                    number = table.Column<string>(type: "varchar(250)", nullable: false),
                    paid_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    email = table.Column<string>(type: "varchar(150)", nullable: false),
                    document = table.Column<string>(type: "varchar(150)", nullable: false),
                    payer = table.Column<string>(type: "varchar(250)", nullable: false),
                    total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    total_paid = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    expire_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubscriptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payment_Subscription_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalSchema: "RichDomain",
                        principalTable: "Subscription",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payment_SubscriptionId",
                schema: "RichDomain",
                table: "Payment",
                column: "SubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscription_StudentId",
                schema: "RichDomain",
                table: "Subscription",
                column: "StudentId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payment",
                schema: "RichDomain");

            migrationBuilder.DropTable(
                name: "Subscription",
                schema: "RichDomain");

            migrationBuilder.DropTable(
                name: "Student",
                schema: "RichDomain");
        }
    }
}
