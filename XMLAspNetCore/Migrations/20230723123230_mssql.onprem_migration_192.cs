using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XMLAspNetCore.Migrations
{
    /// <inheritdoc />
    public partial class mssqlonpremmigration192 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Production");

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                schema: "Production",
                columns: table => new
                {
                    ProductCategoryID = table.Column<int>(type: "int", nullable: false, comment: "Primary key for ProductCategory records.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Category description."),
                    rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())", comment: "ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample."),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Date and time the record was last updated.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory_ProductCategoryID", x => x.ProductCategoryID);
                },
                comment: "High-level product categorization.");

            migrationBuilder.CreateIndex(
                name: "AK_ProductCategory_Name",
                schema: "Production",
                table: "ProductCategory",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_ProductCategory_rowguid",
                schema: "Production",
                table: "ProductCategory",
                column: "rowguid",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductCategory",
                schema: "Production");
        }
    }
}
