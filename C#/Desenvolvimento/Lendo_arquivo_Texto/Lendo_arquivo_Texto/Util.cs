using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lendo_arquivo_Texto
{
    public class Util
    {
        public string arquivo;
        public string Open_FileDialog()
        {
            try
            {

                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Title = "Lukas Kraft";
                    openFileDialog.InitialDirectory = @"C:\Users\Jrcam\OneDrive\Área de Trabalho\"; //Se ja quiser em abrir   em um diretorio especifico
                    openFileDialog.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
                    openFileDialog.FilterIndex = 2;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        arquivo = openFileDialog.FileName;
                    }

                    return arquivo;
                }

            }
            catch (Exception ex)
            {

                throw ex; 
            }

        }
        public List<string> Reader(string filePath)
        {

            try
            {
                string mensagem;
                List<string> mensagemLinha = new List<string>();

                StreamReader reader = new StreamReader(arquivo);

                {
                    while ((mensagem = reader.ReadLine()) != null)
                    {
                        mensagemLinha.Add(mensagem);
                    }

                    string teste = "";
                    int merda = 10 / Convert.ToInt32(teste);


                }

                reader.Close();

                return mensagemLinha;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
    }
}
