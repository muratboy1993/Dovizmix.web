using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AlphabeticCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Category = table.Column<string>(unicode: false, maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlphabeticCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Cities = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComplaintTopics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Topic = table.Column<string>(unicode: false, maxLength: 75, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplaintTopics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Name = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    FlagCode = table.Column<string>(unicode: false, maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Genders = table.Column<string>(unicode: false, maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Job",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Jobs = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<int>(unicode: false, nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Application = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Logged = table.Column<DateTime>(unicode: false, nullable: false),
                    Level = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Message = table.Column<string>(unicode: false, nullable: true),
                    Logger = table.Column<string>(unicode: false, maxLength: 250, nullable: true),
                    CallSite = table.Column<string>(unicode: false, maxLength: 1024, nullable: true),
                    Exception = table.Column<string>(unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MarketTypes",
                columns: table => new
                {
                    Id = table.Column<int>(unicode: false, nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Type = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    RoleName = table.Column<string>(unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Username = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    PasswordHash = table.Column<string>(unicode: false, maxLength: 150, nullable: false),
                    Email = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    IsEmailConfirmed = table.Column<byte>(type: "tinyint(1)", nullable: false, defaultValue: (byte)0),
                    IsPhoneNumberConfirmed = table.Column<byte>(type: "tinyint(1)", nullable: false, defaultValue: (byte)0),
                    RegistrationDateTime = table.Column<DateTime>(nullable: false),
                    ActivationDateTime = table.Column<DateTime>(nullable: true),
                    ActivationCode = table.Column<string>(unicode: false, maxLength: 6, nullable: false),
                    ActivationCodeExpirationDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EconomicDictionary",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    CategoryId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Seourl = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Content = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EconomicDictionary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EconomicDictionary_AlphabeticCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "AlphabeticCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Formations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    CategoryId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Seourl = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Content = table.Column<string>(nullable: true),
                    Graphic = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Formations_AlphabeticCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "AlphabeticCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OpenCloseMarkets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    CountryId = table.Column<int>(nullable: false),
                    OpenCloseIcon = table.Column<string>(nullable: true),
                    OpenDateTime = table.Column<DateTime>(nullable: false),
                    CloseDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenCloseMarkets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpenCloseMarkets_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Markets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    TypeId = table.Column<int>(nullable: false),
                    Code = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Unit = table.Column<byte>(nullable: false),
                    Icon = table.Column<string>(unicode: false, maxLength: 150, nullable: false),
                    SeoUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Markets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Markets_MarketTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "MarketTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BannedUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    UserId = table.Column<int>(unicode: false, nullable: false),
                    BanStartDateTime = table.Column<DateTime>(unicode: false, nullable: false),
                    BanEndDateTime = table.Column<DateTime>(unicode: false, nullable: false),
                    BanReason = table.Column<string>(unicode: false, maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BannedUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BannedUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Blocks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    BlockedByUserId = table.Column<int>(nullable: false),
                    BlockedUserId = table.Column<int>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blocks_Users_BlockedByUserId",
                        column: x => x.BlockedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Blocks_Users_BlockedUserId",
                        column: x => x.BlockedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeletedUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    UserId = table.Column<int>(nullable: false),
                    DeleteDateTime = table.Column<DateTime>(unicode: false, nullable: false),
                    DeleteReason = table.Column<string>(unicode: false, maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeletedUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeletedUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FrozenUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    UserId = table.Column<int>(nullable: false),
                    FrozenDateTime = table.Column<DateTime>(unicode: false, nullable: false),
                    FrozenReason = table.Column<string>(unicode: false, maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrozenUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FrozenUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    SubscribedByUserId = table.Column<int>(nullable: false),
                    SubscribedUserId = table.Column<int>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subscriptions_Users_SubscribedByUserId",
                        column: x => x.SubscribedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subscriptions_Users_SubscribedUserId",
                        column: x => x.SubscribedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserComplaints",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    TopicOfComplaintId = table.Column<int>(nullable: false),
                    ComplainantUserId = table.Column<int>(nullable: false),
                    ComplainedUserId = table.Column<int>(nullable: false),
                    ComplaintDescription = table.Column<string>(unicode: false, maxLength: 500, nullable: false),
                    ComplaintDateTime = table.Column<DateTime>(nullable: false),
                    State = table.Column<string>(unicode: false, maxLength: 50, nullable: true, defaultValue: "İşleme alındı.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserComplaints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserComplaints_Users_ComplainantUserId",
                        column: x => x.ComplainantUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserComplaints_Users_ComplainedUserId",
                        column: x => x.ComplainedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserComplaints_ComplaintTopics_TopicOfComplaintId",
                        column: x => x.TopicOfComplaintId,
                        principalTable: "ComplaintTopics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    UserId = table.Column<int>(nullable: false),
                    LastLoginDateTime = table.Column<DateTime>(nullable: false),
                    LastLogoutDateTime = table.Column<DateTime>(nullable: true),
                    IpAddress = table.Column<string>(unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    UserId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    Surname = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    UserLevel = table.Column<byte>(type: "tinyint", unicode: false, nullable: false, defaultValue: (byte)0),
                    Job = table.Column<string>(unicode: false, maxLength: 30, nullable: true, defaultValue: "Belirtmek istemiyorum."),
                    DateOfBirth = table.Column<DateTime>(type: "date", unicode: false, nullable: true),
                    Gender = table.Column<string>(unicode: false, maxLength: 30, nullable: true, defaultValue: "Belirtmek istemiyorum."),
                    PhoneNumber = table.Column<string>(unicode: false, maxLength: 11, nullable: true),
                    ExperienceScore = table.Column<int>(unicode: false, nullable: false, defaultValue: 0),
                    City = table.Column<string>(unicode: false, maxLength: 30, nullable: true, defaultValue: "Belirtmek istemiyorum."),
                    TwitterProfile = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    FacebookProfile = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    InstagramProfile = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    AvatarPath = table.Column<string>(unicode: false, maxLength: 150, nullable: true, defaultValue: "empty.png"),
                    PersonalOpinion = table.Column<string>(unicode: false, maxLength: 5000, nullable: true),
                    LastPageViewed = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    LastPageViewedDateTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfiles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    UserId = table.Column<int>(nullable: false),
                    Message = table.Column<string>(unicode: false, maxLength: 5000, nullable: false),
                    CommentParentId = table.Column<int>(nullable: true),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<byte>(type: "tinyint(1)", unicode: false, nullable: false, defaultValue: (byte)0),
                    IsPinned = table.Column<byte>(type: "tinyint(1)", unicode: false, nullable: false, defaultValue: (byte)0),
                    CommentIp = table.Column<string>(unicode: false, nullable: false),
                    MarketId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Markets_MarketId",
                        column: x => x.MarketId,
                        principalTable: "Markets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EconomicCalendar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Subject = table.Column<string>(nullable: true),
                    CountryId = table.Column<int>(nullable: false),
                    MarketId = table.Column<int>(nullable: false),
                    Importance = table.Column<int>(nullable: false),
                    SubjectDateTime = table.Column<DateTime>(nullable: false),
                    Actual = table.Column<double>(unicode: false, maxLength: 10, nullable: false),
                    Forecast = table.Column<double>(unicode: false, maxLength: 10, nullable: false),
                    Previous = table.Column<double>(unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EconomicCalendar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EconomicCalendar_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EconomicCalendar_Markets_MarketId",
                        column: x => x.MarketId,
                        principalTable: "Markets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exchanges",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    MarketId = table.Column<int>(nullable: false),
                    LastBuyPrice = table.Column<double>(unicode: false, nullable: false),
                    LastSellPrice = table.Column<double>(unicode: false, nullable: false),
                    MarketCup = table.Column<double>(nullable: false),
                    MarketVolume = table.Column<double>(nullable: false),
                    MarketSupply = table.Column<double>(nullable: false),
                    Rate = table.Column<double>(unicode: false, nullable: false),
                    CreatedDateTime = table.Column<DateTime>(unicode: false, nullable: false),
                    LastUpdatedDateTime = table.Column<DateTime>(unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exchanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exchanges_Markets_MarketId",
                        column: x => x.MarketId,
                        principalTable: "Markets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Investments",
                columns: table => new
                {
                    Id = table.Column<int>(unicode: false, nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    UserId = table.Column<int>(nullable: false),
                    MarketId = table.Column<int>(nullable: false),
                    Amount = table.Column<double>(unicode: false, nullable: false),
                    Price = table.Column<double>(unicode: false, nullable: false),
                    Note = table.Column<string>(unicode: false, nullable: true),
                    PurchaseDateTime = table.Column<DateTime>(type: "DATE", unicode: false, nullable: false),
                    CreatedDateTime = table.Column<DateTime>(unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Investments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Investments_Markets_MarketId",
                        column: x => x.MarketId,
                        principalTable: "Markets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Investments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommentComplaints",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    UserId = table.Column<int>(nullable: false),
                    CommentId = table.Column<int>(nullable: false),
                    TopicId = table.Column<int>(nullable: false),
                    ComplaintDescription = table.Column<string>(unicode: false, maxLength: 500, nullable: false),
                    ComplaintDateTime = table.Column<DateTime>(nullable: false),
                    State = table.Column<string>(unicode: false, maxLength: 50, nullable: true, defaultValue: "İşleme alınmıştır.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentComplaints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentComplaints_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommentComplaints_ComplaintTopics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "ComplaintTopics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommentComplaints_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommentGraphics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    CommentId = table.Column<int>(nullable: false),
                    GraphicPath = table.Column<string>(unicode: false, maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentGraphics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentGraphics_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommentLikes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    CommentId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    LikedOrDisliked = table.Column<byte>(type: "tinyint(1)", unicode: false, nullable: false),
                    LikedDateTime = table.Column<DateTime>(unicode: false, nullable: false),
                    IsShown = table.Column<byte>(type: "tinyint(1)", unicode: false, nullable: false, defaultValue: (byte)0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentLikes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentLikes_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommentLikes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommentNotifications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    CommentId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    IsShown = table.Column<byte>(type: "tinyint(1)", unicode: false, nullable: false, defaultValue: (byte)0),
                    IsDelete = table.Column<byte>(type: "tinyint(1)", unicode: false, nullable: false, defaultValue: (byte)0),
                    CreateDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentNotifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentNotifications_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommentNotifications_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommentPolls",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    CommentId = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentPolls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentPolls_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommentPollOptions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    PollId = table.Column<int>(nullable: false),
                    Options = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentPollOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentPollOptions_CommentPolls_PollId",
                        column: x => x.PollId,
                        principalTable: "CommentPolls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommentPollVotes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    UserId = table.Column<int>(nullable: false),
                    PollOptionId = table.Column<int>(nullable: false),
                    CreateDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentPollVotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentPollVotes_CommentPollOptions_PollOptionId",
                        column: x => x.PollOptionId,
                        principalTable: "CommentPollOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommentPollVotes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AlphabeticCategories",
                columns: new[] { "Id", "Category" },
                values: new object[,]
                {
                    { 1, "A" },
                    { 26, "Z" },
                    { 25, "Y" },
                    { 24, "X" },
                    { 22, "V" },
                    { 21, "U" },
                    { 20, "T" },
                    { 19, "S" },
                    { 18, "R" },
                    { 17, "Q" },
                    { 16, "P" },
                    { 15, "O" },
                    { 14, "N" },
                    { 23, "W" },
                    { 12, "L" },
                    { 13, "M" },
                    { 2, "B" },
                    { 3, "C" },
                    { 5, "E" },
                    { 6, "F" },
                    { 4, "D" },
                    { 8, "H" },
                    { 9, "I" },
                    { 10, "J" },
                    { 11, "K" },
                    { 7, "G" }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "Cities" },
                values: new object[,]
                {
                    { 60, "60 Tokat" },
                    { 53, "53 Rize" },
                    { 59, "59 Tekirdağ" },
                    { 58, "58 Sivas" },
                    { 57, "57 Sinop" },
                    { 56, "56 Siirt" },
                    { 55, "55 Samsun" },
                    { 52, "52 Ordu" },
                    { 46, "46 K.maraş" },
                    { 50, "50 Nevşehir" },
                    { 49, "49 Muş" },
                    { 48, "48 Muğla" },
                    { 47, "47 Mardin" },
                    { 45, "45 Manisa" },
                    { 44, "44 Malatya" },
                    { 43, "43 Kütahya" },
                    { 61, "61 Trabzon" },
                    { 51, "51 Niğde" },
                    { 62, "62 Tunceli" },
                    { 75, "75 Ardahan" },
                    { 64, "64 Uşak" },
                    { 81, "81 Düzce" },
                    { 80, "80 Osmaniye" },
                    { 79, "79 Kilis" },
                    { 78, "78 Karabük" },
                    { 77, "77 Yalova" },
                    { 76, "76 Iğdır" },
                    { 42, "42 Konya" },
                    { 74, "74 Bartın" },
                    { 73, "73 Şırnak" },
                    { 72, "72 Batman" },
                    { 71, "71 Kırıkkale" },
                    { 70, "70 Karaman" },
                    { 69, "69 Bayburt" },
                    { 68, "68 Aksaray" },
                    { 67, "67 Zonguldak" },
                    { 66, "66 Yozgat" },
                    { 65, "65 Van" },
                    { 63, "63 Şanlıurfa" },
                    { 41, "41 Kocaeli" },
                    { 54, "54 Sakarya" },
                    { 39, "39 Kırklareli" },
                    { 16, "16 Bursa" },
                    { 15, "15 Burdur" },
                    { 14, "14 Bolu" },
                    { 13, "13 Bitlis" },
                    { 12, "12 Bingöl" },
                    { 11, "11 Bilecik" },
                    { 10, "10 Balıkesir" },
                    { 9, "09 Aydın" },
                    { 8, "08 Artvin" },
                    { 7, "07 Antalya" },
                    { 6, "06 Ankara" },
                    { 5, "05 Amasya" },
                    { 4, "04 Ağrı" },
                    { 3, "03 Afyon" },
                    { 2, "02 Adıyaman" },
                    { 1, "01 Adana" },
                    { 40, "40 Kırşehir" },
                    { 17, "17 Çanakkale" },
                    { 18, "18 Çankırı" },
                    { 19, "19 Çorum" },
                    { 29, "29 Gümüşhane" },
                    { 35, "35 İzmir" },
                    { 34, "34 İstanbul" },
                    { 33, "33 İçel (Mersin)" },
                    { 32, "32 Isparta" },
                    { 31, "31 Hatay" },
                    { 30, "30 Hakkari" },
                    { 20, "20 Denizli" },
                    { 36, "36 Kars" },
                    { 28, "28 Giresun" },
                    { 27, "27 Gaziantep" },
                    { 26, "26 Eskişehir" },
                    { 25, "25 Erzurum" },
                    { 24, "24 Erzincan" },
                    { 23, "23 Elazığ" },
                    { 22, "22 Edirne" },
                    { 21, "21 Diyarbakır" },
                    { 38, "38 Kayseri" },
                    { 37, "37 Kastamonu" }
                });

            migrationBuilder.InsertData(
                table: "ComplaintTopics",
                columns: new[] { "Id", "Topic" },
                values: new object[,]
                {
                    { 6, "Ticari ve/veya kişisel reklam" },
                    { 8, "Uygunsuz Profil" },
                    { 5, "Spam" },
                    { 7, "Uygunsuz Bio" },
                    { 3, "Polemik Sataşma Ahlaksız içerik" },
                    { 1, "Genel ahlaka aykırı uslup" },
                    { 4, "Grafik ihlali ve/veya kopya içerik" },
                    { 2, "Siyasi ve Dini konular" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "FlagCode", "Name" },
                values: new object[,]
                {
                    { 49, "Lithuania", "Litvanya" },
                    { 68, "Rwanda", "Ruanda" },
                    { 67, "Romania", "Romanya" },
                    { 66, "Portugal", "Portekiz" },
                    { 65, "Poland", "Polonya" },
                    { 64, "Peru", "Peru" },
                    { 63, "Pakistan", "Pakistan" },
                    { 62, "Norway", "Norveç" },
                    { 61, "Nigeria", "Nijerya" },
                    { 60, "Namibia", "Namibya" },
                    { 59, "Mauritius", "Morityus" },
                    { 57, "Egypt", "Mısır" },
                    { 56, "Mexico", "Meksika" },
                    { 55, "Malta", "Malta" },
                    { 54, "Malaysia", "Malezya" },
                    { 53, "Malawi", "Malavi" },
                    { 52, "Hungary", "Macaristan" },
                    { 51, "Luxembourg", "Lüksemburg" },
                    { 50, "Lebanon", "Lübnan" },
                    { 69, "Russian_Federation", "Rusya" },
                    { 58, "Mongolia", "Mongolya" },
                    { 71, "Singapore", "Singapur" },
                    { 72, "Serbia", "Sırbistan" },
                    { 48, "Latvia", "Letonya" },
                    { 91, "Zimbabwe", "Zimbabve" },
                    { 90, "Zambia", "Zambiya" },
                    { 89, "Greece", "Yunanistan" },
                    { 88, "New_Zealand", "Yeni Zelanda" },
                    { 87, "Vietnam", "Vietnam" },
                    { 86, "Venezuela", "Venezuela" },
                    { 85, "Jordan", "Ürdün" },
                    { 84, "Oman", "Umman" },
                    { 70, "Chile", "Şili" },
                    { 83, "Ukraine", "Ukrayna" },
                    { 81, "Turkey", "Türkiye" },
                    { 80, "Tunisia", "Tunus" },
                    { 79, "Taiwan", "Tayvan" },
                    { 78, "Thailand", "Tayland" },
                    { 77, "Tanzania", "Tanzanya" },
                    { 76, "Saudi_Arabia", "Suudi Arabistan" },
                    { 75, "Sri_Lanka", "Srilanka" },
                    { 74, "Slovenia", "Slovenya" },
                    { 73, "Slovakia", "Slovakya" },
                    { 82, "Uganda", "Uganda" },
                    { 47, "Kuwait", "Kuveyt" },
                    { 4, "Bahrain", "Bahreyn" },
                    { 45, "Colombia", "Kolombiya" },
                    { 20, "Philippines", "Filipinler" },
                    { 19, "Cote_dIvoire", "Fildişi Shilleri" },
                    { 18, "Morocco", "Fas" },
                    { 17, "Europe", "Euro Bölgesi" },
                    { 16, "Estonia", "Estonya" },
                    { 15, "Indonesia", "Endonezya" },
                    { 14, "Ecuador", "Ekvador" },
                    { 13, "China", "Çin" },
                    { 12, "Czech_Republic", "Çek Cumhuriyeti" },
                    { 11, "Bulgaria", "Bulgaristan" },
                    { 10, "Brazil", "Brezilya" },
                    { 9, "Bosnia", "Bosna Hersek" },
                    { 46, "Costa_Ri", "Kosta Rika" },
                    { 7, "Dubai", "Birleşik Arap Emirlikleri" },
                    { 6, "Belgium", "Belçika" },
                    { 5, "Bangladesh", "Bangladeş" },
                    { 3, "Australia", "Avustralya" },
                    { 2, "Argentina", "Arjantin" },
                    { 1, "USA", "ABD" },
                    { 21, "Palestine", "Filistin" },
                    { 22, "Finland", "Finlandiya" },
                    { 8, "UK", "İngiltere" },
                    { 24, "South_Korea", "Güney Kore" },
                    { 23, "South_Africa", "Güney Afrika" },
                    { 44, "Cyprus", "Kıbrıs" },
                    { 43, "Kenya", "Kenya" },
                    { 42, "Kazakhstan", "Kazakistan" },
                    { 41, "Qatar", "Katar" },
                    { 40, "Montenegro", "Karadağ" },
                    { 39, "Canada", "Kanada" },
                    { 37, "Jamaica", "Jamaika" },
                    { 36, "Iceland", "İzlanda" },
                    { 35, "Italy", "İtalya" },
                    { 38, "Japan", "Japonya" },
                    { 33, "Sweden", "İsveç" },
                    { 25, "India", "Hindistan" },
                    { 26, "Croatia", "Hırvatistan" },
                    { 34, "Switzerland", "İsviçre" },
                    { 28, "Hong_Kong", "Hon Kong" },
                    { 27, "Netherlands", "Hollanda" },
                    { 30, "Ireland", "İrlanda" },
                    { 31, "Spain", "İspanya" },
                    { 32, "Israel", "İsrail" },
                    { 29, "Iraq", "Irak" }
                });

            migrationBuilder.InsertData(
                table: "Gender",
                columns: new[] { "Id", "Genders" },
                values: new object[,]
                {
                    { 1, "Erkek" },
                    { 2, "Kadın" },
                    { 3, "Belirtmek istemiyorum" }
                });

            migrationBuilder.InsertData(
                table: "Job",
                columns: new[] { "Id", "Jobs" },
                values: new object[,]
                {
                    { 9, "Bilişim" },
                    { 7, "Dişçi" },
                    { 8, "Serbest Meslek" },
                    { 6, "İşçi" },
                    { 2, "Memur" },
                    { 4, "Doktor" },
                    { 3, "Mühendis" },
                    { 1, "Belirtmek istemiyorum" },
                    { 5, "Savcı/Hakim" }
                });

            migrationBuilder.InsertData(
                table: "MarketTypes",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "Döviz" },
                    { 2, "Altın" },
                    { 3, "Kripto" },
                    { 4, "BİST 100" },
                    { 5, "BİST 50" },
                    { 6, "BİST 30" },
                    { 7, "Parite" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName" },
                values: new object[,]
                {
                    { 3, "mod" },
                    { 1, "admin" },
                    { 2, "user" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ActivationCode", "ActivationCodeExpirationDateTime", "ActivationDateTime", "Email", "IsEmailConfirmed", "IsPhoneNumberConfirmed", "PasswordHash", "RegistrationDateTime", "Username" },
                values: new object[,]
                {
                    { 8, "abc16", new DateTime(2019, 7, 2, 8, 24, 3, 255, DateTimeKind.Local).AddTicks(6039), new DateTime(2019, 7, 3, 8, 24, 3, 255, DateTimeKind.Local).AddTicks(6038), "DocLY@gmail.com", (byte)1, (byte)1, "03AC674216F3E15C761EE1A5E255F067953623C8B388B4459E13F978D7C846F4", new DateTime(2019, 7, 2, 8, 24, 3, 255, DateTimeKind.Local).AddTicks(6038), "DocLY" },
                    { 1, "1bc12", new DateTime(2019, 7, 10, 8, 24, 3, 255, DateTimeKind.Local).AddTicks(5582), new DateTime(2019, 7, 11, 8, 24, 3, 255, DateTimeKind.Local).AddTicks(3972), "admin@admin.com", (byte)1, (byte)1, "03AC674216F3E15C761EE1A5E255F067953623C8B388B4459E13F978D7C846F4", new DateTime(2019, 7, 10, 8, 24, 3, 255, DateTimeKind.Local).AddTicks(4361), "admin" },
                    { 2, "ab245", new DateTime(2019, 7, 9, 8, 24, 3, 255, DateTimeKind.Local).AddTicks(6018), new DateTime(2019, 7, 10, 8, 24, 3, 255, DateTimeKind.Local).AddTicks(5995), "user@user.com", (byte)1, (byte)1, "03AC674216F3E15C761EE1A5E255F067953623C8B388B4459E13F978D7C846F4", new DateTime(2019, 7, 9, 8, 24, 3, 255, DateTimeKind.Local).AddTicks(6000), "user" },
                    { 3, "a8612", new DateTime(2019, 7, 8, 8, 24, 3, 255, DateTimeKind.Local).AddTicks(6026), new DateTime(2019, 7, 11, 8, 24, 3, 255, DateTimeKind.Local).AddTicks(6024), "serkan@serkan.com", (byte)1, (byte)1, "03AC674216F3E15C761EE1A5E255F067953623C8B388B4459E13F978D7C846F4", new DateTime(2019, 7, 8, 8, 24, 3, 255, DateTimeKind.Local).AddTicks(6025), "serkan" },
                    { 4, "a1212", new DateTime(2019, 7, 7, 8, 24, 3, 255, DateTimeKind.Local).AddTicks(6029), new DateTime(2019, 7, 8, 8, 24, 3, 255, DateTimeKind.Local).AddTicks(6027), "aykutonall@gmail.com", (byte)1, (byte)1, "03AC674216F3E15C761EE1A5E255F067953623C8B388B4459E13F978D7C846F4", new DateTime(2019, 7, 7, 8, 24, 3, 255, DateTimeKind.Local).AddTicks(6028), "aykut" },
                    { 5, "ab522", new DateTime(2019, 7, 6, 8, 24, 3, 255, DateTimeKind.Local).AddTicks(6031), new DateTime(2019, 7, 7, 8, 24, 3, 255, DateTimeKind.Local).AddTicks(6030), "moboy.isbak@gmail.com", (byte)1, (byte)1, "03AC674216F3E15C761EE1A5E255F067953623C8B388B4459E13F978D7C846F4", new DateTime(2019, 7, 6, 8, 24, 3, 255, DateTimeKind.Local).AddTicks(6030), "MOBOY" },
                    { 6, "7bc12", new DateTime(2019, 7, 5, 8, 24, 3, 255, DateTimeKind.Local).AddTicks(6034), new DateTime(2019, 7, 6, 8, 24, 3, 255, DateTimeKind.Local).AddTicks(6032), "kkvarol@gmail.com", (byte)1, (byte)1, "03AC674216F3E15C761EE1A5E255F067953623C8B388B4459E13F978D7C846F4", new DateTime(2019, 7, 5, 8, 24, 3, 255, DateTimeKind.Local).AddTicks(6033), "kkvarol" },
                    { 7, "ab312", new DateTime(2019, 7, 3, 8, 24, 3, 255, DateTimeKind.Local).AddTicks(6037), null, "zeynel@gmail.com", (byte)0, (byte)0, "03AC674216F3E15C761EE1A5E255F067953623C8B388B4459E13F978D7C846F4", new DateTime(2019, 7, 3, 8, 24, 3, 255, DateTimeKind.Local).AddTicks(6036), "zeynel" },
                    { 9, "a2c12", new DateTime(2019, 7, 1, 8, 24, 3, 255, DateTimeKind.Local).AddTicks(6041), new DateTime(2019, 7, 2, 8, 24, 3, 255, DateTimeKind.Local).AddTicks(6040), "CR@gmail.com", (byte)1, (byte)1, "03AC674216F3E15C761EE1A5E255F067953623C8B388B4459E13F978D7C846F4", new DateTime(2019, 7, 1, 8, 24, 3, 255, DateTimeKind.Local).AddTicks(6040), "CristianoRonaldo" }
                });

            migrationBuilder.InsertData(
                table: "BannedUsers",
                columns: new[] { "Id", "BanEndDateTime", "BanReason", "BanStartDateTime", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 10, 9, 8, 24, 3, 257, DateTimeKind.Local).AddTicks(6715), "Uygunsuz Mesaj", new DateTime(2019, 7, 10, 8, 24, 3, 257, DateTimeKind.Local).AddTicks(6510), 8 },
                    { 2, new DateTime(2019, 11, 8, 8, 24, 3, 257, DateTimeKind.Local).AddTicks(7104), "Uygunsuz Avatar", new DateTime(2019, 7, 8, 8, 24, 3, 257, DateTimeKind.Local).AddTicks(7100), 9 }
                });

            migrationBuilder.InsertData(
                table: "Blocks",
                columns: new[] { "Id", "BlockedByUserId", "BlockedUserId", "CreatedDateTime" },
                values: new object[,]
                {
                    { 8, 6, 8, new DateTime(2019, 7, 10, 5, 24, 3, 255, DateTimeKind.Utc).AddTicks(7850) },
                    { 3, 3, 7, new DateTime(2019, 7, 7, 5, 24, 3, 255, DateTimeKind.Utc).AddTicks(7846) },
                    { 7, 6, 4, new DateTime(2019, 7, 3, 5, 24, 3, 255, DateTimeKind.Utc).AddTicks(7849) },
                    { 4, 3, 9, new DateTime(2019, 7, 6, 5, 24, 3, 255, DateTimeKind.Utc).AddTicks(7847) },
                    { 2, 3, 6, new DateTime(2019, 7, 8, 5, 24, 3, 255, DateTimeKind.Utc).AddTicks(7836) },
                    { 5, 4, 5, new DateTime(2019, 7, 9, 5, 24, 3, 255, DateTimeKind.Utc).AddTicks(7847) },
                    { 1, 4, 5, new DateTime(2019, 7, 11, 5, 24, 3, 255, DateTimeKind.Utc).AddTicks(7252) },
                    { 6, 4, 6, new DateTime(2019, 7, 4, 5, 24, 3, 255, DateTimeKind.Utc).AddTicks(7848) }
                });

            migrationBuilder.InsertData(
                table: "DeletedUsers",
                columns: new[] { "Id", "DeleteDateTime", "DeleteReason", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 7, 9, 8, 24, 3, 257, DateTimeKind.Local).AddTicks(7611), "Uzun Süredir kullanılmadı", 6 },
                    { 2, new DateTime(2019, 7, 8, 8, 24, 3, 257, DateTimeKind.Local).AddTicks(8004), "Bıktım ama ya", 9 }
                });

            migrationBuilder.InsertData(
                table: "EconomicDictionary",
                columns: new[] { "Id", "CategoryId", "Content", "Name", "Seourl" },
                values: new object[,]
                {
                    { 31, 18, "Yatırım yapanların veya borç verenlerin alıkları risklerin niteliğine bağlı olarak risksiz getiri oranı üzerine ilave olarak talep ettikleri oranıdır.Risk primi işlemin türüne,vadeye ve alınan teminatların niteliğine göre değişebilir.", "Risk Primi", "risk-primi" },
                    { 25, 14, "Bakınız Caril Gayri Safi Yurtiçi Hasıla.", "Nominal GSYH", "nominal-GSYH" },
                    { 26, 15, "Öncesi Marshall Yardımı’na dayanır. 2. Dünya Savaşı'nın bitiminden sonra savaşta büyük zarar gören Batı Avrupa ülkelerinin ekonomik kalkınmasını finanse etmek için Dünya Bankası kurulmuş ve ayrıca ABD o zamanki dışişleri bakanının soyadı ile anılan Marshall Yardımı’nı organize etmişti. Daha sonra ABD'nin yanına Kanada'nın da katılması ile bu yardımları koordine etmek amacıyla Avrupa Ekonomik İşbirliği Örgütü kuruldu. Bu örgüt daha sonra OECD'ye dönüştü.", "OECD", "oecd" },
                    { 27, 15, "Opsiyon işleminde doğrudan dayanak varlığın alınması ya da satılması değil, alım ya da satım hakkının alınıp satılması söz konusudur. Opsiyon işlemlerinde alıcının vadede sözleşmeden vazgeçme hakkı vardır. Ama alıcı satın almış olduğu hakkı kullanmak isterse satıcı alıcının almış olduğu hak kullanımına göre dayanak varlığı kullanım fiyatından almak ya da satmak durumunda kalır.Opsiyon işlemleri hakkın kullanım türüne göre alım hakkı veren(call) opsiyonlar ve satım hakkı veren(put) opsiyonlar olmak üzere ikiye ayrılırlar.Alım hakkı veren(call) opsiyonlarda opsiyon alıcısı ileri bir tarihte veya bu tarihten önce kullanım fiyatından dayanak varlığı alabilir ama,almak zorunda değildir.Ancak alım hakkı veren opsiyonun alıcısı dayanak varlığı kullanım fiyatından alma hakkını kullanmak isterse bu opsiyonu satan satıcı alıcıya ilgili dayanak varlığı kullanım fiyatından satmak zorunda kalır.Satım hakkı veren(put) opsiyonlarda opsiyon alıcısı ileri bir tarihte veya bu tarihten önce kullanım fiyatından dayanak varlığı satabilir,ama satmak zorunda değildir.Ancak satım hakkı veren opsiyonun alıcısı dayanak varlığı kullanım fiyatından satma hakkını kullanmak isterse bu opsiyonu satan satıcı alıcıdan ilgili dayanak varlığı kullanım fiyatından almak zorunda kalır.Görüldüğü gibi Opsiyon alan taraf vadede veya vadeden önce(opsiyon işleminin Avrupa tipi opsiyon veya Amerikan tipi opsiyon olmasına göre) isterse hakkını kullanabilir,kullanmazsa opsiyon işlemi kendiliğinden sona erer.Satıcının ise tamamen alıcıya bağlıdır.Alıcı vadede veya vadeden önce hakkını kullanmak isterse satıcının yükümlülüğü oluşmaktadır.Opsiyon işleminde inisiyatif alıcının elinde olduğu için satıcı alıcıya göre çok daha fazla risk taşımaktadır.Bu yüzden vadede opsiyon hakkı alıcı tarafından kullanılsa da kullanılmasa da opsiyon işleminin alım satımı sırasında alıcı satıcıya mutlaka bir opsiyon primi öder.Alıcının opsiyon işleminden dolayı kayıp miktarı en fazla ödediği prim kadar olurken kazancı vadede dayanak varlığın fiyatının ne kadar lehinde olduğuna bağlı olarak artar.Satıcının ise en fazla kazancı tahsil etmiş olduğu opsiyon primi kadar olup zararı vadede dayanak varlığın fiyatının ne kadar aleyhinde olduğuna göre değişir.Opsiyonlar hem tezgah üstü finansal piyasalarda hem de organize finansal piyasalarda işlem görürler.", "Opsiyon", "opsiyon" },
                    { 28, 16, "Para kurulu genellikle merkez bankası olmayan küçük ülkelerde görülmektedir. Ancak geçmişte merkez bankası olan ülkelerde de uygulanmıştır. Para kurulu uygulamasında belirlenmiş esnek olmayan sabit bir kur vardır. Merkez bankasının da bulunduğu ülkelerde para kurulu rejimi uygulanıyorsa, bu takdirde merkez bankasının görevi sabit bir kurdan döviz almak ve satmaktır.Bu metinin yazıldığı an itibariyle para kurulu uygulamasına sahip olan ülkelere Hong Kong,Bulgaristan ve Bosna Hersek verilebilir.İlkinin değeri ABD Doları'na, diğer ülke para birimlerinin değerleri de Euro'ya sabitlenmişlerdir.Geçmişte Arjantin para kurulu uygulamasında bulunmuştur.Türkiye'de de 2000 yılının başından 2001 krizine kadar para kurulu yumuşak çıpa rejimiyle (bakınız döviz kuru) birlikte karma bir şekilde uygulanmıştır.Avantajları ve dezavantajları mevcuttur(bakınız sabit kur rejimi)", "Para Kurulu", "para-kurulu" },
                    { 29, 16, "Monetarist ekonomistler para arzının ekonomi üzerinde etkili olduğuna inandıklarından merkez bankalarının para arzını kontrol etmeleri gerektiğine inanırlar.Monetarizme göre para arzı ile nominal milli gelir arasında önemli bir ilişki vardır.Nominal milli gelir para arzı ile paranın elden ele dolaşımı anlamına gelen parasal hızlandıranın çarpımına eşittir.Bu görüşte olan ekonomistler paranın dolaşım hızının uzun vadede değişmediğini düşündüklerinden nominal gelirdeki değişmenin sadece para arzındaki değişiklikle belirlenebileceğini söylerler.Onlara göre,para arzından gereğinden fazla bir artış kısa vadede ekonominin nominal büyümesini sağlamasına rağmen uzun vadede enflasyonda artışa neden olur.Monetaristlere göre enflasyon ya da deflasyonu kontrol etmek isteyen merkez bankaları para arzındaki gelişmeleri hedef almalıdırlar.Eğer bir ülkede enflasyon gereğinden fazla yüksekse yapılması gereken para arzını kısmaktır.Aynı şekilde deflasyon söz konusuysa para arzında genişlemeye gitmek gerekir.Monetaristler Keynesyen ekonomistler gibi bir ekonomide maliye politikası uygulamalarının para politikası uygulamaları kadar etkili olmadığını da iddia ederler.", "Parasalcılık", "parasalcilik" },
                    { 30, 18, "Eğer nominal getiri yatırım süresi boyunca beklenen ya da gerçekleşen enflasyon oranından yüksekse pozitif reel getiri; düşükse negatif reel getiri söz konusudur.Beklenen enflasyona göre hesaplanan reel getiriye ex - ante reel getiri,gerçekleşmiş enflasyona göre hesaplanan getiriye ex - post reel getiri denir.", "Reel Getiri Oranı", "reel-getiri-orani" },
                    { 32, 19, "Sabit maliyetler kısa dönemde per değişmezler ancak uzun vadede yapılan yeni yatırımlara bağlı olarak artabilir ya da şirketin faaliyetlerinin azalması ile düşürülebilir.", "Sabit Maliyet", "sabit-maliyet" },
                    { 38, 22, "Bilanço mantığı açısından baktığımızda, bilanço kalemleri varlıklar (aktifler) ve yükümlülük kalemlerinden oluşurlar. Bilançonun varlık kalemleri sağlanan kaynakların nerelerde kullanıldığını veya nerelere yatırıldığını gösterirler.Varlıkları dönen(cari) varlıklar ve duran varlıklar olarak iki ana gruba ayrılırlar.Dönen varlıklar likiditesi en yüksek olduğu kabul edilen veya bir yıl içinde nakde dönüşebilecek olan varlık kalemleridir.Duran varlıklar kolay nakde dönüşemeyecek veya nakde dönüşebilmesi için 1 yıldan fazla bir zamanın geçmesi gerektiği kabul edilen kalemlerdir.Aslında bir şirketin uzun vadeli yatırımlarını gösterir.Duran varlıklar da devam eden ama tamamlanmamış yatırımlar, maddi duran varlıklar ve maddi olmayan duran varlıklar olarak üçe ayrılabilir.", "Varlıklar", "varliklar" },
                    { 34, 20, "Nakdi teminatlara örnek olarak nakit, çek, menkul kıymetler, gelecekte elde edilecek olan nakit akışlarının temliki verilebilir.Gayri nakdi teminatlara teminat mektupları,gayrimenkuller,taşınır mallar ve kefalet verilebilir.", "Teminat", "teminat" },
                    { 35, 20, "Teşvikleri her kurum veya gerçek kişi v erebilir. Ancak genellikle anlaşılan kamu teşvikleridir. Merkezi hükümetler, yerel yönetimler veya bunlara bağlı olan kamu kurumları belirli ekonomik aktivitelerin yapılmasını sağlamak veya ülkenin belirli bir bölgesinde ekonomik kalkınmanın sağlanması ve işsizliğin azaltılması için şirketleri yatırım yapmaya ikna etmek için teşvikleri kullanırlar.Teşvikler tüm sektörlere verilebildiği gibi sadece bazı sektörler için de verilebilir.Örneğin tarım ve hayvancılığın gelişmesi için verilen sıfır faizli krediler ile destekleme alımları teşvik türlerindendir.Teşvikler yatırımcılara arsa verilmesi, düşük faiz veya sıfır faiz oranlı kredi verilmesi, kamu tarafından alım garantisi verilmesi, kurumlar vergisi ve gelir vergisi uygulamalarında avantajlar,vb.olabilir.Teşvikler aynı zamanda bir maliye politikası araçlarındandır.", "Teşvik", "tesvik" },
                    { 36, 21, "Merkezi Washington, ABD'dir. 1945 yılında kurulmuştur.IMF'nin 1944 yılında 44 ülke temsilcisinin bir araya gelerek imzaladıkları daha sonra Bretton Woods Sistemi olarak da adlandırılan, Birleşmiş Milletler Para ve Maliye Konferansı'nda(United Nations Monetary and Financial Conference) kurulması kararlaştırılmıştır.Bretton Woods Sistemi 1 ons altının fiyatını 35 ABD Doları'na sabitlemişti. Diğer üye ülke para birimlerinin değerleri de ABD Doları'na sabitlenmişti.Sabitlenen kur değerleri üzerinden aşağı ve yukarı yönlerde en fazla % 1'lik dalgalanmaya izin verilmekteydi.Kurların sabitlenmesi ve dış ticaretin liberalleşmesi sonucu oluşabilecek olan dış ticaret dengesizliklerin neden olabileceği ödemeler dengesi problemlerini çözmek için devalüasyon veya revalüasyon yapma zorunluluğuna gerek kalmadan çözüm bulmak amacıyla yapılan anlaşma ile ayrıca IMF adlı bir kurum kurulmasına karar verildi.IMF, ödemeler dengesinde oluşabilecek geçici dengesizlik durumlarında cari açık verebilecek olan ülkelerin kurlarını değiştirmeden onlara kısa vadeli sermaye sağlamak amacıyla görevlendirildi.Sistem bir ülkelerin ödemeler dengesinde ancak yapısal sorunlar oluşması durumunda IMF’nin onayıyla bir para biriminde % 10 devalüasyona veya revalüasyona izin veriyordu.Ancak Bretton Woods sistemi 1970'li yıllarda çöktü. Sistemin çöküşünden sonra IMF'nin misyonu da değişti.IMF'nin ana misyonları şöyle tanımlanabilir:1) Uluslararası para ve finansal sistemin gözetimi, üye ülkelerin ekonomik politikalarının ve mali politikalarının izlenmesi ve üye ülkeler arasında işbirliğinin sağlanması.Bu fonksiyonu nedeniyle küresel düzeyde veya üye ülkelerin herhangi birinde finansal istikrarı bozacak olan olası riskleri belirlemek ve bu konularda tavsiyede bulunmak2) Ödemeler dengesinde sorunlar yaşayacak veya yaşamakta olan ülkelere borç vererek yardımcı olmak. Bu fonksiyon aslında tam da kuruluş misyonuna uygun olandır.Ödemeler dengesinde sorunlar yaşayan ülkelere borç vererek bu ülkelerin para birimlerinin diğer para birimlerine karşı değerlerinde istikrar sağlamayı, bu ülkelerin \"hard currency\" cinsinden döviz rezervlerini güçlendirmeyi, ithalat ödemelerini sürdürmeyi, ekonomik büyümenin olumsuz etkilenmesini önlemeyi sağlamaya çalışmaktadır. Ancak bu desteği sağlarken de sorun yaşayan ülkelerin gerekli istikrar önlemlerini almasını talep etmektedir.3) IMF ayrıca üye ülkelerin ekonomik politikalarını oluşturmada ve mali işlerini daha etkin yürütmelerini sağlamada teknik destek de vermektedir.IMF'nin fonlarını her üye ülkenin küresel ekonomideki büyüklükleriyle orantılı olarak sağlamış oldukları ve taahhüt etmiş oldukları \"hard currency\" denen kaynaklar oluşturmaktadır. Bu kaynaklara kota denmektedir.Kotaların dışında altın ve IMF'nin 1969 yılında yaratmış olduğu özel çekme hakkı (SDR) denen para birimi de vardır.Bu kaynakların dışında ihtiyaç olduğunda IMF ayrıca finansal piyasalardan borçlanabilmektedir.IMF, 1973 Arap - İsrail savaşından sonra ve 1979 İran Devrimi'nden sonra petrol fiyatında görülen hızlı yükselişler ve Bretton Woods Sistemi'nin çöküşünden sonra hızlı yaşanan devalüasyonlar nedeniyle ödemeler dengesinde büyük problemler yaşayan gelişmekte olan ülkelere destek sağlamıştır.Sermaye hareketlerinin serbestleşmesi sonucu 1980'ler ve 1990'larda gelişmekte olan ülkelerde yaşanan krizlerde bu ülkelere fon sağlamış ve istikrar paketlerinin uygulanmasını gözetmiştir.Özellikle Meksika Tekila Krizi, Arjantin, Doğu Asya Bölgesel Krizi, Rusya, Brezilya, 1980, 1994 ve 2001 Türkiye krizlerinin yarattığı sorunların çözümünde ve bu ülkelerin istikrar paketi uygulamalarında önemli rol oynamıştır.2009'da Yunanistan'ın borçlarını ödeyememe problemiyle başlayan ve daha sonra Portekiz, İrlanda ve Kıbrıs Rum Kesimi gibi Avro Bölgesi ülkelerine AB ile birlikte önemli fonlama desteği sağlamıştır.", "Uluslararası Para Fonu", "uluslararasi-para-fonu" },
                    { 37, 21, "Bir ülkenin uluslararası ticaret rakamları ödemeler dengesinin cari denge alt kaleminde takip edilir. Yurt dışın amal satımına ihracat, yurt dışından mal alımına ithalat denir.Yurtdışı ile yapılan mal ticaretinin yanında turizm,nakliye, müteahhitlik,finansal hizmetler vb.hizmetlerde uluslararası ticaretin konusudur.Uluslararası ticaretin göstergesi olan cari denge rakamlarının yurtiçi gayri safi milli hasıla(GSYH) rakamları üzerinde etkisi vardır.Cari denge açık verdiği zaman GSYH'i azalmakta, fazla verdiği zaman ise GSYH artmaktadır.Bir ülkenin uluslararası ticaret hacmi o ülkenin ne kadar dışarıyla açık olduğunu, yani entegre olduğunu da gösterir.Alım ve satım rakamlarının toplamının GSYH'ye oranı bu göstergeyi sağlar.Uluslararası ticaret ihracat ve hizmet satımı anlamında farklı pazarlarda farklı müşteriler ve pazar payı edinilmesini sağladığı gibi, belirli malların üretimi için gerekli olan ancak ülkede olmayan veya sınırlı miktarlarda bulunan veya üretilen hammaddelerin veya hizmetlerin temin edilmesini sağlar.Uluslararası ticaret ülkeler arası serbest ticaret ile küreselleşme ile de doğrudan ilişkilidir.Özellikle 1989'da Berlin Duvarı'nın çökmesiyle birlikte sermaye hareketlerine olan sınırların kalkması ile birlikte doğrudan yabancı yatırımlar da bir artış yaşanmıştır.Bu artış ile birlikte birçok çokuluslu şirket üretimlerinin bir kısmını değişik ülkelere özellikle kendilerine ucuz işgücü sağlayan ve / veya hammadde kaynaklarını üreten gelişmekte olan ülkelere kaydırmışlardır.Bu kaydırma ile birlikte aynı çokuluslu şirketler bünyesinde kalsa bile ülkeler arasındaki ticaret hacmi artmıştır.", "Uluslararası Ticaret", "uluslararasi-ticaret" },
                    { 24, 14, "Başta proje finansmanı olmak üzere uzun vadeli her türlü yatırım kararlarında kullanılır. NBD hesaplamadaki amaç herhangi bir yatırım kararının alınıp alınmaması ile ilgilidir. NBD’si pozitif olan yatırımlar her zaman katma değer sağlarlar. NBD’si negatif olan yatırımlar hiç bir katkı sağlamadıkları gibi şirketin veya bireyin refahında erimeye neden olurlar.Eğer bir yatırım kısatlaması yoksa rasyonel olan NBD’si pozitif olan tüm yatırımlarla ilgili olumlu karar almaktır.Sermaye kısıtlaması olduğu zamanlarda ise pozitif NBD’lerden tutarı en yüksek olandan başlayarak yatırım kararı alınmalıdır.NBD hesaplaması için ilerideki nakit akımlarının mümkün olduğunca gerçeğe yakın ve uygun sermaye fırsat maliyetini tahmin edilmeleri en önemli kriterlerdir.", "Net Bugünkü Değer", "net-bugunku-deger" },
                    { 39, 22, "Toplanan vergi gelirleri ile bütçe açığı veren merkezi hükümetlerin kamu harcamalarının bir kısmı karşılanır.Vergiler birer maliye politikası aracı olarak da merkezi hükümetlerce kullanılır.Vergiler doğrudan vergiler ve dolaylı vergiler olarak iki grupta toplanır.", "Vergiler", "vergiler" },
                    { 40, 25, "Bunu bir örnekle açıklayalım. Ev almak istiyoruz ve evin bir bölümünü peşin olarak ödememiz gerekiyor. Ancak bugün itibariyle peşin paramız yok. Bu durumda gelecekte istediğimiz evi alabilmek için peşinatı biriktirmemiz diğer bir deyişle bugün daha az harcamamız gerekir. Biriktirdiğimiz tutar yatırımlarımızı oluşturur. Bugün harcamaktan vaz geçmemiz için bizi motive eden faktör gelecekte alacağımız ev için para biriktirmektir. Biriktirdiğimiz paranın da evi alacağımız güne kadar gelir getirmesini arzu ederiz.Yukarıdaki örneğin yanında bugün tüketim harcaması yapmak yerine bizi yatırıma yönlendiren başka bir sebep de ileride bugüne göre daha fazla tüketim harcaması yapabilecek tutara sahip olacağımızı düşündüğümüzde ortaya çıkar.Yatırımlar reel yatırımlar ve finansal yatırımlar olmak üzere ikiye ayrılır.Örneğimize geri dönersek ev almak için biriktirdiğimiz peşinat finansal yatırımdır.Finansal yatırımlarımızı, mevduat, sabit getirili menkul kıymetler,pay(hisse) senedi,yatırım fonu,emeklilik fonu vb.yatırım araçlarında değerlendiririz.Evi satın aldığımızda finansal yatırımımız artık reel yatırım haline dönüşür.Reel yatırımlara,arazi,makine,fabrika ve sanatsal tablolara yapılan yatırımları örnek verebiliriz.Yaptığımız yatırımlardan çeşitli kazançlar(kayıplar) sağlarız.Bu kazançlar(kayıplar) sermaye kazancı(kaybı) ya da faiz kazancı olarak adlandırılır.Yatırım yapıp yapmamaya risk ve getiri ilişkisi ile karar veririz.", "Yatırım", "yatirim" },
                    { 41, 25, "Bazı durumlarda da bazı sektörlerin rekabet avantajını kaybetmesi sonucu diğer sektörlerde çalışabilecek yetenek ve bilgi düzeyine sahip olamayanlar arasında görülen işsizliktir. En büyük işsizlik sorunu yapısal işsizlik sorunudur. Yapısal işsizliğin uzun sürmesi talep azalması nedeniyle bir ekonominin daha da küçülmesine ve deflasyon problemine sebep olabilir.", "Yapısal İşsizlik", "yapisal-issizlik" },
                    { 33, 19, "Özkaynaklar girişimcinin kendi kaynaklarından sağladığı ve maliyeti sermaye maliyeti olan kaynaktır.Yabancı kaynaklar girişimcinin başkalarından ödünç almış olduğu kaynaklar olup,maliyeti faiz oranı, komisyon,vb.olan kaynaktır.Sermaye ekonomi teorisindeki üretim faktörlerinden birisidir.", "Sermaye", "sermaye" },
                    { 23, 13, "Amortisman harcamaları bir ekonomide belirli bir dönemde makine, teçhizat, fabrika binaları, vb. demirbaşlardaki yıpranmaları telafi etmek amacıyla yapılan nihai harcamalardır. GSMH'den amortisman harcamaları düşüldükten sonra safi hasıla rakamına ulaşılır.Safi harcamaların içerisinde katma değer vergisi(KDV),özel tüketim vergisi(ÖTV) gibi dolaylı vergiler de dahildir.Safi hasılayı dolaylı vergilerin etkisinden arındırdığımızda o ülkede belirli bir dönemde elde edilen milli gelir rakamına ulaşırız.Milli gelirin nüfus başına bölünmesi ile kişi başına milli gelir rakamı elde edilir.Milli gelir rakamına emeklilik gibi ödemelerin ilave edilmesi ile kişisel gelirlerin toplamı elde edilir. Kişisel gelir toplamından gelir vergisi,kurumlar vergisi gibi doğrudan ödenen vergiler düşülünce harcanabilir gelir rakamı bulunur.", "Milli Gelir", "milli-gelir" },
                    { 1, 1, "Eğer satılan yatırım aracının ileri bir tarihte geri alınması düşünülüyorsa, gün sonunda karşı tarafa teslim edilmesi gerekir. Bu yüzden satılan yatırım aracının üçüncü taraflardan ödünç alınması gerekir. Bunun da bir maliyeti vardır. Açığa satışa konu olan yatırım aracının teslimatında sorunlarla karşılaşmamak için, yani bir kredi risk konusu oluşmaması için organize finansal piyasalarda bu tür işlemler belirli sınırlamalara ve kurallara tabidirler. Örneğin ülkemizde menkul kıymetlerin açığa satışı için SPK'nın yapmış olduğu bir takım düzenlemeler vardır.", "Açığa Satış", "aciga-satis" },
                    { 21, 12, "Likitideyi bir vücuttaki dolaşım sisteminin içinde hayati önemi olan kana benzetebiliriz. Dolayısıyla kansızlık olgusu zamanla vücütta diğer organları nasıl olumsuz etkilerse ne kadar karlı görünseniz bile likitidenin kesilmesi halinde günlük faaliyetlerinizi yerine getirmekte zorlanabilirsiniz.Likitidenin en kaba ölçüsü vadesi gelen borçların çevirme gücüne sahip olunmasıdır.Ya da vadesi gelen bir borcunuzu başka bir kaynaktan kolaylıkla borç alarak ödeyebilme gücüdür.Bunların yanında sahip olunan varlıkların gerektiğinde hızlı bir biçimde ve piyasa fiyatına yakın düzeylerden elden çıkarabilme imkanıdır.Bu üçünü tek tek veya hepsini bir arada yapabilme gücü varsa likitide problemi yok demektir.", "Likidite", "likidite" },
                    { 2, 1, "Altın tarih boyunca hem bir para birimi, hem de bir servet aracı olarak kullanılmıştır. Altın, bazen gümüşle bazen de tek başına bir para standardına da temel teşkil etmiştir (bakınız altın standardı).Bugün özellikle kuyumculuk sektöründe önemli bir hammadde olmasına rağmen halen bir yatırım aracı olarak çekiciliğini sürdürmektedir.Özellikle enflasyonist ve hatta bazı durumlarda deflasyonist beklentilerde yatırımcılar için güvenli liman özelliğine sahip olmaktadır.Altının uluslararası değeri ABD Doları'na karşı belirlenmektedir. Dolayısıyla diğer para birimlerinin altın karşısındaki değeri Altının ABD Doları'nın ilgili para birimi karşısındaki değerinden de etkilenmektedir.Örneğin gram altının Türk Lirası karşısındaki değeri ons altının ABD Doları'na karşı değeri ile ABD Doları/Türk Lirası döviz kurundaki değişimden etkilenmektedir.", "Altın", "altin" },
                    { 22, 13, "Bu tutarın ilgili vergi oranı ile çarpılması sonucu ödenecek vergi tutarı hesaplanır.Verginin matrahı kazanca, belirli bir ekonomik kıymete veya işleme bağlı olarak hesaplanır.Örneğin gelir vergisi ve kurumlar vergisi matrahları kazanca bağlı olarak oluşur.Bireysel yatırımcıların elde ettikleri faiz gelirleri ile menkul kıymet işlemlerindeki sermaye kazançları; yıllık brüt ücretler ve maaşlar; elde edilen yıllık kira gelirleri gibi kazançlar gelir vergisi matrahını oluşturur.Şirketlerin faaliyetlerinden dolayı elde ettikleri net gelirler vergi öncesi kar olarak adlandırılır ve kurumlar vergisi matrahını oluşturur.Kazançların yanında sahip olunan gayrimenkuller, otomobiller, vbg nitelikteki varlıkların ekonomik değerleri vergi matrahını oluştururlar.Kredi faiz tutarı, yapılan satın alma tutarları gibi ekonomik değerler, katma değer vergisi(KDV), özel tüketim vergisi(ÖTV), bankacılık ve sigortacılık muameleleri vergisi(BSMV) gibi vergilerin hesaplanmasında kullanılan matrah değerleridir.", "Matrah", "matrah" },
                    { 3, 2, "Bankalar çeşitli türlere ayrılabilirler. Ülkemizdeki mevzuata göre üç tip banka vardır:", "Banka", "banka" },
                    { 4, 2, "Sistematik risk yatım aracına bağlı olmadığından finansal piyasaların genelini ilgilendirdiğinden portföy çeşitlendirilmesiyle bu riskten kaçınmak mümkün değildir. Ama sistematik olmayan riski yönetebilir ve kontrol edebiliriz. Bunun da en basit yolu bütün yumurtaları aynı sepete koymamak ve farklı yatırım araçlarının bir araya gelmesiyle oluşan bir portföy oluşturmaktır. Böylece sistematik olmayan riski minimize edebiliriz. Beta katsayısı analizi Sharpe tarafından Markowitz Modern Portföy Teorisi’nden yola çıkarak geliştirmiş olduğu Finansal Varlık Fiyatlama Modeli’nin(FVFM – CAPM) belkemiğini oluşturmaktadır.Ekonomideki bazı gelişmeler,finansal piyasalardaki yatırım araçlarının getirisini farklı yönde etkiler.Örneğin,faiz oranlarındaki düşüş,GSYH'nın yükselişi, likidite artışı gibi olaylar, pay (hisse) senetlerine olan talebi dolayısıyla pay senetlerinin fiyatlarını arttırabilir. Faiz oranlarının yükselmesi, döviz fiyatlarındaki artış gibi olaylar, pay senetlerine olan talebi azaltabileceği için fiyatların düşmesine neden olabilir.Beta katsayısı, herhangi bir yatırım aracının finansal piyasalardaki dalgalanmalara karşı duyarlılığının bir ölçüsüdür.Bir başka değişle,yatırım aracının portföy içindeki payının bir birim arttırılması sonucu,portföyün varyans değerinde meydana gelen değişmeyi ifade eder.Yatırımcılar yatarım aracıyle ilgili analizi yaparken, her yatırım aracının kendine özgü,yani finasal piyasalardan bağımsız olan koşullar yanında bu piyasalarla olan bağımlılık derecelerini de incelemelidirler.Portföyün beta katsayısı,tek tek yatırım araçlarının beta katsayılarının ağırlıklı ortalaması olarak tanımlanabilir.Beta katsayısı aşağıdaki formülle gösterilir.ßi = Cov(i, m) / Var(m)Burada i,herhangi bir yatırım aracını,Cov(i, m) o yatırım aracının getirisi ile piyasadaki yatarım araçlarının tümünü kapsayan portföyün getirisi arasındaki kovaryansı,Var(m) piyasa portföyünün getirilerinin varsansını, ßi beta katsayısını ifade etmektedir.Beta katsayısı, bir yatırım aracının getirisinin finansal piyasaların bir bütün olarak getirisine bağlı olarak hangi yönde ve kuvvette değiştiğini gösterir.Portföye alınacak yatırım araçlarının seçiminde,beta katsayısından yararlanılabilirEğer bir yatırım aracının beta katsayısı 1’den büyükse,bu yatırım aracının getirisinde,piyasanın getirisindeki değişme ile aynı yönde ve ondan daha büyük bir değişme olacaktır.Bu tür yatırım araçlarına atak yatırım araçları denir Bu tür yatırım araçlarının piyasaya karşı duyarlılıkları fazladır.Piyasa portföyünün getirinde % 1 artış olduğunda bu yatırım aracının getirinde artış % 1'den fazla olur. Başka bir değişle, piyasa portföyünün getirisinde %1’lik bir düşüş olursa bu yatırım aracının getirisi de %1’den fazla düşer.Eğer bir yatırım aracının beta katsayısı 1 ise, bu yatırım aracının getirisinde,piyasa portföyünün getirisindeki değişme ile aynı yönde ve oranda bir değişme olacaktır.Piyasa portföyünün getirinde % 1 artış olduğunda bu yatırım aracının getirinde de artış % 1 olur.Başka bir değişle, piyasa portföyünün getirisinde % 1’lik bir düşüş olursa bu yatırım aracının getirisi de % 1 düşer.Eğer beta katsaysı sıfır 0 ise yatırım aracının getirindeki değişim ile piyasanın getirisindeki değişme arasında hiç bir ilişki olamayacak,bu yatırım aracını fiyatındaki dalgalanmanın nedenleri tamamıyla sistematik olmayan risk faktörleri olacaktır(böyle bir durum pratikte neredeyse hiç görülmez).Eğer beta katsasyısı sıfır ile 1 arasında bir değer alırsa, yatırım aracının getirisindeki değişim piyasa portföyünün getirisindeki değişimle aynı yönde ama daha az etkilenir olacak demektir.Eğer ßeta - 1’den küçük ise,yatırım aracının getirisinde,piyasa portföyünün getirisindeki değişme ile ters yönde ve ondan daha büyük bir değişme olacaktır.Bu tür yatırım araçlarının piyasaya karşı duyarlılıkları fazladır.Piyasa portföyünün getirinde % 1 artış olduğunda bu yatırım aracının getirinde düşüş % 1'den fazla olur. Başka bir değişle, piyasa portföyünün getirisinde %1’lik bir düşüş olursa bu yatırım aracının getirisi de %1’den fazla artar.Eğer bir yatırım aracının beta katsayısı - 1 ise, bu yatırım aracının getirisinde, piyasa portföyünün getirisindeki değişme ile zıt yönde ve aynı oranda bir değişme olacaktır.Piyasa portföyünün getirinde % 1 artış olduğunda bu yatırım aracının getirindeki azalış % 1 olur.Başka bir değişle, piyasa portföyünün getirisinde % 1’lik bir düşüş olursa bu yatırım aracının getirisi % 1 artar.Eğer beta katsasyısı sıfır ile - 1 arasında bir değer alırsa,yatırım aracının getirisindeki değişim piyasa portföyünün getirisindeki değişimle zıt yönde ama daha az etkilenir demektir.", "Beta", "beta" },
                    { 6, 3, "Alt başlıklarını dış ticaret dengesi (mal dengesi), hizmetler dengesi ve net dış alem ve faktör gelirleri (NDAFG) olarak isimlendirebiliriz.Dış ticaret dengesi mal ihracat ve ithalat tutarları arasındaki farktır.Eğer ihracat ithalattan fazla ise dış ticaret fazlası,aksi durumda ise dış ticaret açığı oluşur.Hizmetler dengesi başta net turizm gelirleri, sigortacılık,uluslararası nakliye, faiz gelir ve giderleri yaratmayan finansal hizmetler ile yurt dışı müteahhitlik gelirlerinden oluşur.Bir ülke cari açık vermişse yurt dışından sermaye girişi olmuş ya da var olan döviz rezervleri kullanılmış demektir.Eğer cari fazla vermişse yurt dışına sermaye yatırımı olmuş veya döviz rezervleri artmış demektir.", "Cari Denge", "cari-denge" },
                    { 7, 4, "Dealer bir işlemi doğrudan yapabileceği gibi bir broker aracılığıyla da gerçekleştirebilir.", "Dealer", "dealer" },
                    { 8, 4, "Depresyonlar ani yaşanan çok büyük ekonomik krizler sonucu oluşurlar. Yaşandıklarında toplum üzerinde izleri uzun yıllar boyunca silinmeyecek derin sosyolojik ve psikolojik etkiler bırakırlar.1929 – 38 yılları arasında başta ABD olmak üzere gelişmiş ülkelerde yaşanan ve büyük ekonomik buhran olarak adlandırılan dönem bir depresyon dönemidir.", "Depresyon", "depresyon" },
                    { 9, 5, "İşte ekonomi bir sosyal bilim olarak kıt kaynakların bu istekler ve ihtiyaçlar arasında nasıl dağıtılacağını; hangi ürünlerin hangi kriterlere göre seçileceğini veya seçilmeyeceğini inceleyen bir disiplindir. Bu kriterler fayda ve fırsat maliyetidir.Ekonominin teorik temeli rasyonel insan anlayışına dayanır.Rasyonel insan daima faydasını maksimize etmeye çalışırken seçimlerinden dolayı maruz kalacağı fırsat maliyetlerini minimize etmeye çalışır.Kaynak kıtlığı sadece maddi değil zamansal da olabilir.Ekonominin konusunu sadece bir bedel karşılığı değiş tokuşa konu olan ürünler oluşturur.Bunun dışındaki ürünler serbest ürünler olarak adlandırılır.Örneğin bir pınarın suyunu kimse bedel ödemeden içme suyu olarak kullanabiliyorsa bu ürün serbest bir üründür.Ancak bu su şişelenmeye başlayıp bir bedel karşılığında satılırsa ekonomik ürün haline gelir.Ekonomi makroekonomi ve mikroekonomi olarak ikiye ayrılır.Bugün rasyonellik sorgulanmaktadır.İnsanların kararlarını rasyonel bir biçimde değil daha çok irrasyonel en azından sınırlı ölçüde rasyonel olarak aldıkları ileri sürülmektedir.Bu tür sorgulamalar davranışsal ekonominin konusu olmaktadır.Davranışsal ekonomi bilişsel psikoloji ile sosyal psikoloji ile iç içe geçmiş bir disiplindir.İlgilendiği konular insanların aslında hangi kriterlere göre seçim yaptığı,aldıkları veya alamadıkları kararlar, pişmanlıklar, sahiplik etkisi, herüstik,vb.davranışsal faktörlerin ekonomi üzerindeki etkileridir.", "Ekonomi", "ekonomi" },
                    { 10, 5, "Enerji, alkollü içkiler ve tütün ürünleri hariç TÜFE. Ayrıca bakınız Özel Kapsamlı Tüketici Fiyatları Endeksi (Özel Kapsamlı TÜFE).", "E Endeksi", "e-endeksi" },
                    { 11, 6, "Enerji, alkollü içkiler, tütün ürünleri ve fiyatları yönetilen / yönlendirilen diğer ürünler ve dolaylı vergiler hariç TÜFE. Ayrıca bakınız Özel Kapsamlı Tüketici Fiyatları Endeksi (Özel Kapsamlı TÜFE).", "F Endeksi", "f-endeksi" },
                    { 5, 3, "Enerji ürünleri hariç TÜFE. Ayrıca bakınız Özel Kapsamlı Tüketici Fiyatları Endeksi (Özel Kapsamlı TÜFE).", "C Endeksi", "c-endeksi" },
                    { 20, 12, "Daha önce Britanya Bankalar Birliği tarafından yönetilen ve organize edilen sistem şimdi Intercontinental Exchange (ICE) adlı kurum tarafından yönetilmektedir.Sisteme üye olan bankaların belirli bir saatteki birbirlerine borç verme oranlarından yola çıkılarak gecelik; bir haftalık; 1,2,3,6 ve 12 aylık vadeler için günlük olarak ABD Doları, Euro, Pound, Yen ve İsviçre Frangı cinsinden faiz oranları için hesaplanırlar.En çok işlem gören ve bir ekonomik gösterge olarak da izlenilenleri 3 aylık LIBOR'dur.LIBOR diğer finansal işlemlerde referans olarak da kullanılır. Faiz oranlarına dayalı ileri valörlü faiz anlaşmaları(FRA), 3 aylık para piyasası faiz oranları üzerine vadeli işlem(futures) sözleşmeleri, faiz ve çapraz para swaplarında değişken faiz oranlarının tespiti amacıyla referans olarak kullanılır.Ayrıca özellikle ülkemizde yukarıda sayılan para birimlerinden ya da bunlara endeksli değişken faiz oranlı Türk Lirası kredilerde de önemli bir referanstır.", "Libor", "libor" },
                    { 13, 7, "Bir şirket için ana gelir kalemi yapmış olduğu ürün satışlarının parasal karşılığıdır. Bir ücretli veya maaşlı çalışan için aylık olarak elde ettiği kazancın parasal ifadesidir.Gelirleri brüt ve net gelirler olarak genelde ikiye ayırmak mümkündür.Bir şirket için brüt gelir yapmış olduğu satışların parasal tutarı olurken, bir ücretli veya maaşlı için gelir vergisi ve sosyal güvenlik kesintileri yapılmadan önceki gelir anlamına gelmektedir.Şirketler elde ettikleri satış gelirlerinden satılan malın maliyetini düştükten sonra brüt kar rakamına ulaşılır.Brüt kar rakamından şirketin faaliyetleri ve finansman nedeniyle yüklendikleri giderler düşüldükten sonra vergi öncesi kar rakamına; buradan da ödenecek olan kurumlar vergisi düşüldükten sonra ise net kar rakamına ulaşılır.Ücretliler ile maaşlılardan gelir vergisi ve sosyal güvenlik kesintileri yapıldıktan sonraki haline de net ücret veya maaş denir. Bu gelire harcanabilir gelir de denilebilir.", "Gelir", "gelir" },
                    { 19, 11, "Kalabalıklaşma etkisi merkezi hükümetin veya genelde kamunun borç verilebilecek kaynaklarının büyük bir kısmını talep etmesi anlamına gelmektedir. Kalabalıklaşma etkisi sınırlı fon bulma imkanı nedeniyle reel sektör kuruluşlarının ve hane halkının borçlanabilme kabiliyetlerinin azalmasına neden olur. Özellikle resesyon ile ekonomik durgunluk dönemlerinde bu durum ekonomik büyüme üzerinde negatif etki yapabilir.", "Kalabalıklaşma Etkisi", "kalabaliklasma-etkisi" },
                    { 14, 7, "İş hayatında kuruluş, işletme ve girişim anlamlarına gelmektedir.", "Girişim", "girisim" },
                    { 12, 6, "Faiz oranı risksiz getiri oranı ile risk priminin toplamından oluşur. Paranın zaman değerini belirleyen en önemli faktörlerden biridir. Diğerleri ise beklenen getiri oranı ve sermaye maliyetidir.Faiz oranı dönemsel faiz oranı, yıllık basit faiz oranı veya bileşik faiz oranı olarak ifade edilebilirler.Dönemsel faiz oranı belirli bir dönemin sonunda ödenecek veya tahsil edilecek olan faiz tutarını belirlemekte kullanılır.Yıllık basit faiz oranı dönemsel faiz oranının bir yılın tamamı için hesaplanan faiz oranıdır.Bileşik faiz oranı, birbirini izleyen birkaç eşdeğer dönem boyunca anapara ve faiz tutarlarının sürekli borçlanılması veya borç verilmesi durumunda elde edilecek kümüle faiz tutarını tespit etmek amacıyla kullanılan faiz oranıdır.Bileşik faiz oranı hesaplamasında en çok yıllık bileşik faiz oranı kullanılır.Bileşik faiz oranının sadece bir yıl içerisindeki eşdeğer dönemlerinin karşılığıdır.", "Faiz", "faiz" },
                    { 15, 8, "Hazine bonosunun özelliklerini şöyle sıralayabiliriz:Bunların dışında üzerlerinde hiç bir ibare bulunmaz.İhraç sırasında alınırken veya daha sonra alım satıma konu olurken ödenecek veya tahsil edilecek tutar(ana para) nominal tutarın o anki piyasa getiri oranından iskonto edilmesi suretiyle hesaplanır.Hesaplama yapılırken ya her 100 Türk Lirası nominal tutar için birim fiyattan yola çıkılarak ya da doğrudan nominal tutarın piyasa getiri oranından iskonto edilmesiyle bulunur.Hazine bonolarında birim fiyat veya ana para tutarı hesaplanırken ihraç sırasında yani birincil finansal piyasa işlemi olduğunda bir yıl 364 gün kabul edilir.İkincil finansal piyasada işlem gördüklerinde bir yıl 365 gün olarak ele alınır.", "Hazine Bonosu", "hazine-bonosu" },
                    { 16, 8, "Bu durumda arabamızı, evimizi, eşyalarımızı sigorta yapmak aslında hedge yaparak olası zararlardan kendimizi korumaya çalışmaktır.Finansal piyasalarda yaşanan volatiliteye karşı kendimizi korumak amacıyla türev ürünlerin hedge amaçlı kullanımı çok sıklıkla karşımıza çıkmaktadır.Türev ürünlerin bu amaçla kullanımı finansal piyasalarda sahip olduğumuz pozisyonlardan dolayı maruz kaldığımız döviz kurlarındaki, faiz oranlarındaki, pay(hisse) senedi ve emtia fiyatlarındaki dalgalanmaların neden olduğu riskleri elimine etmek ya da en azından azaltmak amaçlı olmaktadır.", "Hedge", "hedge" },
                    { 18, 11, "Kar payı dağıtımı bir şirketin bir önceki dönemde elde ettiği ya da daha önceki dönemde elde etmiş olduğu dağıtılabilir nitelikteki karların tamamının veya bir kısmını dağıtma kararı vermesi sonucu sermayedarlarına nakit veya yeni pay (hisse) senedi vermek suretiyle gerçekleştirilir.Dolayısıyla herhangi bir pay senedine yatırım yapan yatırımcıların elde etmeyi bekledikleri önemli gelir kaynaklarından biridir.", "Kar Payı", "kar-payi" },
                    { 17, 10, "Japonya’nın para birimidir.", "Japon Yeni", "japon-yeni" }
                });

            migrationBuilder.InsertData(
                table: "Formations",
                columns: new[] { "Id", "CategoryId", "Content", "Graphic", "Name", "Seourl" },
                values: new object[,]
                {
                    { 9, 19, "Her tepenin bir öncekinden daha alt seviyede, her desteğin ise bir öncekinden daha üst seviyede oluşması ile ortaya çıkarlar. Çizgi çalışması yapılırken iki direnç ve iki destek noktasına temas etmesi istenir. Fiyatlar bu iki çizgi arasında gittikçe sıkışmaya başlar. Formasyon üçgenin kırılması ile tamamlanmış olur ve bu kırılma anından sonra pozisyona girilir. Kırılmanın %3 - %5 oranında olması güveni artıracaktır. Tercih edilen ise kırılmanın yükselen işlem hacmi ile onaylanmasıdır. Genellikle trendin devamı şeklinde kırılırlar. Fiyatın üçgenin dip ve tepe seviyesi farkı kadar gitmesi gerekir aksi takdirde formasyonun başarısızlığa uğradığı kabul edilerek pozisyonlar kapatılır.", "formasyon9.png", "Simetrik Üçgen Formasyonu", "simetrik-ucgen" },
                    { 11, 1, "Dipler aynı seviyelerde gerçekleşirken her zirvenin bir önceki seviyeden daha alt bir seviyede oluşması ile şekillenirler. Talebin azaldığı dolayısıyla fiyatın düşme eğiliminde olduğunu gösterir. Formasyon oluşma kuralları yükselen üçgende olduğu gibidir.", "formasyon11.png", "Alçalan Üçgen Formasyonu", "alcalan-ucgen" },
                    { 14, 1, "Destek ve direnç çizgileri de aşağı eğilimli olmasına rağmen, direnç daha diktir. Kırılmanın yukarı yönlü olması daha sık görülen bir durum olsa da kırılmadan sonraki hareketin büyüklüğü hakkında fikir yürütmek zordur.", "formasyon15.png", "Alçalan Takoz Formasyonu", "alcalan-takoz" },
                    { 12, 2, "Oldukça sık görülen formasyon türleridir ve ortaya çıkış şekilleri birbirine oldukça benzer. Hacimle desteklenen sert bir piyasa hareketinden sonra gelen duraksama anlarını gösterirler. Fiyatlar bir süre konsolide olduktan sonra aynı yönlü hareketini devam ettirme eğilimindedir. Yükselen trendde oluşumları 5 gün ile 1-3 hafta arasında tamamlanırken aşağı trendlerde bu süre 1-2 haftadır. Flama formasyonlarının oluşumları, bayrak formasyonlarına göre daha kısa sürelidir. Spekülatif varlıklarda daha sık görülmektedirler. Yükselen bir piyasada hafif aşağı eğimli, düşen bir piyasada hafif yukarı eğimli olabilirler. Formasyon oluşmadan önce gelen hareket “bayrak direği” olarak adlandırılır ve kırılma anından sonra fiyatın bu uzunluk kadar gitmesi beklenir. ", "formasyon13.png", "Bayrak ve Flama Formasyonları", "bayrak-ve-flama" },
                    { 18, 2, "Yanlış bir al sinyali olarak, düşen bir trendde fiyatların direnç seviyesini kırma hareketinden sonra düşen trendin devam etmesidir.", "formasyon19.png", "Boğa Tuzağı Formasyonu", "boga-tuzagi" },
                    { 1, 15, "Yükselen bir trendin sonlanmakta olduğunu ve düşen bir trendin başladığını gösterir. Bu formasyonda fiyatlar önce bir tepe yapar ve sol omuz oluşur. Sonrasında daha yüksek bir tepe ile fiyat hareketinin devamı başı oluşturur. Formasyon, üçüncü tepenin (sağ omuz) en yüksek noktalarının ilk tepe ile aynı fiyat seviyelerinde oluştuktan sonra satışların güçlenmesi sonucunda destek seviyesinin (boyun çizgisi) kırılması ile tamamlanmış varsayılır.İlk tepe,oluşan rallide karlarını realize eden yatırımcıların satışları ve talebin azalması ile oluşur.Buradaki geri çekilme ile geç katılımcılar bir alım fırsatı yakaladıkları varsayımıyla alışa geçerler.İkinci  tepe geçici ve kısa bir süre gelen taleple ilk tepenin üstünde oluşur fakat ilk tepede satış fırsatını kaçırdıklarını düşünen yatırımcıların satışları ile fiyat yeni zirveler yapamaz ve buradaki hacim ilk tepeyi oluşturan hacmin altındadır.Sol omuz ile başın dipleri arasındaki çizgi kritik destek seviyesi olan boyun çizgisi(neckline)’dir.Buradan gelen son tepki alışları sol omuz seviyelerinde son bulur ve fiyatlar tekrar boyun seviyesine gelerek sağ omuzu oluşturur.Boyun çizgisi eğimli olabilir ve bazı teknik analizciler aşağıya doğru eğimin formasyonun güvenilirliğini artırdığına inanmaktadırlar.Fiyatların boyun seviyesini en az % 5 aşağı doğru kırması ile formasyon tamamlanmış olur.Destek seviyesi kırıldıktan sonra fiyatın H boyu kadar gitmesi hedeflenir.Oluşumların vadesi 3 - 4 haftadan birkaç yıla kadar sürmektedir. ", "formasyon1.png", "Omuz Baş Omuz Formasyonu", "omuz-bas-omuz" },
                    { 3, 3, "Trend dönüşlerinde önemli sinyallerdir. “M” harfine benzemektedirler. Fiyatların aynı zirve seviyeleri iki kez test etmesi ile oluşurlar. İşlem hacmi ilk tepede, ikinciye nispeten daha yoğundur. Çift tepeler ana trend değişim formasyonlarıdır ve iki tepenin oluşması arasındaki süre 2-3 ay sürebilir. İki tepe arasındaki yükseklik farkı %3 olabilir. Bu formasyonda da destek seviyesinin kırılması ile fiyatın H boyu kadar düşmesi beklenir.", "formasyon3.png", "Çift Tepe Formasyonu ", "cift-tepe" },
                    { 17, 1, "Yanlış bir sat sinyali olarak, yükselen bir trendde fiyatların destek seviyesini kırma  hareketinden sonra yükselen trendini devam ettirmesidir.", "formasyon18.png", "Ayı Tuzağı Formasyonu", "ayi-tuzagi" },
                    { 13, 25, "Fiyatların artmasına rağmen talep gittikçe azalmaktadır. Alçalan ya da yükselen trendlerde görülebilirler. Destek,  direnç seviyesine göre daha dik olmaktadır. Formasyonun yukarı yönlü olması, kırılmanın yukarı yönlü olabileceği gibi bir beklentiye neden olsa da bu çok doğru değildir. Kırılmadan sonra formasyonun oluşumunu tamamladığı varsayılır.", "formasyon14.png", "Yükselen Takoz Formasyonu", "yukselen-takoz" },
                    { 2, 20, "Düşüş trendinin sonunda oluşan yüksek güvenilirlikli bir dip formasyonudur. Oluşum kuralları omuz baş omuz formasyonu ile aynıdır ve omuz baş omuz formasyonunun simetriği gibi görünür. Burada da hacim öneli bir kriterdir. İlk dipte oluşan hacim ortadaki dip seviyesinden yüksektir ve son dip seviyesinin hacmi ilk iki dip seviyesini oluşturan hacmin 1,5 – 2 katı olmalıdır. ", "formasyon2.png", "Ters Omuz Baş Omuz Formasyonu", "ters-omuz-bas-omuz" },
                    { 5, 21, "Sıklıkla görülen formasyonlar değillerdir ve çift tepe formasyonunun özelliklerini taşırlar. İkinci tepeden sonra aşağı yönlü hareket eden fiyatların destek seviyesini kırmaması ve aynı seviyelerde yeni bir tepe oluşturması ile ortaya çıkarlar. İşlem hacmi son tepede en düşük seviyesindedir. ", "formasyon5.png", "Üçlü Tepe Formasyonu", "uclu-tepe" },
                    { 6, 21, "Üçlü Tepe Formasyonları’nın simetriğidirler ve düşen bir trendin diplerinde oluşurlar. Farklı olarak, oluşum sürecinde işlem hacminin gittikçe artması beklenir. Üçlü Tepe ve Üçlü Dip formasyonlarında trend dönüşlerinin nispeten daha sert olduğu söylenebilir.", "formasyon6.png", "Üçlü Dip Formasyonu", "uclu-dip" },
                    { 7, 22, "Çok hızlı seyreden fiyat hareketleri ile oluşurlar. Çoğunlukla geç fark edilirler. Bu hareketlerin kaynağı genelde yatırımcıların spekülatif işlemleridir. Nispeten kısa vadeli trendlerin tepe ve diplerinde uzun vadeli trendlere göre daha sık görülürler.  Yükselişlerin işlem hacmi ile desteklenmesi beklenir. ", "formasyon7.png", "V Tepe ve Dipler ( V Formasyonları)", "v-tepe-ve-dip" },
                    { 16, 4, "Üçgen formasyonları gibi dinlenme alanlarını gösterirler. Farklı olarak zirveler ve dipler aynı fiyat seviyelerinde oluşur ve bu seviyeleri birleştiren doğrular birbirine paraleldir. Bu formasyon düşüş trendinde yukarı eğilimli, yükseliş trendinde aşağı eğilimli olabilir. Formasyonun oluşma süreci gittikçe azalan bir işlem hacmi ile tamamlanır ve kırılmadan sonra gelen hareketin dikdörtgenin yüksekliği kadar olması beklenir.", "formasyon17.png", "Dikdörtgen Formasyonu", "dikdortgen" },
                    { 4, 3, "Çift tepe formasyonlarının tam tersi olup, piyasanın dip noktalarında oluşurlar. Oluşum kuralları çift tepe formasyonları ile aynıdır. “W” harfine benzerler. İşlem hacmi ilk dip oluşurken en yüksek seviyededir. İkinci dibin en alt noktasından itibaren hacim fiyatlarla beraber yükselmeye başlar.", "formasyon4.png", "Çift Dip Formasyonu", "cift-dip" },
                    { 10, 25, "Zirveler aynı seviyelerde gerçekleşirken her dibin bir önceki seviyeden daha üst bir seviyede oluşmasıyla şekillenirler. Gittikçe azalan bir işlem hacmi vardır. Formasyon tamamlandıkça bir dik üçgen görüntüsü ortaya çıkar. Kırılmanın yükselen hacimle gelmesi formasyonun güvenilirliğini artırmaktadır. Kırılma anından sonra hedef fiyat üçgenin yüksekliği kadardır. ", "formasyon10.png", "Yükselen Üçgen Formasyonu", "yukselen-ucgen" },
                    { 8, 3, "Çanak formasyonları düşen  piyasa dönüşlerinde, Ters Çanak Formasyonları ise yükselen piyasa dönüşlerinde görülmektedir. Çanak Formasyonu genellikle varlık fiyatının ucuz olduğu, Ters Çanak Formasyonu ise varlıkların yüksek fiyatlandığı piyasalarda görülür.Çanak formasyonunda fiyatlar bir dip çalışması yaparak bir süre yatay harekette bulunur.Bu hareket sırasında işlem hacmi azalarak çanağın orta seviyesinde en düşük seviyesine geriler.Sonraki süreçte alışlar düşük ivmeyle artmaya başlar ve fiyatlar direnç seviyesine doğru seyreder.Fiyatların direnç seviyesini kırması ile formasyon tamamlanmış varsayılır.Çanak formasyonlarıın tersidir.Zirve seviyelerinde oluşurlar.İşlem hacmi, formasyon oluşumunu tamamladıkça azalmaktadır.Fiyatların artması ve düşmesi simetrik olmalıdır.", "formasyon8.png", "Çanak ve Ters Çanak Formasyonları", "canak-ve-ters-canak" },
                    { 15, 5, "Genellikle piyasanın tepelerinde görülen bir ana trend formasyonudur. Gittikçe genişleyen ve gittikçe daralan iki üçgenin birleşimi gibi görünür. Oluşumları birkaç ayı bulabilir. Bu süre içerisinde görülen hareketler nispeten daha volatildir. Ölçümleme işlemleri üçgen formasyonlarına benzer. Kırılmadan   sonra fiyatın, formasyonun en dip ve en üst seviyesi arasındaki fark kadar hareket etmesi beklenir.", "formasyon16.png", "Elmas Formasyonu", "elmas" }
                });

            migrationBuilder.InsertData(
                table: "FrozenUsers",
                columns: new[] { "Id", "FrozenDateTime", "FrozenReason", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 7, 11, 7, 24, 3, 257, DateTimeKind.Local).AddTicks(5599), "Sıkıldım", 5 },
                    { 2, new DateTime(2019, 7, 11, 7, 24, 3, 257, DateTimeKind.Local).AddTicks(6003), "Ara verecem", 7 }
                });

            migrationBuilder.InsertData(
                table: "Markets",
                columns: new[] { "Id", "Code", "Icon", "Name", "SeoUrl", "TypeId", "Unit" },
                values: new object[,]
                {
                    { 38, "HUF", "Hungary", "Macar Forinti", "macar-forinti", 1, (byte)1 },
                    { 45, "NAD", "Namibia", "Namibian Doları", "namibian-dolari", 1, (byte)1 },
                    { 44, "MUR", "Mauritius", "Mauritius Rupisi", "mauritius-rupisi", 1, (byte)1 },
                    { 43, "MNT", "Mongolia", "Moğol Tugrik", "mogol-tugrik", 1, (byte)1 },
                    { 46, "NGN", "Nigeria", "Nijerya Nairası", "nijerya-nairasi", 1, (byte)1 },
                    { 42, "EGP", "Egypt", "Mısır Lirası", "misir-lirasi", 1, (byte)1 },
                    { 41, "MXN", "Mexico", "Meksika Pesosu", "meksika-pesosu", 1, (byte)1 },
                    { 40, "MYR", "Malaysia", "Malezya Ringgiti", "malezsya-ringgiti", 1, (byte)1 },
                    { 39, "MWK", "Malawi", "Malavi Kvaçası", "malavi-kvacasi", 1, (byte)1 },
                    { 33, "KES", "Kenya", "Kenya Şilini", "kenya-silini", 1, (byte)1 },
                    { 36, "KWD", "Kuwait", "Kuveyt Dinarı", "kuveyt-dinari", 1, (byte)1 },
                    { 35, "CRC", "Costa_Rica", "Kosta Rika Kolonu", "kosta-rika-kolonu", 1, (byte)1 },
                    { 34, "COP", "Colombia", "Kolombiya Pesosu", "kolombiya-pesosu", 1, (byte)1 },
                    { 28, "JMD", "Jamaica", "Jamaika Doları", "jamaika-dolari", 1, (byte)1 },
                    { 32, "KZT", "Kazakhstan", "Kazakistan Tengesi", "kazakistan-tengesi", 1, (byte)1 },
                    { 31, "QAR", "Qatar", "Katar Riyali", "katar-riyali", 1, (byte)1 },
                    { 30, "KND", "Canada", "Kanada Doları", "kanada-dolari", 1, (byte)1 },
                    { 29, "JPY", "Japan", "Japon Yeni", "japon-yeni", 1, (byte)1 },
                    { 47, "NOK", "Norway", "Norveç Kronu", "norvec-kronu", 1, (byte)1 },
                    { 37, "LBP", "Lebanon", "Lübnan Lirası", "lubnan-lirasi", 1, (byte)1 },
                    { 48, "PKR", "Pakistan", "Pakistan Rupisi", "pakistan-rupisi", 1, (byte)1 },
                    { 68, "VES", "Venezuela", "Venezuela bolivarı", "venezuela-bolivari", 1, (byte)1 },
                    { 50, "PLN", "Poland", "Polonya Zlotisi", "polonya-zlotisi", 1, (byte)1 },
                    { 27, "ISK", "Iceland", "İzlanda Kronu", "izlanda-kronu", 1, (byte)1 },
                    { 71, "ZMK", "Zambia", "Zambiya Kvaçası", "zambiya-kvacasi", 1, (byte)1 },
                    { 70, "NZD", "New_Zealand", "Yeni Zelanda Doları", "yeni-zellanda-dolari", 1, (byte)1 },
                    { 69, "VND", "Vietnam", "Vietnam Dongu", "vietnam-dongu", 1, (byte)1 },
                    { 67, "JOD", "Jordan", "Ürdün Dinarı", "urdun-dinari", 1, (byte)1 },
                    { 66, "OMR", "Oman", "Umman Riyali", "umman-riyali", 1, (byte)1 },
                    { 65, "UAH", "Ukraine", "Ukrayna Grivnası", "ukrayna-grivnasi", 1, (byte)1 },
                    { 64, "UGX", "Uganda", "Uganda Şilini", "uganda-silini", 1, (byte)1 },
                    { 63, "TRY", "Turkey", "Türk Lirası", "turk-lirasi", 1, (byte)1 },
                    { 62, "TND", "Tunisia", "Tunus Dinarı", "tunus-dinari", 1, (byte)1 },
                    { 61, "TWD", "Taiwan", "Yeni Tayvan Doları", "yeni-tayvan-dolari", 1, (byte)1 },
                    { 60, "THB", "Thailand", "Tayland Bahtı", "tayland-bahti", 1, (byte)1 },
                    { 59, "TZS", "Tanzania", "Tanzanya Şilini", "tanzanya-silini", 1, (byte)1 },
                    { 58, "SAR", "Saudi_Arabia", "Suudi Arabistan Riyali", "suudi-arabistan-riyali", 1, (byte)1 },
                    { 57, "LKR", "Sri_Lanka", "Sri Lanka Rupisi", "sri-lanka-rupisi", 1, (byte)1 },
                    { 56, "RSD", "Serbia", "Sırp Dinarı", "sirp-dinari", 1, (byte)1 },
                    { 55, "SGD", "Singapore", "Singapur Doları", "singapur-dolari", 1, (byte)1 },
                    { 54, "CLP", "Chile", "Şili Pesosu", "sili-pesosu", 1, (byte)1 },
                    { 53, "RUB", "Russian_Federation", "Rus Rublesi", "rus-rublesi", 1, (byte)1 },
                    { 52, "RWF", "Rwanda", "Ruanda Frangı", "ruanda-frangi", 1, (byte)1 },
                    { 51, "RON", "Romania", "Rumen Leyi", "rumen-leyi", 1, (byte)1 },
                    { 49, "PEN", "Peru", "Peruvian Sol", "peruvian-sol", 1, (byte)1 },
                    { 26, "CHF", "Switzerland", "İsviçre Frangı", "isvicre-frangi", 1, (byte)1 },
                    { 14, "IDR", "Indonesia", "Endonezya Rupisi", "endonezya-rupisi", 1, (byte)1 },
                    { 24, "IQD", "Iraq", "Irak Dinarı", "irak-dinari", 1, (byte)1 },
                    { 25, "SEK", "Sweden", "İsveç Kronu", "isvec-kronu", 1, (byte)1 },
                    { 1, "USD", "USA", "Amerikan Doları", "usd", 1, (byte)1 },
                    { 2, "ARS", "Argentina", "Arjantin Pesosu", "arjantin-pesosu", 1, (byte)100 },
                    { 3, "AUD", "Australia", "Avustralya Doları", "avustralya-dolari", 1, (byte)1 },
                    { 5, "BDT", "Bangladesh", "Bangladeş Takası", "banglades-takasi", 1, (byte)1 },
                    { 6, "EURO", "Belgium", "EURO", "euro", 1, (byte)1 },
                    { 7, "AED", "Dubai", "Birleşik Arap Emirlikleri Dirhemi", "birlesik-arap-emirlikleri-dirhemi", 1, (byte)1 },
                    { 8, "STERLIN", "UK", "Sterlin", "ingiliz-sterlin", 1, (byte)1 },
                    { 9, "BAM", "Bosnia", "Bosna-Hersek Markı", "bosna-herkes-marki", 1, (byte)1 },
                    { 10, "BRL", "Brazil", "Brezilya Reali", "brezilya-reali", 1, (byte)1 },
                    { 11, "BGN", "Bulgaria", "Bulgar Levası", "bulgar-levasi", 1, (byte)100 },
                    { 4, "BHD", "Bahrain", "Bahreyn Dinarı", "bahreyn-dinari", 1, (byte)1 },
                    { 13, "CNY", "China", "Çin Yuanı", "cin-yuani", 1, (byte)1 },
                    { 23, "HKD", "Hong_Kong", "Hong Kong Doları", "hong-kong-dolari", 1, (byte)1 },
                    { 12, "CZK", "Czech_Republic", "Çek Korunası", "cek-korunasi", 1, (byte)1 },
                    { 22, "HRK", "Croatia", "Hırvatistan Kunası", "hirvatistan-kunasi", 1, (byte)1 },
                    { 20, "KRW", "South_Korea", "Güney Kore Wonu", "guney-kore-wonu", 1, (byte)1 },
                    { 21, "INR", "India", "Hindistan Rupisi", "hindistan-rupisi", 1, (byte)1 },
                    { 18, "ILS", "Palestine", "Yeni İsrail Şekeli", "yeni-israil-sekeli", 1, (byte)1 },
                    { 17, "PHP", "Philippines", "Filipin Pesosu", "filipin-pesosu", 1, (byte)1 },
                    { 16, "CFA", "Cote_dIvoire", "Batı Afrika CFA Frang", "bati-afrika-cfa-frang", 1, (byte)1 },
                    { 15, "MAD", "Morocco", "Fas Dirhemi", "fas-dirhemi", 1, (byte)1 },
                    { 19, "ZAR", "South_Africa", "Güney Afrika Randı", "güney-afrika-randi", 1, (byte)1 }
                });

            migrationBuilder.InsertData(
                table: "OpenCloseMarkets",
                columns: new[] { "Id", "CloseDateTime", "CountryId", "OpenCloseIcon", "OpenDateTime" },
                values: new object[,]
                {
                    { 16, new DateTime(2019, 7, 10, 22, 24, 3, 258, DateTimeKind.Local).AddTicks(3034), 17, "picture/close", new DateTime(2019, 7, 11, 10, 24, 3, 258, DateTimeKind.Local).AddTicks(3033) },
                    { 2, new DateTime(2019, 7, 10, 22, 24, 3, 258, DateTimeKind.Local).AddTicks(3008), 2, "picture/close", new DateTime(2019, 7, 11, 10, 24, 3, 258, DateTimeKind.Local).AddTicks(3004) },
                    { 15, new DateTime(2019, 7, 11, 15, 24, 3, 258, DateTimeKind.Local).AddTicks(3032), 15, "picture/open", new DateTime(2019, 7, 11, 7, 24, 3, 258, DateTimeKind.Local).AddTicks(3032) },
                    { 14, new DateTime(2019, 7, 11, 16, 24, 3, 258, DateTimeKind.Local).AddTicks(3031), 14, "picture/open", new DateTime(2019, 7, 11, 8, 24, 3, 258, DateTimeKind.Local).AddTicks(3030) },
                    { 1, new DateTime(2019, 7, 11, 15, 24, 3, 258, DateTimeKind.Local).AddTicks(2773), 1, "picture/open", new DateTime(2019, 7, 11, 7, 24, 3, 258, DateTimeKind.Local).AddTicks(2552) },
                    { 3, new DateTime(2019, 7, 11, 6, 24, 3, 258, DateTimeKind.Local).AddTicks(3013), 3, "picture/close", new DateTime(2019, 7, 11, 19, 24, 3, 258, DateTimeKind.Local).AddTicks(3012) },
                    { 10, new DateTime(2019, 7, 11, 6, 24, 3, 258, DateTimeKind.Local).AddTicks(3024), 10, "picture/close", new DateTime(2019, 7, 11, 19, 24, 3, 258, DateTimeKind.Local).AddTicks(3023) },
                    { 12, new DateTime(2019, 7, 11, 9, 24, 3, 258, DateTimeKind.Local).AddTicks(3028), 12, "picture/open", new DateTime(2019, 7, 11, 1, 24, 3, 258, DateTimeKind.Local).AddTicks(3027) },
                    { 11, new DateTime(2019, 7, 11, 18, 24, 3, 258, DateTimeKind.Local).AddTicks(3026), 11, "picture/open", new DateTime(2019, 7, 11, 6, 24, 3, 258, DateTimeKind.Local).AddTicks(3025) },
                    { 4, new DateTime(2019, 7, 11, 18, 24, 3, 258, DateTimeKind.Local).AddTicks(3015), 4, "picture/open", new DateTime(2019, 7, 11, 6, 24, 3, 258, DateTimeKind.Local).AddTicks(3014) },
                    { 9, new DateTime(2019, 7, 10, 22, 24, 3, 258, DateTimeKind.Local).AddTicks(3022), 9, "picture/close", new DateTime(2019, 7, 11, 10, 24, 3, 258, DateTimeKind.Local).AddTicks(3022) },
                    { 8, new DateTime(2019, 7, 11, 15, 24, 3, 258, DateTimeKind.Local).AddTicks(3021), 8, "picture/open", new DateTime(2019, 7, 11, 7, 24, 3, 258, DateTimeKind.Local).AddTicks(3020) },
                    { 7, new DateTime(2019, 7, 11, 16, 24, 3, 258, DateTimeKind.Local).AddTicks(3019), 7, "picture/open", new DateTime(2019, 7, 11, 8, 24, 3, 258, DateTimeKind.Local).AddTicks(3019) },
                    { 18, new DateTime(2019, 7, 11, 6, 24, 3, 258, DateTimeKind.Local).AddTicks(3035), 18, "picture/close", new DateTime(2019, 7, 11, 19, 24, 3, 258, DateTimeKind.Local).AddTicks(3034) },
                    { 13, new DateTime(2019, 7, 11, 1, 24, 3, 258, DateTimeKind.Local).AddTicks(3029), 13, "picture/close", new DateTime(2019, 7, 11, 9, 24, 3, 258, DateTimeKind.Local).AddTicks(3029) },
                    { 5, new DateTime(2019, 7, 11, 9, 24, 3, 258, DateTimeKind.Local).AddTicks(3016), 5, "picture/open", new DateTime(2019, 7, 11, 1, 24, 3, 258, DateTimeKind.Local).AddTicks(3016) },
                    { 19, new DateTime(2019, 7, 11, 18, 24, 3, 258, DateTimeKind.Local).AddTicks(3037), 19, "picture/open", new DateTime(2019, 7, 11, 6, 24, 3, 258, DateTimeKind.Local).AddTicks(3036) },
                    { 21, new DateTime(2019, 7, 11, 1, 24, 3, 258, DateTimeKind.Local).AddTicks(3040), 21, "picture/close", new DateTime(2019, 7, 11, 9, 24, 3, 258, DateTimeKind.Local).AddTicks(3039) },
                    { 36, new DateTime(2019, 7, 11, 16, 24, 3, 258, DateTimeKind.Local).AddTicks(3063), 36, "picture/open", new DateTime(2019, 7, 11, 8, 24, 3, 258, DateTimeKind.Local).AddTicks(3062) },
                    { 35, new DateTime(2019, 7, 11, 1, 24, 3, 258, DateTimeKind.Local).AddTicks(3061), 35, "picture/close", new DateTime(2019, 7, 11, 9, 24, 3, 258, DateTimeKind.Local).AddTicks(3061) },
                    { 34, new DateTime(2019, 7, 11, 9, 24, 3, 258, DateTimeKind.Local).AddTicks(3060), 34, "picture/open", new DateTime(2019, 7, 11, 1, 24, 3, 258, DateTimeKind.Local).AddTicks(3059) },
                    { 33, new DateTime(2019, 7, 11, 18, 24, 3, 258, DateTimeKind.Local).AddTicks(3058), 33, "picture/open", new DateTime(2019, 7, 11, 6, 24, 3, 258, DateTimeKind.Local).AddTicks(3058) },
                    { 32, new DateTime(2019, 7, 11, 6, 24, 3, 258, DateTimeKind.Local).AddTicks(3057), 32, "picture/close", new DateTime(2019, 7, 11, 19, 24, 3, 258, DateTimeKind.Local).AddTicks(3056) },
                    { 31, new DateTime(2019, 7, 10, 22, 24, 3, 258, DateTimeKind.Local).AddTicks(3055), 31, "picture/close", new DateTime(2019, 7, 11, 10, 24, 3, 258, DateTimeKind.Local).AddTicks(3055) },
                    { 30, new DateTime(2019, 7, 11, 15, 24, 3, 258, DateTimeKind.Local).AddTicks(3054), 30, "picture/open", new DateTime(2019, 7, 11, 7, 24, 3, 258, DateTimeKind.Local).AddTicks(3053) },
                    { 29, new DateTime(2019, 7, 11, 16, 24, 3, 258, DateTimeKind.Local).AddTicks(3052), 29, "picture/open", new DateTime(2019, 7, 11, 8, 24, 3, 258, DateTimeKind.Local).AddTicks(3052) },
                    { 28, new DateTime(2019, 7, 11, 1, 24, 3, 258, DateTimeKind.Local).AddTicks(3051), 28, "picture/close", new DateTime(2019, 7, 11, 9, 24, 3, 258, DateTimeKind.Local).AddTicks(3050) },
                    { 20, new DateTime(2019, 7, 11, 9, 24, 3, 258, DateTimeKind.Local).AddTicks(3038), 20, "picture/open", new DateTime(2019, 7, 11, 1, 24, 3, 258, DateTimeKind.Local).AddTicks(3038) },
                    { 6, new DateTime(2019, 7, 11, 1, 24, 3, 258, DateTimeKind.Local).AddTicks(3018), 6, "picture/close", new DateTime(2019, 7, 11, 9, 24, 3, 258, DateTimeKind.Local).AddTicks(3017) },
                    { 22, new DateTime(2019, 7, 11, 16, 24, 3, 258, DateTimeKind.Local).AddTicks(3041), 22, "picture/open", new DateTime(2019, 7, 11, 8, 24, 3, 258, DateTimeKind.Local).AddTicks(3041) },
                    { 23, new DateTime(2019, 7, 11, 15, 24, 3, 258, DateTimeKind.Local).AddTicks(3043), 23, "picture/open", new DateTime(2019, 7, 11, 7, 24, 3, 258, DateTimeKind.Local).AddTicks(3042) },
                    { 24, new DateTime(2019, 7, 10, 22, 24, 3, 258, DateTimeKind.Local).AddTicks(3044), 24, "picture/close", new DateTime(2019, 7, 11, 10, 24, 3, 258, DateTimeKind.Local).AddTicks(3044) },
                    { 25, new DateTime(2019, 7, 11, 6, 24, 3, 258, DateTimeKind.Local).AddTicks(3046), 25, "picture/close", new DateTime(2019, 7, 11, 19, 24, 3, 258, DateTimeKind.Local).AddTicks(3045) },
                    { 27, new DateTime(2019, 7, 11, 9, 24, 3, 258, DateTimeKind.Local).AddTicks(3049), 27, "picture/open", new DateTime(2019, 7, 11, 1, 24, 3, 258, DateTimeKind.Local).AddTicks(3049) },
                    { 26, new DateTime(2019, 7, 11, 18, 24, 3, 258, DateTimeKind.Local).AddTicks(3048), 26, "picture/open", new DateTime(2019, 7, 11, 6, 24, 3, 258, DateTimeKind.Local).AddTicks(3047) }
                });

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "Id", "CreatedDateTime", "SubscribedByUserId", "SubscribedUserId" },
                values: new object[,]
                {
                    { 2, new DateTime(2019, 7, 1, 8, 24, 3, 255, DateTimeKind.Local).AddTicks(8765), 2, 3 },
                    { 6, new DateTime(2019, 7, 4, 8, 24, 3, 255, DateTimeKind.Local).AddTicks(8772), 5, 2 },
                    { 5, new DateTime(2019, 7, 2, 8, 24, 3, 255, DateTimeKind.Local).AddTicks(8772), 2, 5 },
                    { 1, new DateTime(2019, 7, 11, 8, 24, 3, 255, DateTimeKind.Local).AddTicks(8541), 1, 2 },
                    { 4, new DateTime(2019, 7, 10, 8, 24, 3, 255, DateTimeKind.Local).AddTicks(8771), 3, 5 },
                    { 7, new DateTime(2019, 7, 7, 8, 24, 3, 255, DateTimeKind.Local).AddTicks(8773), 5, 8 },
                    { 8, new DateTime(2019, 7, 6, 8, 24, 3, 255, DateTimeKind.Local).AddTicks(8774), 8, 7 },
                    { 3, new DateTime(2019, 6, 29, 8, 24, 3, 255, DateTimeKind.Local).AddTicks(8770), 3, 2 }
                });

            migrationBuilder.InsertData(
                table: "UserComplaints",
                columns: new[] { "Id", "ComplainantUserId", "ComplainedUserId", "ComplaintDateTime", "ComplaintDescription", "TopicOfComplaintId" },
                values: new object[] { 6, 6, 4, new DateTime(2019, 7, 11, 5, 24, 3, 257, DateTimeKind.Local).AddTicks(5048), "Rahatsız edici", 5 });

            migrationBuilder.InsertData(
                table: "UserComplaints",
                columns: new[] { "Id", "ComplainantUserId", "ComplainedUserId", "ComplaintDateTime", "ComplaintDescription", "TopicOfComplaintId" },
                values: new object[] { 2, 1, 3, new DateTime(2019, 7, 11, 6, 24, 3, 257, DateTimeKind.Local).AddTicks(5042), "Uygunsuz", 1 });

            migrationBuilder.InsertData(
                table: "UserComplaints",
                columns: new[] { "Id", "ComplainantUserId", "ComplainedUserId", "ComplaintDateTime", "ComplaintDescription", "TopicOfComplaintId" },
                values: new object[] { 1, 1, 2, new DateTime(2019, 7, 11, 7, 24, 3, 257, DateTimeKind.Local).AddTicks(4809), "Alakasız", 1 });

            migrationBuilder.InsertData(
                table: "UserComplaints",
                columns: new[] { "Id", "ComplainantUserId", "ComplainedUserId", "ComplaintDateTime", "ComplaintDescription", "TopicOfComplaintId" },
                values: new object[] { 3, 3, 2, new DateTime(2019, 7, 11, 4, 24, 3, 257, DateTimeKind.Local).AddTicks(5047), "Kötü", 4 });

            migrationBuilder.InsertData(
                table: "UserLogins",
                columns: new[] { "Id", "IpAddress", "LastLoginDateTime", "LastLogoutDateTime", "UserId" },
                values: new object[,]
                {
                    { 1, "192.168.1.1", new DateTime(2019, 7, 11, 8, 24, 3, 255, DateTimeKind.Local).AddTicks(9291), new DateTime(2019, 7, 11, 11, 24, 3, 255, DateTimeKind.Local).AddTicks(9497), 2 },
                    { 7, "192.168.1.52", new DateTime(2019, 7, 11, 8, 24, 3, 255, DateTimeKind.Local).AddTicks(9994), new DateTime(2019, 7, 11, 19, 24, 3, 255, DateTimeKind.Local).AddTicks(9994), 7 },
                    { 6, "192.168.1.53", new DateTime(2019, 7, 11, 8, 24, 3, 255, DateTimeKind.Local).AddTicks(9991), new DateTime(2019, 7, 11, 21, 24, 3, 255, DateTimeKind.Local).AddTicks(9992), 6 },
                    { 2, "192.168.1.2", new DateTime(2019, 7, 11, 8, 24, 3, 255, DateTimeKind.Local).AddTicks(9976), new DateTime(2019, 7, 11, 10, 24, 3, 255, DateTimeKind.Local).AddTicks(9980), 1 },
                    { 3, "192.168.1.36", new DateTime(2019, 7, 11, 8, 24, 3, 255, DateTimeKind.Local).AddTicks(9987), new DateTime(2019, 7, 11, 20, 24, 3, 255, DateTimeKind.Local).AddTicks(9987), 3 },
                    { 5, "192.168.1.54", new DateTime(2019, 7, 11, 8, 24, 3, 255, DateTimeKind.Local).AddTicks(9990), new DateTime(2019, 7, 11, 12, 24, 3, 255, DateTimeKind.Local).AddTicks(9990), 5 },
                    { 8, "192.168.1.51", new DateTime(2019, 7, 11, 8, 24, 3, 255, DateTimeKind.Local).AddTicks(9995), new DateTime(2019, 7, 11, 15, 24, 3, 255, DateTimeKind.Local).AddTicks(9996), 8 },
                    { 4, "192.168.1.55", new DateTime(2019, 7, 11, 8, 24, 3, 255, DateTimeKind.Local).AddTicks(9989), new DateTime(2019, 7, 11, 9, 24, 3, 255, DateTimeKind.Local).AddTicks(9989), 4 }
                });

            migrationBuilder.InsertData(
                table: "UserProfiles",
                columns: new[] { "Id", "AvatarPath", "City", "DateOfBirth", "ExperienceScore", "FacebookProfile", "Gender", "InstagramProfile", "Job", "LastPageViewed", "LastPageViewedDateTime", "Name", "PersonalOpinion", "PhoneNumber", "Surname", "TwitterProfile", "UserId", "UserLevel" },
                values: new object[,]
                {
                    { 8, "3.jpg", "Istanbul", new DateTime(1921, 7, 11, 8, 24, 3, 258, DateTimeKind.Local).AddTicks(1601), 232133, "www.facebook8.com", "Bayan", null, "doktor", "Euro", new DateTime(2019, 7, 11, 8, 16, 3, 258, DateTimeKind.Local).AddTicks(1606), "leyla", "Alım satımda üstüme tanımam", "05420000007", "mert", "www.twitter8.com", 8, (byte)4 },
                    { 7, "8.jpg", "Istanbul", new DateTime(2001, 7, 11, 8, 24, 3, 258, DateTimeKind.Local).AddTicks(1598), 23335, null, "Bay", "www.instagram7.com", "doçent", "Dolar", new DateTime(2019, 7, 11, 8, 17, 3, 258, DateTimeKind.Local).AddTicks(1600), "mehmet", null, "05420000006", "toprak", "www.twitter7.com", 7, (byte)3 },
                    { 9, "2.jpg", "Istanbul", new DateTime(1921, 7, 11, 8, 24, 3, 258, DateTimeKind.Local).AddTicks(1607), 2133, null, "Bay", null, "Futbolcu", "Dolar", new DateTime(2019, 7, 11, 8, 19, 3, 258, DateTimeKind.Local).AddTicks(1608), "Cris", "Vurdum gol oldu", "05420050007", "Ronaldo", null, 9, (byte)2 },
                    { 6, "7.jpg", "Adana", new DateTime(2000, 7, 11, 8, 24, 3, 258, DateTimeKind.Local).AddTicks(1595), 23334, "www.facebook6.com", "Bay", "www.instagram6.com", "sanatçı", "Homepage", new DateTime(2019, 7, 11, 8, 18, 3, 258, DateTimeKind.Local).AddTicks(1597), "ahmet", "Bu siteye bayılıyorum", "05420000005", "su", null, 6, (byte)1 },
                    { 5, "4.jpg", "Sakarya", new DateTime(2008, 7, 11, 8, 24, 3, 258, DateTimeKind.Local).AddTicks(1592), 23333, "www.facebook5.com", "Bayan", "www.instagram5.com", "fifa oynamak", "Serkan Topkan profil sayfası", new DateTime(2019, 7, 11, 8, 19, 3, 258, DateTimeKind.Local).AddTicks(1594), "damla", null, "05420000004", "çiçek", "www.twitter5.com", 5, (byte)3 },
                    { 4, "6.jpg", "Istanbul", new DateTime(1995, 7, 11, 8, 24, 3, 258, DateTimeKind.Local).AddTicks(1589), 5333, null, "Bay", null, "Mühendis", "Euro", new DateTime(2019, 7, 11, 8, 20, 3, 258, DateTimeKind.Local).AddTicks(1591), "Aykut", "Ekonomi yazılarım için takip edin.", "05420000003", "Onal", null, 4, (byte)5 },
                    { 3, "9.jpg", "Adana", new DateTime(1997, 7, 11, 8, 24, 3, 258, DateTimeKind.Local).AddTicks(1586), 3333, "www.facebook3.com", "Bay", "www.instagram3.com", "ScrumMaster-SoftwareArchitect", "USD/EUR Parite", new DateTime(2019, 7, 11, 8, 21, 3, 258, DateTimeKind.Local).AddTicks(1587), "Serkan", "Serkan Reis", "05420000002", "Topkan", "www.twitter3.com", 3, (byte)4 },
                    { 2, "5.jpg", "Ankara", new DateTime(1999, 7, 11, 8, 24, 3, 258, DateTimeKind.Local).AddTicks(1542), 33, "www.facebook2.com", "Bayan", "www.instagram2.com", "User", "Dolar", new DateTime(2019, 7, 11, 8, 22, 3, 258, DateTimeKind.Local).AddTicks(1565), "User", "Sıradan user", "05420000001", "User", "www.twitter2.com", 2, (byte)1 },
                    { 1, "1.jpg", "Istanbul", new DateTime(1989, 7, 11, 8, 24, 3, 257, DateTimeKind.Local).AddTicks(9203), 2333, "www.facebook.com", "Bayan", "www.instagram.com", "Admin", "Homepage", new DateTime(2019, 7, 11, 8, 23, 3, 258, DateTimeKind.Local).AddTicks(917), "admin", "admin", "05420000000", "admin", "www.twitter.com", 1, (byte)5 }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[,]
                {
                    { 5, 3, 5 },
                    { 7, 2, 7 },
                    { 4, 3, 4 },
                    { 3, 2, 3 },
                    { 2, 2, 2 },
                    { 8, 2, 8 },
                    { 6, 3, 6 },
                    { 1, 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentIp", "CommentParentId", "CreatedDateTime", "MarketId", "Message", "UserId" },
                values: new object[] { 1, "158.65.14.02", null, new DateTime(2019, 7, 10, 2, 24, 3, 256, DateTimeKind.Local).AddTicks(8376), 1, "Dolar 1", 2 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentIp", "CommentParentId", "CreatedDateTime", "IsPinned", "MarketId", "Message", "UserId" },
                values: new object[] { 10, "158.65.14.01", null, new DateTime(2019, 7, 10, 11, 24, 3, 256, DateTimeKind.Local).AddTicks(9422), (byte)1, 2, "Japon Yeni pinli", 1 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentIp", "CommentParentId", "CreatedDateTime", "IsDelete", "MarketId", "Message", "UserId" },
                values: new object[] { 11, "158.65.14.02", 8, new DateTime(2019, 7, 10, 12, 24, 3, 256, DateTimeKind.Local).AddTicks(9423), (byte)1, 2, "Japon Yeni silinmiş alt yorum", 2 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentIp", "CommentParentId", "CreatedDateTime", "MarketId", "Message", "UserId" },
                values: new object[] { 25, "158.65.14.02", null, new DateTime(2019, 7, 11, 2, 24, 3, 256, DateTimeKind.Local).AddTicks(9446), 5, "Şili Pesosu 1", 2 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentIp", "CommentParentId", "CreatedDateTime", "IsDelete", "MarketId", "Message", "UserId" },
                values: new object[] { 30, "158.65.14.01", null, new DateTime(2019, 7, 11, 7, 24, 3, 256, DateTimeKind.Local).AddTicks(9452), (byte)1, 5, "Şili Pesosu silinmiş", 1 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentIp", "CommentParentId", "CreatedDateTime", "IsDelete", "MarketId", "Message", "UserId" },
                values: new object[] { 12, "158.65.14.01", null, new DateTime(2019, 7, 10, 13, 24, 3, 256, DateTimeKind.Local).AddTicks(9431), (byte)1, 3, "Japon Yeni silinmiş", 1 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentIp", "CommentParentId", "CreatedDateTime", "IsDelete", "MarketId", "Message", "UserId" },
                values: new object[] { 13, "158.65.14.01", null, new DateTime(2019, 7, 10, 14, 24, 3, 256, DateTimeKind.Local).AddTicks(9432), (byte)1, 3, "Euro silinmiş", 1 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentIp", "CommentParentId", "CreatedDateTime", "MarketId", "Message", "UserId" },
                values: new object[] { 14, "158.65.14.02", null, new DateTime(2019, 7, 10, 15, 24, 3, 256, DateTimeKind.Local).AddTicks(9433), 3, "Euro Yeni 1", 2 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentIp", "CommentParentId", "CreatedDateTime", "MarketId", "Message", "UserId" },
                values: new object[] { 15, "158.65.14.03", null, new DateTime(2019, 7, 10, 16, 24, 3, 256, DateTimeKind.Local).AddTicks(9434), 3, "Euro Yeni 2", 3 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentIp", "CommentParentId", "CreatedDateTime", "MarketId", "Message", "UserId" },
                values: new object[] { 16, "158.65.14.01", null, new DateTime(2019, 7, 10, 17, 24, 3, 256, DateTimeKind.Local).AddTicks(9435), 3, "Euro Yeni 3", 1 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentIp", "CommentParentId", "CreatedDateTime", "IsPinned", "MarketId", "Message", "UserId" },
                values: new object[] { 17, "158.65.14.01", null, new DateTime(2019, 7, 10, 18, 24, 3, 256, DateTimeKind.Local).AddTicks(9436), (byte)1, 3, "Euro Yeni pinli", 1 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentIp", "CommentParentId", "CreatedDateTime", "IsDelete", "MarketId", "Message", "UserId" },
                values: new object[] { 18, "158.65.14.02", 14, new DateTime(2019, 7, 10, 19, 24, 3, 256, DateTimeKind.Local).AddTicks(9437), (byte)1, 3, "Euro Yeni silinmiş alt yorum", 2 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentIp", "CommentParentId", "CreatedDateTime", "IsDelete", "MarketId", "Message", "UserId" },
                values: new object[] { 24, "158.65.14.01", null, new DateTime(2019, 7, 11, 1, 24, 3, 256, DateTimeKind.Local).AddTicks(9445), (byte)1, 4, "Libya Dinarı silinmiş", 1 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentIp", "CommentParentId", "CreatedDateTime", "IsDelete", "MarketId", "Message", "UserId" },
                values: new object[] { 23, "158.65.14.02", 20, new DateTime(2019, 7, 11, 0, 24, 3, 256, DateTimeKind.Local).AddTicks(9444), (byte)1, 4, "Libya Dinarı silinmiş alt yorum", 2 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentIp", "CommentParentId", "CreatedDateTime", "IsPinned", "MarketId", "Message", "UserId" },
                values: new object[] { 22, "158.65.14.01", null, new DateTime(2019, 7, 10, 23, 24, 3, 256, DateTimeKind.Local).AddTicks(9443), (byte)1, 4, "Libya Dinarı pinli", 1 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentIp", "CommentParentId", "CreatedDateTime", "MarketId", "Message", "UserId" },
                values: new object[] { 21, "158.65.14.01", null, new DateTime(2019, 7, 10, 22, 24, 3, 256, DateTimeKind.Local).AddTicks(9441), 4, "Libya Dinarı 3", 1 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentIp", "CommentParentId", "CreatedDateTime", "MarketId", "Message", "UserId" },
                values: new object[] { 9, "158.65.14.01", null, new DateTime(2019, 7, 10, 10, 24, 3, 256, DateTimeKind.Local).AddTicks(9421), 2, "Japon Yeni 3", 1 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentIp", "CommentParentId", "CreatedDateTime", "MarketId", "Message", "UserId" },
                values: new object[] { 19, "158.65.14.02", null, new DateTime(2019, 7, 10, 20, 24, 3, 256, DateTimeKind.Local).AddTicks(9439), 4, "Libya Dinarı 1", 2 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentIp", "CommentParentId", "CreatedDateTime", "MarketId", "Message", "UserId" },
                values: new object[] { 8, "158.65.14.03", null, new DateTime(2019, 7, 10, 9, 24, 3, 256, DateTimeKind.Local).AddTicks(9420), 2, "Japon Yeni 2", 3 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentIp", "CommentParentId", "CreatedDateTime", "IsDelete", "MarketId", "Message", "UserId" },
                values: new object[] { 6, "158.65.14.01", null, new DateTime(2019, 7, 10, 7, 24, 3, 256, DateTimeKind.Local).AddTicks(9417), (byte)1, 2, "Dolar silinmiş", 1 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentIp", "CommentParentId", "CreatedDateTime", "MarketId", "Message", "UserId" },
                values: new object[] { 2, "158.65.14.03", null, new DateTime(2019, 7, 10, 3, 24, 3, 256, DateTimeKind.Local).AddTicks(9129), 1, "Dolar 2", 3 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentIp", "CommentParentId", "CreatedDateTime", "MarketId", "Message", "UserId" },
                values: new object[] { 3, "158.65.14.01", null, new DateTime(2019, 7, 10, 4, 24, 3, 256, DateTimeKind.Local).AddTicks(9142), 1, "Dolar 3", 1 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentIp", "CommentParentId", "CreatedDateTime", "IsPinned", "MarketId", "Message", "UserId" },
                values: new object[] { 4, "158.65.14.01", null, new DateTime(2019, 7, 10, 5, 24, 3, 256, DateTimeKind.Local).AddTicks(9144), (byte)1, 1, "Dolar pinli", 1 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentIp", "CommentParentId", "CreatedDateTime", "IsDelete", "MarketId", "Message", "UserId" },
                values: new object[] { 5, "158.65.14.02", 2, new DateTime(2019, 7, 10, 6, 24, 3, 256, DateTimeKind.Local).AddTicks(9145), (byte)1, 1, "Dolar silinmiş alt yorum", 2 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentIp", "CommentParentId", "CreatedDateTime", "MarketId", "Message", "UserId" },
                values: new object[] { 31, "158.65.14.01", null, new DateTime(2019, 7, 9, 6, 24, 3, 256, DateTimeKind.Local).AddTicks(9459), 1, "Dolara ekstra beğeni 1", 4 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentIp", "CommentParentId", "CreatedDateTime", "MarketId", "Message", "UserId" },
                values: new object[] { 32, "158.65.14.01", null, new DateTime(2019, 7, 9, 7, 24, 3, 256, DateTimeKind.Local).AddTicks(9461), 1, "Dolara ekstra beğeni 2", 5 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentIp", "CommentParentId", "CreatedDateTime", "MarketId", "Message", "UserId" },
                values: new object[] { 33, "158.65.14.01", null, new DateTime(2019, 7, 9, 8, 24, 3, 256, DateTimeKind.Local).AddTicks(9462), 1, "Dolara ekstra beğeni 3", 9 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentIp", "CommentParentId", "CreatedDateTime", "MarketId", "Message", "UserId" },
                values: new object[] { 7, "158.65.14.02", null, new DateTime(2019, 7, 10, 8, 24, 3, 256, DateTimeKind.Local).AddTicks(9419), 2, "Japon Yeni 1", 2 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentIp", "CommentParentId", "CreatedDateTime", "MarketId", "Message", "UserId" },
                values: new object[] { 34, "158.65.14.01", null, new DateTime(2019, 7, 9, 9, 24, 3, 256, DateTimeKind.Local).AddTicks(9463), 1, "Dolara ekstra beğeni 4", 5 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentIp", "CommentParentId", "CreatedDateTime", "MarketId", "Message", "UserId" },
                values: new object[] { 36, "158.65.14.01", null, new DateTime(2019, 7, 9, 11, 24, 3, 256, DateTimeKind.Local).AddTicks(9465), 1, "Dolara ekstra beğeni 6", 5 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentIp", "CommentParentId", "CreatedDateTime", "MarketId", "Message", "UserId" },
                values: new object[] { 37, "158.65.14.01", null, new DateTime(2019, 7, 9, 12, 24, 3, 256, DateTimeKind.Local).AddTicks(9466), 1, "Dolara ekstra beğeni 7", 5 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentIp", "CommentParentId", "CreatedDateTime", "IsDelete", "MarketId", "Message", "UserId" },
                values: new object[] { 29, "158.65.14.02", 26, new DateTime(2019, 7, 11, 6, 24, 3, 256, DateTimeKind.Local).AddTicks(9451), (byte)1, 5, "Şili Pesosu silinmiş alt yorum", 2 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentIp", "CommentParentId", "CreatedDateTime", "IsPinned", "MarketId", "Message", "UserId" },
                values: new object[] { 28, "158.65.14.01", null, new DateTime(2019, 7, 11, 5, 24, 3, 256, DateTimeKind.Local).AddTicks(9449), (byte)1, 5, "Şili Pesosu pinli", 1 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentIp", "CommentParentId", "CreatedDateTime", "MarketId", "Message", "UserId" },
                values: new object[] { 27, "158.65.14.01", null, new DateTime(2019, 7, 11, 4, 24, 3, 256, DateTimeKind.Local).AddTicks(9448), 5, "Şili Pesosu 3", 1 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentIp", "CommentParentId", "CreatedDateTime", "MarketId", "Message", "UserId" },
                values: new object[] { 26, "158.65.14.03", null, new DateTime(2019, 7, 11, 3, 24, 3, 256, DateTimeKind.Local).AddTicks(9447), 5, "Şili Pesosu 2", 3 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentIp", "CommentParentId", "CreatedDateTime", "MarketId", "Message", "UserId" },
                values: new object[] { 35, "158.65.14.01", null, new DateTime(2019, 7, 9, 10, 24, 3, 256, DateTimeKind.Local).AddTicks(9464), 1, "Dolara ekstra beğeni 5", 5 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentIp", "CommentParentId", "CreatedDateTime", "MarketId", "Message", "UserId" },
                values: new object[] { 20, "158.65.14.03", null, new DateTime(2019, 7, 10, 21, 24, 3, 256, DateTimeKind.Local).AddTicks(9440), 4, "Libya Dinarı 2", 3 });

            migrationBuilder.InsertData(
                table: "EconomicCalendar",
                columns: new[] { "Id", "Actual", "CountryId", "Forecast", "Importance", "MarketId", "Previous", "Subject", "SubjectDateTime" },
                values: new object[,]
                {
                    { 12, 1.52, 6, 1.73, 3, 6, 1.6399999999999999, "Caixin İmalat Satın Alma Müdürleri Endeksi (PMI) (Mar)", new DateTime(2019, 7, 11, 10, 24, 3, 258, DateTimeKind.Local).AddTicks(4918) },
                    { 11, 1.52, 20, 1.73, 3, 20, 1.6399999999999999, "Caixin İmalat Satın Alma Müdürleri Endeksi (PMI) (Mar)", new DateTime(2019, 7, 13, 8, 24, 3, 258, DateTimeKind.Local).AddTicks(4917) },
                    { 7, 1.23, 7, 1.45, 2, 7, 1.8999999999999999, "İspanya İmalat Satın Alma Müdürleri Endeksi (PMI) (Mar)", new DateTime(2019, 7, 12, 22, 24, 3, 258, DateTimeKind.Local).AddTicks(4913) },
                    { 8, 1.52, 12, 1.73, 2, 12, 1.6399999999999999, "Caixin İmalat Satın Alma Müdürleri Endeksi (PMI) (Mar)", new DateTime(2019, 7, 11, 16, 24, 3, 258, DateTimeKind.Local).AddTicks(4914) },
                    { 10, 1.52, 16, 1.73, 3, 16, 1.6399999999999999, "Caixin İmalat Satın Alma Müdürleri Endeksi (PMI) (Mar)", new DateTime(2019, 7, 12, 23, 24, 3, 258, DateTimeKind.Local).AddTicks(4916) },
                    { 9, 1.52, 26, 1.73, 3, 26, 1.6399999999999999, "Caixin İmalat Satın Alma Müdürleri Endeksi (PMI) (Mar)", new DateTime(2019, 7, 11, 17, 24, 3, 258, DateTimeKind.Local).AddTicks(4915) },
                    { 13, 1.52, 36, 1.73, 3, 36, 1.6399999999999999, "Caixin İmalat Satın Alma Müdürleri Endeksi (PMI) (Mar)", new DateTime(2019, 7, 11, 14, 24, 3, 258, DateTimeKind.Local).AddTicks(4920) },
                    { 19, 1.52, 49, 1.73, 3, 49, 1.6399999999999999, "Caixin İmalat Satın Alma Müdürleri Endeksi (PMI) (Mar)", new DateTime(2019, 7, 12, 7, 24, 3, 258, DateTimeKind.Local).AddTicks(4927) },
                    { 18, 1.52, 55, 1.73, 3, 55, 1.6399999999999999, "Caixin İmalat Satın Alma Müdürleri Endeksi (PMI) (Mar)", new DateTime(2019, 7, 11, 9, 24, 3, 258, DateTimeKind.Local).AddTicks(4926) },
                    { 16, 1.52, 76, 1.73, 3, 58, 1.6399999999999999, "Caixin İmalat Satın Alma Müdürleri Endeksi (PMI) (Mar)", new DateTime(2019, 7, 12, 11, 24, 3, 258, DateTimeKind.Local).AddTicks(4924) },
                    { 20, 1.52, 59, 1.73, 3, 59, 1.6399999999999999, "Caixin İmalat Satın Alma Müdürleri Endeksi (PMI) (Mar)", new DateTime(2019, 7, 12, 9, 24, 3, 258, DateTimeKind.Local).AddTicks(4928) },
                    { 14, 1.52, 6, 1.73, 3, 6, 1.6399999999999999, "Caixin İmalat Satın Alma Müdürleri Endeksi (PMI) (Mar)", new DateTime(2019, 7, 12, 1, 24, 3, 258, DateTimeKind.Local).AddTicks(4921) },
                    { 6, 1.52, 6, 1.73, 3, 6, 1.6399999999999999, "Caixin İmalat Satın Alma Müdürleri Endeksi (PMI) (Mar)", new DateTime(2019, 7, 11, 15, 24, 3, 258, DateTimeKind.Local).AddTicks(4911) },
                    { 15, 1.52, 86, 1.73, 3, 68, 1.6399999999999999, "Caixin İmalat Satın Alma Müdürleri Endeksi (PMI) (Mar)", new DateTime(2019, 7, 12, 6, 24, 3, 258, DateTimeKind.Local).AddTicks(4922) },
                    { 4, 0.5, 4, 1.0, 2, 4, 1.2, "Kentsel Dönüşüm Kurumu (URA) Mülk Endeksi (çeyreklik) (1. Çeyrek)", new DateTime(2019, 7, 12, 6, 24, 3, 258, DateTimeKind.Local).AddTicks(4909) },
                    { 17, 1.52, 66, 1.73, 3, 66, 1.6399999999999999, "Caixin İmalat Satın Alma Müdürleri Endeksi (PMI) (Mar)", new DateTime(2019, 7, 14, 13, 24, 3, 258, DateTimeKind.Local).AddTicks(4925) },
                    { 1, 1.5, 1, 1.7, 1, 1, 1.6000000000000001, "İmalat Satın Alma Müdürleri Endeksi", new DateTime(2019, 7, 11, 17, 24, 3, 258, DateTimeKind.Local).AddTicks(4121) },
                    { 2, 1.3, 2, 1.2, 2, 2, 1.6000000000000001, "	AiG İmalat Endeksi (Mar)", new DateTime(2019, 7, 9, 16, 24, 3, 258, DateTimeKind.Local).AddTicks(4894) },
                    { 3, 2.5, 3, 1.7, 2, 3, 3.6000000000000001, "Tankan Bütün Büyük Sanayilerin Sermaye Harcamaları Endeksi (1. Çeyrek)", new DateTime(2019, 7, 11, 15, 24, 3, 258, DateTimeKind.Local).AddTicks(4908) },
                    { 5, 1.95, 5, 1.77, 2, 5, 1.6599999999999999, "Investing.com GBP/USD Endeksi", new DateTime(2019, 7, 12, 9, 24, 3, 258, DateTimeKind.Local).AddTicks(4910) }
                });

            migrationBuilder.InsertData(
                table: "Exchanges",
                columns: new[] { "Id", "CreatedDateTime", "LastBuyPrice", "LastSellPrice", "LastUpdatedDateTime", "MarketCup", "MarketId", "MarketSupply", "MarketVolume", "Rate" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 7, 11, 8, 24, 3, 256, DateTimeKind.Local).AddTicks(2761), 5.6021000000000001, 5.5919999999999996, new DateTime(2019, 7, 12, 8, 24, 3, 256, DateTimeKind.Local).AddTicks(3003), 0.0, 1, 0.0, 0.0, 0.050000000000000003 },
                    { 3, new DateTime(2019, 7, 7, 8, 24, 3, 256, DateTimeKind.Local).AddTicks(3236), 1.6021000000000001, 1.6919999999999999, new DateTime(2019, 7, 14, 8, 24, 3, 256, DateTimeKind.Local).AddTicks(3236), 0.0, 2, 0.0, 0.0, 0.13500000000000001 },
                    { 9, new DateTime(2019, 7, 9, 8, 24, 3, 256, DateTimeKind.Local).AddTicks(3247), 2.5217000000000001, 2.6920000000000002, new DateTime(2019, 7, 20, 8, 24, 3, 256, DateTimeKind.Local).AddTicks(3248), 0.0, 12, 0.0, 0.0, 0.245 },
                    { 10, new DateTime(2019, 7, 10, 8, 24, 3, 256, DateTimeKind.Local).AddTicks(3249), 3.0217000000000001, 3.0920000000000001, new DateTime(2019, 7, 21, 8, 24, 3, 256, DateTimeKind.Local).AddTicks(3250), 0.0, 13, 0.0, 0.0, 0.54500000000000004 },
                    { 8, new DateTime(2019, 7, 7, 8, 24, 3, 256, DateTimeKind.Local).AddTicks(3245), 2.1516999999999999, 2.1819999999999999, new DateTime(2019, 7, 19, 8, 24, 3, 256, DateTimeKind.Local).AddTicks(3245), 0.0, 11, 0.0, 0.0, 0.32500000000000001 },
                    { 7, new DateTime(2019, 7, 8, 8, 24, 3, 256, DateTimeKind.Local).AddTicks(3243), 1.2217, 1.3919999999999999, new DateTime(2019, 7, 18, 8, 24, 3, 256, DateTimeKind.Local).AddTicks(3244), 0.0, 10, 0.0, 0.0, 0.123 },
                    { 6, new DateTime(2019, 7, 9, 8, 24, 3, 256, DateTimeKind.Local).AddTicks(3241), 2.0217000000000001, 2.0920000000000001, new DateTime(2019, 7, 17, 8, 24, 3, 256, DateTimeKind.Local).AddTicks(3242), 0.0, 8, 0.0, 0.0, 0.14499999999999999 },
                    { 5, new DateTime(2019, 7, 4, 8, 24, 3, 256, DateTimeKind.Local).AddTicks(3240), 0.69210000000000005, 0.79200000000000004, new DateTime(2019, 7, 16, 8, 24, 3, 256, DateTimeKind.Local).AddTicks(3241), 0.0, 7, 0.0, 0.0, 0.14499999999999999 },
                    { 2, new DateTime(2019, 7, 8, 8, 24, 3, 256, DateTimeKind.Local).AddTicks(3227), 4.6021000000000001, 4.6120000000000001, new DateTime(2019, 7, 13, 8, 24, 3, 256, DateTimeKind.Local).AddTicks(3232), 0.0, 6, 0.0, 0.0, 0.14499999999999999 },
                    { 4, new DateTime(2019, 7, 10, 8, 24, 3, 256, DateTimeKind.Local).AddTicks(3238), 6.6021000000000001, 6.6920000000000002, new DateTime(2019, 7, 15, 8, 24, 3, 256, DateTimeKind.Local).AddTicks(3239), 0.0, 3, 0.0, 0.0, 0.115 }
                });

            migrationBuilder.InsertData(
                table: "Investments",
                columns: new[] { "Id", "Amount", "CreatedDateTime", "MarketId", "Note", "Price", "PurchaseDateTime", "UserId" },
                values: new object[,]
                {
                    { 1, 500.0, new DateTime(2019, 7, 11, 8, 24, 3, 253, DateTimeKind.Local).AddTicks(9415), 2, "jpy yatırımı", 5.6943000000000001, new DateTime(2019, 2, 11, 8, 24, 3, 253, DateTimeKind.Local).AddTicks(9127), 4 },
                    { 4, 1000.0, new DateTime(2019, 6, 26, 8, 24, 3, 253, DateTimeKind.Local).AddTicks(9688), 1, "dolar yatırımı", 5.3277999999999999, new DateTime(2018, 7, 11, 8, 24, 3, 253, DateTimeKind.Local).AddTicks(9687), 5 },
                    { 2, 200.0, new DateTime(2019, 7, 8, 8, 24, 3, 253, DateTimeKind.Local).AddTicks(9674), 1, null, 5.4199999999999999, new DateTime(2018, 9, 11, 8, 24, 3, 253, DateTimeKind.Local).AddTicks(9667), 3 },
                    { 3, 50.0, new DateTime(2019, 7, 4, 8, 24, 3, 253, DateTimeKind.Local).AddTicks(9686), 3, "euro yatırımı", 5.9913999999999996, new DateTime(2019, 2, 11, 8, 24, 3, 253, DateTimeKind.Local).AddTicks(9684), 6 },
                    { 5, 500.0, new DateTime(2019, 7, 9, 8, 24, 3, 253, DateTimeKind.Local).AddTicks(9691), 3, "euro yatırımı", 5.8499999999999996, new DateTime(2019, 1, 11, 8, 24, 3, 253, DateTimeKind.Local).AddTicks(9690), 1 }
                });

            migrationBuilder.InsertData(
                table: "CommentComplaints",
                columns: new[] { "Id", "CommentId", "ComplaintDateTime", "ComplaintDescription", "TopicId", "UserId" },
                values: new object[] { 1, 1, new DateTime(2019, 7, 11, 8, 24, 3, 257, DateTimeKind.Local).AddTicks(2123), "Rahatsız Edici", 1, 1 });

            migrationBuilder.InsertData(
                table: "CommentComplaints",
                columns: new[] { "Id", "CommentId", "ComplaintDateTime", "ComplaintDescription", "TopicId", "UserId" },
                values: new object[] { 3, 1, new DateTime(2019, 6, 30, 8, 24, 3, 257, DateTimeKind.Local).AddTicks(2359), "Span", 1, 4 });

            migrationBuilder.InsertData(
                table: "CommentComplaints",
                columns: new[] { "Id", "CommentId", "ComplaintDateTime", "ComplaintDescription", "TopicId", "UserId" },
                values: new object[] { 6, 6, new DateTime(2019, 7, 12, 8, 24, 3, 257, DateTimeKind.Local).AddTicks(2362), "Uygunsuz içerik", 1, 3 });

            migrationBuilder.InsertData(
                table: "CommentComplaints",
                columns: new[] { "Id", "CommentId", "ComplaintDateTime", "ComplaintDescription", "TopicId", "UserId" },
                values: new object[] { 5, 5, new DateTime(2019, 7, 10, 8, 24, 3, 257, DateTimeKind.Local).AddTicks(2361), "Alakasız paylaşım", 1, 7 });

            migrationBuilder.InsertData(
                table: "CommentComplaints",
                columns: new[] { "Id", "CommentId", "ComplaintDateTime", "ComplaintDescription", "TopicId", "UserId" },
                values: new object[] { 4, 7, new DateTime(2019, 8, 2, 8, 24, 3, 257, DateTimeKind.Local).AddTicks(2360), "Kötü içerik", 1, 2 });

            migrationBuilder.InsertData(
                table: "CommentComplaints",
                columns: new[] { "Id", "CommentId", "ComplaintDateTime", "ComplaintDescription", "TopicId", "UserId" },
                values: new object[] { 7, 6, new DateTime(2019, 7, 14, 8, 24, 3, 257, DateTimeKind.Local).AddTicks(2363), "Beni taklit ediyor", 1, 1 });

            migrationBuilder.InsertData(
                table: "CommentComplaints",
                columns: new[] { "Id", "CommentId", "ComplaintDateTime", "ComplaintDescription", "TopicId", "UserId" },
                values: new object[] { 2, 2, new DateTime(2019, 7, 18, 8, 24, 3, 257, DateTimeKind.Local).AddTicks(2354), "Bunaltıcı", 1, 3 });

            migrationBuilder.InsertData(
                table: "CommentComplaints",
                columns: new[] { "Id", "CommentId", "ComplaintDateTime", "ComplaintDescription", "TopicId", "UserId" },
                values: new object[] { 8, 2, new DateTime(2019, 7, 13, 8, 24, 3, 257, DateTimeKind.Local).AddTicks(2364), "Beğenmiyorum paylaşımlarını", 1, 2 });

            migrationBuilder.InsertData(
                table: "CommentGraphics",
                columns: new[] { "Id", "CommentId", "GraphicPath" },
                values: new object[,]
                {
                    { 4, 5, "landscape12.jpg" },
                    { 3, 3, "landscape11.jpg" },
                    { 5, 8, "landscape13.jpg" },
                    { 1, 1, "landscape1.jpg" },
                    { 2, 2, "landscape10.jpg" }
                });

            migrationBuilder.InsertData(
                table: "CommentLikes",
                columns: new[] { "Id", "CommentId", "LikedDateTime", "LikedOrDisliked", "UserId" },
                values: new object[] { 8, 7, new DateTime(2019, 7, 11, 8, 23, 55, 257, DateTimeKind.Local).AddTicks(819), (byte)1, 7 });

            migrationBuilder.InsertData(
                table: "CommentLikes",
                columns: new[] { "Id", "CommentId", "LikedDateTime", "LikedOrDisliked", "UserId" },
                values: new object[] { 4, 1, new DateTime(2019, 7, 11, 8, 23, 59, 257, DateTimeKind.Local).AddTicks(815), (byte)1, 2 });

            migrationBuilder.InsertData(
                table: "CommentLikes",
                columns: new[] { "Id", "CommentId", "LikedDateTime", "LikedOrDisliked", "UserId" },
                values: new object[] { 3, 4, new DateTime(2019, 7, 11, 8, 24, 0, 257, DateTimeKind.Local).AddTicks(813), (byte)0, 2 });

            migrationBuilder.InsertData(
                table: "CommentLikes",
                columns: new[] { "Id", "CommentId", "LikedDateTime", "LikedOrDisliked", "UserId" },
                values: new object[] { 7, 6, new DateTime(2019, 7, 11, 8, 23, 56, 257, DateTimeKind.Local).AddTicks(818), (byte)1, 1 });

            migrationBuilder.InsertData(
                table: "CommentLikes",
                columns: new[] { "Id", "CommentId", "LikedDateTime", "LikedOrDisliked", "UserId" },
                values: new object[] { 2, 1, new DateTime(2019, 7, 11, 8, 24, 1, 257, DateTimeKind.Local).AddTicks(809), (byte)1, 3 });

            migrationBuilder.InsertData(
                table: "CommentLikes",
                columns: new[] { "Id", "CommentId", "LikedDateTime", "LikedOrDisliked", "UserId" },
                values: new object[] { 1, 1, new DateTime(2019, 7, 11, 8, 24, 2, 257, DateTimeKind.Local).AddTicks(582), (byte)1, 1 });

            migrationBuilder.InsertData(
                table: "CommentLikes",
                columns: new[] { "Id", "CommentId", "LikedDateTime", "LikedOrDisliked", "UserId" },
                values: new object[] { 5, 5, new DateTime(2019, 7, 11, 8, 23, 58, 257, DateTimeKind.Local).AddTicks(815), (byte)0, 4 });

            migrationBuilder.InsertData(
                table: "CommentLikes",
                columns: new[] { "Id", "CommentId", "LikedDateTime", "LikedOrDisliked", "UserId" },
                values: new object[] { 9, 31, new DateTime(2019, 7, 11, 8, 23, 48, 257, DateTimeKind.Local).AddTicks(820), (byte)1, 5 });

            migrationBuilder.InsertData(
                table: "CommentLikes",
                columns: new[] { "Id", "CommentId", "LikedDateTime", "LikedOrDisliked", "UserId" },
                values: new object[] { 10, 32, new DateTime(2019, 7, 11, 8, 23, 48, 257, DateTimeKind.Local).AddTicks(821), (byte)1, 6 });

            migrationBuilder.InsertData(
                table: "CommentLikes",
                columns: new[] { "Id", "CommentId", "LikedDateTime", "LikedOrDisliked", "UserId" },
                values: new object[] { 11, 33, new DateTime(2019, 7, 11, 8, 23, 48, 257, DateTimeKind.Local).AddTicks(823), (byte)1, 7 });

            migrationBuilder.InsertData(
                table: "CommentLikes",
                columns: new[] { "Id", "CommentId", "LikedDateTime", "LikedOrDisliked", "UserId" },
                values: new object[] { 6, 6, new DateTime(2019, 7, 11, 8, 23, 57, 257, DateTimeKind.Local).AddTicks(817), (byte)1, 4 });

            migrationBuilder.InsertData(
                table: "CommentPolls",
                columns: new[] { "Id", "CommentId", "EndDate", "StartDate" },
                values: new object[,]
                {
                    { 4, 4, new DateTime(2019, 7, 7, 8, 24, 3, 256, DateTimeKind.Local).AddTicks(5254), new DateTime(2019, 7, 6, 8, 24, 3, 256, DateTimeKind.Local).AddTicks(5253) },
                    { 3, 3, new DateTime(2019, 7, 9, 8, 24, 3, 256, DateTimeKind.Local).AddTicks(5252), new DateTime(2019, 7, 8, 8, 24, 3, 256, DateTimeKind.Local).AddTicks(5252) },
                    { 2, 2, new DateTime(2019, 7, 10, 8, 24, 3, 256, DateTimeKind.Local).AddTicks(5248), new DateTime(2019, 7, 9, 8, 24, 3, 256, DateTimeKind.Local).AddTicks(5244) },
                    { 1, 1, new DateTime(2019, 7, 11, 8, 24, 3, 256, DateTimeKind.Local).AddTicks(5035), new DateTime(2019, 7, 10, 8, 24, 3, 256, DateTimeKind.Local).AddTicks(4816) },
                    { 5, 17, new DateTime(2019, 7, 7, 8, 24, 3, 256, DateTimeKind.Local).AddTicks(5256), new DateTime(2019, 7, 5, 8, 24, 3, 256, DateTimeKind.Local).AddTicks(5255) },
                    { 6, 21, new DateTime(2019, 7, 4, 8, 24, 3, 256, DateTimeKind.Local).AddTicks(5257), new DateTime(2019, 7, 1, 8, 24, 3, 256, DateTimeKind.Local).AddTicks(5257) }
                });

            migrationBuilder.InsertData(
                table: "CommentPollOptions",
                columns: new[] { "Id", "Options", "PollId" },
                values: new object[,]
                {
                    { 1, "Evet", 1 },
                    { 2, "Hayır", 1 },
                    { 3, "Katılıyorum", 2 },
                    { 4, "Katılmıyorum", 2 },
                    { 5, "Doğrudur", 3 },
                    { 6, "Yanlıştır", 3 },
                    { 7, "Herzaman", 4 },
                    { 8, "Asla", 4 },
                    { 9, "Tesadüf", 5 },
                    { 10, "Doğru üzerinde hareket ettiriyorlar", 5 },
                    { 11, "Metaller", 6 },
                    { 12, "Dövizler", 6 }
                });

            migrationBuilder.InsertData(
                table: "CommentPollVotes",
                columns: new[] { "Id", "CreateDateTime", "PollOptionId", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 7, 10, 8, 24, 3, 256, DateTimeKind.Local).AddTicks(7086), 1, 1 },
                    { 30, new DateTime(2019, 7, 1, 8, 24, 3, 256, DateTimeKind.Local).AddTicks(7338), 11, 8 },
                    { 29, new DateTime(2019, 7, 2, 8, 24, 3, 256, DateTimeKind.Local).AddTicks(7338), 11, 7 },
                    { 28, new DateTime(2019, 7, 3, 8, 24, 3, 256, DateTimeKind.Local).AddTicks(7337), 11, 6 },
                    { 25, new DateTime(2019, 7, 4, 8, 24, 3, 256, DateTimeKind.Local).AddTicks(7334), 11, 1 },
                    { 23, new DateTime(2019, 7, 6, 8, 24, 3, 256, DateTimeKind.Local).AddTicks(7332), 10, 6 },
                    { 22, new DateTime(2019, 7, 6, 8, 24, 3, 256, DateTimeKind.Local).AddTicks(7331), 10, 5 },
                    { 21, new DateTime(2019, 7, 7, 8, 24, 3, 256, DateTimeKind.Local).AddTicks(7330), 10, 4 },
                    { 24, new DateTime(2019, 7, 5, 8, 24, 3, 256, DateTimeKind.Local).AddTicks(7333), 9, 7 },
                    { 20, new DateTime(2019, 7, 7, 8, 24, 3, 256, DateTimeKind.Local).AddTicks(7329), 9, 1 },
                    { 19, new DateTime(2019, 7, 6, 8, 24, 3, 256, DateTimeKind.Local).AddTicks(7328), 8, 9 },
                    { 17, new DateTime(2019, 7, 6, 8, 24, 3, 256, DateTimeKind.Local).AddTicks(7327), 8, 4 },
                    { 18, new DateTime(2019, 7, 6, 8, 24, 3, 256, DateTimeKind.Local).AddTicks(7327), 7, 7 },
                    { 16, new DateTime(2019, 7, 6, 8, 24, 3, 256, DateTimeKind.Local).AddTicks(7325), 7, 3 },
                    { 15, new DateTime(2019, 7, 7, 8, 24, 3, 256, DateTimeKind.Local).AddTicks(7324), 7, 1 },
                    { 14, new DateTime(2019, 7, 8, 8, 24, 3, 256, DateTimeKind.Local).AddTicks(7323), 6, 9 },
                    { 13, new DateTime(2019, 7, 8, 8, 24, 3, 256, DateTimeKind.Local).AddTicks(7322), 6, 7 },
                    { 11, new DateTime(2019, 7, 9, 8, 24, 3, 256, DateTimeKind.Local).AddTicks(7320), 6, 4 },
                    { 12, new DateTime(2019, 7, 9, 8, 24, 3, 256, DateTimeKind.Local).AddTicks(7321), 5, 6 },
                    { 10, new DateTime(2019, 7, 9, 8, 24, 3, 256, DateTimeKind.Local).AddTicks(7320), 5, 2 },
                    { 9, new DateTime(2019, 7, 9, 8, 24, 3, 256, DateTimeKind.Local).AddTicks(7319), 4, 8 },
                    { 6, new DateTime(2019, 7, 10, 8, 24, 3, 256, DateTimeKind.Local).AddTicks(7316), 4, 2 },
                    { 5, new DateTime(2019, 7, 10, 8, 24, 3, 256, DateTimeKind.Local).AddTicks(7315), 4, 1 },
                    { 8, new DateTime(2019, 7, 10, 8, 24, 3, 256, DateTimeKind.Local).AddTicks(7318), 3, 5 },
                    { 7, new DateTime(2019, 7, 10, 8, 24, 3, 256, DateTimeKind.Local).AddTicks(7317), 3, 3 },
                    { 4, new DateTime(2019, 7, 11, 8, 24, 3, 256, DateTimeKind.Local).AddTicks(7314), 2, 6 },
                    { 3, new DateTime(2019, 7, 11, 8, 24, 3, 256, DateTimeKind.Local).AddTicks(7313), 1, 4 },
                    { 2, new DateTime(2019, 7, 10, 8, 24, 3, 256, DateTimeKind.Local).AddTicks(7308), 1, 3 },
                    { 26, new DateTime(2019, 7, 4, 8, 24, 3, 256, DateTimeKind.Local).AddTicks(7335), 12, 2 },
                    { 27, new DateTime(2019, 7, 3, 8, 24, 3, 256, DateTimeKind.Local).AddTicks(7336), 12, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BannedUsers_UserId",
                table: "BannedUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Blocks_BlockedByUserId",
                table: "Blocks",
                column: "BlockedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Blocks_BlockedUserId",
                table: "Blocks",
                column: "BlockedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentComplaints_CommentId",
                table: "CommentComplaints",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentComplaints_TopicId",
                table: "CommentComplaints",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentComplaints_UserId",
                table: "CommentComplaints",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentGraphics_CommentId",
                table: "CommentGraphics",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentLikes_CommentId",
                table: "CommentLikes",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentLikes_UserId",
                table: "CommentLikes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentNotifications_CommentId",
                table: "CommentNotifications",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentNotifications_UserId",
                table: "CommentNotifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentPollOptions_PollId",
                table: "CommentPollOptions",
                column: "PollId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentPolls_CommentId",
                table: "CommentPolls",
                column: "CommentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CommentPollVotes_PollOptionId",
                table: "CommentPollVotes",
                column: "PollOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentPollVotes_UserId",
                table: "CommentPollVotes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_MarketId",
                table: "Comments",
                column: "MarketId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "idx_FlagPath",
                table: "Countries",
                column: "FlagCode");

            migrationBuilder.CreateIndex(
                name: "idx_CountryName",
                table: "Countries",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeletedUsers_UserId",
                table: "DeletedUsers",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EconomicCalendar_CountryId",
                table: "EconomicCalendar",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_EconomicCalendar_MarketId",
                table: "EconomicCalendar",
                column: "MarketId");

            migrationBuilder.CreateIndex(
                name: "IX_EconomicDictionary_CategoryId",
                table: "EconomicDictionary",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Exchanges_MarketId",
                table: "Exchanges",
                column: "MarketId");

            migrationBuilder.CreateIndex(
                name: "IX_Formations_CategoryId",
                table: "Formations",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FrozenUsers_UserId",
                table: "FrozenUsers",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Investments_MarketId",
                table: "Investments",
                column: "MarketId");

            migrationBuilder.CreateIndex(
                name: "IX_Investments_UserId",
                table: "Investments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "idx_Code",
                table: "Markets",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_MarketIcon",
                table: "Markets",
                column: "Icon",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_MarketName",
                table: "Markets",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Markets_TypeId",
                table: "Markets",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenCloseMarkets_CountryId",
                table: "OpenCloseMarkets",
                column: "CountryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_RoleName",
                table: "Roles",
                column: "RoleName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_SubscribedByUserId",
                table: "Subscriptions",
                column: "SubscribedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_SubscribedUserId",
                table: "Subscriptions",
                column: "SubscribedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserComplaints_ComplainantUserId",
                table: "UserComplaints",
                column: "ComplainantUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserComplaints_ComplainedUserId",
                table: "UserComplaints",
                column: "ComplainedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserComplaints_TopicOfComplaintId",
                table: "UserComplaints",
                column: "TopicOfComplaintId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_phonenumber",
                table: "UserProfiles",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_UserId",
                table: "UserProfiles",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "idx_email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BannedUsers");

            migrationBuilder.DropTable(
                name: "Blocks");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "CommentComplaints");

            migrationBuilder.DropTable(
                name: "CommentGraphics");

            migrationBuilder.DropTable(
                name: "CommentLikes");

            migrationBuilder.DropTable(
                name: "CommentNotifications");

            migrationBuilder.DropTable(
                name: "CommentPollVotes");

            migrationBuilder.DropTable(
                name: "DeletedUsers");

            migrationBuilder.DropTable(
                name: "EconomicCalendar");

            migrationBuilder.DropTable(
                name: "EconomicDictionary");

            migrationBuilder.DropTable(
                name: "Exchanges");

            migrationBuilder.DropTable(
                name: "Formations");

            migrationBuilder.DropTable(
                name: "FrozenUsers");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropTable(
                name: "Investments");

            migrationBuilder.DropTable(
                name: "Job");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "OpenCloseMarkets");

            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DropTable(
                name: "UserComplaints");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "CommentPollOptions");

            migrationBuilder.DropTable(
                name: "AlphabeticCategories");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "ComplaintTopics");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "CommentPolls");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Markets");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "MarketTypes");
        }
    }
}
