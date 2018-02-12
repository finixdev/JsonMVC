using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace JsonMVC.Data.Migrations
{
    public partial class AddItemOwnerId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "JsonItems",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "JsonItems",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "JsonItems");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "JsonItems",
                newName: "id");
        }
    }
}
