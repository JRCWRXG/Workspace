using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lendo_arquivo_Texto
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void lerArquivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLeitura_arquivo frmFilho = new frmLeitura_arquivo();
            frmFilho.MdiParent = this;
            frmFilho.Show();
        }
    }
}
