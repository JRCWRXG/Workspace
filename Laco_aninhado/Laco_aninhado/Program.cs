using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laco_aninhado
{

    class Program
    {

        static void Main(string[] args)
        {
            ////////////int alvenaria = 0;
            ////////////int vinil = 1;
            ////////////int fibra = 2;
            ////////////int plastico = 3;

            ////////////double area = 50;
            ////////////int tipo = 0;

            // int tipo = alvenaria;



            Material objmaterial = new Material();

            List<Material> listaMaterial = new List<Material>();

            var loja = new List<Material>();

            var lista = new Material { codigo = 1, nome = "alvenaria", preco = 10 };
            var lista1 = new Material { codigo = 2, nome = "fibra", preco = 20 };
            var lista2 = new Material { codigo = 3, nome = "prego", preco = 30 };
            var lista3 = new Material { codigo = 4, nome = "plastico", preco = 40 };

            listaMaterial.Add(lista);
            listaMaterial.Add(lista1);
            listaMaterial.Add(lista2);
            listaMaterial.Add(lista3);

            int tamanho = 10;


            Console.WriteLine("Lista de preços");
            Console.WriteLine("\n---------------------------------------------------------------");
            Console.WriteLine("Item \t\tPreço \tTamanho \tTotal");
            Console.WriteLine("---------------------------------------------------------------");



            while (tamanho < 60)
            {
                foreach (var item in listaMaterial)
                {

                    Console.WriteLine(item.nome.PadRight(8, ' ') + "\t" + item.preco + "\t" + tamanho + " \t" + objmaterial.Calcular(item.preco, tamanho));


                }
                Console.WriteLine("---------------------------------------------------------------");
                tamanho = tamanho + 10;
            }

            Console.ReadLine();
            //Material objMaterial = new Material();

            //objMaterial.codigo = 1;
            //objMaterial.nome = "Areia";
            //objMaterial.preco = 10;


            //objMaterial.codigo = 2;
            //objMaterial.nome = "cimento";
            //objMaterial.preco = 50;


            //objMaterial.codigo = 3;
            //objMaterial.nome = "prego";
            //objMaterial.preco = 1;



            //produto1.Nome = “Maca”;
            //produto1.Quantidade = 100;


            //////////////Double ValorPiscina(double area1, int material)
            //////////////{

            //////////////    double valor = 0;

            //////////////    switch (material)
            //////////////    {
            //////////////        case 0:
            //////////////            valor = 2000;
            //////////////            break;

            //////////////        case 1:
            //////////////            valor = 3000;
            //////////////            break;

            //////////////        case 2:
            //////////////            valor = 400;
            //////////////            break;

            //////////////        case 3:
            //////////////            valor = 500;
            //////////////            break;

            //////////////        default:
            //////////////            valor = -1;
            //////////////            break;
            //////////////    }

            //////////////    return (area1 * valor);
            //////////////}

            //  Console.WriteLine("material: " + ValorPiscina(3, 5));
            //Console.WriteLine(alvenaria + "\t\t" + ValorPiscina(area, alvenaria));
            //Console.WriteLine(vinil + "\t\t" + ValorPiscina(area, vinil));
            //Console.WriteLine(fibra + "\t\t" + ValorPiscina(area, fibra));
            //Console.WriteLine(plastico + "\t\t" + ValorPiscina(area, plastico));


            //while (tipo <= plastico)
            //{
            //    Console.WriteLine(tipo + "\t\t" + ValorPiscina(area, tipo));
            //    tipo = tipo +1;
            //}


            //while (tipo <= plastico)
            //{
            //    Console.WriteLine(tipo + "\t\t" + ValorPiscina(area, tipo));
            //    tipo = tipo +1;
            //}


            ////////////////    Console.WriteLine("\n---------------------------------------------------------------");
            ////////////////    Console.WriteLine("Area \tCodigo \t\tMaterial \t\tValor");
            ////////////////    Console.WriteLine("---------------------------------------------------------------");

            ////////////////    while (area <= 200)
            ////////////////    {
            ////////////////        //cuidado em tirar essa variavel pois ela nao sendo zerada dá chabu...
            ////////////////        tipo = alvenaria;

            ////////////////        while (tipo <= plastico)
            ////////////////        {
            ////////////////            tipox descricao = (tipox)tipo; //mes = Mes.Dezembro

            ////////////////            // string merda = (area + "\t" + tipo  + "\t\t" + ValorPiscina(area, tipo));

            ////////////////            string valor = Convert.ToDouble(ValorPiscina(area, tipo)).ToString().PadLeft(8, '0');

            ////////////////            string merda = (area + "\t" + tipo + "\t\t" + descricao.ToString().PadRight(12, ' ') + "\t\t" + ValorPiscina(area, tipo));

            ////////////////            Console.WriteLine(merda);

            ////////////////            tipo = tipo + 1;
            ////////////////        }

            ////////////////        Console.WriteLine("\n---------------------------------------------------------------");
            ////////////////        area = area + 50;
            ////////////////    }

            ////////////////    Console.ReadLine();
            ////////////////}


            ////////////////enum tipox
            ////////////////{
            ////////////////    alvenaria = 0,
            ////////////////    vinil = 1,
            ////////////////    fibra = 2,
            ////////////////    plastico = 3
            ////////////////}






        }
    }
}
