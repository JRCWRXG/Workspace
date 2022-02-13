using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.IO;

namespace IN100_INSS
{
    public class Excel
    {

        Desaverbacao objDesaverbacao = new Desaverbacao();
        Config objConfig = new Config();


        public List<Desaverbacao> LerExcel(List<Config> _listaConfig)

        {

            var listaDesaverbar = new List<Desaverbacao>();
            List<Desaverbacao> listaDesaverbacao = new List<Desaverbacao>();


            try
            {
                var xls = new XLWorkbook(_listaConfig[0].Path_origem + _listaConfig[0].Arquivo_origem);

                //  var planilha = xls.Worksheets.First(w => w.Name == "Planilha1");
                var planilha = xls.Worksheet(1);
                var totalLinhas = planilha.Rows().Count() - 1;



                var linha = 2;

                while (true)
                {

                    var lista = new Desaverbacao

                    //listaDesaverbacao.Add(new Desaverbacao()
                    {
                        BNC = int.Parse(planilha.Cell($"A{linha}").Value.ToString()),
                        vazio1 = "",
                        codigo = planilha.Cell($"B{linha}").Value.ToString(),
                        // // nome = planilha.Cell($"C{linha}").Value.ToString(),
                        nome = planilha.Cell("C" + linha.ToString()).Value.ToString(),
                        UF = planilha.Cell($"D{linha}").Value.ToString(),
                        CPF = planilha.Cell("A" + linha.ToString()).Value.ToString().PadLeft(11, '0'),
                        NB = planilha.Cell($"F{linha}").Value.ToString().PadLeft(14, '0'),
                        vazio3 = "",
                        vlr_parcela = string.Format("{0:N}", planilha.Cell($"G{linha}").Value).Replace(",", "").Replace(".", "").PadLeft(7, '0').ToString(),
                        contrato = planilha.Cell($"H{linha}").Value.ToString().PadLeft(9, '0').ToString(),
                        banco = short.Parse(planilha.Cell($"I{linha}").Value.ToString()),
                        retorno = planilha.Cell($"J{linha}").Value.ToString()

                    };

                    listaDesaverbar.Add(lista);




                    if (String.IsNullOrEmpty(lista.CPF)) break;

                    linha++;



                }

                objDesaverbacao.EscrevaArquivo(_listaConfig, listaDesaverbacao);


            }

            catch (Exception ex)
            {

                objConfig.gravarLog(ex.Message.ToString(), _listaConfig);

                Console.WriteLine("          ");
                Console.WriteLine("          ");
                Console.WriteLine("          ");
                Console.WriteLine(" ------------------- Foi detectado falha ------------------------------------------------");
                Console.WriteLine("Erro meu amigo! " + "\r\n " + ex.Message.ToString());
                Console.WriteLine("-------------------------------------------------------------------------");
                //  System.Environment.Exit(1);


            }

            finally
            {
                Console.WriteLine("  finaly        ");
                objDesaverbacao.EscrevaArquivo(_listaConfig, listaDesaverbacao);

            }


            return listaDesaverbacao;


        }

        public List<Desaverbacao> lerPlanilha(List<Config> _listaConfig)
        {

            OleDbConnection connect = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" 
                    + _listaConfig[0].Path_origem 
                    + _listaConfig[0].Arquivo_origem 
                    + "; Extended Properties=Excel 12.0 Xml");


            string strSql = "Select * from [Planilha1$] where cpf <> null;";
            OleDbCommand command = new OleDbCommand(strSql, connect);

            List<Desaverbacao> listaDesaverbacao = new List<Desaverbacao>();

            try
            {
                connect.Open();
                OleDbDataReader rd = command.ExecuteReader();

                while (rd.Read())
                {
                    listaDesaverbacao.Add(new Desaverbacao()
                    {
                        BNC = Convert.ToInt32(rd["BNC"]),
                        codigo = rd["codigo"].ToString(),
                        nome = rd["nome"].ToString(),
                        UF = rd["uf"].ToString(),
                        CPF = rd["cpf"].ToString().PadLeft(11, '0'),
                        NB = rd["nb"].ToString().PadLeft(14, '0'),
                        vlr_parcela = string.Format("{0:N}", rd["vlr_parcela"].ToString().Replace(",", "").Replace(".", "").PadLeft(7, '0').ToString()),
                        contrato = rd["contrato"].ToString().PadLeft(9, '0'),
                        banco = Convert.ToInt32(rd["BNC"]),
                        retorno = rd["retorno"].ToString(),

                    });
                }

                objDesaverbacao.EscrevaArquivo(_listaConfig, listaDesaverbacao);



            }
            catch (Exception ex)
            {

                objConfig.gravarLog(ex.Message.ToString(), _listaConfig);

                Console.WriteLine("          ");
                Console.WriteLine("          ");
                Console.WriteLine("          ");
                Console.WriteLine(" ------------------- Foi detectado falha ------------------------------------------------");
                Console.WriteLine("Erro meu amigo! " + "\r\n " + ex.Message.ToString());
                Console.WriteLine("-----------------------------------------------------------------------------------------");
                Console.ReadLine();
            }

            finally
            {

                connect.Close();
                connect.Dispose();
            }

            return listaDesaverbacao;
        }

        public IList<Desaverbacao> lerCsv(List<Config> _listaConfig)
        {
            List<Desaverbacao> listaDesaverbacao = new List<Desaverbacao>();
            string linha = "";
            string[] linhaseparada = null;

            StreamReader reader = new StreamReader(@"C:\Users\Jrcam\source\rtlibCSV.csv", Encoding.UTF8, true);


            try
            {
                //string Header = reader.ReadLine();
                bool isFirst = true;

                while (!reader.EndOfStream)
                {

                    if (isFirst)
                    {
                        linha = reader.ReadLine();
                        isFirst = false;
                        continue;
                    }

                    linha = reader.ReadLine();
                    if (linha == null) break;
                    linhaseparada = linha.Split(';');


                    //string resultado = string.Format(
                    //@"Linha - 
                    //    Campo 1: {0}
                    //    Campo 2: {1}
                    //    Campo 3: {2}
                    //    Campo 4: {3}
                    //    Campo 5: {4}", linhaseparada[0], linhaseparada[1], linhaseparada[2], linhaseparada[3], linhaseparada[4]);


                    listaDesaverbacao.Add(new Desaverbacao()
                    {
                        BNC = Convert.ToInt32(linhaseparada[0].ToString()),
                        codigo = linhaseparada[1].ToString(),
                        nome = linhaseparada[2].ToString(),
                        UF = linhaseparada[3].ToString(),
                        CPF = linhaseparada[4].ToString().PadLeft(11, '0'),
                        NB = linhaseparada[5].ToString(),
                        vlr_parcela = string.Format("{0:N}", linhaseparada[6].ToString().Replace(",", "").Replace(".", "").PadLeft(7, '0').ToString()),
                        contrato = linhaseparada[7].ToString().PadLeft(9, '0'),
                        banco = Convert.ToInt32(linhaseparada[8].ToString()),
                        retorno = linhaseparada[9].ToString(),

                    });

                }

                objDesaverbacao.EscrevaArquivo(_listaConfig, listaDesaverbacao);

            }
            catch (Exception ex)
            {

                throw ex;
            }

            reader.Close();
            reader.Dispose();
            return listaDesaverbacao;
        }



        public IList<Desaverbacao> lerCsv2(List<Config> _listaConfig)
        {
            var reader = new StreamReader(File.OpenRead(@"C:\Users\Jrcam\source\rtlibCSV.csv"));

            List<Desaverbacao> listaDesaverbacao = new List<Desaverbacao>();

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');

                //listA.Add(values[0]);
                //listB.Add(values[1]);
                //foreach (var coloumn1 in listA)
                //{
                //    Console.WriteLine(coloumn1);
                //}
                //foreach (var coloumn2 in listA)
                //{
                //    Console.WriteLine(coloumn2);
                //}
            }

            reader.Close();
            return listaDesaverbacao;

        }
    }
}
