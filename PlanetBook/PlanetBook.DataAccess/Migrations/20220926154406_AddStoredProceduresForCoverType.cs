using Microsoft.EntityFrameworkCore.Migrations;

namespace PlanetBook.DataAccess.Migrations
{
    public partial class AddStoredProceduresForCoverType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROC sp_GetCoverTypes 
                                    AS 
                                    BEGIN 
                                     SELECT * FROM   dbo.CoverTypes 
                                    END");

            migrationBuilder.Sql(@"CREATE PROC sp_GetCoverType 
                                    @Id int 
                                    AS 
                                    BEGIN 
                                     SELECT * FROM   dbo.CoverTypes  WHERE  (Id = @Id) 
                                    END ");

            migrationBuilder.Sql(@"CREATE PROC sp_UpdateCoverType
	                                @Id int,
	                                @Name varchar(100)
                                    AS 
                                    BEGIN 
                                     UPDATE dbo.CoverTypes
                                     SET  Name = @Name
                                     WHERE  Id = @Id
                                    END");

            migrationBuilder.Sql(@"CREATE PROC sp_DeleteCoverType
	                                @Id int
                                    AS 
                                    BEGIN 
                                     DELETE FROM dbo.CoverTypes
                                     WHERE  Id = @Id
                                    END");

            migrationBuilder.Sql(@"CREATE PROC sp_CreateCoverType
                                   @Name varchar(100)
                                   AS 
                                   BEGIN 
                                    INSERT INTO dbo.CoverTypes(Name)
                                    VALUES (@Name)
                                   END");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE sp_GetCoverTypes");
            migrationBuilder.Sql(@"DROP PROCEDURE sp_GetCoverType");
            migrationBuilder.Sql(@"DROP PROCEDURE sp_UpdateCoverType");
            migrationBuilder.Sql(@"DROP PROCEDURE sp_DeleteCoverType");
            migrationBuilder.Sql(@"DROP PROCEDURE sp_CreateCoverType");
        }
    }
}
