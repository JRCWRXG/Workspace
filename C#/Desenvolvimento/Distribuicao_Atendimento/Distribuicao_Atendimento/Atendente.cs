using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations.Schema;
using Distribuicao_Atendimento.DAL;

namespace Distribuicao_Atendimento
{
    [Table("Atendente")]
    public class Atendente
    {
        public string nome { get; set; }
        public int id_atendente { get; set; }
        public int id_status { get; set; }

        public string descricao { get; set; }

        public void ListarStatusAtendente()
        {
            StringBuilder strSQL = new StringBuilder();

            strSQL.Append("SELECT  a.id_atendente ");
            strSQL.Append(",a.nome ");
            strSQL.Append(",a.status_atendente ");
            strSQL.Append(",b.descricao ");
            strSQL.Append("FROM tb_atendente as a ");
            strSQL.Append("INNER JOIN tb_status_atendente as b ");
            strSQL.Append("on a.status_atendente = b.id_status;");

            DALConexao cx = new DALConexao(Conexao.StringDeConexao);
            DALCategoria bll = new DALCategoria(cx);
            List<Atendente> ListaAtendente = new List<Atendente>();

            ListaAtendente = bll.ListarStatusAtendente(strSQL.ToString());
            StatusDoAtende(ListaAtendente);

        }

        public void StatusDoAtende(List<Atendente> lista)
        {
            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.WriteLine("\t\t\tLISTA(S) DE ATENDENTE(S)");
            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.WriteLine("\nAtendente \t\tid_Atendente, \tDescrição, \tid_Status");
            Console.WriteLine("-----------------------------------------------------------------------------");

            for (int i = 0; i <= lista.Count - 1; i++)
            {
                Console.WriteLine(String.Format("{0} \t{1} \t{2} \t{3}", lista[i].nome.ToString().PadRight(25, ' '), lista[i].id_atendente, lista[i].descricao, lista[i].id_status));
                Console.WriteLine("-----------------------------------------------------------------------------");
               
            }
        }

    }
}
