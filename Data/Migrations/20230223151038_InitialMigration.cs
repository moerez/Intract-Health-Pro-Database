using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InteractHealthProDatabase.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "ClientSequence");

            migrationBuilder.CreateSequence(
                name: "HealthCompanyContactSequence");

            migrationBuilder.CreateSequence(
                name: "InsuranceCompanyContactSequence");

            migrationBuilder.CreateSequence(
                name: "LawyerSequence");

            migrationBuilder.CreateSequence(
                name: "MedicalHistorySequence");

            migrationBuilder.CreateSequence(
                name: "PsychotherapySequence");

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
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [ClientSequence]"),
                    Referral = table.Column<int>(type: "int", nullable: true),
                    ContactName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CellPhone = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HealthCompanies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthCompanies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InsuranceCompanies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceCompanies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lawyers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [LawyerSequence]"),
                    ContactName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CellPhone = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lawyers", x => x.Id);
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
                        onDelete: ReferentialAction.Cascade);
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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
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
                name: "AccidentDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    DateTimeAcc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MedicalHistoryUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FMedVisit = table.Column<int>(type: "int", nullable: true),
                    Weather = table.Column<int>(type: "int", nullable: true),
                    Visibility = table.Column<int>(type: "int", nullable: true),
                    RoadCondition = table.Column<int>(type: "int", nullable: true),
                    AccidentLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccidentDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PoliceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PoliceBadgeNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PoliceDept = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PoliceReportAccDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PoliceReportCenter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PoliceCharge = table.Column<bool>(type: "bit", nullable: true),
                    EmeAtScenePolice = table.Column<bool>(type: "bit", nullable: false),
                    EmeAtSceneAmbulance = table.Column<bool>(type: "bit", nullable: false),
                    EmeAtSceneFirefighters = table.Column<bool>(type: "bit", nullable: false),
                    EmeAtSceneTowing = table.Column<bool>(type: "bit", nullable: false),
                    EmeAtSceneNoOneCame = table.Column<bool>(type: "bit", nullable: false),
                    TakeByAmbulance = table.Column<bool>(type: "bit", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccidentDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccidentDetails_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientMVA",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Dob = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OHIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Consent = table.Column<bool>(type: "bit", nullable: true),
                    DominantHand = table.Column<bool>(type: "bit", nullable: true),
                    Height = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaritalStatus = table.Column<int>(type: "int", nullable: true),
                    Accommodation = table.Column<int>(type: "int", nullable: true),
                    AccommodationType = table.Column<int>(type: "int", nullable: true),
                    Household = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmergencyContactName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Relationship = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CellPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Interpreter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreferredLanguage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientMVA", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientMVA_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Concussion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    HeadAches = table.Column<bool>(type: "bit", nullable: true),
                    Vision = table.Column<bool>(type: "bit", nullable: true),
                    Amnesia = table.Column<bool>(type: "bit", nullable: true),
                    Smell = table.Column<bool>(type: "bit", nullable: true),
                    Tinitus = table.Column<bool>(type: "bit", nullable: true),
                    Seizures = table.Column<bool>(type: "bit", nullable: true),
                    Dizziness = table.Column<bool>(type: "bit", nullable: true),
                    Balance = table.Column<bool>(type: "bit", nullable: true),
                    Tremors = table.Column<bool>(type: "bit", nullable: true),
                    Nausea = table.Column<bool>(type: "bit", nullable: true),
                    Blackouts = table.Column<bool>(type: "bit", nullable: true),
                    Tasks = table.Column<bool>(type: "bit", nullable: true),
                    Motivation = table.Column<bool>(type: "bit", nullable: true),
                    FinishTasks = table.Column<bool>(type: "bit", nullable: true),
                    Assert = table.Column<bool>(type: "bit", nullable: true),
                    Forgetful = table.Column<bool>(type: "bit", nullable: true),
                    AttentionSpan = table.Column<bool>(type: "bit", nullable: true),
                    AnticipateOthers = table.Column<bool>(type: "bit", nullable: true),
                    ProblemSolving = table.Column<bool>(type: "bit", nullable: true),
                    MentalStamina = table.Column<bool>(type: "bit", nullable: true),
                    Reading = table.Column<bool>(type: "bit", nullable: true),
                    Performance = table.Column<bool>(type: "bit", nullable: true),
                    LanguageDifficulty = table.Column<bool>(type: "bit", nullable: true),
                    Verbal = table.Column<bool>(type: "bit", nullable: true),
                    ImpairedJudgement = table.Column<bool>(type: "bit", nullable: true),
                    Reactions = table.Column<bool>(type: "bit", nullable: true),
                    NotesTimer = table.Column<bool>(type: "bit", nullable: true),
                    AbnormalAnxiety = table.Column<bool>(type: "bit", nullable: true),
                    Rude = table.Column<bool>(type: "bit", nullable: true),
                    Personality = table.Column<bool>(type: "bit", nullable: true),
                    Mood = table.Column<bool>(type: "bit", nullable: true),
                    Depression = table.Column<bool>(type: "bit", nullable: true),
                    Indifference = table.Column<bool>(type: "bit", nullable: true),
                    Fatigue = table.Column<bool>(type: "bit", nullable: true),
                    Shallow = table.Column<bool>(type: "bit", nullable: true),
                    MentalFlex = table.Column<bool>(type: "bit", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concussion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Concussion_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dependent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    Person = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Wheelchair = table.Column<bool>(type: "bit", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dependent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dependent_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [MedicalHistorySequence]"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    Hospitalized = table.Column<bool>(type: "bit", nullable: true),
                    HospitalizedCondition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Asthma = table.Column<bool>(type: "bit", nullable: true),
                    Arthritis = table.Column<bool>(type: "bit", nullable: true),
                    Diabetes = table.Column<bool>(type: "bit", nullable: true),
                    HeartStroke = table.Column<bool>(type: "bit", nullable: true),
                    Thyroid = table.Column<bool>(type: "bit", nullable: true),
                    Other = table.Column<bool>(type: "bit", nullable: true),
                    Cancer = table.Column<bool>(type: "bit", nullable: true),
                    None = table.Column<bool>(type: "bit", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalHistory_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalHistoryAccident",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameOfPatiant = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ambulance = table.Column<bool>(type: "bit", nullable: true),
                    Walkin = table.Column<bool>(type: "bit", nullable: true),
                    Attending = table.Column<bool>(type: "bit", nullable: true),
                    Xray = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalHistoryAccident", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalHistoryAccident_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    Cat = table.Column<int>(type: "int", nullable: true),
                    Dog = table.Column<int>(type: "int", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pet_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Psychotherapies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [PsychotherapySequence]"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    Stressed = table.Column<bool>(type: "bit", nullable: true),
                    Sad = table.Column<bool>(type: "bit", nullable: true),
                    NervousDepressed = table.Column<bool>(type: "bit", nullable: true),
                    Irritable = table.Column<bool>(type: "bit", nullable: true),
                    Restless = table.Column<bool>(type: "bit", nullable: true),
                    SleepTrouble = table.Column<bool>(type: "bit", nullable: true),
                    Flashbacks = table.Column<bool>(type: "bit", nullable: true),
                    Nightmares = table.Column<bool>(type: "bit", nullable: true),
                    MemoryProblems = table.Column<bool>(type: "bit", nullable: true),
                    AfraidDriving = table.Column<bool>(type: "bit", nullable: true),
                    AfraidPassenger = table.Column<bool>(type: "bit", nullable: true),
                    RelationshipsAffected = table.Column<bool>(type: "bit", nullable: true),
                    DifficultyWActivities = table.Column<bool>(type: "bit", nullable: true),
                    LowEnergy = table.Column<bool>(type: "bit", nullable: true),
                    Apathy = table.Column<bool>(type: "bit", nullable: true),
                    Avoidance = table.Column<bool>(type: "bit", nullable: true),
                    Other = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CellPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Psychotherapies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Psychotherapies_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    From = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Until = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkHistory_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HealthCompanyContacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [HealthCompanyContactSequence]"),
                    Title = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    HealthCompanyId = table.Column<int>(type: "int", nullable: false),
                    ContactName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CellPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthCompanyContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HealthCompanyContacts_HealthCompanies_HealthCompanyId",
                        column: x => x.HealthCompanyId,
                        principalTable: "HealthCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HealthFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    HealthCompanyId = table.Column<int>(type: "int", nullable: false),
                    RefNo = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    OtherRefNo = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TypeOfAppointment = table.Column<int>(type: "int", nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HealthFiles_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HealthFiles_HealthCompanies_HealthCompanyId",
                        column: x => x.HealthCompanyId,
                        principalTable: "HealthCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InsuranceClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    InsuranceCompanyId = table.Column<int>(type: "int", nullable: false),
                    Claimref = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    OtherClaimRef = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InsuranceClaims_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InsuranceClaims_InsuranceCompanies_InsuranceCompanyId",
                        column: x => x.InsuranceCompanyId,
                        principalTable: "InsuranceCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InsuranceCompanyContacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [InsuranceCompanyContactSequence]"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsuranceCompanyId = table.Column<int>(type: "int", nullable: false),
                    ContactName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CellPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceCompanyContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InsuranceCompanyContacts_InsuranceCompanies_InsuranceCompanyId",
                        column: x => x.InsuranceCompanyId,
                        principalTable: "InsuranceCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    LawyerId = table.Column<int>(type: "int", nullable: false),
                    CaseRef = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    OtherRef = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cases_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cases_Lawyers_LawyerId",
                        column: x => x.LawyerId,
                        principalTable: "Lawyers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccidentVehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccidentDetailId = table.Column<int>(type: "int", nullable: false),
                    TransportType = table.Column<int>(type: "int", nullable: true),
                    DriverPosition = table.Column<int>(type: "int", nullable: true),
                    Make = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: true),
                    License = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    VehiclePersName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleNoPeople = table.Column<int>(type: "int", nullable: true),
                    OtherLiableParties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DroveFrmScene = table.Column<bool>(type: "bit", nullable: false),
                    Seatbelt = table.Column<bool>(type: "bit", nullable: false),
                    AirbagDeploy = table.Column<bool>(type: "bit", nullable: false),
                    Bracing = table.Column<bool>(type: "bit", nullable: false),
                    Anticipated = table.Column<bool>(type: "bit", nullable: false),
                    MvaCoName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MvaPolicyNo = table.Column<int>(type: "int", nullable: true),
                    MvaClaimNo = table.Column<int>(type: "int", nullable: true),
                    MvaAdjuster = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MvaTel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MvaFax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MvaEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MvaAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MvaCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MvaProv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MvaPC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsuranceUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccidentVehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccidentVehicles_AccidentDetails_AccidentDetailId",
                        column: x => x.AccidentDetailId,
                        principalTable: "AccidentDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BodyPart",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccidentDetailId = table.Column<int>(type: "int", nullable: false),
                    Concussion = table.Column<bool>(type: "bit", nullable: true),
                    Fracture = table.Column<bool>(type: "bit", nullable: true),
                    DiscHerniation = table.Column<bool>(type: "bit", nullable: true),
                    HeadR = table.Column<bool>(type: "bit", nullable: true),
                    HeadL = table.Column<bool>(type: "bit", nullable: true),
                    HeadF = table.Column<bool>(type: "bit", nullable: true),
                    HeadB = table.Column<bool>(type: "bit", nullable: true),
                    FaceR = table.Column<bool>(type: "bit", nullable: true),
                    FaceL = table.Column<bool>(type: "bit", nullable: true),
                    Jaw = table.Column<bool>(type: "bit", nullable: true),
                    Teeth = table.Column<bool>(type: "bit", nullable: true),
                    Neck = table.Column<bool>(type: "bit", nullable: true),
                    UpBack = table.Column<bool>(type: "bit", nullable: true),
                    UpBackR = table.Column<bool>(type: "bit", nullable: true),
                    UpBackL = table.Column<bool>(type: "bit", nullable: true),
                    MidBack = table.Column<bool>(type: "bit", nullable: true),
                    MidBackR = table.Column<bool>(type: "bit", nullable: true),
                    MidBackL = table.Column<bool>(type: "bit", nullable: true),
                    LowBack = table.Column<bool>(type: "bit", nullable: true),
                    LowBackR = table.Column<bool>(type: "bit", nullable: true),
                    LowBackL = table.Column<bool>(type: "bit", nullable: true),
                    ShoulderR = table.Column<bool>(type: "bit", nullable: true),
                    ShoulderL = table.Column<bool>(type: "bit", nullable: true),
                    UpArmR = table.Column<bool>(type: "bit", nullable: true),
                    UpArmL = table.Column<bool>(type: "bit", nullable: true),
                    ElbowR = table.Column<bool>(type: "bit", nullable: true),
                    ElbowL = table.Column<bool>(type: "bit", nullable: true),
                    ForearmR = table.Column<bool>(type: "bit", nullable: true),
                    ForearmL = table.Column<bool>(type: "bit", nullable: true),
                    WristR = table.Column<bool>(type: "bit", nullable: true),
                    WristL = table.Column<bool>(type: "bit", nullable: true),
                    HandR = table.Column<bool>(type: "bit", nullable: true),
                    HandL = table.Column<bool>(type: "bit", nullable: true),
                    FingersR = table.Column<bool>(type: "bit", nullable: true),
                    FingersL = table.Column<bool>(type: "bit", nullable: true),
                    ChestR = table.Column<bool>(type: "bit", nullable: true),
                    ChestL = table.Column<bool>(type: "bit", nullable: true),
                    RibsR = table.Column<bool>(type: "bit", nullable: true),
                    RibsL = table.Column<bool>(type: "bit", nullable: true),
                    ButtocksR = table.Column<bool>(type: "bit", nullable: true),
                    ButtocksL = table.Column<bool>(type: "bit", nullable: true),
                    HipR = table.Column<bool>(type: "bit", nullable: true),
                    HipL = table.Column<bool>(type: "bit", nullable: true),
                    ThighR = table.Column<bool>(type: "bit", nullable: false),
                    ThighL = table.Column<bool>(type: "bit", nullable: true),
                    UpLegR = table.Column<bool>(type: "bit", nullable: true),
                    UpLegL = table.Column<bool>(type: "bit", nullable: true),
                    LowLegRt = table.Column<bool>(type: "bit", nullable: true),
                    LowLegR = table.Column<bool>(type: "bit", nullable: true),
                    KneeR = table.Column<bool>(type: "bit", nullable: true),
                    KneeL = table.Column<bool>(type: "bit", nullable: true),
                    AnkleR = table.Column<bool>(type: "bit", nullable: true),
                    AnkleL = table.Column<bool>(type: "bit", nullable: true),
                    FootR = table.Column<bool>(type: "bit", nullable: true),
                    FootL = table.Column<bool>(type: "bit", nullable: true),
                    ToesR = table.Column<bool>(type: "bit", nullable: true),
                    ToesL = table.Column<bool>(type: "bit", nullable: true),
                    TingRArm = table.Column<bool>(type: "bit", nullable: true),
                    TingLArm = table.Column<bool>(type: "bit", nullable: true),
                    NumbRHand = table.Column<bool>(type: "bit", nullable: true),
                    NumbLHand = table.Column<bool>(type: "bit", nullable: true),
                    PainRArm = table.Column<bool>(type: "bit", nullable: true),
                    PainLArm = table.Column<bool>(type: "bit", nullable: true),
                    TingRLeg = table.Column<bool>(type: "bit", nullable: true),
                    TingLLeg = table.Column<bool>(type: "bit", nullable: true),
                    NumbRLeg = table.Column<bool>(type: "bit", nullable: true),
                    NumbLLeg = table.Column<bool>(type: "bit", nullable: true),
                    PainRLeg = table.Column<bool>(type: "bit", nullable: true),
                    PainLLeg = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BodyPart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BodyPart_AccidentDetails_AccidentDetailId",
                        column: x => x.AccidentDetailId,
                        principalTable: "AccidentDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medication",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicalHistoryId = table.Column<int>(type: "int", nullable: true),
                    MedicalHistoryAccidentId = table.Column<int>(type: "int", nullable: true),
                    Diagnosis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Treatment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Drug = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Doseage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateDiagnosed = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medication", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medication_MedicalHistoryAccident_MedicalHistoryAccidentId",
                        column: x => x.MedicalHistoryAccidentId,
                        principalTable: "MedicalHistoryAccident",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Medication_MedicalHistory_MedicalHistoryId",
                        column: x => x.MedicalHistoryId,
                        principalTable: "MedicalHistory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccidentDetails_ClientId",
                table: "AccidentDetails",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_AccidentVehicles_AccidentDetailId",
                table: "AccidentVehicles",
                column: "AccidentDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_AccidentVehicles_License",
                table: "AccidentVehicles",
                column: "License");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ClientId",
                table: "Appointments",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_Start",
                table: "Appointments",
                column: "Start");

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
                name: "IX_BodyPart_AccidentDetailId",
                table: "BodyPart",
                column: "AccidentDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_CaseRef_OtherRef",
                table: "Cases",
                columns: new[] { "CaseRef", "OtherRef" });

            migrationBuilder.CreateIndex(
                name: "IX_Cases_ClientId",
                table: "Cases",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_LawyerId",
                table: "Cases",
                column: "LawyerId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientMVA_ClientId",
                table: "ClientMVA",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ContactName_Email_CellPhone",
                table: "Clients",
                columns: new[] { "ContactName", "Email", "CellPhone" });

            migrationBuilder.CreateIndex(
                name: "IX_Concussion_ClientId",
                table: "Concussion",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Dependent_ClientId",
                table: "Dependent",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthCompanies_Title",
                table: "HealthCompanies",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_HealthCompanyContacts_HealthCompanyId",
                table: "HealthCompanyContacts",
                column: "HealthCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthCompanyContacts_Title_ContactName_Telephone",
                table: "HealthCompanyContacts",
                columns: new[] { "Title", "ContactName", "Telephone" });

            migrationBuilder.CreateIndex(
                name: "IX_HealthFiles_ClientId",
                table: "HealthFiles",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthFiles_HealthCompanyId",
                table: "HealthFiles",
                column: "HealthCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthFiles_RefNo_OtherRefNo",
                table: "HealthFiles",
                columns: new[] { "RefNo", "OtherRefNo" });

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceClaims_Claimref_OtherClaimRef",
                table: "InsuranceClaims",
                columns: new[] { "Claimref", "OtherClaimRef" });

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceClaims_ClientId",
                table: "InsuranceClaims",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceClaims_InsuranceCompanyId",
                table: "InsuranceClaims",
                column: "InsuranceCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceCompanies_Title",
                table: "InsuranceCompanies",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceCompanyContacts_InsuranceCompanyId",
                table: "InsuranceCompanyContacts",
                column: "InsuranceCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Lawyers_ContactName_CellPhone",
                table: "Lawyers",
                columns: new[] { "ContactName", "CellPhone" });

            migrationBuilder.CreateIndex(
                name: "IX_MedicalHistory_ClientId",
                table: "MedicalHistory",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalHistoryAccident_ClientId",
                table: "MedicalHistoryAccident",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Medication_MedicalHistoryAccidentId",
                table: "Medication",
                column: "MedicalHistoryAccidentId");

            migrationBuilder.CreateIndex(
                name: "IX_Medication_MedicalHistoryId",
                table: "Medication",
                column: "MedicalHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Pet_ClientId",
                table: "Pet",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Psychotherapies_ClientId",
                table: "Psychotherapies",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkHistory_ClientId",
                table: "WorkHistory",
                column: "ClientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccidentVehicles");

            migrationBuilder.DropTable(
                name: "Appointments");

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
                name: "BodyPart");

            migrationBuilder.DropTable(
                name: "Cases");

            migrationBuilder.DropTable(
                name: "ClientMVA");

            migrationBuilder.DropTable(
                name: "Concussion");

            migrationBuilder.DropTable(
                name: "Dependent");

            migrationBuilder.DropTable(
                name: "HealthCompanyContacts");

            migrationBuilder.DropTable(
                name: "HealthFiles");

            migrationBuilder.DropTable(
                name: "InsuranceClaims");

            migrationBuilder.DropTable(
                name: "InsuranceCompanyContacts");

            migrationBuilder.DropTable(
                name: "Medication");

            migrationBuilder.DropTable(
                name: "Pet");

            migrationBuilder.DropTable(
                name: "Psychotherapies");

            migrationBuilder.DropTable(
                name: "WorkHistory");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "AccidentDetails");

            migrationBuilder.DropTable(
                name: "Lawyers");

            migrationBuilder.DropTable(
                name: "HealthCompanies");

            migrationBuilder.DropTable(
                name: "InsuranceCompanies");

            migrationBuilder.DropTable(
                name: "MedicalHistoryAccident");

            migrationBuilder.DropTable(
                name: "MedicalHistory");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropSequence(
                name: "ClientSequence");

            migrationBuilder.DropSequence(
                name: "HealthCompanyContactSequence");

            migrationBuilder.DropSequence(
                name: "InsuranceCompanyContactSequence");

            migrationBuilder.DropSequence(
                name: "LawyerSequence");

            migrationBuilder.DropSequence(
                name: "MedicalHistorySequence");

            migrationBuilder.DropSequence(
                name: "PsychotherapySequence");
        }
    }
}
