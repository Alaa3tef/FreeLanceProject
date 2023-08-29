using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TempProject.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccidentCauses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccidentCauses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                name: "ClassificationOfAccidents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassificationOfAccidents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Classifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComminucationMethods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComminucationMethods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DriverNames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LicenceExpireData = table.Column<DateTime>(type: "date", nullable: false),
                    LicenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverNames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LeadershipVisits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeadershipType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadershipVisits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NonRecordableAccidents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccidentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NonRecordableAccidents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Passengers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passengers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PreventionCategorys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreventionCategorys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QHSEPositions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QHSEPositions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecordableAccidents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccidentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecordableAccidents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReportedByPositions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportedByPositions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rigs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rigs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RouteNames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RouteNames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ToolPusherPositions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToolPusherPositions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeOfInjurys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfInjurys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeOfObservationCategorys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfObservationCategorys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassengerNumber = table.Column<int>(type: "int", nullable: false),
                    LicenceExpireData = table.Column<DateTime>(type: "date", nullable: false),
                    LicenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ViolationCategorys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViolationCategorys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "QHSEPositionNames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmpCode = table.Column<int>(type: "int", nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QHSEPositionNames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QHSEPositionNames_QHSEPositions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "QHSEPositions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ReportedByNames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmpCode = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportedByNames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportedByNames_ReportedByPositions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "ReportedByPositions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Bop",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RigId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    ECDC = table.Column<int>(type: "int", nullable: false),
                    Client = table.Column<int>(type: "int", nullable: false),
                    Service = table.Column<int>(type: "int", nullable: false),
                    Visitors = table.Column<int>(type: "int", nullable: false),
                    Catering = table.Column<int>(type: "int", nullable: false),
                    WatchMen = table.Column<int>(type: "int", nullable: false),
                    inspection = table.Column<int>(type: "int", nullable: false),
                    Rental = table.Column<int>(type: "int", nullable: false),
                    Other = table.Column<int>(type: "int", nullable: false),
                    ManPower = table.Column<int>(type: "int", nullable: false),
                    TotalManHours = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bop", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bop_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Bop_Rigs_RigId",
                        column: x => x.RigId,
                        principalTable: "Rigs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PTSMs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RigId = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<TimeSpan>(type: "time", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    TrainerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumsofTrainees = table.Column<int>(type: "int", nullable: false),
                    SubjectTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubjectContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PTSMs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PTSMs_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PTSMs_Rigs_RigId",
                        column: x => x.RigId,
                        principalTable: "Rigs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "RigMovePerformances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RigId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OldWellName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NewWellName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoveDistance = table.Column<double>(type: "float", nullable: false),
                    ReleaseTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    AcceptanceTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "date", nullable: false),
                    AcceptanceDate = table.Column<DateTime>(type: "date", nullable: false),
                    ActualMoveTime = table.Column<double>(type: "float", nullable: false),
                    DieselConsumed = table.Column<double>(type: "float", nullable: false),
                    TargetArchived = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BudgetTargetTotalDay = table.Column<double>(type: "float", nullable: false),
                    BudgetTargetTotalMoney = table.Column<double>(type: "float", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RigMovePerformances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RigMovePerformances_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_RigMovePerformances_Rigs_RigId",
                        column: x => x.RigId,
                        principalTable: "Rigs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ToolPusherPositionNames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmpCode = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToolPusherPositionNames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToolPusherPositionNames_ToolPusherPositions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "ToolPusherPositions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "JMPs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JournyNumber = table.Column<int>(type: "int", nullable: false),
                    NightDrivingReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QHSEManagerMustApprove = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpeedLimit = table.Column<double>(type: "float", nullable: false),
                    Distance = table.Column<double>(type: "float", nullable: false),
                    PurposeOfJourny = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReachBeforeDark = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommunicationID = table.Column<int>(type: "int", nullable: false),
                    JournyManagerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManagerNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DriverNameId = table.Column<int>(type: "int", nullable: false),
                    InspectionVechile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartureDate = table.Column<DateTime>(type: "date", nullable: false),
                    Time = table.Column<double>(type: "float", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    EstimatedArriveDate = table.Column<DateTime>(type: "date", nullable: false),
                    EstimatedArriveTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    RestLocationNames = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RouteNameID = table.Column<int>(type: "int", nullable: false),
                    userID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    EnterTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    notifyStatus = table.Column<int>(type: "int", nullable: false),
                    ArrivalTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArrivalStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JMPs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JMPs_AspNetUsers_userID",
                        column: x => x.userID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_JMPs_ComminucationMethods_CommunicationID",
                        column: x => x.CommunicationID,
                        principalTable: "ComminucationMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_JMPs_DriverNames_DriverNameId",
                        column: x => x.DriverNameId,
                        principalTable: "DriverNames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_JMPs_RouteNames_RouteNameID",
                        column: x => x.RouteNameID,
                        principalTable: "RouteNames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_JMPs_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "StopCardRegisters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    ClassificationID = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmpCode = table.Column<int>(type: "int", nullable: false),
                    ReportedByPositionID = table.Column<int>(type: "int", nullable: false),
                    ReportedByNameID = table.Column<int>(type: "int", nullable: false),
                    ActionRequired = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeOfObservationCategoryID = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StopWorkAuthorityApplied = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StopCardRegisters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StopCardRegisters_AspNetUsers_userID",
                        column: x => x.userID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StopCardRegisters_Classifications_ClassificationID",
                        column: x => x.ClassificationID,
                        principalTable: "Classifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StopCardRegisters_ReportedByNames_ReportedByNameID",
                        column: x => x.ReportedByNameID,
                        principalTable: "ReportedByNames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StopCardRegisters_ReportedByPositions_ReportedByPositionID",
                        column: x => x.ReportedByPositionID,
                        principalTable: "ReportedByPositions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StopCardRegisters_TypeOfObservationCategorys_TypeOfObservationCategoryID",
                        column: x => x.TypeOfObservationCategoryID,
                        principalTable: "TypeOfObservationCategorys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Attendances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    No = table.Column<int>(type: "int", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    PTSMId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attendances_PTSMs_PTSMId",
                        column: x => x.PTSMId,
                        principalTable: "PTSMs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ProblemFacedDuringRigMoves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Item = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProblemDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeLostProblem = table.Column<double>(type: "float", nullable: false),
                    RecommendationProblemRepeated = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RigMovePerformanceId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProblemFacedDuringRigMoves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProblemFacedDuringRigMoves_RigMovePerformances_RigMovePerformanceId",
                        column: x => x.RigMovePerformanceId,
                        principalTable: "RigMovePerformances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Accidents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RigId = table.Column<int>(type: "int", nullable: false),
                    TimeOfEvent = table.Column<TimeSpan>(type: "time", nullable: false),
                    DateOfEvent = table.Column<DateTime>(type: "date", nullable: false),
                    TypeOfInjuryID = table.Column<int>(type: "int", nullable: false),
                    ViolationCategoryId = table.Column<int>(type: "int", nullable: false),
                    AccidentCausesId = table.Column<int>(type: "int", nullable: false),
                    PreventionCategoryId = table.Column<int>(type: "int", nullable: false),
                    ClassificationOfAccidentId = table.Column<int>(type: "int", nullable: false),
                    AccidentLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QHSEPositionNameId = table.Column<int>(type: "int", nullable: false),
                    QHSEEmpCode = table.Column<int>(type: "int", nullable: false),
                    PusherEmpCode = table.Column<int>(type: "int", nullable: false),
                    ToolPusherPositionNameId = table.Column<int>(type: "int", nullable: false),
                    DrillerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionOfTheEvent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToolPusherPositionId = table.Column<int>(type: "int", nullable: false),
                    QHSEPositionId = table.Column<int>(type: "int", nullable: false),
                    ImmediateActionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DirectCauses = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RootCauses = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Recommendations = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pictures = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accidents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accidents_AccidentCauses_AccidentCausesId",
                        column: x => x.AccidentCausesId,
                        principalTable: "AccidentCauses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Accidents_AspNetUsers_userID",
                        column: x => x.userID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Accidents_ClassificationOfAccidents_ClassificationOfAccidentId",
                        column: x => x.ClassificationOfAccidentId,
                        principalTable: "ClassificationOfAccidents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Accidents_PreventionCategorys_PreventionCategoryId",
                        column: x => x.PreventionCategoryId,
                        principalTable: "PreventionCategorys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Accidents_QHSEPositionNames_QHSEPositionNameId",
                        column: x => x.QHSEPositionNameId,
                        principalTable: "QHSEPositionNames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Accidents_QHSEPositions_QHSEPositionId",
                        column: x => x.QHSEPositionId,
                        principalTable: "QHSEPositions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Accidents_Rigs_RigId",
                        column: x => x.RigId,
                        principalTable: "Rigs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Accidents_ToolPusherPositionNames_ToolPusherPositionNameId",
                        column: x => x.ToolPusherPositionNameId,
                        principalTable: "ToolPusherPositionNames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Accidents_ToolPusherPositions_ToolPusherPositionId",
                        column: x => x.ToolPusherPositionId,
                        principalTable: "ToolPusherPositions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Accidents_TypeOfInjurys_TypeOfInjuryID",
                        column: x => x.TypeOfInjuryID,
                        principalTable: "TypeOfInjurys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Accidents_ViolationCategorys_ViolationCategoryId",
                        column: x => x.ViolationCategoryId,
                        principalTable: "ViolationCategorys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "JMP_Passengers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    PassengerID = table.Column<int>(type: "int", nullable: false),
                    JMPID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JMP_Passengers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JMP_Passengers_JMPs_JMPID",
                        column: x => x.JMPID,
                        principalTable: "JMPs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_JMP_Passengers_Passengers_PassengerID",
                        column: x => x.PassengerID,
                        principalTable: "Passengers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accidents_AccidentCausesId",
                table: "Accidents",
                column: "AccidentCausesId");

            migrationBuilder.CreateIndex(
                name: "IX_Accidents_ClassificationOfAccidentId",
                table: "Accidents",
                column: "ClassificationOfAccidentId");

            migrationBuilder.CreateIndex(
                name: "IX_Accidents_PreventionCategoryId",
                table: "Accidents",
                column: "PreventionCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Accidents_QHSEPositionId",
                table: "Accidents",
                column: "QHSEPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Accidents_QHSEPositionNameId",
                table: "Accidents",
                column: "QHSEPositionNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Accidents_RigId",
                table: "Accidents",
                column: "RigId");

            migrationBuilder.CreateIndex(
                name: "IX_Accidents_ToolPusherPositionId",
                table: "Accidents",
                column: "ToolPusherPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Accidents_ToolPusherPositionNameId",
                table: "Accidents",
                column: "ToolPusherPositionNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Accidents_TypeOfInjuryID",
                table: "Accidents",
                column: "TypeOfInjuryID");

            migrationBuilder.CreateIndex(
                name: "IX_Accidents_userID",
                table: "Accidents",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_Accidents_ViolationCategoryId",
                table: "Accidents",
                column: "ViolationCategoryId");

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
                name: "IX_Attendances_PTSMId",
                table: "Attendances",
                column: "PTSMId");

            migrationBuilder.CreateIndex(
                name: "IX_Bop_RigId",
                table: "Bop",
                column: "RigId");

            migrationBuilder.CreateIndex(
                name: "IX_Bop_UserId",
                table: "Bop",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_JMP_Passengers_JMPID",
                table: "JMP_Passengers",
                column: "JMPID");

            migrationBuilder.CreateIndex(
                name: "IX_JMP_Passengers_PassengerID",
                table: "JMP_Passengers",
                column: "PassengerID");

            migrationBuilder.CreateIndex(
                name: "IX_JMPs_CommunicationID",
                table: "JMPs",
                column: "CommunicationID");

            migrationBuilder.CreateIndex(
                name: "IX_JMPs_DriverNameId",
                table: "JMPs",
                column: "DriverNameId");

            migrationBuilder.CreateIndex(
                name: "IX_JMPs_RouteNameID",
                table: "JMPs",
                column: "RouteNameID");

            migrationBuilder.CreateIndex(
                name: "IX_JMPs_userID",
                table: "JMPs",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_JMPs_VehicleId",
                table: "JMPs",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_ProblemFacedDuringRigMoves_RigMovePerformanceId",
                table: "ProblemFacedDuringRigMoves",
                column: "RigMovePerformanceId");

            migrationBuilder.CreateIndex(
                name: "IX_PTSMs_RigId",
                table: "PTSMs",
                column: "RigId");

            migrationBuilder.CreateIndex(
                name: "IX_PTSMs_UserId",
                table: "PTSMs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_QHSEPositionNames_PositionId",
                table: "QHSEPositionNames",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportedByNames_PositionId",
                table: "ReportedByNames",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_RigMovePerformances_RigId",
                table: "RigMovePerformances",
                column: "RigId");

            migrationBuilder.CreateIndex(
                name: "IX_RigMovePerformances_UserId",
                table: "RigMovePerformances",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StopCardRegisters_ClassificationID",
                table: "StopCardRegisters",
                column: "ClassificationID");

            migrationBuilder.CreateIndex(
                name: "IX_StopCardRegisters_ReportedByNameID",
                table: "StopCardRegisters",
                column: "ReportedByNameID");

            migrationBuilder.CreateIndex(
                name: "IX_StopCardRegisters_ReportedByPositionID",
                table: "StopCardRegisters",
                column: "ReportedByPositionID");

            migrationBuilder.CreateIndex(
                name: "IX_StopCardRegisters_TypeOfObservationCategoryID",
                table: "StopCardRegisters",
                column: "TypeOfObservationCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_StopCardRegisters_userID",
                table: "StopCardRegisters",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_ToolPusherPositionNames_PositionId",
                table: "ToolPusherPositionNames",
                column: "PositionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accidents");

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
                name: "Attendances");

            migrationBuilder.DropTable(
                name: "Bop");

            migrationBuilder.DropTable(
                name: "JMP_Passengers");

            migrationBuilder.DropTable(
                name: "LeadershipVisits");

            migrationBuilder.DropTable(
                name: "NonRecordableAccidents");

            migrationBuilder.DropTable(
                name: "ProblemFacedDuringRigMoves");

            migrationBuilder.DropTable(
                name: "RecordableAccidents");

            migrationBuilder.DropTable(
                name: "StopCardRegisters");

            migrationBuilder.DropTable(
                name: "AccidentCauses");

            migrationBuilder.DropTable(
                name: "ClassificationOfAccidents");

            migrationBuilder.DropTable(
                name: "PreventionCategorys");

            migrationBuilder.DropTable(
                name: "QHSEPositionNames");

            migrationBuilder.DropTable(
                name: "ToolPusherPositionNames");

            migrationBuilder.DropTable(
                name: "TypeOfInjurys");

            migrationBuilder.DropTable(
                name: "ViolationCategorys");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "PTSMs");

            migrationBuilder.DropTable(
                name: "JMPs");

            migrationBuilder.DropTable(
                name: "Passengers");

            migrationBuilder.DropTable(
                name: "RigMovePerformances");

            migrationBuilder.DropTable(
                name: "Classifications");

            migrationBuilder.DropTable(
                name: "ReportedByNames");

            migrationBuilder.DropTable(
                name: "TypeOfObservationCategorys");

            migrationBuilder.DropTable(
                name: "QHSEPositions");

            migrationBuilder.DropTable(
                name: "ToolPusherPositions");

            migrationBuilder.DropTable(
                name: "ComminucationMethods");

            migrationBuilder.DropTable(
                name: "DriverNames");

            migrationBuilder.DropTable(
                name: "RouteNames");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Rigs");

            migrationBuilder.DropTable(
                name: "ReportedByPositions");
        }
    }
}
