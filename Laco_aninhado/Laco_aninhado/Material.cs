using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laco_aninhado
{
    public class Material
    {
        public int codigo;
        public string nome;
        public double preco;




        public double Calcular(double valor, int area)
        {

            return (valor * area);
        }




    }

}
