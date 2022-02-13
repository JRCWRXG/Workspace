using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distribuicao_Atendimento.DAL
{
    public class DALCategoria
    {
        private DALConexao conexao;
        SqlTransaction transaction;

        public DALCategoria(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(Fila fila)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "insert into categoria(cat_nome) values (@nome); select @@IDENTITY;";
            cmd.Parameters.AddWithValue("@nome", fila.id_atendente);
            conexao.Conectar();
            fila.id_atendente = Convert.ToInt32(cmd.ExecuteScalar());
            conexao.Desconectar();
        }

        public void Alterar(Fila fila)
        {

            try
            {
                StringBuilder strSQL = new StringBuilder();
                StringBuilder strSQL1 = new StringBuilder();

                strSQL.Append("update tb_atendente ");
                strSQL.Append("set status_atendente = 3 ");
                strSQL.Append("where id_atendente = " + "'" + fila.id_atendente + "'");

                strSQL1.Append("update tb_atendimento ");
                strSQL1.Append("set status_atendimento = 2 , id_atendente = " + "'" + fila.id_atendente + "'");
                strSQL1.Append(" where id = " + "'" + fila.id + "'");

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSQL.ToString();

                //   cmd.Parameters.AddWithValue("@nome", fila.CatNome);
                //  cmd.Parameters.AddWithValue("@codigo", fila.id_atendente);

                SqlCommand cmd1 = new SqlCommand();
                cmd1.Connection = conexao.ObjetoConexao;
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = strSQL1.ToString();

                conexao.Conectar();

                transaction = conexao.ObjetoConexao.BeginTransaction();

                cmd.Transaction = transaction;
                cmd.ExecuteNonQuery();

                cmd1.Transaction = transaction;
                cmd1.ExecuteNonQuery();

                transaction.Commit();

                Console.WriteLine("Atendimento ID " + fila.id + " segue para atendimento");

            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }

            finally
            {
                conexao.Desconectar();
            }
        }

        public List<Fila> ListarFilaGeral(string strSql)
        {
            SqlCommand cmd = new SqlCommand(strSql);
            cmd.Connection = conexao.ObjetoConexao;

            conexao.Conectar();

            List<Fila> ListaDaFila = new List<Fila>();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ListaDaFila.Add(new Fila()
                {
                    entrada = Convert.ToDateTime(reader["entrada"]),
                    // saida = Convert.ToDateTime(reader["saida"]),
                    prioridade = Convert.ToInt32(reader["prioridade"]),
                    descricao_prioridade = reader["descricao"].ToString(),
                    status_atendimento = Convert.ToInt32(reader["status_atendimento"]),
                    descricao_status_atendimento = reader["descricao_status"].ToString(),
                    senha = reader["senha"].ToString(),
                    cliente = reader["cliente"].ToString()

                });
            }

            reader.Close();
            return ListaDaFila;
        }







        public List<Atendente> ListarStatusAtendente(string strSql)
        {
            SqlCommand cmd = new SqlCommand(strSql);
            cmd.Connection = conexao.ObjetoConexao;

            conexao.Conectar();
                     
            List<Atendente> ListaAtendente = new List<Atendente>();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ListaAtendente.Add(new Atendente()
                {
                    descricao = reader["descricao"].ToString(),
                    id_atendente = Convert.ToInt32(reader["id_atendente"]),
                    id_status = Convert.ToInt32(reader["status_atendente"]),
                    nome = reader["nome"].ToString()
                });
            }

            reader.Close();
          
            return ListaAtendente;
        }







        public List<Fila> StatusAtendente(string strSql)
        {
            List<Fila> ListaDaFila = new List<Fila>();

            SqlCommand cmd = new SqlCommand(strSql);
            cmd.Connection = conexao.ObjetoConexao;
            conexao.Conectar();

            SqlDataReader rd = cmd.ExecuteReader();

            // bool verdade = Convert.ToBoolean(rd.HasRows.ToString());
            //rda = reader.HasRows.ToString();

            while (rd.Read())
            {
                ListaDaFila.Add(new Fila()
                {
                    id_atendente = Convert.ToInt32(rd["id_atendente"]),
                    status_atendente = Convert.ToInt32(rd["status_atendente"]),
                    nome = rd["nome"].ToString()

                });
            }

            rd.Close();
            Console.ReadLine();

            return ListaDaFila;
        }



        public List<Fila> AtendenteDisponivel(string strSQL)
        {
            List<Fila> ListaAtendenteDisponivel = new List<Fila>();

            SqlCommand cmd = new SqlCommand(strSQL);
            cmd.Connection = conexao.ObjetoConexao;
            conexao.Conectar();

            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                ListaAtendenteDisponivel.Add(new Fila()
                {
                    id_atendente = Convert.ToInt32(rd["id_atendente"]),
                    status_atendente = Convert.ToInt32(rd["status_atendente"]),
                    nome = rd["nome"].ToString()

                });
            }

            rd.Close();
           
            return ListaAtendenteDisponivel;
        }




        //public DataTable Localizar(String valor)
        //{
        //    DataTable tabela = new DataTable();
        //    SqlDataAdapter da = new SqlDataAdapter("Select * from categoria where cat_nome like '%" +
        //        valor + "%'", conexao.StringConexao);
        //    da.Fill(tabela);
        //    return tabela;
        //}

        //public ModeloCategoria CarregaModeloCategoria(int codigo)
        //{
        //    ModeloCategoria modelo = new ModeloCategoria();
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.Connection = conexao.ObjetoConexao;
        //    cmd.CommandText = "select * from categoria where cat_cod = @codigo";
        //    cmd.Parameters.AddWithValue("@codigo", codigo);
        //    conexao.Conectar();
        //    SqlDataReader registro = cmd.ExecuteReader();
        //    if (registro.HasRows)
        //    {
        //        registro.Read();
        //        modelo.CatCod = Convert.ToInt32(registro["cat_cod"]);
        //        modelo.CatNome = Convert.ToString(registro["cat_nome"]);
        //    }
        //    conexao.Desconectar();
        //    return modelo;
        //}
    }
}
