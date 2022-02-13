using FileHelpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IN100_INSS
{
    [FixedLengthRecord(FixedMode.ExactLength)]


    public class Desaverbacao

    {
       


        [FieldFixedLength(3)]
        [FieldOrder(1)]
        public int BNC { get; set; }

        [FieldFixedLength(10)]
        [FieldOrder(2)]
        public string vazio1;


        [FieldFixedLength(2)]
        [FieldOrder(3)]
        public string codigo { get; set; }


        //[FieldFixedLength(10)]
        //[FieldConverter(ConverterKind.Date, "ddMMyyyy")] // Outros formatos de data são possíveis. Ex: "DD/MM/AAAA", "ddMMyyyyHHmmss", etc.
        //public DateTime dataInclusao;

        [FieldFixedLength(30)]
        [FieldOrder(4)]
        public string nome { get; set; }


        [FieldFixedLength(2)]
        [FieldOrder(5)]
        public string UF { get; set; }


        [FieldFixedLength(4)]
        [FieldOrder(6)]
        public string vazio2 { get; set; }



        [FieldFixedLength(11)]
        [FieldOrder(7)]
        public string CPF { get; set; }



        [FieldFixedLength(14)]
        [FieldOrder(8)]
        public string NB { get; set; }



        [FieldFixedLength(69)]
        [FieldOrder(9)]
        public string vazio3 { get; set; }



        [FieldFixedLength(7)]
        [FieldOrder(10)]
        public string vlr_parcela { get; set; }



        [FieldFixedLength(11)]
        [FieldOrder(11)]
        public string vazio4;



        [FieldFixedLength(9)]
        [FieldOrder(12)]
        public string contrato { get; set; }



        [FieldFixedLength(49)]
        [FieldOrder(13)]
        public string vazio5;

        [FieldFixedLength(3)]
        [FieldOrder(14)]
        public int banco { get; set; }

        [FieldFixedLength(7)]
        [FieldOrder(15)]
        public string vazio6;

        [FieldFixedLength(2)]
        [FieldOrder(16)]
        public string retorno { get; set; }



        public void EscrevaArquivo(List<Config> _listaConfig, List<Desaverbacao> registros)
        {

            Config objConfig = new Config();

            try

            {   
                if (!objConfig.moverArquivo(_listaConfig) == false)

                {

                    FileHelperEngine engine = new FileHelperEngine(typeof(Desaverbacao));
                    int totalRegistros = registros.Count();


                    List<Desaverbacao>GerarLote = new List<Desaverbacao>();
                  
                    int total = 0;
                    int sequencial = 1;
                                       
                    foreach (var item in registros)
                    {
                        GerarLote.Add(new Desaverbacao()
                        {

                            nome = item.nome,
                            CPF = item.CPF,
                            vlr_parcela = item.vlr_parcela,
                            BNC = item.BNC


                        }); ;

                        totalRegistros = totalRegistros - 1;

                        if (totalRegistros == 0)
                        {
                            engine.WriteFile(_listaConfig[0].Path_destino + _listaConfig[0].Arquivo_destino + "-" + sequencial + ".txt", GerarLote);
                            continue;
                        }




                        if (total == _listaConfig[0].Total_Lote)
                        {  
                            engine.WriteFile(_listaConfig[0].Path_destino + _listaConfig[0].Arquivo_destino + "-" + sequencial + ".txt", GerarLote);

                            total = 0;
                            sequencial++;
                            GerarLote.Clear();
                            continue;
                        }

                        total++;
                    }



                    engine.WriteFile(_listaConfig[0].Path_destino + _listaConfig[0].Arquivo_destino, registros);
                    objConfig.gravarLog(totalRegistros, _listaConfig);

                    Console.WriteLine("\n\n\n-----------------------------------------------------------------------------");
                    Console.WriteLine(string.Format($"  PROCESSAMENTO"));
                    Console.WriteLine("-----------------------------------------------------------------------------");
                    Console.WriteLine("                 Conversão executada com sucesso!    ");
                    Console.WriteLine("                 [ " + string.Join("", registros.Count()) 
                        + " ] - Registro(s) inserido(s) no arquivo - " 
                        + _listaConfig[0].Arquivo_destino);
                    Console.WriteLine("\n\n\n-----------------------------------------------------------------------------");
                    Console.WriteLine(string.Format($"  TERMINO - " + Convert.ToString(DateTime.Now)));
                    Console.WriteLine("-----------------------------------------------------------------------------");
                    Console.WriteLine("\t\t\t\n\n\n  *** Aperte qualquer tecla para encerrar! ***    ");

                    //  Console.ReadLine();
                    Console.ReadKey();
                }

                else
                {
                    throw new Exception(_listaConfig[0].Path_origem + " pasta não encontrada!");
                }

            }
            catch (Exception ex)
            {
                objConfig.gravarLog(ex.Message.ToString() + " - " + ex.StackTrace, _listaConfig);

                Console.WriteLine(" \n\n\n------------------- Foi detectado falha ------------------------------------------------");
                Console.WriteLine("Erro meu amigo! " + "\r\n " + ex.Message.ToString());
                Console.WriteLine("-----------------------------------------------------------------------------------------");
                Console.ReadLine();
            }
        }
    }
}

