using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IN100_INSS
{
    class Program
    {
        static void Main(string[] args)
        {

            Excel objExcel = new Excel();
            Config objConfig = new Config();

            List<Config> configuracao = new List<Config>();

            //chama appsetings
            configuracao = objConfig.listaDeConfiguracao();
                       
            try
            {

                Console.Clear();
                Console.Title = "Conversor - IN100";
              //  Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetWindowSize(80, 30);
                
                //altura
                //Console.WindowHeight 
                
                //largura 
                //Console.WindowWidth
               

                Console.WriteLine("-----------------------------------------------------------------------------");
                Console.WriteLine(string.Format($"  INICIO - " + Convert.ToString(DateTime.Now)));
                Console.WriteLine("-----------------------------------------------------------------------------");
               
                Console.WriteLine(string.Format($"\n\n\t\t CONFIGURAÇÃO CONVERSOR ARQUIVO:"));
                Console.WriteLine("-----------------------------------------------------------------------------");
                Console.WriteLine(string.Format($"\t\t Arquivo Origem: {configuracao[0].Arquivo_origem}"));
                Console.WriteLine(string.Format($"\t\t Pasta Origem: - {configuracao[0].Path_origem}"));
                Console.WriteLine(string.Format($"\t\t Pasta Destino:  - {configuracao[0].Path_destino}"));



              //  objExcel.lerCsv(configuracao);

                //Metodo para ler planilha
                objExcel.lerPlanilha(configuracao);
                //objExcel.LerExcel(configuracao);

            }
            catch (Exception ex)
            {


                objConfig.gravarLog(ex.Message.ToString(), configuracao);

                Console.WriteLine("\n\n\n ------------------- Foi detectado falha ------------------------------------------------");
                Console.WriteLine("Erro meu amigo! " + "\r\n " + ex.Message.ToString());
                Console.WriteLine("-----------------------------------------------------------------------------------------------");
                Console.ReadLine();
            }
        }

    }
}
