using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "AspNetRoles",
                table => new
                {
                    Id = table.Column<string>("varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    Name = table.Column<string>("varchar(256) CHARACTER SET utf8mb4", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>("varchar(256) CHARACTER SET utf8mb4", maxLength: 256,
                        nullable: true),
                    ConcurrencyStamp = table.Column<string>("longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_AspNetRoles", x => x.Id); });

            migrationBuilder.CreateTable(
                "AspNetUsers",
                table => new
                {
                    Id = table.Column<string>("varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    UserName = table.Column<string>("varchar(256) CHARACTER SET utf8mb4", maxLength: 256,
                        nullable: true),
                    NormalizedUserName = table.Column<string>("varchar(256) CHARACTER SET utf8mb4", maxLength: 256,
                        nullable: true),
                    Email = table.Column<string>("varchar(256) CHARACTER SET utf8mb4", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>("varchar(256) CHARACTER SET utf8mb4", maxLength: 256,
                        nullable: true),
                    EmailConfirmed = table.Column<bool>("tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>("longtext CHARACTER SET utf8mb4", nullable: true),
                    SecurityStamp = table.Column<string>("longtext CHARACTER SET utf8mb4", nullable: true),
                    ConcurrencyStamp = table.Column<string>("longtext CHARACTER SET utf8mb4", nullable: true),
                    PhoneNumber = table.Column<string>("longtext CHARACTER SET utf8mb4", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>("tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>("tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>("datetime(6)", nullable: true),
                    LockoutEnabled = table.Column<bool>("tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>("int", nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_AspNetUsers", x => x.Id); });

            migrationBuilder.CreateTable(
                "Author",
                table => new
                {
                    Id = table.Column<int>("int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>("longtext CHARACTER SET utf8mb4", nullable: true),
                    Surname = table.Column<string>("longtext CHARACTER SET utf8mb4", nullable: true),
                    DateOfBirth = table.Column<string>("longtext CHARACTER SET utf8mb4", nullable: true),
                    DateOfDeath = table.Column<string>("longtext CHARACTER SET utf8mb4", nullable: true),
                    LifeDescription = table.Column<string>("longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Author", x => x.Id); });

            migrationBuilder.CreateTable(
                "Category",
                table => new
                {
                    Id = table.Column<int>("int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>("longtext CHARACTER SET utf8mb4", nullable: true),
                    Description = table.Column<string>("longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Category", x => x.Id); });

            migrationBuilder.CreateTable(
                "Order",
                table => new
                {
                    Id = table.Column<int>("int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>("varchar(25) CHARACTER SET utf8mb4", maxLength: 25, nullable: false),
                    Surname = table.Column<string>("varchar(25) CHARACTER SET utf8mb4", maxLength: 25, nullable: false),
                    Adress = table.Column<string>("varchar(35) CHARACTER SET utf8mb4", maxLength: 35, nullable: false),
                    Phone = table.Column<string>("varchar(15) CHARACTER SET utf8mb4", maxLength: 15, nullable: false),
                    Email = table.Column<string>("varchar(25) CHARACTER SET utf8mb4", maxLength: 25, nullable: false),
                    OrderTime = table.Column<DateTime>("datetime(6)", nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Order", x => x.Id); });

            migrationBuilder.CreateTable(
                "AspNetRoleClaims",
                table => new
                {
                    Id = table.Column<int>("int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>("varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    ClaimType = table.Column<string>("longtext CHARACTER SET utf8mb4", nullable: true),
                    ClaimValue = table.Column<string>("longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        x => x.RoleId,
                        "AspNetRoles",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "AspNetUserClaims",
                table => new
                {
                    Id = table.Column<int>("int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>("varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    ClaimType = table.Column<string>("longtext CHARACTER SET utf8mb4", nullable: true),
                    ClaimValue = table.Column<string>("longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        "FK_AspNetUserClaims_AspNetUsers_UserId",
                        x => x.UserId,
                        "AspNetUsers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "AspNetUserLogins",
                table => new
                {
                    LoginProvider = table.Column<string>("varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    ProviderKey = table.Column<string>("varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    ProviderDisplayName = table.Column<string>("longtext CHARACTER SET utf8mb4", nullable: true),
                    UserId = table.Column<string>("varchar(255) CHARACTER SET utf8mb4", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new {x.LoginProvider, x.ProviderKey});
                    table.ForeignKey(
                        "FK_AspNetUserLogins_AspNetUsers_UserId",
                        x => x.UserId,
                        "AspNetUsers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "AspNetUserRoles",
                table => new
                {
                    UserId = table.Column<string>("varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    RoleId = table.Column<string>("varchar(255) CHARACTER SET utf8mb4", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new {x.UserId, x.RoleId});
                    table.ForeignKey(
                        "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        x => x.RoleId,
                        "AspNetRoles",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_AspNetUserRoles_AspNetUsers_UserId",
                        x => x.UserId,
                        "AspNetUsers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "AspNetUserTokens",
                table => new
                {
                    UserId = table.Column<string>("varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    LoginProvider = table.Column<string>("varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    Name = table.Column<string>("varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    Value = table.Column<string>("longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new {x.UserId, x.LoginProvider, x.Name});
                    table.ForeignKey(
                        "FK_AspNetUserTokens_AspNetUsers_UserId",
                        x => x.UserId,
                        "AspNetUsers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Book",
                table => new
                {
                    Id = table.Column<int>("int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>("longtext CHARACTER SET utf8mb4", nullable: true),
                    ShortDescription = table.Column<string>("longtext CHARACTER SET utf8mb4", nullable: true),
                    LongDescription = table.Column<string>("longtext CHARACTER SET utf8mb4", nullable: true),
                    Image = table.Column<string>("longtext CHARACTER SET utf8mb4", nullable: true),
                    Price = table.Column<ushort>("smallint unsigned", nullable: false),
                    IsOnMainPage = table.Column<bool>("tinyint(1)", nullable: false),
                    Available = table.Column<bool>("tinyint(1)", nullable: false),
                    CategoryId = table.Column<int>("int", nullable: false),
                    AuthorId = table.Column<int>("int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id);
                    table.ForeignKey(
                        "FK_Book_Author_AuthorId",
                        x => x.AuthorId,
                        "Author",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_Book_Category_CategoryId",
                        x => x.CategoryId,
                        "Category",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "OrderDetail",
                table => new
                {
                    Id = table.Column<int>("int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OrderID = table.Column<int>("int", nullable: false),
                    BookID = table.Column<int>("int", nullable: false),
                    Price = table.Column<uint>("int unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.Id);
                    table.ForeignKey(
                        "FK_OrderDetail_Book_BookID",
                        x => x.BookID,
                        "Book",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_OrderDetail_Order_OrderID",
                        x => x.OrderID,
                        "Order",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "ShopBasketItem",
                table => new
                {
                    Id = table.Column<int>("int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BookId = table.Column<int>("int", nullable: true),
                    Price = table.Column<int>("int", nullable: false),
                    ShopBasketId = table.Column<string>("longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopBasketItem", x => x.Id);
                    table.ForeignKey(
                        "FK_ShopBasketItem_Book_BookId",
                        x => x.BookId,
                        "Book",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                "IX_AspNetRoleClaims_RoleId",
                "AspNetRoleClaims",
                "RoleId");

            migrationBuilder.CreateIndex(
                "RoleNameIndex",
                "AspNetRoles",
                "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_AspNetUserClaims_UserId",
                "AspNetUserClaims",
                "UserId");

            migrationBuilder.CreateIndex(
                "IX_AspNetUserLogins_UserId",
                "AspNetUserLogins",
                "UserId");

            migrationBuilder.CreateIndex(
                "IX_AspNetUserRoles_RoleId",
                "AspNetUserRoles",
                "RoleId");

            migrationBuilder.CreateIndex(
                "EmailIndex",
                "AspNetUsers",
                "NormalizedEmail");

            migrationBuilder.CreateIndex(
                "UserNameIndex",
                "AspNetUsers",
                "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_Book_AuthorId",
                "Book",
                "AuthorId");

            migrationBuilder.CreateIndex(
                "IX_Book_CategoryId",
                "Book",
                "CategoryId");

            migrationBuilder.CreateIndex(
                "IX_OrderDetail_BookID",
                "OrderDetail",
                "BookID");

            migrationBuilder.CreateIndex(
                "IX_OrderDetail_OrderID",
                "OrderDetail",
                "OrderID");

            migrationBuilder.CreateIndex(
                "IX_ShopBasketItem_BookId",
                "ShopBasketItem",
                "BookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "AspNetRoleClaims");

            migrationBuilder.DropTable(
                "AspNetUserClaims");

            migrationBuilder.DropTable(
                "AspNetUserLogins");

            migrationBuilder.DropTable(
                "AspNetUserRoles");

            migrationBuilder.DropTable(
                "AspNetUserTokens");

            migrationBuilder.DropTable(
                "OrderDetail");

            migrationBuilder.DropTable(
                "ShopBasketItem");

            migrationBuilder.DropTable(
                "AspNetRoles");

            migrationBuilder.DropTable(
                "AspNetUsers");

            migrationBuilder.DropTable(
                "Order");

            migrationBuilder.DropTable(
                "Book");

            migrationBuilder.DropTable(
                "Author");

            migrationBuilder.DropTable(
                "Category");
        }
    }
}