using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesDP.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "__EFMigrationsLock",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Timestamp = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK___EFMigrationsLock", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "country",
                columns: table => new
                {
                    country_id = table.Column<int>(type: "INT", nullable: false),
                    country_iso_code = table.Column<string>(type: "TEXT", nullable: true, defaultValueSql: "NULL"),
                    country_name = table.Column<string>(type: "TEXT", nullable: true, defaultValueSql: "NULL")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_country", x => x.country_id);
                });

            migrationBuilder.CreateTable(
                name: "department",
                columns: table => new
                {
                    department_id = table.Column<int>(type: "INT", nullable: false),
                    department_name = table.Column<string>(type: "TEXT", nullable: true, defaultValueSql: "NULL")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_department", x => x.department_id);
                });

            migrationBuilder.CreateTable(
                name: "gender",
                columns: table => new
                {
                    gender_id = table.Column<int>(type: "INT", nullable: false),
                    gender = table.Column<string>(type: "TEXT", nullable: true, defaultValueSql: "NULL")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gender", x => x.gender_id);
                });

            migrationBuilder.CreateTable(
                name: "genre",
                columns: table => new
                {
                    genre_id = table.Column<int>(type: "INT", nullable: false),
                    genre_name = table.Column<string>(type: "TEXT", nullable: true, defaultValueSql: "NULL")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genre", x => x.genre_id);
                });

            migrationBuilder.CreateTable(
                name: "keyword",
                columns: table => new
                {
                    keyword_id = table.Column<int>(type: "INT", nullable: false),
                    keyword_name = table.Column<string>(type: "varchar(100)", nullable: true, defaultValueSql: "NULL")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_keyword", x => x.keyword_id);
                });

            migrationBuilder.CreateTable(
                name: "language",
                columns: table => new
                {
                    language_id = table.Column<int>(type: "INT", nullable: false),
                    language_code = table.Column<string>(type: "TEXT", nullable: true, defaultValueSql: "NULL"),
                    language_name = table.Column<string>(type: "TEXT", nullable: true, defaultValueSql: "NULL")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_language", x => x.language_id);
                });

            migrationBuilder.CreateTable(
                name: "language_role",
                columns: table => new
                {
                    role_id = table.Column<int>(type: "INT", nullable: false),
                    language_role = table.Column<string>(type: "TEXT", nullable: true, defaultValueSql: "NULL")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_language_role", x => x.role_id);
                });

            migrationBuilder.CreateTable(
                name: "movie",
                columns: table => new
                {
                    movie_id = table.Column<int>(type: "INT", nullable: false),
                    title = table.Column<string>(type: "TEXT", nullable: true, defaultValueSql: "NULL"),
                    budget = table.Column<int>(type: "INT", nullable: true, defaultValueSql: "NULL"),
                    homepage = table.Column<string>(type: "TEXT", nullable: true, defaultValueSql: "NULL"),
                    overview = table.Column<string>(type: "TEXT", nullable: true, defaultValueSql: "NULL"),
                    popularity = table.Column<double>(type: "REAL", nullable: true, defaultValueSql: "NULL"),
                    release_date = table.Column<DateOnly>(type: "DATE", nullable: true, defaultValueSql: "NULL"),
                    revenue = table.Column<long>(type: "INT", nullable: true, defaultValueSql: "NULL"),
                    runtime = table.Column<int>(type: "INT", nullable: true, defaultValueSql: "NULL"),
                    movie_status = table.Column<string>(type: "TEXT", nullable: true, defaultValueSql: "NULL"),
                    tagline = table.Column<string>(type: "TEXT", nullable: true, defaultValueSql: "NULL"),
                    vote_average = table.Column<double>(type: "REAL", nullable: true, defaultValueSql: "NULL"),
                    vote_count = table.Column<int>(type: "INT", nullable: true, defaultValueSql: "NULL")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movie", x => x.movie_id);
                });

            migrationBuilder.CreateTable(
                name: "person",
                columns: table => new
                {
                    person_id = table.Column<int>(type: "INT", nullable: false),
                    person_name = table.Column<string>(type: "TEXT", nullable: true, defaultValueSql: "NULL")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_person", x => x.person_id);
                });

            migrationBuilder.CreateTable(
                name: "production_company",
                columns: table => new
                {
                    company_id = table.Column<int>(type: "INT", nullable: false),
                    company_name = table.Column<string>(type: "TEXT", nullable: true, defaultValueSql: "NULL")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_production_company", x => x.company_id);
                });

            migrationBuilder.CreateTable(
                name: "movie_genres",
                columns: table => new
                {
                    movie_id = table.Column<int>(type: "INT", nullable: true, defaultValueSql: "NULL"),
                    genre_id = table.Column<int>(type: "INT", nullable: true, defaultValueSql: "NULL")
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_movie_genres_genre_genre_id",
                        column: x => x.genre_id,
                        principalTable: "genre",
                        principalColumn: "genre_id");
                    table.ForeignKey(
                        name: "FK_movie_genres_movie_movie_id",
                        column: x => x.movie_id,
                        principalTable: "movie",
                        principalColumn: "movie_id");
                });

            migrationBuilder.CreateTable(
                name: "movie_keywords",
                columns: table => new
                {
                    movie_id = table.Column<int>(type: "INT", nullable: true, defaultValueSql: "NULL"),
                    keyword_id = table.Column<int>(type: "INT", nullable: true, defaultValueSql: "NULL")
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_movie_keywords_keyword_keyword_id",
                        column: x => x.keyword_id,
                        principalTable: "keyword",
                        principalColumn: "keyword_id");
                    table.ForeignKey(
                        name: "FK_movie_keywords_movie_movie_id",
                        column: x => x.movie_id,
                        principalTable: "movie",
                        principalColumn: "movie_id");
                });

            migrationBuilder.CreateTable(
                name: "movie_languages",
                columns: table => new
                {
                    movie_id = table.Column<int>(type: "INT", nullable: true, defaultValueSql: "NULL"),
                    language_id = table.Column<int>(type: "INT", nullable: true, defaultValueSql: "NULL"),
                    language_role_id = table.Column<int>(type: "INT", nullable: true, defaultValueSql: "NULL")
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_movie_languages_language_language_id",
                        column: x => x.language_id,
                        principalTable: "language",
                        principalColumn: "language_id");
                    table.ForeignKey(
                        name: "FK_movie_languages_language_role_language_role_id",
                        column: x => x.language_role_id,
                        principalTable: "language_role",
                        principalColumn: "role_id");
                    table.ForeignKey(
                        name: "FK_movie_languages_movie_movie_id",
                        column: x => x.movie_id,
                        principalTable: "movie",
                        principalColumn: "movie_id");
                });

            migrationBuilder.CreateTable(
                name: "production_country",
                columns: table => new
                {
                    movie_id = table.Column<int>(type: "INT", nullable: true, defaultValueSql: "NULL"),
                    country_id = table.Column<int>(type: "INT", nullable: true, defaultValueSql: "NULL")
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_production_country_country_country_id",
                        column: x => x.country_id,
                        principalTable: "country",
                        principalColumn: "country_id");
                    table.ForeignKey(
                        name: "FK_production_country_movie_movie_id",
                        column: x => x.movie_id,
                        principalTable: "movie",
                        principalColumn: "movie_id");
                });

            migrationBuilder.CreateTable(
                name: "movie_cast",
                columns: table => new
                {
                    movie_id = table.Column<int>(type: "INT", nullable: true, defaultValueSql: "NULL"),
                    person_id = table.Column<int>(type: "INT", nullable: true, defaultValueSql: "NULL"),
                    character_name = table.Column<string>(type: "TEXT", nullable: true, defaultValueSql: "NULL"),
                    gender_id = table.Column<int>(type: "INT", nullable: true, defaultValueSql: "NULL"),
                    cast_order = table.Column<int>(type: "INT", nullable: true, defaultValueSql: "NULL")
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_movie_cast_gender_gender_id",
                        column: x => x.gender_id,
                        principalTable: "gender",
                        principalColumn: "gender_id");
                    table.ForeignKey(
                        name: "FK_movie_cast_movie_movie_id",
                        column: x => x.movie_id,
                        principalTable: "movie",
                        principalColumn: "movie_id");
                    table.ForeignKey(
                        name: "FK_movie_cast_person_person_id",
                        column: x => x.person_id,
                        principalTable: "person",
                        principalColumn: "person_id");
                });

            migrationBuilder.CreateTable(
                name: "movie_crew",
                columns: table => new
                {
                    movie_id = table.Column<int>(type: "INT", nullable: true, defaultValueSql: "NULL"),
                    person_id = table.Column<int>(type: "INT", nullable: true, defaultValueSql: "NULL"),
                    department_id = table.Column<int>(type: "INT", nullable: true, defaultValueSql: "NULL"),
                    job = table.Column<string>(type: "TEXT", nullable: true, defaultValueSql: "NULL")
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_movie_crew_department_department_id",
                        column: x => x.department_id,
                        principalTable: "department",
                        principalColumn: "department_id");
                    table.ForeignKey(
                        name: "FK_movie_crew_movie_movie_id",
                        column: x => x.movie_id,
                        principalTable: "movie",
                        principalColumn: "movie_id");
                    table.ForeignKey(
                        name: "FK_movie_crew_person_person_id",
                        column: x => x.person_id,
                        principalTable: "person",
                        principalColumn: "person_id");
                });

            migrationBuilder.CreateTable(
                name: "movie_company",
                columns: table => new
                {
                    movie_id = table.Column<int>(type: "INT", nullable: true, defaultValueSql: "NULL"),
                    company_id = table.Column<int>(type: "INT", nullable: true, defaultValueSql: "NULL")
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_movie_company_movie_movie_id",
                        column: x => x.movie_id,
                        principalTable: "movie",
                        principalColumn: "movie_id");
                    table.ForeignKey(
                        name: "FK_movie_company_production_company_company_id",
                        column: x => x.company_id,
                        principalTable: "production_company",
                        principalColumn: "company_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_movie_cast_gender_id",
                table: "movie_cast",
                column: "gender_id");

            migrationBuilder.CreateIndex(
                name: "IX_movie_cast_movie_id",
                table: "movie_cast",
                column: "movie_id");

            migrationBuilder.CreateIndex(
                name: "IX_movie_cast_person_id",
                table: "movie_cast",
                column: "person_id");

            migrationBuilder.CreateIndex(
                name: "IX_movie_company_company_id",
                table: "movie_company",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_movie_company_movie_id",
                table: "movie_company",
                column: "movie_id");

            migrationBuilder.CreateIndex(
                name: "IX_movie_crew_department_id",
                table: "movie_crew",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "IX_movie_crew_movie_id",
                table: "movie_crew",
                column: "movie_id");

            migrationBuilder.CreateIndex(
                name: "IX_movie_crew_person_id",
                table: "movie_crew",
                column: "person_id");

            migrationBuilder.CreateIndex(
                name: "IX_movie_genres_genre_id",
                table: "movie_genres",
                column: "genre_id");

            migrationBuilder.CreateIndex(
                name: "IX_movie_genres_movie_id",
                table: "movie_genres",
                column: "movie_id");

            migrationBuilder.CreateIndex(
                name: "IX_movie_keywords_keyword_id",
                table: "movie_keywords",
                column: "keyword_id");

            migrationBuilder.CreateIndex(
                name: "IX_movie_keywords_movie_id",
                table: "movie_keywords",
                column: "movie_id");

            migrationBuilder.CreateIndex(
                name: "IX_movie_languages_language_id",
                table: "movie_languages",
                column: "language_id");

            migrationBuilder.CreateIndex(
                name: "IX_movie_languages_language_role_id",
                table: "movie_languages",
                column: "language_role_id");

            migrationBuilder.CreateIndex(
                name: "IX_movie_languages_movie_id",
                table: "movie_languages",
                column: "movie_id");

            migrationBuilder.CreateIndex(
                name: "IX_production_country_country_id",
                table: "production_country",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "IX_production_country_movie_id",
                table: "production_country",
                column: "movie_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "__EFMigrationsLock");

            migrationBuilder.DropTable(
                name: "movie_cast");

            migrationBuilder.DropTable(
                name: "movie_company");

            migrationBuilder.DropTable(
                name: "movie_crew");

            migrationBuilder.DropTable(
                name: "movie_genres");

            migrationBuilder.DropTable(
                name: "movie_keywords");

            migrationBuilder.DropTable(
                name: "movie_languages");

            migrationBuilder.DropTable(
                name: "production_country");

            migrationBuilder.DropTable(
                name: "gender");

            migrationBuilder.DropTable(
                name: "production_company");

            migrationBuilder.DropTable(
                name: "department");

            migrationBuilder.DropTable(
                name: "person");

            migrationBuilder.DropTable(
                name: "genre");

            migrationBuilder.DropTable(
                name: "keyword");

            migrationBuilder.DropTable(
                name: "language");

            migrationBuilder.DropTable(
                name: "language_role");

            migrationBuilder.DropTable(
                name: "country");

            migrationBuilder.DropTable(
                name: "movie");
        }
    }
}
