using ContasApp.Data.Entities;
using ContasApp.Data.Settings;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContasApp.Data.Repositories
{
    /// <summary>
    /// Classe para operações de Banco de dados da tabela de Usuário
    /// </summary>
    public class UsuarioRepository
    {
        /// <summary>
        /// Método para cadastrar um usuário no banco de dados
        /// </summary>
        /// <param name="usuario"></param>
        public void Add(Usuario usuario)
        {
            var query = @"
                INSERT INTO USUARIO(
                    ID,
                    NOME,
                    EMAIL,
                    SENHA,
                    DATAHORACRIACAO)
                VALUES(
                    @Id,
                    @Nome,
                    @Email,
                    CONVERT(VARCHAR(32),  HASHBYTES('MD5', @Senha), 2),
                    @DataHoraCriacao)
             ";

            //abrindo conexão com o banco de dados..
            using (var connection = new SqlConnection(SqlServerSettings.GetConnectionString()))
            {
                //executando o comando SQL no banco de dados
                connection.Execute(query, usuario);
            }
        }

        /// <summary>
        /// Método para atualizar os dados do usário no banco de dados
        /// </summary>
        /// <param name="usuario"></param>
        public void Update(Usuario usuario)
        {
            var query = @"
                UPDATE USUARIO SET
                    NOME = @Nome,
                    EMAIL = @Email
                WHERE
                    ID = @Id
                ";

            //abrindo conexão com o banco de dados..
            using (var connection = new SqlConnection(SqlServerSettings.GetConnectionString()))
            {
                //executando o comando SQL no banco de dados
                connection.Execute(query, usuario);
            }
        }

        /// <summary>
        /// Método para atualizar somente a senha do usuário
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <param name="senha"></param>
        public void UpdatePassword(Guid idUsuario, string senha)
        {
            var query = @"
                UPDATE USUARIO
                SET
                    SENHA = CONVERT(VARCHAR(32), HASHBYTES('MD5', @Senha), 2)
                WHERE
                    IDUSUARIO = @IdUsuario
             ";

            using (var connection = new SqlConnection(SqlServerSettings.GetConnectionString()))
            {
                connection.Execute(query, new { @IdUsuario = idUsuario, @Senha = senha });
            }
        }

        /// <summary>
        /// Método para excluir um usuário do banco de dados
        /// </summary>
        /// <param name="usuario"></param>
        public void Delete(Usuario usuario)
        {
            var query = @"
                DELETE FROM USUARIO
                WHERE ID = @Id
            ";

            //abrindo conexão com o banco de dados..
            using (var connection = new SqlConnection(SqlServerSettings.GetConnectionString()))
            {
                //executando o comando SQL no banco de dados
                connection.Execute(query, usuario);
            }
        }


        public Usuario? GetById(Guid id)
        {
            var query = @"
                SELECT * FROM USUARIO
                WHERE ID = @Id
            ";

            //abrindo conexão com o banco de dados..
            using (var connection = new SqlConnection(SqlServerSettings.GetConnectionString()))
            {
                //executando o comando SQL no banco de dados
                return connection.Query<Usuario>(query, new { @Id = id }).FirstOrDefault();
            }
        }

        /// <summary>
        /// Método para consultar 1 usuário no banco de dados através do Email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Usuario? GetByEmail(string email)
        {
            var query = @"
                SELECT * FROM USUARIO WHERE EMAIL = @Email
            ";

            //abrindo conexão com o banco de dados..
            using (var connection = new SqlConnection(SqlServerSettings.GetConnectionString()))
            {
                //executando o comando SQL no banco de dados
                return connection.Query<Usuario>(query, new { @Email = email }).FirstOrDefault();
            }
        }

        /// <summary>
        /// Método para consultar 1 usuário no banco de dados através do Email e da Senha
        /// </summary>
        /// <param name="email"></param>
        /// <param name="senha"></param>
        /// <returns></returns>
        public Usuario? GetByEmailAndSenha(string email, string senha)
        {
            var query = @"
                SELECT * FROM USUARIO WHERE EMAIL = @Email AND SENHA = CONVERT(VARCHAR(32), HASHBYTES('MD5', @Senha), 2)
             ";

            //abrindo conexão com o banco de dados..
            using (var connection = new SqlConnection(SqlServerSettings.GetConnectionString()))
            {
                //executando o comando SQL no banco de dados
                return connection.Query<Usuario>(query, new { @Email = email, @Senha = senha }).FirstOrDefault();
            }
        }
    }
}
