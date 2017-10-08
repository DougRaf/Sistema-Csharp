using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace bibliotecaControle
{
    public partial class DGSSISTEMAS : Form
    {
        public DGSSISTEMAS()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3 tela2 = new Form3();
            tela2.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string usu = textBox1.Text;
            string pwd = textBox2.Text;


            if (usu == "" && pwd == "")
            {
                MessageBox.Show("campos em branco", "mensagem do sistema");
                return;
            }
            else if (usu == "")
            {
                MessageBox.Show("usuario em branco", "mensagem do sistema");
                return;
            }
            else if (pwd == "")
            {
                MessageBox.Show("senha em branco", "mensagem do sistema");
                return;
            }
            else if (pwd.Length > 8)
            {
                MessageBox.Show("você exedeu o limite", "mensagem do sistema");
                return;
            }
            else if (pwd.Length < 8)
            {
                MessageBox.Show("limite inferior de dados", "mensagem do sistema");
                return;
            }
            else if (pwd == "12345678" && usu == "douglas")
            {
                this.Hide();
                Form4 tela2 = new Form4();
                tela2.ShowDialog();
            }

            string configuracao = "server= opmy0013.servidorwebfacil.com ; Port = 3306 ;" +
           "Database = desquinela_sqlserver ; uid = desqu_douglas ; password = motoka33 ;";

            MySqlConnection Conexao = new MySqlConnection(configuracao);
            string userConectado;

            try
            {
                this.Cursor = Cursors.WaitCursor;
                string _Sql = "SELECT `id_cod` FROM `senhas` WHERE `nome` = @nome AND senha = @senha ";

                MySqlCommand cmd = new MySqlCommand(_Sql, Conexao);

                cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = usu;
                cmd.Parameters.Add("@senha", MySqlDbType.VarChar).Value = pwd;

                Conexao.Open();

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                    this.Hide();
                    userConectado = usu;
                    Form4 tela2 = new Form4();
                    tela2.ShowDialog();
                    this.Cursor = Cursors.Default;
                }
                else
                {
                    MessageBox.Show("Problema com os dados inseridos", "mensagem do sistema");
                    this.Cursor = Cursors.Default;
                    return;
                }

            }
            catch (MySqlException)
            {
                MessageBox.Show("Problema com o Banco de dados", "mensagem do sistema");
                this.Cursor = Cursors.Default;
                return;
            }
            Conexao.Close();
        }
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            String target = "http://www.dgssistemas.net";
            System.Diagnostics.Process.Start(target);

        }

        private void button2_Click(object sender, EventArgs e)
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

        private void MainForm_KeyUP(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);

            }

        }

    }
}