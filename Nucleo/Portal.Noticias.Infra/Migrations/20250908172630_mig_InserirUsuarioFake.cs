using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portal.Noticias.Infra.Migrations
{
    /// <inheritdoc />
    public partial class mig_InserirUsuarioFake : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //Inserindo Usuário Fake
            migrationBuilder.Sql(@"
                SET IDENTITY_INSERT Usuario ON;

                INSERT INTO Usuario (Id, Nome, Email, Senha)
                VALUES (1, 'Usuário Teste', 'teste@teste.com', 'D41D8CD98F00B204E9800998ECF8427E');

                SET IDENTITY_INSERT Usuario OFF;
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
