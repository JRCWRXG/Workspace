using System;

namespace Nota_Aluno
{
    class Program
    {
        static void Main(string[] args)
        {
            //comentario
           
            Console.WriteLine("Digite a nota do primeiiro bimestre!");
            int nota_1 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Digite a nota do segundo bimestre!");
            int nota_2 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Digite a nota do terceiro bimestre!");
            int nota_3 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Digite a nota do quarto bimestre!");
            int nota_4 = Convert.ToInt32(Console.ReadLine());

            double media = (nota_1 + nota_2 + nota_3 + nota_4) / 4;

            Console.WriteLine("Aguarde calculando as médias...");
            Console.ReadKey();

            Console.WriteLine(" ");
            Console.WriteLine("***************************************************************");

            if (media >= 7)
            {
                Console.WriteLine("Parabens aluno! Aprovado!");

            }

            else if (media >= 6 && media < 7)
            {
                Console.WriteLine("Parabens aluno! Aprovado!");
            }

            else
            {
                Console.WriteLine("Aluno estude um pouco mais! Reprovado!");
            }

            int teste = int.Parse("8");

            

            Console.WriteLine(" ");
            Console.WriteLine("***************************************************************");
            Console.WriteLine("Sua média foi: " + Convert.ToString(media));
            Console.ReadKey();

        }
    }
}
