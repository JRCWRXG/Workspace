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
        Util objUtil = new Util();
        public frmLeitura_arquivo()
        {
            InitializeComponent();

        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            MetodoParaLerLinhaArquivo();
        }

        private string arquivo;
        List<string> mensagemLinha = new List<string>();


        private void MetodoParaLerLinhaArquivo()
        {
            try

            {
                arquivo = objUtil.Open_FileDialog();

                if (String.IsNullOrEmpty(arquivo))
                {
                    MessageBox.Show("Arquivo Invalido", "Salvar Como", MessageBoxButtons.OK);
                }
                else
                {
                    mensagemLinha = objUtil.Reader(arquivo);

                    foreach (var item in mensagemLinha)
                    {
                        listBox1.Items.Add(item);

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
            catch (Exception ex)
            {

                MessageBox.Show("Meu amigo algo deu errado! ", ex.Message);
            }
        }

    }
}
