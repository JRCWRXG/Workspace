using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Lendo_arquivo_Texto
{
    public partial class frmLeitura_arquivo : Form
    {
        public frmLeitura_arquivo()
        {
            InitializeComponent();
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            MetodoParaLerLinhaArquivo();
        }

        //private string arquivo;
        private string mensagem;
        List<string> mensagemLinha = new List<string>();

        string arquivo = @"C:\Users\Jrcam\OneDrive\Área de Trabalho\nomes.txt";
        private void MetodoParaLerLinhaArquivo()
        {


            //https://www.devmedia.com.br/criacao-dos-formularios-filhos-sistema-simples-de-uma-biblioteca-parte-2/18050

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                //openFileDialog.Title = "xxxxxxxxxo";
                //openFileDialog.InitialDirectory = @"c:\Program Files"; //Se ja quiser em abrir   em um diretorio especifico
                // openFileDialog.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
                //openFileDialog.FilterIndex = 2;
                //openFileDialog.RestoreDirectory = true;
                //if (openFileDialog.ShowDialog() == DialogResult.OK)
                //    arquivo = openFileDialog.FileName;
                //txtLocal.Text = arquivo;
            }
          
            
            if (String.IsNullOrEmpty(arquivo))
            {
                MessageBox.Show("Arquivo Invalido", "Salvar Como", MessageBoxButtons.OK);
            }
            else
            {
                //    using (StreamReader texto = new StreamReader(arquivo))
                StreamReader texto = new StreamReader(arquivo);

                {
                    while ((mensagem = texto.ReadLine()) != null)
                    {
                        mensagemLinha.Add(mensagem);

                        listBox1.Items.Add(mensagem);
                    }
                }
                int registro = mensagemLinha.Count; //total de linhas do arquivo.
                for (int i = 0; i < mensagemLinha.Count; i++)
                {
                    //TextBox textbox1 = new TextBox();
                    //textbox1.Text += mensagemLinha[i];
                    //File.WriteAllText(arquivo, mensagemLinha[i] + "1");
                }
            }
        }

        private void btnGrava_Click(object sender, EventArgs e)
        {
            string nome = "jose roberto de campos";
            foreach (string item in mensagemLinha)
            {
                listBox2.Items.Add("item adicionado: " + item);

                if (item.Equals("jose roberto de campos"))
                {
                    MessageBox.Show("merda");
                }

                if (item.Contains("jose"))
                {
                    MessageBox.Show("esse cara é bom");
                }
            }
        }
    }
}
