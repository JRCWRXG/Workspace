using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Distribuicao_Atendimento.DAL;
using System.Threading;

namespace Distribuicao_Atendimento
{
    public class Program
    {

        static void Main(string[] args)
        {
            FilaContext context = new FilaContext();
            Atendente objAtendente = new Atendente();
            Fila objFila = new Fila();


            string strConnection = "Data Source=.\\SQLExpress; Initial Catalog=OBZE; Integrated Security=True";
            int menu = 0;





            for (int i = 0; i < 500; i++)
            {
                Console.WriteLine("Nova atualização a cada 20 segundos.");
                objFila.TratarFila(strConnection);
                Thread.Sleep(20000);
            }

            Console.WriteLine("Final do processo da fila, por hj as atividades foram encerradas.");



            ////////////Console.ForegroundColor = ConsoleColor.Red;

            ////////////Console.Write("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒ CONTROL-BOOK 2013 ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
            ////////////Console.ForegroundColor = ConsoleColor.White;
            ////////////Console.WriteLine("");

            ////////////Console.WriteLine("");

            ////////////Console.WriteLine("");

            ////////////Console.WriteLine("╔═════════════════MENU DE OPÇÕES════════════════╗    ");

            ////////////Console.WriteLine("║ 0 LISTA STATUS ATENDENTE                      ║    ");

            ////////////Console.WriteLine("║                                               ║    ");

            ////////////Console.WriteLine("║ 1 LISTAR A FILA                               ║    ");

            ////////////Console.WriteLine("║                                               ║    ");

            ////////////Console.WriteLine("║ 2 FILA                                        ║    ");

            ////////////Console.WriteLine("║                                               ║    ");

            ////////////Console.WriteLine("║ 3 EM MANUTENÇÃO...                            ║    ");

            ////////////Console.WriteLine("║                                               ║    ");

            ////////////Console.WriteLine("║ 4 EM MANUTENÇÃO...                            ║    ");

            ////////////Console.WriteLine("║                                               ║    ");

            ////////////Console.WriteLine("║ 5 SAIR                                        ║    ");

            ////////////Console.WriteLine("╚═══════════════════════════════════════════════╝    ");

            ////////////Console.WriteLine(" ");


            ////////////Console.Write("DIGITE UMA OPÇÃO : ");


            //////////////============================MENU DE ATENDIMENTO==============================================
            ////////////menu = Convert.ToInt32(Console.ReadLine());


            ////////////switch (menu)
            ////////////{
            ////////////    case 0:
            ////////////        objAtendente.ListarStatusAtendente();
            ////////////        Console.ReadLine();
            ////////////        break;
            ////////////    case 1:
            ////////////        objFila.ConsultaGeralAtendimento();
            ////////////        break;

            ////////////    case 2:
            ////////////        objFila.TratarFila(strConnection);
            ////////////        break;

            ////////////    case 3:
            ////////////        Console.WriteLine("a implementar");
            ////////////        break;

            ////////////    default:
            ////////////        Console.WriteLine("a implementar");
            ////////////        break;
            ////////////}

        }
    }
}

