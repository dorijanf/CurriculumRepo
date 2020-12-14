using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CurriculumRepository.CORE.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "AspNetRoles",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        IdUserType = table.Column<int>(type: "int", nullable: true),
            //        Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetRoles", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUsers",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        Iduser = table.Column<int>(type: "int", nullable: false),
            //        Firstname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        Lastname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        ProfilePicture = table.Column<byte[]>(type: "image", nullable: true),
            //        RegistrationDate = table.Column<DateTime>(type: "datetime", nullable: false),
            //        IsDeleted = table.Column<bool>(type: "bit", nullable: false),
            //        UserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
            //        NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
            //        PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
            //        TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
            //        LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
            //        LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
            //        AccessFailedCount = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUsers", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Keyword",
            //    columns: table => new
            //    {
            //        IDKeyword = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        KeywordName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_KljucniPojam", x => x.IDKeyword);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "LACollaboration",
            //    columns: table => new
            //    {
            //        IDCollaboration = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        CollaborationName = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: false),
            //        Active = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_RazinaSuradnje", x => x.IDCollaboration);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "LAPerformance",
            //    columns: table => new
            //    {
            //        IDPerformance = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        PerformanceName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_LAPerformance", x => x.IDPerformance);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "LAType",
            //    columns: table => new
            //    {
            //        IDLAType = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        LATypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        Active = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_NacinIzvodenja", x => x.IDLAType);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "LearningOutcomeCT",
            //    columns: table => new
            //    {
            //        IDLearningOutcomeCT = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        LearningOutcomeCTStatement = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_IshodUcenjaRR", x => x.IDLearningOutcomeCT);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "LearningOutcomeSubject",
            //    columns: table => new
            //    {
            //        IDLearningOutcomeSubject = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        LearningOutcomeSubjectStatement = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_IshodUcenjaPredmet", x => x.IDLearningOutcomeSubject);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "LSType",
            //    columns: table => new
            //    {
            //        IDLSType = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        LSTypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        Active = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_VrstaScenarija", x => x.IDLSType);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "StrategyMethodType",
            //    columns: table => new
            //    {
            //        IDStrategyMethodType = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        StrategyMethodTypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        Active = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_VrstaStrategijeIMetode", x => x.IDStrategyMethodType);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "TeachingAidType",
            //    columns: table => new
            //    {
            //        IDTeachingAidType = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        TeachingAidTypeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
            //        Active = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_TeachingAidType", x => x.IDTeachingAidType);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "TeachingSubject",
            //    columns: table => new
            //    {
            //        IDTeachingSubject = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        TeachingSubjectName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        Active = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
            //        IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_NastavniPredmet", x => x.IDTeachingSubject);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetRoleClaims",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
            //            column: x => x.RoleId,
            //            principalTable: "AspNetRoles",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserClaims",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_AspNetUserClaims_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserLogins",
            //    columns: table => new
            //    {
            //        LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
            //        table.ForeignKey(
            //            name: "FK_AspNetUserLogins_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserRoles",
            //    columns: table => new
            //    {
            //        UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
            //        table.ForeignKey(
            //            name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
            //            column: x => x.RoleId,
            //            principalTable: "AspNetRoles",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_AspNetUserRoles_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserTokens",
            //    columns: table => new
            //    {
            //        UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
            //        table.ForeignKey(
            //            name: "FK_AspNetUserTokens_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "LA",
            //    columns: table => new
            //    {
            //        IDLA = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        LAName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
            //        LADuration = table.Column<TimeSpan>(type: "time", nullable: false),
            //        LADescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        LAGrade = table.Column<byte>(type: "tinyint", nullable: false),
            //        DigitalTechnology = table.Column<bool>(type: "bit", nullable: false),
            //        LAAcknowledgment = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
            //        LSID = table.Column<int>(type: "int", nullable: false),
            //        LATypeID = table.Column<int>(type: "int", nullable: false),
            //        PerformanceID = table.Column<int>(type: "int", nullable: true),
            //        CooperationID = table.Column<int>(type: "int", nullable: false),
            //        LAStrategiesID = table.Column<int>(type: "int", nullable: false),
            //        OrdinalNumber = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Aktivnost", x => x.IDLA);
            //        table.ForeignKey(
            //            name: "FK_LA_LACooperation",
            //            column: x => x.CooperationID,
            //            principalTable: "LACollaboration",
            //            principalColumn: "IDCollaboration",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_LA_LAPerformance",
            //            column: x => x.PerformanceID,
            //            principalTable: "LAPerformance",
            //            principalColumn: "IDPerformance",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_LA_LAType",
            //            column: x => x.LATypeID,
            //            principalTable: "LAType",
            //            principalColumn: "IDLAType",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "StrategyMethod",
            //    columns: table => new
            //    {
            //        IDStrategyMethod = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        StrategyMethodPicture = table.Column<byte[]>(type: "image", nullable: true),
            //        StrategyMethodName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
            //        StrategyMethodTypeID = table.Column<int>(type: "int", nullable: false),
            //        Active = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_StrategijeIMetode", x => x.IDStrategyMethod);
            //        table.ForeignKey(
            //            name: "FK_StrategyMethod_StrategyMethodType",
            //            column: x => x.StrategyMethodTypeID,
            //            principalTable: "StrategyMethodType",
            //            principalColumn: "IDStrategyMethodType",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "TeachingAid",
            //    columns: table => new
            //    {
            //        IDTeachingAid = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        TeachingAidPicture = table.Column<byte[]>(type: "image", nullable: true),
            //        TeachingAidName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
            //        TeachingAidTypeID = table.Column<int>(type: "int", nullable: false),
            //        Active = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_TeachingAid", x => x.IDTeachingAid);
            //        table.ForeignKey(
            //            name: "FK_TeachingAid_TeachingAidType",
            //            column: x => x.TeachingAidTypeID,
            //            principalTable: "TeachingAidType",
            //            principalColumn: "IDTeachingAidType",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "LS",
            //    columns: table => new
            //    {
            //        IDLS = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        LSName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
            //        LSDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        LSDuration = table.Column<TimeSpan>(type: "time", nullable: false),
            //        LSAcknowledgment = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
            //        UserID = table.Column<string>(type: "nvarchar(450)", nullable: true),
            //        TeachingSubjectId = table.Column<int>(type: "int", nullable: false),
            //        LSTypeID = table.Column<int>(type: "int", nullable: false),
            //        LearningOutcomeSubjectID = table.Column<int>(type: "int", nullable: false),
            //        LearningOutcomeCTID = table.Column<int>(type: "int", nullable: false),
            //        LSGrade = table.Column<int>(type: "int", nullable: true),
            //        IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ScenarijUcenja", x => x.IDLS);
            //        table.ForeignKey(
            //            name: "FK_LS_LearningOutcomeCTID",
            //            column: x => x.LearningOutcomeCTID,
            //            principalTable: "LearningOutcomeCT",
            //            principalColumn: "IDLearningOutcomeCT",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_LS_LearningOutcomeSubjectID",
            //            column: x => x.LearningOutcomeSubjectID,
            //            principalTable: "LearningOutcomeSubject",
            //            principalColumn: "IDLearningOutcomeSubject",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_LS_LSType",
            //            column: x => x.LSTypeID,
            //            principalTable: "LSType",
            //            principalColumn: "IDLSType",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_LS_TeachingSubjectID",
            //            column: x => x.TeachingSubjectId,
            //            principalTable: "TeachingSubject",
            //            principalColumn: "IDTeachingSubject",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_LS_UserID",
            //            column: x => x.UserID,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "LAStrategyMethod",
            //    columns: table => new
            //    {
            //        IDLAStrategyMethod = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        LAID = table.Column<int>(type: "int", nullable: false),
            //        StrategyMethodID = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_LAStrategyMethod", x => x.IDLAStrategyMethod);
            //        table.ForeignKey(
            //            name: "FK_LAStrategyMethod_LA",
            //            column: x => x.LAID,
            //            principalTable: "LA",
            //            principalColumn: "IDLA",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_LAStrategyMethod_StrategyMethod",
            //            column: x => x.StrategyMethodID,
            //            principalTable: "StrategyMethod",
            //            principalColumn: "IDStrategyMethod",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "LATeachingAid",
            //    columns: table => new
            //    {
            //        IDLATeachingAid = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        LATeachingAidUser = table.Column<bool>(type: "bit", nullable: true, comment: "Atribut definira hoće li se nastavnim sredstvom služiti nastavnik ili učenik. Npr. 0 za nastavnika, a 1 za učenika."),
            //        LAID = table.Column<int>(type: "int", nullable: false),
            //        TeachingAidID = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_LATeachingAid", x => x.IDLATeachingAid);
            //        table.ForeignKey(
            //            name: "FK_LATeachingAid_LA",
            //            column: x => x.LAID,
            //            principalTable: "LA",
            //            principalColumn: "IDLA",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_LATeachingAid_TeachingAid",
            //            column: x => x.TeachingAidID,
            //            principalTable: "TeachingAid",
            //            principalColumn: "IDTeachingAid",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "LSCorrelationInterdisciplinarity",
            //    columns: table => new
            //    {
            //        IDLSCorrelationInterdisciplinarity = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        LSID = table.Column<int>(type: "int", nullable: false),
            //        TeachingSubjectID = table.Column<int>(type: "int", nullable: false),
            //        IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_LSCorrelationInterdisciplinarity", x => x.IDLSCorrelationInterdisciplinarity);
            //        table.ForeignKey(
            //            name: "FK_LSCorrelationInterdisciplinarity_LS",
            //            column: x => x.LSID,
            //            principalTable: "LS",
            //            principalColumn: "IDLS",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_LSCorrelationInterdisciplinarity_TeachingSubject",
            //            column: x => x.TeachingSubjectID,
            //            principalTable: "TeachingSubject",
            //            principalColumn: "IDTeachingSubject",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "LSKEYWORD",
            //    columns: table => new
            //    {
            //        IDLSKEYWORD = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        LSID = table.Column<int>(type: "int", nullable: false),
            //        KEYWORDID = table.Column<int>(type: "int", nullable: false),
            //        IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_LSKEYWORD", x => x.IDLSKEYWORD);
            //        table.ForeignKey(
            //            name: "FK_LSKEYWORD_KEYWORD",
            //            column: x => x.KEYWORDID,
            //            principalTable: "Keyword",
            //            principalColumn: "IDKeyword",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_LSKEYWORD_LS",
            //            column: x => x.LSID,
            //            principalTable: "LS",
            //            principalColumn: "IDLS",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "LSLA",
            //    columns: table => new
            //    {
            //        IDLSLA = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        LSID = table.Column<int>(type: "int", nullable: false),
            //        LAID = table.Column<int>(type: "int", nullable: false),
            //        Rank = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_LSLA", x => x.IDLSLA);
            //        table.ForeignKey(
            //            name: "FK_LSLA_LA",
            //            column: x => x.LAID,
            //            principalTable: "LA",
            //            principalColumn: "IDLA",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_LSLA_LS",
            //            column: x => x.LSID,
            //            principalTable: "LS",
            //            principalColumn: "IDLS",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetRoleClaims_RoleId",
            //    table: "AspNetRoleClaims",
            //    column: "RoleId");

            //migrationBuilder.CreateIndex(
            //    name: "RoleNameIndex",
            //    table: "AspNetRoles",
            //    column: "NormalizedName",
            //    unique: true,
            //    filter: "[NormalizedName] IS NOT NULL");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetUserClaims_UserId",
            //    table: "AspNetUserClaims",
            //    column: "UserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetUserLogins_UserId",
            //    table: "AspNetUserLogins",
            //    column: "UserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetUserRoles_RoleId",
            //    table: "AspNetUserRoles",
            //    column: "RoleId");

            //migrationBuilder.CreateIndex(
            //    name: "EmailIndex",
            //    table: "AspNetUsers",
            //    column: "NormalizedEmail");

            //migrationBuilder.CreateIndex(
            //    name: "UserNameIndex",
            //    table: "AspNetUsers",
            //    column: "NormalizedUserName",
            //    unique: true,
            //    filter: "[NormalizedUserName] IS NOT NULL");

            //migrationBuilder.CreateIndex(
            //    name: "IX_LA_CooperationID",
            //    table: "LA",
            //    column: "CooperationID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_LA_LATypeID",
            //    table: "LA",
            //    column: "LATypeID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_LA_PerformanceID",
            //    table: "LA",
            //    column: "PerformanceID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_LAStrategyMethod_LAID",
            //    table: "LAStrategyMethod",
            //    column: "LAID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_LAStrategyMethod_StrategyMethodID",
            //    table: "LAStrategyMethod",
            //    column: "StrategyMethodID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_LATeachingAid_LAID",
            //    table: "LATeachingAid",
            //    column: "LAID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_LATeachingAid_TeachingAidID",
            //    table: "LATeachingAid",
            //    column: "TeachingAidID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_LS_LearningOutcomeCTID",
            //    table: "LS",
            //    column: "LearningOutcomeCTID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_LS_LearningOutcomeSubjectID",
            //    table: "LS",
            //    column: "LearningOutcomeSubjectID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_LS_LSTypeID",
            //    table: "LS",
            //    column: "LSTypeID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_LS_TeachingSubjectId",
            //    table: "LS",
            //    column: "TeachingSubjectId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_LS_UserID",
            //    table: "LS",
            //    column: "UserID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_LSCorrelationInterdisciplinarity_LSID",
            //    table: "LSCorrelationInterdisciplinarity",
            //    column: "LSID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_LSCorrelationInterdisciplinarity_TeachingSubjectID",
            //    table: "LSCorrelationInterdisciplinarity",
            //    column: "TeachingSubjectID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_LSKEYWORD_KEYWORDID",
            //    table: "LSKEYWORD",
            //    column: "KEYWORDID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_LSKEYWORD_LSID",
            //    table: "LSKEYWORD",
            //    column: "LSID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_LSLA_LAID",
            //    table: "LSLA",
            //    column: "LAID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_LSLA_LSID",
            //    table: "LSLA",
            //    column: "LSID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_StrategyMethod_StrategyMethodTypeID",
            //    table: "StrategyMethod",
            //    column: "StrategyMethodTypeID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_TeachingAid_TeachingAidTypeID",
            //    table: "TeachingAid",
            //    column: "TeachingAidTypeID");
            migrationBuilder.AddColumn<string>(
                name: "NormalizedName",
                table: "AspNetRoles",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "AspNetRoles",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "AspNetRoleClaims");

            //migrationBuilder.DropTable(
            //    name: "AspNetUserClaims");

            //migrationBuilder.DropTable(
            //    name: "AspNetUserLogins");

            //migrationBuilder.DropTable(
            //    name: "AspNetUserRoles");

            //migrationBuilder.DropTable(
            //    name: "AspNetUserTokens");

            //migrationBuilder.DropTable(
            //    name: "LAStrategyMethod");

            //migrationBuilder.DropTable(
            //    name: "LATeachingAid");

            //migrationBuilder.DropTable(
            //    name: "LSCorrelationInterdisciplinarity");

            //migrationBuilder.DropTable(
            //    name: "LSKEYWORD");

            //migrationBuilder.DropTable(
            //    name: "LSLA");

            //migrationBuilder.DropTable(
            //    name: "AspNetRoles");

            //migrationBuilder.DropTable(
            //    name: "StrategyMethod");

            //migrationBuilder.DropTable(
            //    name: "TeachingAid");

            //migrationBuilder.DropTable(
            //    name: "Keyword");

            //migrationBuilder.DropTable(
            //    name: "LA");

            //migrationBuilder.DropTable(
            //    name: "LS");

            //migrationBuilder.DropTable(
            //    name: "StrategyMethodType");

            //migrationBuilder.DropTable(
            //    name: "TeachingAidType");

            //migrationBuilder.DropTable(
            //    name: "LACollaboration");

            //migrationBuilder.DropTable(
            //    name: "LAPerformance");

            //migrationBuilder.DropTable(
            //    name: "LAType");

            //migrationBuilder.DropTable(
            //    name: "LearningOutcomeCT");

            //migrationBuilder.DropTable(
            //    name: "LearningOutcomeSubject");

            //migrationBuilder.DropTable(
            //    name: "LSType");

            //migrationBuilder.DropTable(
            //    name: "TeachingSubject");

            //migrationBuilder.DropTable(
            //    name: "AspNetUsers");
        }
    }
}
