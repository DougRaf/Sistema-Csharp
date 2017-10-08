using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bibliotecaControle
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
         try
           {
            this.cursoTableAdapter.Fill(this.desquinela_sqlserverDataSet.curso);
            this.reportViewer1.RefreshReport();
           }
              catch (Exception )
           {
                MessageBox.Show("Erro banco de dados",  "Erro do banco de dados");
                this.Close();
           }
                   
        }
    }
}
