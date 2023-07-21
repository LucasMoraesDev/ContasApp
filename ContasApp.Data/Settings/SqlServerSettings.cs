using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContasApp.Data.Settings
{
    /// <summary>
    /// Classe para armazenar a string de conexão do banco de dados
    /// </summary>
    public class SqlServerSettings
    {
        /// <summary>
        /// Método para retornar a string de conexão do banco de dados
        /// </summary>
        /// <returns></returns>
        public static string GetConnectionString()
        {
            return @"Data Source=SQL8005.site4now.net;Initial Catalog=db_a9c8d4_contasapp;User Id=db_a9c8d4_contasapp_admin;Password=v@HMFU4YXj#S!E6";
        }
    }
}
