using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distribuicao_Atendimento.DAL
{
    public class Conexao
    {
        public static string StringDeConexao

        {
            get

            {
                return @"Data Source=.\SQLEXPRESS;Initial Catalog=OBZE;Integrated Security=True";
            }
        }
    }
}

