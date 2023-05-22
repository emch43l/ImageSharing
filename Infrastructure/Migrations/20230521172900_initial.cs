using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Thumbnails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Thumbnails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Albums_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ThumbnailId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Images_Thumbnails_ThumbnailId",
                        column: x => x.ThumbnailId,
                        principalTable: "Thumbnails",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AlbumImage",
                columns: table => new
                {
                    AlbumId = table.Column<int>(type: "int", nullable: false),
                    ImageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlbumImage", x => new { x.AlbumId, x.ImageId });
                    table.ForeignKey(
                        name: "FK_AlbumImage_Albums_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Albums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlbumImage_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Posts_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Posts_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reactions_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reactions_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Guid", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "146eed7c-cc67-44fe-8241-74a09948d929", null, true, new Guid("a144520d-2142-436e-b472-d03b798c39bc"), false, null, null, null, null, null, true, null, false, "Rosanna" },
                    { 2, 0, "d6d97a2d-2605-41cd-9ddd-e0b36b1bd3b6", null, true, new Guid("ada3aa64-b734-4bca-9c03-b681b234dae3"), false, null, null, null, null, null, true, null, false, "Lori" },
                    { 3, 0, "f7bfe50c-d452-425d-b78c-a924719c60e2", null, true, new Guid("2ece1d2f-44a0-4c56-838b-679ccb56953c"), false, null, null, null, null, null, true, null, false, "Caesar" },
                    { 4, 0, "5e4df17d-5b95-4709-a63d-c8a39dfcac47", null, true, new Guid("b2361aa9-bfcb-46de-85d4-e560492fd743"), false, null, null, null, null, null, true, null, false, "Jevon" },
                    { 5, 0, "06cc1600-b0ec-49e4-b472-ebf82f6f36d0", null, true, new Guid("74b3eaba-2fc5-4c13-a0fb-4a6f2537b62d"), false, null, null, null, null, null, true, null, false, "Zackery" }
                });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Visible" },
                    { 2, "Hidden" }
                });

            migrationBuilder.InsertData(
                table: "Thumbnails",
                columns: new[] { "Id", "Guid", "Name" },
                values: new object[,]
                {
                    { 1, new Guid("9c7cbc50-7331-4ba4-8e97-51d92ef0a1c6"), "iusto quam at" },
                    { 2, new Guid("2779e492-9133-4fb1-8d36-076079beb6e1"), "quisquam est aut" },
                    { 3, new Guid("c2d4ad8b-1b05-45ad-a98d-be8071afe879"), "et ut non" },
                    { 4, new Guid("d535b130-d7b6-40bf-9dad-2f6ef3ebd7c5"), "illo consectetur molestiae" },
                    { 5, new Guid("3c4a279b-665c-4ea4-adff-31f07e9aa6ae"), "necessitatibus delectus quia" },
                    { 6, new Guid("8009d32c-a73f-4fbb-bc90-8cce678eff43"), "inventore aspernatur ad" },
                    { 7, new Guid("0e6a4edb-1c0d-4d6e-9451-42ad57d97996"), "animi laboriosam occaecati" },
                    { 8, new Guid("9f30d7f2-1ff8-4eb2-9ea9-9c7ef8bdabf3"), "porro aut necessitatibus" },
                    { 9, new Guid("dd5644e4-7020-4010-b218-3ea789ae11f7"), "omnis ut eius" },
                    { 10, new Guid("fe288163-d67d-4b12-9ff9-62e5d021131e"), "sint blanditiis vel" },
                    { 11, new Guid("7706ea3d-e4cd-4be7-91eb-f229a848394e"), "nesciunt debitis aut" },
                    { 12, new Guid("c071929d-900c-4455-8460-75e16d6716f3"), "sint reiciendis provident" },
                    { 13, new Guid("853a406f-58af-4486-a59f-9c1d896f79d2"), "fuga accusantium temporibus" },
                    { 14, new Guid("166be630-717e-4b5e-bf7e-a8552c82b232"), "maxime beatae sequi" },
                    { 15, new Guid("23cd2777-ad84-4df5-8b79-a9d57400ebe0"), "et expedita mollitia" },
                    { 16, new Guid("9240705d-35e5-4ead-ba09-4dfdfdbee026"), "reprehenderit asperiores maxime" },
                    { 17, new Guid("656a5753-99f3-4917-88b4-97c8065c174d"), "quas voluptatem qui" },
                    { 18, new Guid("30342f80-f7d5-4842-a0f8-e64e712c2728"), "ut totam voluptates" },
                    { 19, new Guid("550412a3-f955-4562-af16-552973a8fdc5"), "dolorum commodi autem" },
                    { 20, new Guid("97cc891c-1cc6-4d82-a6c1-959a0a5fb17a"), "autem saepe maiores" }
                });

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "Id", "Description", "Guid", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, "Error voluptatem voluptas error.\nEt illo est dolore vel minus.\nLaboriosam molestiae sit repellendus harum modi enim natus.", new Guid("3b16b34c-43b9-4242-b303-2f2d92a9c971"), "sit et sint ipsum", 1 },
                    { 2, "Perspiciatis nesciunt optio vitae ut debitis.\nSit minus omnis non ea assumenda aspernatur eaque delectus facilis.\nRerum sint unde in rerum sequi doloremque non.", new Guid("ad987643-5633-4af8-b58c-0368eeaaef84"), "sapiente eos corporis modi", 1 },
                    { 3, "Optio qui quia eligendi vel error.\nAut qui asperiores velit.\nMinima numquam quas porro sunt natus iste.", new Guid("759514d9-8157-49fd-8e02-b027cc2a79ab"), "explicabo voluptate consequuntur possimus", 1 },
                    { 4, "Placeat sapiente eius nam aut dolorem.\nQui quo cupiditate vero sed perferendis eligendi id.\nQuaerat accusantium exercitationem numquam eaque.", new Guid("695be7fc-e50b-4670-930b-2b80f888914a"), "asperiores ratione illo sint", 1 },
                    { 5, "Doloribus expedita repudiandae minima consequatur consequatur autem quis.\nCum unde perspiciatis quaerat.\nQuia vel dolores.", new Guid("5a100ff7-9860-4bd0-8276-80bbf6e57948"), "omnis odio officiis autem", 1 }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Extension", "Guid", "Slug", "ThumbnailId", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, ".jpg", new Guid("ab761895-bad9-4ea2-a176-73c872d47cff"), "", 1, "cum labore illum", 1 },
                    { 2, ".jpg", new Guid("a6a2253d-4d90-4ef9-a492-d59c0d5ad302"), "", 2, "in explicabo pariatur", 1 },
                    { 3, ".jpg", new Guid("a9597b34-0549-4f86-8379-6c0557142acb"), "", 3, "esse facere velit", 1 },
                    { 4, ".jpg", new Guid("7095c89e-f5ed-4ddf-bfba-d27da8e9a673"), "", 4, "magni eos eveniet", 1 },
                    { 5, ".jpg", new Guid("5dbac941-dfe3-464f-80b4-fb24de9ebd13"), "", 5, "earum officiis ea", 1 },
                    { 6, ".jpg", new Guid("da913456-f3d0-4b1b-8065-a9f0f43b087c"), "", 6, "eaque et assumenda", 1 },
                    { 7, ".jpg", new Guid("b9a14a29-896b-43a7-bce7-b479a0dc95ca"), "", 7, "temporibus et pariatur", 1 },
                    { 8, ".jpg", new Guid("1898cf6e-4ed9-4460-8e0a-27a38fa435b7"), "", 8, "voluptatem earum sunt", 1 },
                    { 9, ".jpg", new Guid("346ededb-75fd-4b1d-a38f-e6263e5c93f5"), "", 9, "corrupti explicabo cupiditate", 1 },
                    { 10, ".jpg", new Guid("9581b1da-a9ed-4ef9-96d4-2c7bd54ba1d6"), "", 10, "voluptatem similique soluta", 1 },
                    { 11, ".jpg", new Guid("b76536bc-c0a5-451d-84ce-19c6e49515b2"), "", 11, "eligendi ex enim", 1 },
                    { 12, ".jpg", new Guid("acf00a61-5da6-4aac-925e-83c712b2a8d5"), "", 12, "dolorem sit neque", 1 },
                    { 13, ".jpg", new Guid("61ca76de-0fc6-4092-b5fb-cbd7d6a31180"), "", 13, "qui cumque aut", 1 },
                    { 14, ".jpg", new Guid("b444e63d-bb16-4405-bc39-49b171c53b83"), "", 14, "autem tempore molestiae", 1 },
                    { 15, ".jpg", new Guid("3f7b5839-d35d-47fe-91e7-16a1603b8c33"), "", 15, "vel et nemo", 1 },
                    { 16, ".jpg", new Guid("73bd40e5-ca1e-442a-b72e-0f2e9326ea8d"), "", 16, "sint autem nesciunt", 1 },
                    { 17, ".jpg", new Guid("6fb44193-69ec-462d-8764-99446b479a95"), "", 17, "aut autem et", 1 },
                    { 18, ".jpg", new Guid("fcb149bd-be50-4de3-8494-a78bf1e5b98a"), "", 18, "aliquid ut expedita", 1 },
                    { 19, ".jpg", new Guid("ce263b1b-c1b7-4c96-ab1b-0d6e49bbcfe9"), "", 19, "ipsa earum distinctio", 1 },
                    { 20, ".jpg", new Guid("00b48358-3976-487d-a828-7f573aa04b65"), "", 20, "fugit deserunt aliquid", 1 }
                });

            migrationBuilder.InsertData(
                table: "AlbumImage",
                columns: new[] { "AlbumId", "ImageId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 1, 5 },
                    { 1, 6 },
                    { 1, 7 },
                    { 1, 8 },
                    { 1, 9 },
                    { 1, 10 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 2, 4 },
                    { 2, 5 },
                    { 2, 6 },
                    { 2, 7 },
                    { 2, 8 },
                    { 2, 9 },
                    { 2, 10 },
                    { 2, 11 },
                    { 2, 12 },
                    { 2, 13 },
                    { 2, 14 },
                    { 2, 15 },
                    { 2, 16 },
                    { 3, 1 },
                    { 3, 2 },
                    { 3, 3 },
                    { 3, 4 },
                    { 3, 5 },
                    { 3, 6 },
                    { 3, 7 },
                    { 3, 8 },
                    { 3, 9 },
                    { 3, 10 },
                    { 3, 11 },
                    { 3, 12 },
                    { 3, 13 },
                    { 3, 14 },
                    { 3, 15 },
                    { 3, 16 },
                    { 3, 17 },
                    { 3, 18 },
                    { 4, 1 },
                    { 4, 2 },
                    { 5, 1 },
                    { 5, 2 },
                    { 5, 3 },
                    { 5, 4 },
                    { 5, 5 },
                    { 5, 6 },
                    { 5, 7 },
                    { 5, 8 },
                    { 5, 9 },
                    { 5, 10 },
                    { 5, 11 },
                    { 5, 12 },
                    { 5, 13 },
                    { 5, 14 },
                    { 5, 15 },
                    { 5, 16 },
                    { 5, 17 },
                    { 5, 18 }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Guid", "ImageId", "StatusId", "Tags", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, new Guid("c76c71e5-4102-4f65-86c5-bffb30118a04"), 1, 2, "unleash|frame|green", "reiciendis id nemo ut", 1 },
                    { 2, new Guid("5bdd5a37-0f5b-47eb-b3c7-bd39c9f916e3"), 2, 2, "Plastic|Trafficway|HTTP", "maiores id est fuga", 1 },
                    { 3, new Guid("83254b15-b4d4-49c5-8562-16b2f9a8f352"), 3, 2, "mission-critical|Berkshire|Gorgeous", "sed rem unde qui", 1 },
                    { 4, new Guid("9b0e4b40-c762-4ba8-96d6-4cc904bbc5f8"), 4, 2, "relationships|New Mexico|Common", "libero non eos tempore", 1 },
                    { 5, new Guid("17f0bc44-db19-44c0-8c00-85b98af80169"), 5, 1, "Ergonomic Soft Pants|Movies, Health & Computers|concept", "fuga est accusamus explicabo", 1 },
                    { 6, new Guid("3a99d1a1-d327-4990-bd09-84c6ceac0276"), 6, 1, "Consultant|withdrawal|parsing", "sed repudiandae veritatis dolores", 1 },
                    { 7, new Guid("3170ccfa-8d04-46cc-bde6-0c834d9eaf2e"), 7, 1, "Web|context-sensitive|brand", "omnis expedita ea vero", 1 },
                    { 8, new Guid("58294990-1763-4b63-a503-bffdc7f8c15c"), 8, 2, "Bond Markets Units European Composite Unit (EURCO)|Libyan Dinar|program", "totam quis dolorem beatae", 1 },
                    { 9, new Guid("58f05b6d-50bb-49ec-a9b8-c8ceec97e748"), 9, 2, "invoice|Checking Account|Awesome Concrete Bacon", "ea consequatur voluptatem nesciunt", 1 },
                    { 10, new Guid("630cc39e-5091-46aa-bbc2-90e2d3233cd2"), 10, 2, "Home, Shoes & Baby|6th generation|Faroe Islands", "rerum sequi deleniti a", 1 },
                    { 11, new Guid("e687f870-7735-4c4c-9ef5-83ca3a63bcb9"), 11, 1, "Creek|Barbados|Rustic Soft Chicken", "consequatur architecto rerum quae", 1 },
                    { 12, new Guid("2a21b90b-3900-4d28-b7e1-d4a0af512f3b"), 12, 2, "Road|Berkshire|data-warehouse", "voluptatum quaerat qui dolores", 1 },
                    { 13, new Guid("e89c7acf-92d0-4eb2-8b81-ff13c9602b01"), 13, 2, "UIC-Franc|Villages|Mississippi", "rerum in voluptatibus harum", 1 },
                    { 14, new Guid("0ac4f337-c291-40ac-ad7a-38e7800c7775"), 14, 2, "Bedfordshire|Democratic People's Republic of Korea|next-generation", "dolor quo numquam dolores", 1 },
                    { 15, new Guid("485019f2-fe1b-4c8e-b419-c276fc871477"), 15, 1, "Credit Card Account|Bedfordshire|Tasty Concrete Chicken", "est a magni saepe", 1 },
                    { 16, new Guid("b3af73cd-d3d9-4ade-9d0c-44470066825e"), 16, 2, "Grocery|Cedi|Handcrafted Granite Soap", "iusto ullam illum odio", 1 },
                    { 17, new Guid("ef6b1ec2-dd98-4b31-85cf-d6d67cd7438c"), 17, 1, "Credit Card Account|Liechtenstein|Cambridgeshire", "rerum explicabo vero praesentium", 1 },
                    { 18, new Guid("7a007b3c-b000-4aa2-8d3f-7a3c4bac4163"), 18, 2, "Fantastic Granite Keyboard|clicks-and-mortar|Concrete", "voluptas sed et repellat", 1 },
                    { 19, new Guid("8e316a9b-c148-4187-bde4-996f89089a68"), 19, 2, "Infrastructure|Steel|Tasty Steel Ball", "ut eos repudiandae ea", 1 },
                    { 20, new Guid("c0a2b973-4428-469c-8b63-2fefd2e4a8b2"), 20, 2, "Handmade Rubber Shoes|Wooden|visionary", "itaque et animi qui", 1 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Guid", "PostId", "Text", "UserId" },
                values: new object[,]
                {
                    { 1, new Guid("5eac3aef-9fe3-431c-9325-8126103d649c"), 1, "Veniam esse sed et ut in.\nEos dolor autem perspiciatis neque rem nihil.", 5 },
                    { 2, new Guid("0a2c4568-3e60-4f2b-87d9-254221a90e79"), 1, "Placeat laboriosam nemo voluptatem itaque non aperiam nostrum.\nImpedit sed necessitatibus et sit.", 5 },
                    { 3, new Guid("2e7b5985-8dbd-4427-9d69-76692bbae4a5"), 1, "In et eius aliquam voluptas alias.\nRatione repellat consequuntur maiores.", 3 },
                    { 4, new Guid("e067b6a8-0633-4f44-8e51-01a967a61961"), 1, "Explicabo quis dolor sed aut eum quia non.\nIure a et voluptatem vero autem magni consequatur omnis quidem.", 2 },
                    { 5, new Guid("815f131c-7f02-4c5f-b0eb-00ca0e1d72e2"), 1, "Facere qui sed facere.\nAliquid quis maxime.", 2 },
                    { 6, new Guid("e21b8c0d-5950-4e07-bfe4-4ffd542a0348"), 1, "Quia nemo iusto ex debitis.\nLaborum sed facere sapiente praesentium in minus ipsa.", 4 },
                    { 7, new Guid("17b3ee0e-62af-4519-9df7-dbfad212a602"), 1, "Facilis ut voluptate quo reprehenderit pariatur soluta blanditiis molestiae.\nReiciendis ut possimus tenetur.", 2 },
                    { 8, new Guid("f6e604dd-9ac3-4920-b810-ee7847059e57"), 1, "Assumenda sint et voluptatem ut eos est.\nUt maxime consectetur consequatur facilis debitis.", 3 },
                    { 9, new Guid("7ea09f33-2e71-4243-abda-2f65b63ee8c6"), 1, "Debitis cupiditate aliquam assumenda atque.\nAb eum maiores ducimus soluta at ut fuga tempora assumenda.", 2 },
                    { 10, new Guid("39c4d764-9eb9-491a-96bf-1bb49a8dfaeb"), 1, "Nemo et quibusdam.\nEarum odio qui deleniti dolores officia laudantium qui.", 3 },
                    { 11, new Guid("7c228cae-eb80-4425-8ec5-9c07ca111f2e"), 2, "Id quibusdam autem deleniti soluta qui.\nUt omnis ex.", 2 },
                    { 12, new Guid("f228c03c-b905-407d-b571-36d03985d3d5"), 2, "Similique nulla sed nobis ea perspiciatis nobis sed.\nEt ab aut sunt quo nesciunt doloribus inventore.", 3 },
                    { 13, new Guid("d968caf7-f78a-4431-9894-467ef2e9ceda"), 2, "Officiis inventore laudantium repellendus illum et ut corrupti voluptas.\nIncidunt facere dolores perspiciatis totam quibusdam tempore aliquid.", 3 },
                    { 14, new Guid("e308b191-2098-4614-8f6f-391a20841f2e"), 2, "Accusamus eos vel ipsa dolor.\nEum et ipsum modi ipsum modi nisi vitae sit.", 3 },
                    { 15, new Guid("cdcd3936-6dbc-4b33-983a-2066a321d9ee"), 2, "Sapiente aliquam expedita facere fuga laudantium quis rerum.\nAccusantium provident et inventore fugit voluptatem neque.", 2 },
                    { 16, new Guid("b5c36ded-7ef8-49b9-bf48-5e6ab651849a"), 2, "Totam commodi consequatur a et odio aliquid veniam doloribus.\nAdipisci non aut voluptatem repellat cumque.", 4 },
                    { 17, new Guid("111f2fb6-021f-4330-b829-d619daec6c85"), 2, "Est aut aspernatur et possimus numquam quos eum rerum dolore.\nConsectetur earum corrupti qui sit ut magnam.", 3 },
                    { 18, new Guid("abb3c833-5017-4aed-989f-0c9a7e95d70c"), 2, "At consequatur itaque.\nAutem fuga consectetur optio qui adipisci sapiente accusamus animi.", 2 },
                    { 19, new Guid("508d2c79-f699-4119-a55a-745502908fe5"), 2, "Quis asperiores voluptatum eaque dolor modi.\nDolor repellat quasi nesciunt.", 1 },
                    { 20, new Guid("326921a5-e7f9-4d99-a5ad-504da311875b"), 2, "Dolor ut dolorum consequatur ut omnis sed cum.\nIn adipisci excepturi repudiandae.", 3 },
                    { 21, new Guid("09e1e831-db78-45b6-8c6f-95114d2805c9"), 3, "Animi fugit sint qui dolores iusto.\nDolores ipsa quia dolor inventore porro non eos iste.", 3 },
                    { 22, new Guid("cb12e358-cb62-49a0-8e99-bbbfb04e8d6a"), 3, "Qui velit inventore.\nSit quia eveniet facilis ex qui temporibus pariatur distinctio qui.", 4 },
                    { 23, new Guid("4252864c-ec29-4149-a3e9-2d31b6528d01"), 3, "Repudiandae exercitationem sed sint est ratione.\nMaiores est non eos velit sed hic eos.", 5 },
                    { 24, new Guid("9db3c99d-78ba-46ea-a4e9-c10a01093637"), 3, "Voluptas quidem optio minus nulla a eos.\nAdipisci architecto ad iste debitis ex.", 3 },
                    { 25, new Guid("7938c931-43d2-47f3-b6ff-40caf08b1584"), 3, "Odio magni quae ipsum ut aut debitis possimus.\nReprehenderit saepe reiciendis.", 4 },
                    { 26, new Guid("c64acc3b-facb-41d9-b31a-17aa222db211"), 3, "A amet laborum error commodi sint id omnis enim iusto.\nRepellat fugit ea quia sed qui voluptatem perferendis.", 5 },
                    { 27, new Guid("c69a1dae-8f1c-4ea6-8c11-4e17232ccd87"), 3, "Odio nisi consequuntur minima tenetur repellat placeat est amet alias.\nMagni alias quidem adipisci ipsam corrupti beatae qui illum.", 3 },
                    { 28, new Guid("9168cdfd-7ee5-4110-82ca-a01347d0e268"), 3, "Molestiae quia et.\nTenetur sit consectetur sapiente quos ex exercitationem dolor qui qui.", 3 },
                    { 29, new Guid("a75ce037-dd7d-4dc5-a620-bfade9b19c45"), 3, "Repellat et odio et mollitia recusandae voluptas eaque.\nAccusantium aliquam eveniet incidunt et.", 5 },
                    { 30, new Guid("8e413cc1-1236-4daf-b0d2-73a786ad8ca6"), 3, "Quibusdam fugiat porro non.\nOmnis nihil illum voluptas voluptatem totam.", 1 },
                    { 31, new Guid("1e8dd661-29b3-49a2-8b22-5fd7b2c9d407"), 4, "Velit omnis corrupti corporis explicabo vel et.\nIusto et tenetur.", 4 },
                    { 32, new Guid("9c2ca3e2-af4b-4596-b996-97c5e74f33b1"), 4, "Officia neque vitae quidem quidem.\nBlanditiis et perspiciatis sunt iusto officiis dolores aut fugiat pariatur.", 5 },
                    { 33, new Guid("78d766e0-621f-4e1f-9228-ee2191eb73cb"), 4, "Quia rerum error.\nArchitecto optio dicta nemo quia.", 3 },
                    { 34, new Guid("eeca0252-3c29-421a-bd82-48ddcd17c276"), 4, "Est et omnis voluptate dolores ipsam porro quo.\nUt et animi aliquam quasi blanditiis accusantium.", 5 },
                    { 35, new Guid("24bb0c36-67d1-4759-b4ea-d467dff51720"), 4, "Dolores ipsum omnis natus temporibus consequuntur illo mollitia cupiditate itaque.\nRepudiandae labore eum voluptas ea molestiae earum et dolorum.", 1 },
                    { 36, new Guid("3317820b-35dc-49ba-9251-98fe64ea2e46"), 4, "Molestias et nihil architecto ut quam.\nDolores ut est illo quia.", 2 },
                    { 37, new Guid("f7b49ab7-fd4c-4108-8046-91daaeb15cb4"), 4, "Quis omnis veniam praesentium in consequatur quia.\nVel porro fugiat quasi vel voluptatem.", 1 },
                    { 38, new Guid("06c91843-f926-4ff8-a9d1-7651c264b935"), 4, "Et voluptatem consequatur laboriosam possimus et qui porro.\nImpedit esse at impedit ut veritatis ut dolor nesciunt.", 4 },
                    { 39, new Guid("961b2116-cb05-46a4-8369-f3c997604a62"), 4, "Optio corrupti in ipsam autem qui et.\nTotam sit molestias debitis modi consequatur totam est voluptas ipsum.", 1 },
                    { 40, new Guid("bfe6db70-637b-4fd6-aa80-b009e6d4a9f4"), 4, "Sunt et non.\nNesciunt consectetur vel recusandae corrupti sed laborum qui assumenda.", 1 },
                    { 41, new Guid("91e7e5c7-f2ba-4c31-b8ad-1f157bbd9f9e"), 5, "Quo minus veniam velit aliquid eum cumque iusto ea quidem.\nEum laborum omnis provident.", 1 },
                    { 42, new Guid("932ce512-f8ee-45d2-a1e2-f458c23b99fd"), 5, "Illum officiis impedit nobis maxime quis dolorum.\nVelit sunt nemo vel eligendi non sed in repudiandae sit.", 4 },
                    { 43, new Guid("3b6e731f-880f-4fdf-9a94-f027fd8aa50e"), 5, "Officia non natus officia quidem officiis qui libero repellat quia.\nQuae aut ut eum.", 4 },
                    { 44, new Guid("aedb34b7-1138-45f3-b5ea-bc744639ed10"), 5, "Quibusdam aliquid officia beatae voluptas occaecati incidunt maxime rerum.\nAut veniam minus repellendus labore alias nobis exercitationem deleniti.", 5 },
                    { 45, new Guid("06e63b3b-52f8-4ce5-8003-f1f99ba4ffe8"), 5, "Quis sed laudantium laborum quas ut velit culpa inventore ut.\nSequi dolores odio aut quo et consectetur expedita veniam.", 3 },
                    { 46, new Guid("21b5028c-6dea-4065-b81d-94d53b8caaf3"), 5, "In qui cum.\nSunt qui temporibus nostrum animi deserunt.", 2 },
                    { 47, new Guid("86df6e64-1503-4f6d-be37-80718487d707"), 5, "Maxime velit ullam.\nNon ex fugit et.", 2 },
                    { 48, new Guid("387a8ecf-7022-4f4c-85df-09ddd64dd16c"), 5, "Harum blanditiis unde ipsum quo.\nArchitecto ad sequi necessitatibus vel aut dolores quo ipsum.", 4 },
                    { 49, new Guid("0d601806-3715-467f-865e-7198fa9110e4"), 5, "Repellendus magni omnis ea sit.\nSed quia accusamus cum.", 3 },
                    { 50, new Guid("4b382c8a-0b6d-454e-9b13-216a99157a8b"), 5, "Ea iure neque ut est recusandae.\nIn possimus quis ea repellat cumque officiis.", 1 },
                    { 51, new Guid("7fc91c23-c751-40c8-9208-d2b9d7bd4c07"), 6, "Quibusdam ut fugiat voluptatem tenetur ipsa eligendi voluptatum consequuntur commodi.\nEt sed molestiae amet.", 4 },
                    { 52, new Guid("17d05ef2-5f51-4ed6-9e4b-9dff1f27d958"), 6, "Inventore possimus soluta et et voluptatem explicabo ut quia at.\nId vero ipsam similique quaerat consectetur placeat aliquam rem.", 5 },
                    { 53, new Guid("da6f87f9-e86a-475a-b659-b8fa49a243d4"), 6, "Molestias fugit similique debitis porro harum amet.\nVel explicabo quisquam aut libero.", 4 },
                    { 54, new Guid("8907227c-eccd-4913-a475-2254a74b386d"), 6, "Qui alias ut sunt eum.\nFacere a non maxime.", 3 },
                    { 55, new Guid("828c90c1-f147-417f-a005-5b0bd1880932"), 6, "Delectus sit tempore.\nVoluptatem soluta expedita commodi nulla.", 4 },
                    { 56, new Guid("34fc091e-81c1-4fc9-aafb-ffc01110bfbe"), 6, "Quis in officia.\nAd accusantium et totam.", 5 },
                    { 57, new Guid("7582bdbe-e253-45c2-87ac-2241067c83f6"), 6, "Aut explicabo reiciendis fugit iste eaque aut ad.\nBlanditiis consequatur cumque tenetur sint a ut quas.", 5 },
                    { 58, new Guid("1268b0aa-2258-45d3-9fd8-f3ac1d052e4c"), 6, "Non nulla eaque sit corporis et reprehenderit.\nQuisquam omnis unde.", 4 },
                    { 59, new Guid("8aea8572-2143-4dd6-9898-06f6245eb1d6"), 6, "Debitis recusandae cum aliquid.\nEaque voluptatem voluptates quisquam atque error aliquam.", 5 },
                    { 60, new Guid("4e368bdd-6f84-4a75-86d3-97b079a8ba2d"), 6, "Rerum amet cumque porro aperiam autem aut sit et.\nNecessitatibus ipsa quas nihil.", 1 },
                    { 61, new Guid("f95fe9e4-0b78-4eeb-9d75-2a39dccd48eb"), 7, "Rerum eius nisi.\nTotam esse necessitatibus nostrum aut voluptatem ducimus esse et.", 1 },
                    { 62, new Guid("d70c5c94-eab3-4c6a-aaed-7319de01084d"), 7, "Aliquid nihil iste debitis et et voluptatum.\nAd aut consectetur laudantium occaecati dignissimos sint quas.", 3 },
                    { 63, new Guid("bc2ebf4a-d8c4-4a6d-9ee9-56a6fd4597b0"), 7, "Laborum vero et enim rerum quis veniam nulla placeat.\nUt id eveniet aspernatur at blanditiis aliquid.", 2 },
                    { 64, new Guid("ecf208ae-e1bc-4780-800b-09bd1bbfc348"), 7, "Et placeat beatae.\nId illum eos possimus quia inventore repellat deleniti.", 4 },
                    { 65, new Guid("e59dfd9a-a816-49da-8f96-3e48aaecff36"), 7, "Enim et accusamus non sed.\nQuas voluptate eveniet odio aut necessitatibus eum perferendis fuga suscipit.", 5 },
                    { 66, new Guid("27694e1f-c19b-451e-8ec3-0fc9de6c1303"), 7, "Ab voluptate at ratione exercitationem delectus quis laboriosam recusandae nihil.\nTotam quasi possimus molestias ut.", 2 },
                    { 67, new Guid("a3752f21-685d-424c-a6a8-4e18bf200145"), 7, "Voluptas voluptates quo repellat sunt dolorem quam velit nostrum.\nIusto ut aut aspernatur.", 3 },
                    { 68, new Guid("48d426b4-2729-439b-b1eb-6d9fa2f2de10"), 7, "Eveniet et et provident consequatur recusandae qui.\nConsequatur voluptatem atque non eligendi nemo.", 5 },
                    { 69, new Guid("68e4e116-0a46-4005-b14c-02e8affe9fe0"), 7, "Non id totam cupiditate adipisci.\nTempora tenetur atque fuga ut quam voluptatem excepturi animi voluptas.", 1 },
                    { 70, new Guid("db164ef8-f66a-40ad-a322-e70295419232"), 7, "Sit est corporis dolores ea.\nCulpa alias quod non.", 3 },
                    { 71, new Guid("f70c12ae-6b9f-4ab8-9eeb-37f4ea8a9db4"), 8, "Perspiciatis rerum quis adipisci consequatur suscipit non et.\nMagni aut assumenda facilis consequatur totam nostrum.", 4 },
                    { 72, new Guid("f11ae426-b267-4cf9-a1c0-a6f9671d85f5"), 8, "Optio quae qui quo perspiciatis porro et quia.\nFugit sunt exercitationem recusandae dolore totam sit corrupti sunt.", 3 },
                    { 73, new Guid("448e6f09-23a3-44d5-8c8f-5f527110c1b2"), 8, "Ex quia provident sed voluptates vero.\nVoluptatem rerum voluptatem velit animi maiores itaque incidunt id assumenda.", 5 },
                    { 74, new Guid("f4ef817f-d8a6-414c-b65d-1cd88421efc1"), 8, "Delectus explicabo et labore.\nId asperiores maiores odit.", 5 },
                    { 75, new Guid("2baaf7a4-6995-410f-a545-de182871fa97"), 8, "Repellat magnam sapiente.\nQuam inventore magni qui quidem veniam iure asperiores nostrum omnis.", 4 },
                    { 76, new Guid("63d4252a-0239-4980-a65f-cf547e320bee"), 8, "In et excepturi.\nDolorum nobis dicta commodi consequatur eum culpa dolorem rerum ullam.", 2 },
                    { 77, new Guid("fab64817-7445-4b53-bc3f-cc6a0c0b8d45"), 8, "Dolores soluta debitis sequi et consequatur sed rerum.\nNihil veritatis officiis.", 3 },
                    { 78, new Guid("620d8252-0ad0-4a24-9d04-019c16eef507"), 8, "Omnis corporis accusamus consequatur et est quasi cupiditate modi qui.\nReprehenderit quam exercitationem blanditiis.", 2 },
                    { 79, new Guid("9c4bf644-3e98-4362-9235-51d26cf76665"), 8, "Deleniti aperiam rerum voluptatem architecto officia enim qui.\nQuam sit tempora exercitationem laboriosam at nisi.", 3 },
                    { 80, new Guid("e98d54f6-82eb-4743-b997-fc7380efb7ee"), 8, "Est quo voluptas qui quasi minima explicabo ullam.\nA sit cupiditate ipsam.", 4 },
                    { 81, new Guid("7dabaf75-f94f-4533-bbb3-8fb04d26cb6e"), 9, "Facilis earum odio qui.\nVel repellendus in consequatur.", 2 },
                    { 82, new Guid("3a3a9ca2-2221-4b45-bc88-84f96feb5b69"), 9, "Et consequatur sed sapiente vel consequatur.\nDeleniti nesciunt delectus porro harum et iusto non.", 5 },
                    { 83, new Guid("ae5db282-d347-4055-9b03-d04331f58b98"), 9, "Illum animi molestiae eius soluta dolor iste consequuntur.\nVoluptates commodi id veniam minus.", 2 },
                    { 84, new Guid("0e99079b-1f5f-4ec0-b8aa-8cdab1d440b8"), 9, "Numquam quae magnam ullam nostrum neque saepe praesentium aspernatur provident.\nIpsa et tenetur et amet tempora eius.", 4 },
                    { 85, new Guid("1c3c54dc-2d85-47e3-a21b-0bdcfdfdca72"), 9, "Maiores qui aut.\nAut debitis reprehenderit perferendis reiciendis quasi amet.", 5 },
                    { 86, new Guid("87cee320-bf96-417c-8f12-f9eef7919efa"), 9, "Facilis eius quam perspiciatis sint.\nNatus officiis ipsum commodi.", 1 },
                    { 87, new Guid("def910fd-a917-4b1f-b0c3-129a516d7117"), 9, "Qui odit delectus odio natus illum quaerat laborum in aut.\nPlaceat omnis quia doloribus occaecati ut.", 3 },
                    { 88, new Guid("c8eab778-2d30-40d3-8eac-faf73d1e7627"), 9, "Enim dignissimos voluptatem esse facilis dolorem.\nQuaerat perferendis dolores consectetur dolorem soluta consequatur deleniti quae et.", 2 },
                    { 89, new Guid("9483ff97-b1c0-4f62-8fdb-6bd5e81678f9"), 9, "Blanditiis ut est voluptatum nihil quia voluptatem qui.\nLaboriosam reprehenderit enim architecto laudantium veritatis.", 5 },
                    { 90, new Guid("e32a83f8-077a-4c79-a960-f534067c038d"), 9, "Qui tenetur non tempora aut fugiat voluptatem odit odit iure.\nVoluptas non rerum nostrum quia dolorem veritatis accusantium nihil veritatis.", 1 },
                    { 91, new Guid("e1c21cd9-710b-42af-ad94-52d3cf7a5cb0"), 10, "Aut eos voluptatem nostrum et amet nulla sit.\nPerferendis aut atque modi officia est natus accusantium iste repellat.", 2 },
                    { 92, new Guid("580ff39c-7e6e-47f2-bd9b-bac9de9b517e"), 10, "Ut animi voluptatem debitis reiciendis quis quod consectetur nemo voluptatem.\nQuidem et voluptatibus dolor dolor officia deleniti dolor ut doloribus.", 3 },
                    { 93, new Guid("d1d18da2-99b9-424f-9979-49ea547786b5"), 10, "Placeat exercitationem ipsa enim nemo sit est consequatur quaerat.\nCumque doloribus et suscipit ducimus et eos voluptate.", 1 },
                    { 94, new Guid("09c43a05-3a71-43f0-a4e8-6d16044b8fd0"), 10, "Eum et velit quaerat nihil ea explicabo voluptatibus dolorem.\nAssumenda enim voluptate sit fugiat dicta ex.", 1 },
                    { 95, new Guid("182abfc5-c747-439d-bf92-a037a6ace971"), 10, "Molestias dolor quia tempore vel autem.\nNon excepturi facere est.", 5 },
                    { 96, new Guid("7ba1315c-5645-4eff-ae2a-62ce68d21887"), 10, "Recusandae est voluptatum quo et aut dolores sed et autem.\nQuis corporis quis aut sequi corporis.", 2 },
                    { 97, new Guid("b5a1b6c1-64a2-4bd6-9950-b228b6ce78f0"), 10, "Ex et assumenda.\nOfficia hic minima temporibus labore est.", 3 },
                    { 98, new Guid("cf3535e0-7be0-463f-8652-23ac808353bd"), 10, "Qui et cum et eos fugit non.\nEst dolores provident nostrum consequatur alias magni.", 1 },
                    { 99, new Guid("4c320bbb-5637-4a13-b851-cf0bdd4fb78c"), 10, "Expedita autem a quo.\nEa iste amet ipsam et dicta alias.", 2 },
                    { 100, new Guid("8ac8a4fa-3eb0-4384-bf9b-f7eb462655da"), 10, "Quia rerum rerum unde quisquam libero.\nDeleniti quia est qui rem fugiat numquam quasi dolores.", 5 },
                    { 101, new Guid("104462b7-e4b1-4fa2-adcb-9cdc86579055"), 11, "Quia occaecati in dicta nisi.\nConsequatur sunt voluptas consectetur sint numquam aut ullam.", 2 },
                    { 102, new Guid("4b0c3068-4e53-427b-a3df-6cc43f852b24"), 11, "Dicta modi quia cum et.\nQui in blanditiis saepe.", 5 },
                    { 103, new Guid("6a9de19f-c27a-464a-aa34-2c4dcddc8ae5"), 11, "Est optio rerum voluptatibus ipsam aut velit nihil.\nOfficiis unde voluptas qui et commodi.", 1 },
                    { 104, new Guid("c17d8526-6536-4ea7-af69-3de02f582214"), 11, "Soluta aliquam modi quibusdam.\nEt ea deleniti sed ab.", 2 },
                    { 105, new Guid("d4974baa-80f9-4550-9186-264fafe3cce7"), 11, "Reiciendis itaque voluptatum et eligendi praesentium dolores quo fugiat.\nDoloremque aut fuga consectetur unde nam autem omnis sit nostrum.", 2 },
                    { 106, new Guid("d323907f-ad22-4c40-8363-c5a8c38425ec"), 11, "Harum tempore nihil necessitatibus officiis.\nDolores cupiditate velit perspiciatis sint et.", 1 },
                    { 107, new Guid("a41e5b95-8894-47c6-a74d-726277717e5d"), 11, "Mollitia officiis pariatur ut recusandae eos deleniti.\nRerum iste praesentium quia maiores aliquid ipsum eos at inventore.", 4 },
                    { 108, new Guid("9b4b7c31-74f1-43cd-a044-336df367ffa2"), 11, "Asperiores commodi quam veritatis odit officiis explicabo beatae.\nMagni aliquid dolor quia est temporibus corporis vitae impedit.", 4 },
                    { 109, new Guid("0d0ed787-7b1b-4f46-b9ac-e7ea1c46df1e"), 11, "Ut quibusdam libero blanditiis id non et.\nReiciendis modi cum accusamus deserunt et.", 5 },
                    { 110, new Guid("eca0997e-d963-4857-bc32-45fc78890868"), 11, "Reiciendis et deleniti libero odit modi omnis qui quibusdam.\nMinus voluptas est voluptatibus incidunt ullam nulla aut sapiente voluptatem.", 1 },
                    { 111, new Guid("b465aa49-ed2b-4f9f-b5d2-48e4cb06bcc3"), 12, "Sit quam alias minus nisi fuga ipsum delectus quas vitae.\nMaiores cumque deleniti debitis vel dolor dolorem.", 1 },
                    { 112, new Guid("058a69c0-db45-4b4c-9b58-fa65133b084f"), 12, "Nesciunt amet dolores.\nSit deserunt quia possimus repudiandae atque natus.", 4 },
                    { 113, new Guid("919cdbe6-49f6-4be8-b6e1-4c3c39c6e826"), 12, "Voluptates tenetur omnis iure voluptas ullam suscipit.\nIste dolore rem suscipit et minima ipsa nihil nemo.", 1 },
                    { 114, new Guid("becbc371-943c-49e6-b4ff-adc11391fdfd"), 12, "Deserunt a quo aut omnis qui suscipit.\nUt id harum omnis.", 4 },
                    { 115, new Guid("49999c78-5a8b-47be-8ebc-2759d68c513f"), 12, "Provident assumenda magni qui occaecati non est ut.\nBlanditiis omnis et quis ullam corporis fugiat et et sunt.", 3 },
                    { 116, new Guid("20c2265f-6e3e-4f92-ba29-99268cd75e1c"), 12, "Sit vel sed et maiores consequatur ut.\nEsse amet beatae voluptatibus.", 3 },
                    { 117, new Guid("a2744c33-f47f-45bf-bab2-db578ce188ad"), 12, "Iure quam cumque aspernatur labore qui consequatur.\nSed nobis quasi autem animi suscipit fugiat molestiae odio.", 4 },
                    { 118, new Guid("3dd03a50-3cb4-4af8-8f5a-0dc85e1e09be"), 12, "Voluptas molestias fugiat rerum laudantium corporis.\nTempore maiores enim eius consequuntur velit aut vel.", 5 },
                    { 119, new Guid("ab270229-05ce-43fc-ba5d-f599ff68d938"), 12, "Et maxime voluptates commodi deserunt est tempore.\nMagni sequi et exercitationem voluptas et.", 5 },
                    { 120, new Guid("1495958d-65b2-45f8-bf58-31f8ad531659"), 12, "Dolorem architecto quos magni laborum necessitatibus corporis.\nSuscipit culpa incidunt ratione.", 3 },
                    { 121, new Guid("56f7a100-79d5-4b70-be13-880281cafda5"), 13, "Odit voluptates a neque voluptas blanditiis id.\nExcepturi et vel cupiditate sed esse aut beatae.", 5 },
                    { 122, new Guid("25e29532-d69e-4422-83ce-449af6f8f943"), 13, "Tempora pariatur accusantium harum.\nQuia facere dolore dolorem deleniti.", 4 },
                    { 123, new Guid("8dddf28d-3c89-46ea-9b29-401453df20c1"), 13, "Exercitationem velit quia suscipit voluptatem repellendus soluta.\nSaepe velit saepe.", 1 },
                    { 124, new Guid("22fe5327-d885-470f-a815-973093596a3f"), 13, "Ut nobis et beatae.\nEt suscipit itaque possimus rerum assumenda ut a aut error.", 5 },
                    { 125, new Guid("f5cbf8dd-cda6-4b19-a1c0-d9c9b53493e2"), 13, "Quod assumenda voluptate qui et incidunt ea.\nUt vitae qui reiciendis eveniet magnam.", 4 },
                    { 126, new Guid("128bd28f-1c69-459a-8239-ecd6587439c8"), 13, "At fugit atque.\nOccaecati facere non magnam.", 5 },
                    { 127, new Guid("eabcecd7-e012-494b-89fc-308803706ff4"), 13, "Praesentium quis et est dolor in tempora.\nOmnis porro porro sequi ut doloremque et.", 1 },
                    { 128, new Guid("e82cba3e-4f5e-4010-a08f-781bf14ece8f"), 13, "Qui molestiae quo autem esse veniam neque enim.\nRerum et sunt.", 5 },
                    { 129, new Guid("1ebefbdb-804b-4430-a889-c04b95645201"), 13, "Voluptatem consequatur temporibus.\nVoluptatem ut aut est dolore quia delectus sit sint eveniet.", 1 },
                    { 130, new Guid("565ad8ef-4e4a-4e26-b591-c49610956562"), 13, "Enim eos inventore laboriosam minus tenetur ipsa quia.\nEt nihil illum sit voluptate deserunt nobis error.", 4 },
                    { 131, new Guid("9d202327-9226-4c4d-9c6b-731c9d0d60fb"), 14, "Nemo aut consequuntur.\nFacere aut quia vel animi fugiat omnis.", 2 },
                    { 132, new Guid("d39844cc-68dc-409d-8fc4-e2d994aa0b72"), 14, "Voluptatem dolores optio autem est.\nQuae optio quos.", 4 },
                    { 133, new Guid("17e3ea78-00f6-4a4c-973f-b7ae7881cbaf"), 14, "Debitis qui blanditiis quos nesciunt vel consequatur assumenda et.\nVelit non eveniet aut in rem dolor qui sunt omnis.", 4 },
                    { 134, new Guid("b840f771-a15e-430d-9699-5f6d5008c402"), 14, "Ad corporis voluptatem quis modi rerum qui et numquam qui.\nEius ipsum qui.", 2 },
                    { 135, new Guid("0a5b2b44-b062-4e10-98a0-d15d9299c152"), 14, "Similique voluptatem laudantium odio voluptatum in sed unde explicabo sed.\nFugit odio odit beatae nulla aut reiciendis rerum.", 4 },
                    { 136, new Guid("78487e28-aaa7-4a20-a0e0-14d7b2ddb1e3"), 14, "Nemo consectetur ducimus blanditiis repellendus eos.\nLaborum iste laborum deleniti est fuga fuga ut non.", 5 },
                    { 137, new Guid("b8c54f20-7309-4f63-884e-8e4b1cf7a4cb"), 14, "Natus veniam qui tempora eligendi unde vitae.\nLaudantium rerum aut quod.", 5 },
                    { 138, new Guid("034498ce-727d-4675-8a1d-2d5621d26e9a"), 14, "Officiis debitis labore veritatis culpa.\nEius reiciendis rem commodi.", 3 },
                    { 139, new Guid("2d31f25d-a978-4094-bc8c-ad5e6a543925"), 14, "Est ut a ipsum voluptates optio.\nSed ut ut et.", 1 },
                    { 140, new Guid("14724d42-4096-436a-be36-d1684293fbe9"), 14, "Eum corrupti dolores alias tenetur sunt aut voluptatem molestias.\nEum numquam exercitationem culpa mollitia et.", 1 },
                    { 141, new Guid("3bf9b260-5974-4aec-b264-d7a9783a676e"), 15, "Sed delectus asperiores deserunt minima sint.\nCorporis ipsa beatae similique corrupti voluptates sed est iste et.", 5 },
                    { 142, new Guid("87199eaa-b039-48ce-bb4a-ec9a7802d4e9"), 15, "Libero non tempora autem impedit architecto magnam cumque dolores.\nQuia esse exercitationem eos et quos alias.", 5 },
                    { 143, new Guid("9ea5d816-2311-435a-a5ee-cdf541b7c9fe"), 15, "Dolorum dolores neque esse ducimus quia ipsum dicta facere voluptates.\nUllam fugit recusandae rem est distinctio modi soluta.", 4 },
                    { 144, new Guid("cbe801ea-e751-4297-8855-2800d3e78324"), 15, "Blanditiis officiis fugit et ea alias eius quam est autem.\nCumque quae nam pariatur quia sunt odit tempore ex.", 3 },
                    { 145, new Guid("84e89bf2-7030-4d87-b5d9-54481cce1c2a"), 15, "Totam quia rerum.\nQuod doloribus quisquam ex magni est.", 1 },
                    { 146, new Guid("4a705d09-bc6f-4f9d-976b-4a9c8db83c0c"), 15, "Ea neque voluptatem cum reiciendis.\nOccaecati rerum aliquid odit.", 3 },
                    { 147, new Guid("23171e01-7ab0-44e4-b876-49d8458fa771"), 15, "Consequatur minus accusantium sit.\nAut facere fugit quo et ut dolorum est est.", 2 },
                    { 148, new Guid("874fd1cc-c2af-4812-be31-6d7f17434893"), 15, "Facere eos rerum est quaerat architecto facere eligendi et.\nDicta libero eius sed non accusantium dignissimos.", 4 },
                    { 149, new Guid("122b4e3b-a622-4c95-884d-3fbf503f3107"), 15, "In illo aut corrupti ea atque.\nSint dignissimos est est quis enim.", 1 },
                    { 150, new Guid("339d8bd0-79ad-4c8b-8b9c-ba8d93d6091a"), 15, "Est ut sit voluptas.\nEt qui repellat rerum.", 3 },
                    { 151, new Guid("8bb8c5a2-8497-4da6-8cc0-0af6aeb733b2"), 16, "Voluptas rem odit qui maxime eius vel quia.\nTempora voluptate possimus qui fugit asperiores sed mollitia ipsam quisquam.", 2 },
                    { 152, new Guid("7fb2f54c-4fa1-4690-af06-40fbd1858f5d"), 16, "Et ut delectus non est soluta aut suscipit vero dolor.\nAperiam consequuntur eius qui eos eum.", 1 },
                    { 153, new Guid("50983afc-2a25-4ce1-bede-a5b5bfe872b1"), 16, "Corporis nulla id rerum id.\nArchitecto vero blanditiis.", 3 },
                    { 154, new Guid("97f2baab-d33f-4646-8d2a-b2a248aee13c"), 16, "Veniam et rerum aut voluptatem.\nEt soluta nihil officiis.", 5 },
                    { 155, new Guid("28b0d66e-040c-4f3d-8e62-8dca608cead6"), 16, "Fuga corporis est voluptas eos rerum rerum autem quibusdam modi.\nEnim labore omnis ducimus aliquam.", 4 },
                    { 156, new Guid("82760b7f-6c7c-473c-a118-63682b98ecab"), 16, "Assumenda sit quisquam et optio et maxime.\nEt nobis ipsum et iusto.", 2 },
                    { 157, new Guid("cb0a2c2e-7b64-4673-9b06-5ef0447b01de"), 16, "Voluptas ut voluptatem.\nQuo ad voluptatem voluptatem necessitatibus.", 4 },
                    { 158, new Guid("066a4694-e8ae-4552-a0ec-9f70278228ed"), 16, "Enim et doloremque non et totam voluptatem ut praesentium.\nExercitationem rerum rerum velit blanditiis earum voluptas esse repudiandae.", 1 },
                    { 159, new Guid("637ee335-696b-43a8-ad9a-35a296d72fbf"), 16, "Iure voluptatem consequatur qui eos aspernatur quas eveniet et.\nBeatae assumenda qui eum reprehenderit cum voluptatibus quia ad.", 5 },
                    { 160, new Guid("77c79150-3704-46d1-8076-c576e3b2690f"), 16, "Saepe in aut est odio harum velit ab non est.\nQuo asperiores quia.", 4 },
                    { 161, new Guid("be90583c-9bfe-42c4-839c-94d66f144398"), 17, "Eos et architecto tenetur.\nAtque omnis assumenda sunt molestias.", 2 },
                    { 162, new Guid("7bfb2433-3671-4945-b473-baac823a44fb"), 17, "Ex voluptatem maxime est magni.\nDicta voluptas temporibus.", 5 },
                    { 163, new Guid("2a09d28d-7d02-4243-8a2b-41e9397d42d8"), 17, "Nihil quo tempore sequi aut possimus vero dolor alias.\nVoluptatem ducimus veniam incidunt nihil et qui.", 5 },
                    { 164, new Guid("86c642fa-4c1c-452f-9c5c-0f547c94d79f"), 17, "Ex voluptatem enim autem adipisci consectetur dignissimos.\nModi aut vel quia consectetur.", 1 },
                    { 165, new Guid("55da4db6-4b98-48e8-8f45-54a386abc42a"), 17, "Sit quidem sed sunt architecto sit qui dolor eveniet.\nNihil qui eos ipsa.", 3 },
                    { 166, new Guid("a78fb887-1623-43a7-b7de-da5cb283651b"), 17, "Culpa et suscipit ratione voluptatem consectetur occaecati vel optio dignissimos.\nIure ullam dolor dolores vel est harum illum tempora.", 5 },
                    { 167, new Guid("c908b65f-2593-488e-99e4-de9c4e984682"), 17, "Ut quo ut harum incidunt mollitia labore quos.\nOmnis repudiandae eum deserunt et neque dolorum quidem.", 5 },
                    { 168, new Guid("89ae2b6a-4966-4ff5-a4f8-1c620b41f6d5"), 17, "Et non quia amet similique explicabo et quam modi.\nProvident fugiat reiciendis natus.", 2 },
                    { 169, new Guid("6baec4ff-c6f7-4092-adac-afafc8a56557"), 17, "Ad aut optio consequatur quia dolore inventore et quos.\nIn quia temporibus veniam unde itaque tenetur aperiam.", 3 },
                    { 170, new Guid("0488e2f8-4d9a-42ea-8017-1bd71acc82aa"), 17, "Amet perspiciatis tempore.\nConsequatur voluptatem porro.", 5 },
                    { 171, new Guid("a7f7a847-da5b-4acd-afec-89f214cd3b0d"), 18, "Sunt deleniti quis consequatur earum eos asperiores consequatur.\nAut in et quod assumenda.", 5 },
                    { 172, new Guid("399389a5-a6ce-4689-a2cf-54b613784d6e"), 18, "Adipisci quaerat unde velit sed et blanditiis eius eius nihil.\nCorporis eveniet fugit quisquam aut.", 5 },
                    { 173, new Guid("2703bccf-4ca4-4247-aac8-b9fc1658a8f7"), 18, "Recusandae a tempora et eos a repellendus quia.\nVero vel rerum ut illo maxime modi repellendus.", 3 },
                    { 174, new Guid("6bd01053-1e54-404e-928c-674d2ea8ec15"), 18, "Dolorum quam quaerat sequi dolores in.\nAssumenda repellat necessitatibus.", 3 },
                    { 175, new Guid("b5c5363e-7f45-4d0b-b5fb-c12998a0e4c4"), 18, "Qui qui possimus perferendis tempore laborum in consectetur facere est.\nAut omnis blanditiis doloremque et incidunt dolor iure ad adipisci.", 5 },
                    { 176, new Guid("d3fe8dbf-a0b2-4897-bf40-2b5220b25a24"), 18, "Numquam quia beatae ad quasi molestiae in consequatur.\nMagni ipsam rerum aliquid fugit numquam qui totam.", 3 },
                    { 177, new Guid("13966934-b2a5-4921-aaf1-b5e2a76e05ee"), 18, "Nesciunt tempora aliquid ad nesciunt est.\nExpedita laborum molestias at labore doloribus distinctio eius.", 4 },
                    { 178, new Guid("5bc17e87-1585-47c1-a8b8-c8af82f125a1"), 18, "Veniam et sapiente fugit.\nDebitis sunt dolor.", 2 },
                    { 179, new Guid("507b3b03-9bcc-4ad4-9d93-9a86f7e12b75"), 18, "Ab laudantium itaque dolores nihil facere error est illo.\nConsequatur ipsam rerum.", 3 },
                    { 180, new Guid("a1257b1e-21dc-4a48-a391-f088d470ab11"), 18, "Quod dolorem sed officia molestias.\nAutem dolorem ex molestias iusto dicta quas earum quo quaerat.", 2 },
                    { 181, new Guid("8316e95f-e54a-47b3-8729-d7a84a39babf"), 19, "Ab corporis eos distinctio voluptatem aliquid ullam placeat.\nNobis suscipit nihil qui labore odit perspiciatis aspernatur debitis et.", 5 },
                    { 182, new Guid("9210f8fc-95d0-4419-b659-14b9c9707458"), 19, "Ipsa dolorum occaecati eum sed pariatur beatae.\nNemo rerum et omnis placeat in hic consectetur.", 5 },
                    { 183, new Guid("828d82aa-c6e4-4c19-9aea-16624b5542d0"), 19, "Veniam quaerat ut ut perferendis expedita rerum.\nMolestiae provident error et laborum est sapiente qui inventore tempora.", 1 },
                    { 184, new Guid("0c7c0877-b277-4664-8089-23d82be8655a"), 19, "Iusto voluptas earum ut sapiente explicabo ut qui dolores.\nRerum nihil ut dolor excepturi in quia.", 3 },
                    { 185, new Guid("e1be4f9d-c2f0-4512-8eac-fb01e316a638"), 19, "Error alias eum quos.\nAlias dolorem incidunt aut ea.", 4 },
                    { 186, new Guid("44e77814-1a58-4649-a38a-79cefb5aaa5e"), 19, "Omnis unde voluptatibus et autem omnis doloremque.\nCommodi voluptas et quis nobis quae ad.", 1 },
                    { 187, new Guid("285d185e-d609-4aa7-8519-8ed769d30b66"), 19, "Laboriosam vel dolores.\nAmet voluptatibus aut expedita sit suscipit eligendi.", 1 },
                    { 188, new Guid("ce615662-e678-47ba-b809-30c34cbd963e"), 19, "At ut atque et deserunt qui officiis error et.\nDolor incidunt sequi sapiente inventore dolorem.", 3 },
                    { 189, new Guid("e0c11496-f51b-4813-9640-1ded60fbbc89"), 19, "Est deleniti repellendus soluta quibusdam aut.\nIusto voluptatem omnis.", 2 },
                    { 190, new Guid("c4616931-68a0-4c95-9a73-fbde136ff5b2"), 19, "Ea quam molestiae aut sed sunt sit sit rerum.\nNon deserunt esse odio vitae consequatur sunt.", 1 },
                    { 191, new Guid("ce53f488-5642-43dd-954e-912e9eaf0fc0"), 20, "Reiciendis dignissimos et delectus error.\nUnde cupiditate quo pariatur quibusdam sed quibusdam doloribus.", 2 },
                    { 192, new Guid("7ee0de1e-4e68-4006-805e-1f9a60ed8531"), 20, "Amet nemo quae beatae voluptatem voluptas reprehenderit.\nPossimus sit consequatur rerum.", 1 },
                    { 193, new Guid("a012159a-a775-4690-9e4d-1cb06c6e7588"), 20, "Dicta qui perferendis dignissimos.\nDelectus odio aut omnis provident.", 3 },
                    { 194, new Guid("540a4b89-fa69-41fd-807d-581b0ec6ac76"), 20, "Enim eos aut aperiam necessitatibus quis unde quia modi repudiandae.\nNisi delectus quia hic.", 4 },
                    { 195, new Guid("84b1ed70-a04a-4f2d-ac98-3cb9dd791fe5"), 20, "Magnam fuga dignissimos hic cumque.\nAutem fugiat alias.", 1 },
                    { 196, new Guid("74892c26-1aaf-4f91-b173-fbc7883b309f"), 20, "Sit laudantium non repellat quibusdam cupiditate quis aut nam voluptatum.\nEaque quas id explicabo et ipsa necessitatibus consequatur et.", 5 },
                    { 197, new Guid("4a1a40bc-eb18-4bf2-a1aa-7134a5add886"), 20, "Excepturi sequi dolores et velit iure a eum eligendi illum.\nDelectus ullam iusto cumque est omnis commodi ea.", 3 },
                    { 198, new Guid("e3d38f1e-1a83-4021-9d7f-e12bd04eff08"), 20, "Debitis earum voluptas.\nOfficiis fugit nihil praesentium fuga ea necessitatibus veniam.", 3 },
                    { 199, new Guid("65630e90-0223-4dc3-b1e5-967cb5ac9d61"), 20, "In labore dignissimos et sit perspiciatis minus.\nRerum recusandae consequuntur exercitationem autem et.", 5 },
                    { 200, new Guid("2b434721-d38a-4d84-9498-e6f55fee1d31"), 20, "Non reiciendis ipsa corrupti ratione placeat at provident illo eveniet.\nDistinctio laborum omnis similique quidem rerum blanditiis veniam in officia.", 2 }
                });

            migrationBuilder.InsertData(
                table: "Reactions",
                columns: new[] { "Id", "Guid", "PostId", "UserId" },
                values: new object[,]
                {
                    { 1, new Guid("988b8acb-4a90-44d7-9af4-b544b1fb3312"), 1, 2 },
                    { 2, new Guid("88eb39ff-d77b-4c90-a065-c6334855bcaa"), 1, 3 },
                    { 3, new Guid("0fd2c9f2-0dea-495e-b27d-9a52732af9c2"), 1, 3 },
                    { 4, new Guid("5b061067-0630-4a4c-88c0-03bbf0f6092c"), 1, 4 },
                    { 5, new Guid("87c817c3-4450-45e8-85f5-ad8d19e69074"), 1, 5 },
                    { 6, new Guid("bd227626-f6ee-44f3-8512-f8f5a2c71a88"), 2, 2 },
                    { 7, new Guid("7ab8cfdd-be10-4558-a106-fcd8e6a2d34d"), 2, 1 },
                    { 8, new Guid("04354f2f-229b-4cea-bae8-873a21d66252"), 2, 2 },
                    { 9, new Guid("56ec46f5-4677-4a22-b66b-6ac5bebce24b"), 2, 3 },
                    { 10, new Guid("57b4b244-49f2-4c4d-93d5-d8880f6a0668"), 2, 2 },
                    { 11, new Guid("55b72c03-108e-41eb-8403-40123c0b31ba"), 3, 5 },
                    { 12, new Guid("c11217dd-19b0-4a0e-b569-940338921915"), 3, 3 },
                    { 13, new Guid("245ad50b-1a52-42dc-b609-1e4395d03c70"), 3, 4 },
                    { 14, new Guid("a2582b9c-4269-4ecf-ba32-1c6ba4348cf3"), 3, 5 },
                    { 15, new Guid("9eed450d-f31f-48ab-a4ef-41809a49e293"), 3, 3 },
                    { 16, new Guid("d38b3cca-2e73-4ce7-813d-5b4f74da114a"), 4, 3 },
                    { 17, new Guid("42d2046a-fc99-4d98-9d0c-4d53c19bae19"), 4, 3 },
                    { 18, new Guid("ab71c876-9d48-449d-a2be-71c0d8fa9bd7"), 4, 4 },
                    { 19, new Guid("e94e6dcc-cc9b-4ec5-b645-a65ea1ceaf13"), 4, 3 },
                    { 20, new Guid("70739c73-6898-4674-9598-e6be1f3f7456"), 4, 3 },
                    { 21, new Guid("9a0ca3b6-282a-439c-9e7b-53d415a0d3f0"), 5, 1 },
                    { 22, new Guid("3ac6ee4e-bd57-4b83-91e2-4425a87af97b"), 5, 5 },
                    { 23, new Guid("e70db826-ddd6-47af-b066-d7159e2888dd"), 5, 1 },
                    { 24, new Guid("0acf15ea-18cc-4758-8d2e-202d8c2bd20c"), 5, 1 },
                    { 25, new Guid("73dfae71-7162-43b0-9226-5d16e72f2617"), 5, 5 },
                    { 26, new Guid("ebb3262b-c1e6-4430-828c-15621dc67d9e"), 6, 5 },
                    { 27, new Guid("fcab8045-ae2a-4e82-b9f7-0990a69ca608"), 6, 5 },
                    { 28, new Guid("ff2e961f-bffc-49aa-a9ab-1323d58d20bd"), 6, 1 },
                    { 29, new Guid("3c7005df-3de6-474f-b932-26920e38bf2f"), 6, 3 },
                    { 30, new Guid("ff6441a4-98da-4d71-8bea-1a0644a4eb6c"), 6, 5 },
                    { 31, new Guid("2a23a81c-d0bc-4bfd-a103-0a4f59fb065c"), 7, 5 },
                    { 32, new Guid("4794e795-abd2-403b-9fd3-850ac5a75082"), 7, 3 },
                    { 33, new Guid("140d2220-8a62-4c1b-aba5-487588ffae86"), 7, 2 },
                    { 34, new Guid("b34d8e37-ccdc-4aab-a50d-fda76e99a5ac"), 7, 3 },
                    { 35, new Guid("0a3ed264-a8e8-4444-a592-31f045b1af06"), 7, 2 },
                    { 36, new Guid("e2c691f7-92bb-4de2-86c7-acaf12bf13d1"), 8, 5 },
                    { 37, new Guid("e7897c33-b296-483d-883e-8f3bd397b26c"), 8, 4 },
                    { 38, new Guid("9c1c53ab-6c19-43be-b6d3-ee98a8fafc22"), 8, 2 },
                    { 39, new Guid("5e951707-3762-4dde-a120-1e1e47e7df80"), 8, 1 },
                    { 40, new Guid("d95bfb8a-70c7-48a7-b147-f0109fbddf9f"), 8, 1 },
                    { 41, new Guid("55e97c4b-459d-4a04-971a-9e6aa1419dd6"), 9, 3 },
                    { 42, new Guid("18347886-ffc9-4bf8-863d-a2282b6449ec"), 9, 5 },
                    { 43, new Guid("c5c2080c-1677-4639-b962-05374fd6c1c8"), 9, 2 },
                    { 44, new Guid("3ebf3acc-ecd6-4a6d-84ca-97ae628c9029"), 9, 1 },
                    { 45, new Guid("dd44f84a-35c5-4ee1-8fe8-6e50cfb83ba4"), 9, 1 },
                    { 46, new Guid("fbbd1e1b-2914-4635-886d-637521ab86e9"), 10, 3 },
                    { 47, new Guid("0c15609e-dc4a-4e7d-a4df-061ffbf39443"), 10, 1 },
                    { 48, new Guid("6facf161-01a2-41e4-9637-823ba74e1a89"), 10, 5 },
                    { 49, new Guid("f283d0bf-4359-408a-8308-904b5c676feb"), 10, 1 },
                    { 50, new Guid("6bb7a422-e82b-47c8-9b76-6c0f1c26a868"), 10, 5 },
                    { 51, new Guid("4e02a793-3c17-4e80-b791-3aa5efba2f7e"), 11, 5 },
                    { 52, new Guid("f7ea0af2-d151-44cf-b29a-2d36695f4594"), 11, 5 },
                    { 53, new Guid("585da5c8-9e9a-4cce-bcf9-9abaa0362ae8"), 11, 5 },
                    { 54, new Guid("ebacb4e6-cbe3-4abb-97ec-36038d666cce"), 11, 1 },
                    { 55, new Guid("a93bd995-1c07-4bdd-8fc4-dc1cdc21d93f"), 11, 1 },
                    { 56, new Guid("dc9b05a0-72a5-4da2-82f6-2dbb960b55a0"), 12, 3 },
                    { 57, new Guid("ce3592aa-a268-4d8d-bc41-6f183ca52e86"), 12, 2 },
                    { 58, new Guid("7647059f-c6f4-457c-a1fd-744f8492beed"), 12, 1 },
                    { 59, new Guid("e3ac37d4-39cb-4009-a63d-52d364d5652a"), 12, 5 },
                    { 60, new Guid("58d487cb-3664-4ed8-ad5a-88c3d9ea3ba0"), 12, 4 },
                    { 61, new Guid("9fff14a7-4c83-4f2c-8449-a8c50ae7e1f0"), 13, 1 },
                    { 62, new Guid("08a9b131-809a-4b53-9344-7969a705880e"), 13, 5 },
                    { 63, new Guid("1ea36568-b9d5-45d9-b360-5e1f463c165c"), 13, 4 },
                    { 64, new Guid("b387d57a-ef30-4c17-a359-ef15e75b3c82"), 13, 2 },
                    { 65, new Guid("4074ff16-b948-4664-9fc9-becbf89ad9c8"), 13, 3 },
                    { 66, new Guid("4525ab15-29de-4229-88e0-be67acf190fa"), 14, 5 },
                    { 67, new Guid("2814a503-ebc7-43ba-ab4b-aee8f28cc6b7"), 14, 4 },
                    { 68, new Guid("01884231-6324-401c-90bd-3f1fe92bc276"), 14, 5 },
                    { 69, new Guid("a459f7e6-4713-4050-805d-dd0db1567caa"), 14, 1 },
                    { 70, new Guid("3e441f31-10c2-4629-ab79-64ada6304a63"), 14, 2 },
                    { 71, new Guid("bf314c65-aa61-4c18-a0c1-38734d3337b1"), 15, 5 },
                    { 72, new Guid("b4a0b58b-774e-4e7e-9715-98d07a93852c"), 15, 5 },
                    { 73, new Guid("2a8a5be9-cc3c-4f67-8d75-b8fbd24865d7"), 15, 1 },
                    { 74, new Guid("b050248e-7a43-4e36-b7a5-f1b156f86c36"), 15, 1 },
                    { 75, new Guid("a253322e-57ce-4903-b366-05519a697fe7"), 15, 4 },
                    { 76, new Guid("48c45be9-fcc7-4bcb-a0d8-e290294332f3"), 16, 1 },
                    { 77, new Guid("cc2f8f75-cdf9-421c-9a78-56e81c718fb2"), 16, 5 },
                    { 78, new Guid("63e58cd8-de25-4ab3-9b64-ca1d183188c9"), 16, 5 },
                    { 79, new Guid("a58be0b2-24b1-4ad6-a537-53e5e1ca6788"), 16, 1 },
                    { 80, new Guid("6b6c8e25-8729-45ce-ad0d-a0a85fdaa31a"), 16, 4 },
                    { 81, new Guid("78f1c0eb-0b44-46aa-b93e-0c87f015adb9"), 17, 4 },
                    { 82, new Guid("e0b16bd3-2f5c-477a-9871-3c4ac85b8c8e"), 17, 4 },
                    { 83, new Guid("f43c1302-9d73-4ccd-8cfc-54a59305a7fd"), 17, 2 },
                    { 84, new Guid("f66e6e53-d157-4620-bd5b-524a7350db6d"), 17, 3 },
                    { 85, new Guid("efb0ad94-02df-4bf7-bf09-111828e7f501"), 17, 4 },
                    { 86, new Guid("321ed2c0-d4bc-459d-b0dc-d963940e6014"), 18, 1 },
                    { 87, new Guid("0f2af0db-4b1a-4742-82c0-f887934f4e7b"), 18, 3 },
                    { 88, new Guid("ed2814f2-91b2-4250-8503-c8cb4b946b46"), 18, 2 },
                    { 89, new Guid("8b958ba5-4c44-48eb-9877-ab8709e294a2"), 18, 1 },
                    { 90, new Guid("3d683c1a-d909-4535-8142-ba70653b2d92"), 18, 3 },
                    { 91, new Guid("ac1ce504-cb5e-48aa-9a82-021b1a55bff8"), 19, 5 },
                    { 92, new Guid("c9d8fdbb-d65b-4cd8-ac32-cd7cfcd872f7"), 19, 3 },
                    { 93, new Guid("0c74484a-7c21-4897-9079-640a9cfafc0e"), 19, 4 },
                    { 94, new Guid("d5ca7c20-a8ac-44b9-94ad-93d1d2c0d696"), 19, 3 },
                    { 95, new Guid("e3aa4925-94c2-4b0f-9245-c6e4be0432d6"), 19, 3 },
                    { 96, new Guid("2f6a6927-d4cb-43ab-a6cb-d40b1de54169"), 20, 3 },
                    { 97, new Guid("c2205705-3b51-4fb4-932b-3b71530a86c5"), 20, 5 },
                    { 98, new Guid("76cb534e-aa91-40b5-8848-848cfb4e1500"), 20, 3 },
                    { 99, new Guid("2431a2df-0ee4-4e7e-9ef3-9d91c96b17de"), 20, 2 },
                    { 100, new Guid("b41eda09-ff62-436b-b234-0836f5ca4fb0"), 20, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlbumImage_ImageId",
                table: "AlbumImage",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Albums_UserId",
                table: "Albums",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ThumbnailId",
                table: "Images",
                column: "ThumbnailId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_UserId",
                table: "Images",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_ImageId",
                table: "Posts",
                column: "ImageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_StatusId",
                table: "Posts",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reactions_PostId",
                table: "Reactions",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Reactions_UserId",
                table: "Reactions",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlbumImage");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Reactions");

            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Thumbnails");
        }
    }
}
