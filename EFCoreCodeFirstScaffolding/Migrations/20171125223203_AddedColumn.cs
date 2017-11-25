using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EFCoreCodeFirstScaffolding.Migrations
{
    public partial class AddedColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TestId",
                table: "Aircraft",
                nullable: false,
                defaultValue: 0);

            //There is not direct Create Procedure that I could see directly.
            migrationBuilder.Sql("create proc pGiveBack ( @Input varchar(128) ) as Begin Select @input as Output End");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TestId",
                table: "Aircraft");

            migrationBuilder.Sql("drop proc pGiveBack");
        }
    }
}
