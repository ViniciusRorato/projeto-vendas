

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using MySql.Data.MySqlClient;

namespace projeto_vendas.conexao
{
    public class ConnectionFactory
    {
        //Metodo que conecta o banco de dados
        public MySqlConnection GetConnection()
        {
            string conexao = ConfigurationManager.ConnectionStrings["bdvendas"].ConnectionString;
            
            return new MySqlConnection(conexao);
        }
    }
}
