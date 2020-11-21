using System;

namespace Calculadora
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Digite um numero ");
            int tabuada = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Calculadora a tabudada: " + tabuada);
           
            
            //Console.WriteLine("-------------------------------------");

            //for (int i = 1; i <= 10; i++)
            //{
               
              

            //    Console.WriteLine(tabuada + " * " + i + " = " + tabuada * i);
            


            //}

            //Console.WriteLine("-------------------------------------");



            int i = 1;
            while (i <= 10)
            {
                Console.WriteLine(tabuada + " * " + i + " = " + tabuada * i);
                i++;
            }



            Console.ReadLine();


        }
    }
}
