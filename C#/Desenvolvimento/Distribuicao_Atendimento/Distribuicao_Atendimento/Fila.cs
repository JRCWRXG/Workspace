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
    [Table("Fila")]
    public class Fila
    {
        Atendente objAtendente = new Atendente();
        public FilaContext context = new FilaContext();

       


        public DateTime entrada { get; set; }
        public DateTime saida { get; set; }
        public int prioridade { get; set; }
        public string descricao_prioridade { get; set; }
        public string senha { get; set; }
        public int status_atendimento { get; set; }
        public string descricao_status_atendimento { get; set; }
        public string cliente { get; set; }
        public int id { get; set; }

        public int id_atendente { get; set; }
        public int status_atendente { get; set; }

        public string nome { get; set; }

        public void merda()
        {

            var consulta = from c in context.Filas
                           orderby c.id
                           select new
                           {
                               c.id
                           };

        }
        public Fila()
        {
            
                           
        }
        public Fila(int idAtendimento, int idAtendente)
        {
            this.id = idAtendimento;
            this.id_atendente = idAtendente;
        }

        public void StatusDaFila(List<Fila> lista)
        {
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("\t\t\t\tLISTA DA FILA DE ATENDIMENTO");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("\nEntrada \t\t\tcliente \t\t\tSenha \t\t\tPrioridade \t\tStatus");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------");

            for (int i = 0; i <= lista.Count - 1; i++)
            {
                Console.WriteLine(String.Format("{0} \t\t{1} \t{2} \t{3} \t{4} ", lista[i].entrada, lista[i].cliente.ToString().PadRight(25, ' '), lista[i].senha, lista[i].descricao_prioridade.ToString().PadRight(20, ' '), lista[i].descricao_status_atendimento));
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------");
            }
            Console.ReadLine();
        }

        public void TratarFila(string connectionString)
        {
            StringBuilder strSQL = new StringBuilder();

            strSQL.Append("select id ");
            strSQL.Append(", entrada ");
            strSQL.Append(", prioridade ");
            strSQL.Append(",status_atendimento ");
            strSQL.Append(", cliente ");
            strSQL.Append("from tb_atendimento ");
            strSQL.Append("where status_atendimento = 1 ");
            strSQL.Append("order by prioridade, entrada ");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(strSQL.ToString(), connection);

                List<Fila> ListaDaFila = new List<Fila>();
                List<Fila> listaAtendente = new List<Fila>();

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ListaDaFila.Add(new Fila()
                    {
                        id_atendente = Convert.ToInt32(reader["id"]),
                        entrada = Convert.ToDateTime(reader["entrada"]),
                        prioridade = Convert.ToInt32(reader["prioridade"]),
                        status_atendimento = Convert.ToInt32(reader["status_atendimento"]),
                        cliente = reader["cliente"].ToString()
                    });

                    listaAtendente = AtendenteDisponivel();

                    if (listaAtendente.Count() != 0)
                    {
                        foreach (var item in listaAtendente)
                        {
                            // atualizarFila(item.id_atendente, Convert.ToInt32(reader["id"].ToString()), connectionString);

                            id_atendente = item.id_atendente;
                            id = Convert.ToInt32(reader["id"].ToString());

                            DALConexao cx = new DALConexao(Conexao.StringDeConexao);
                            DALCategoria bll = new DALCategoria(cx);
                            Fila objFila = new Fila(id, id_atendente);
                            bll.Alterar(objFila);
                        }
                    }

                    else
                    {
                        Console.WriteLine("sem atendente no momento!");
                        //continue;
                        break;
                    }
                }

                reader.Close();
              //  Console.ReadLine();
            }
        }

        public void ConsultaGeralAtendimento()
        {
            StringBuilder strSQL = new StringBuilder();
            List<Fila> Listavai = new List<Fila>();

            strSQL.Append("SELECT  a.id ");
            strSQL.Append(",a.entrada ");
            strSQL.Append(",a.saida ");
            strSQL.Append(",a.prioridade ");
            strSQL.Append(",c.descricao ");
            strSQL.Append(",a.senha ");
            strSQL.Append(",a.status_atendimento ");
            strSQL.Append(",b.descricao as descricao_status ");
            strSQL.Append(",a.cliente ");
            strSQL.Append("FROM tb_atendimento as a ");
            strSQL.Append("INNER JOIN tb_status_atendimento as b ");
            strSQL.Append("ON a.status_atendimento = b.id_status ");
            strSQL.Append("INNER JOIN tb_prioridade as c ");
            strSQL.Append("on c.prioridade = a.prioridade");

            DALConexao cx = new DALConexao(Conexao.StringDeConexao);
            DALCategoria bll = new DALCategoria(cx);

            Listavai = bll.ListarFilaGeral(strSQL.ToString());

            StatusDaFila(Listavai);
        }



        public List<Fila> AtendenteDisponivel()
        {
           
            StringBuilder strSQL = new StringBuilder();
            List<Fila> ListaAtendenteDisponivel = new List<Fila>();

            strSQL.Append("select top 1");
            strSQL.Append(" id_atendente");
            strSQL.Append(", nome ");
            strSQL.Append(", status_atendente ");
            strSQL.Append("from tb_atendente ");
            strSQL.Append("where status_atendente = 2 ");

            DALConexao cx = new DALConexao(Conexao.StringDeConexao);
            DALCategoria bll = new DALCategoria(cx);

            ListaAtendenteDisponivel = bll.AtendenteDisponivel(strSQL.ToString());
         
            return ListaAtendenteDisponivel;
        }

    }
}
