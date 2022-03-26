using Microsoft.EntityFrameworkCore.Migrations;

namespace ALLMVC.Data.Migrations
{
    public partial class AddedViewComponentData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "socialIcons",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IconName = table.Column<string>(nullable: true),
                    IconBgColor = table.Column<string>(nullable: true),
                    IconTargetUrl = table.Column<string>(nullable: true),
                    IconClass = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_socialIcons", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "socialIcons",
                columns: new[] { "ID", "IconBgColor", "IconClass", "IconName", "IconTargetUrl" },
                values: new object[,]
                {
                    { 1, "#dd4b39", "fa fa-google", "Google", "www.google.com" },
                    { 2, "#3B5998", "fa fa-facebook", "Facebook", "www.facebook.com" },
                    { 3, "#007bb5", "fa fa-fa-linkedin", "Linked In", "www.linkedin.com" },
                    { 4, "#007bb5", "fa fa-youtube", "YouTube", "www.youtube.com" },
                    { 5, "#55acee", "fa fa-twitter", "Twitter", "www.twitter.com" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "socialIcons");
        }
    }
}
