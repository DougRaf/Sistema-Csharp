using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;
using MySql.Data.MySqlClient;

namespace bibliotecaControle
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void clean(Control controles)
        {
            nome.Text = String.Empty;
            sobrenome.Text = String.Empty;
            cpf.Text = String.Empty;
            email.Text = String.Empty;
            celular.Text = String.Empty;
            telefone.Text = String.Empty;
            senha.Text = String.Empty;
            confirmacao.Text = String.Empty;

        }

    
        private void button2_Click(object sender, EventArgs e)
        {
            if (nome.Text == "" || sobrenome.Text == "" || cpf.Text == "" || email.Text == "" || celular.Text == "" || telefone.Text == "" || senha.Text == "" || confirmacao.Text == "")
            {
                MessageBox.Show("Favor preencher todos os campos", "mensagem do sistema");
                return;
            }
            else if (senha.Text != confirmacao.Text)
            {
                MessageBox.Show("As senhas são diferentes", "mensagem do sistema");
                return;
            }
            else if (senha.Text.Length > 8)
            {
                MessageBox.Show("limite de caracteres 8 digitos", "mensagem do sistema");
                return;
            }
            else if (senha.Text.Length < 8)
            {
                MessageBox.Show("limite de caracteres 8 digitos", "mensagem do sistema");
                return;
            }
            string configuracao = "server= opmy0013.servidorwebfacil.com ; Port = 3306 ; Database = desquinela_sqlserver ; uid = desqu_douglas ; password = motoka33 ;";
           MySqlConnection Conexao = new MySqlConnection(configuracao);

            try
            {
                Conexao.Open();
                MySqlCommand comando = new MySqlCommand
              ("INSERT INTO `senhas` (`nome`,`sobrenome`, `cpf`, `email`, `senha`, `celular`, `telefone`)" +
            "VALUES ('" + nome.Text + "','" + sobrenome.Text + "','" + cpf.Text + "','" + email.Text + "','" + senha.Text + "','" + celular.Text + "','" + telefone.Text + "')", Conexao);
                comando.ExecuteNonQuery();
                MessageBox.Show("conta regisrada com sucesso", "conta registrada");
                this.Close();

            }

            catch (MySqlException )
            {
                MessageBox.Show("Erro banco de dados",  "Erro do banco de dados");
                return;
            }
        }


       private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;

        }

        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {

            this.Cursor = Cursors.Hand;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
           clean(this);
            return;
          
        }

        private void MainForm_KeyUP(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);

            }


        }


    }
}
