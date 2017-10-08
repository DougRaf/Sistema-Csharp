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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender)
        {
            // TODO: This line of code loads data into the 'desquinela_sqlserverDataSet.curso' table. You can move, or remove it, as needed.
            this.cursoTableAdapter.Fill(this.desquinela_sqlserverDataSet.curso);
           
        }


        private void limparTextBoxes(Control controles)
        {
            Nome.Text = String.Empty;
            Professor.Text = String.Empty;
            Telefone.Text = String.Empty;
            Ordem.Text = String.Empty;
            Celular.Text = String.Empty;
            Ficha.Text = String.Empty;
            Contador.Text = String.Empty;
            Periodo.Text = String.Empty;
            Observação.Text = String.Empty;
            Turma.Text = String.Empty;
            textBox2.Text = String.Empty;
            textBox1.Enabled = false;
            textBox1.Text = null;
            textBox3.Text = null;
            maskedTextBox1.Text = String.Empty;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;
            radioButton7.Checked = false;
            radioButton8.Checked = false;
            radioButton10.Checked = false;
            radioButton11.Checked = false;
            radioButton12.Checked = false;
            radioButton13.Checked = false;
            radioButton14.Checked = false;
            dataGridView1.DataSource = null;

        }


        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string configuracao = "server= opmy0013.servidorwebfacil.com ; Port = 3306 ;" +
                  " Database = desquinela_sqlserver ; uid = desqu_douglas ; password = motoka33 ;";


            MySqlConnection Conexao = new MySqlConnection(configuracao);
            this.Cursor = Cursors.WaitCursor;

            if (Nome.Text == "" || Professor.Text == "" || Telefone.Text == "" || Ordem.Text == "" ||
                Celular.Text == "" || Ficha.Text == "" || Contador.Text == "" || Periodo.Text == "" || Observação.Text == "" || Turma.Text == "" ||
                maskedTextBox1.Text == "" || radioButton3.Text == "" || radioButton4.Text == "")
            {
                MessageBox.Show("Favor preencher todos os campos", "mensagem do sistema");
                this.Cursor = Cursors.Default;
                return;
            }
            if (radioButton3.Checked)
            {
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    Conexao.Open();

                    MySqlCommand comando = new MySqlCommand
                         ("INSERT INTO `curso` ( `nome`, `professor`,`telefone`,`celular`, `periodo`,`ficha`,`turma`, `tipo`, `contador`,`ordem`, `obs`, `data`)" +
                     "VALUES ('" + Nome.Text + "','" + Professor.Text + "','" + Telefone.Text + "','" + Celular.Text + "','" + Periodo.Text + "','"
                     + Ficha.Text + "','" + Turma.Text + "','" + radioButton3.Text + "','" + Contador.Text + "','" + Ordem.Text + "','" + Observação.Text + "','" + maskedTextBox1.Text + "')", Conexao);
                    comando.ExecuteNonQuery();
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("conta regisrada com sucesso", "conta registrada");
                    limparTextBoxes(this);
                    return;
                }

                catch (MySqlException)
                {
                    MessageBox.Show("Erro do banco de dados", "Erro do banco de dados");
                    return;
                }
            }
            else if (radioButton4.Checked)
            {
                try
                {
                    Conexao.Open();

                    MySqlCommand comando = new MySqlCommand
                         ("INSERT INTO `curso` ( `nome`, `professor`,`telefone`,`celular`, `periodo`,`ficha`,`turma`, `tipo`, `contador`,`ordem`, `obs`, `data`)" +
                     "VALUES ('" + Nome.Text + "','" + Professor.Text + "','" + Telefone.Text + "','" + Celular.Text + "','" + Periodo.Text + "','"
                     + Ficha.Text + "','" + Turma.Text + "','" + radioButton4.Text + "','" + Contador.Text + "','" + Ordem.Text + "','" + Observação.Text + "','" + maskedTextBox1.Text + "')", Conexao);
                    comando.ExecuteNonQuery();
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("conta regisrada com sucesso", "conta registrada");
                    limparTextBoxes(this);
                }

                catch (MySqlException)
                {
                    MessageBox.Show("Erro do banco de dados", "Erro do banco de dados");
                    return;
                }
            }
        }
            
        private void button4_Click(object sender, EventArgs e)
        {
            string configuracao = "server= opmy0013.servidorwebfacil.com ; Port = 3306 ;" +
               " Database = desquinela_sqlserver ; uid = desqu_douglas ; password = motoka33 ;";
            MySqlConnection Conexao = new MySqlConnection(configuracao);

            
            if (textBox2.Text == "")

            {
                MessageBox.Show("texto em branco", "mensagem do sistema");
                return;

            }

            try
            {

                this.Cursor = Cursors.WaitCursor;
                string sql_query = "SELECT * FROM curso WHERE nome like '%" + textBox2.Text + "%'";

                MySqlDataAdapter data = new MySqlDataAdapter(sql_query, Conexao);
                DataSet tabela = new DataSet();
                MySqlCommandBuilder cmd = new MySqlCommandBuilder(data);
                data.Fill(tabela);
                dataGridView1.DataSource = tabela.Tables[0];

                this.Cursor = Cursors.Default;

            }

            catch (MySqlException)
            {
                MessageBox.Show("Problema com o Banco de dados", "mensagem do sistema");
                return;
            }


            if (radioButton1.Checked)
            {

                textBox2.Enabled = true;
                radioButton13.Enabled = false;
                radioButton10.Enabled = false;
                radioButton11.Enabled = false;
                radioButton14.Enabled = false;
                radioButton12.Enabled = false;
                radioButton6.Enabled = false;
                radioButton2.Enabled = false;
                radioButton8.Enabled = false;
                radioButton7.Enabled = false;

                try
                {

                    this.Cursor = Cursors.WaitCursor;
                    string sql_query = "SELECT * FROM curso WHERE nome like '%" + textBox2.Text + "%'";

                    MySqlDataAdapter data = new MySqlDataAdapter(sql_query, Conexao);
                    DataSet tabela = new DataSet();
                    MySqlCommandBuilder cmd = new MySqlCommandBuilder(data);
                    data.Fill(tabela);
                    dataGridView1.DataSource = tabela.Tables[0];

                    this.Cursor = Cursors.Default;

                }

                catch (MySqlException)
                {
                    MessageBox.Show("Problema com o Banco de dados", "mensagem do sistema");
                    return;
                }

            }
            else if (radioButton2.Checked)
            {

                textBox2.Enabled = true;
                radioButton13.Enabled = false;
                radioButton11.Enabled = false;
                radioButton10.Enabled = false;
                radioButton14.Enabled = false;
                radioButton12.Enabled = false;
                radioButton6.Enabled = false;
                radioButton1.Enabled = false;
                radioButton8.Enabled = false;
                radioButton7.Enabled = false;



                try
                {

                    this.Cursor = Cursors.WaitCursor;
                    string sql_query = "SELECT * FROM curso WHERE professor like '%" + textBox2.Text + "%'";

                    MySqlDataAdapter data = new MySqlDataAdapter(sql_query, Conexao);
                    DataSet tabela = new DataSet();
                    MySqlCommandBuilder cmd = new MySqlCommandBuilder(data);
                    data.Fill(tabela);
                    dataGridView1.DataSource = tabela.Tables[0];

                    this.Cursor = Cursors.Default;

                }

                catch (MySqlException)
                {
                    MessageBox.Show("Problema com o Banco de dados", "mensagem do sistema");
                    return;
                }


            }

        }

        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {
            string configuracao = "server= opmy0013.servidorwebfacil.com ; Port = 3306 ;" +
              " Database = desquinela_sqlserver ; uid = desqu_douglas ; password = motoka33 ;";
            
            MySqlConnection Conexao = new MySqlConnection(configuracao);

            if (radioButton11.Checked)
            {

                textBox2.Enabled = false;
                radioButton13.Enabled = false;
                radioButton1.Enabled = false;
                radioButton10.Enabled = false;
                radioButton14.Enabled = false;
                radioButton12.Enabled = false;
                radioButton6.Enabled = false;
                radioButton2.Enabled = false;
                radioButton8.Enabled = false;
                radioButton7.Enabled = false;

                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    Conexao.Open();
                    string sql_query = "SELECT * FROM curso WHERE tipo like '%" + radioButton11.Text + "%'";


                    MySqlDataAdapter data = new MySqlDataAdapter(sql_query, Conexao);
                    DataSet tabela = new DataSet();
                    MySqlCommandBuilder cmd = new MySqlCommandBuilder(data);
                    data.Fill(tabela);
                    dataGridView1.DataSource = tabela.Tables[0];

                    this.Cursor = Cursors.Default;

                }

                catch (MySqlException)
                {
                    MessageBox.Show("Problema com o Banco de dados", "mensagem do sistema");
                    return;
                }

            }
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            string configuracao = "server= opmy0013.servidorwebfacil.com ; Port = 3306 ;" +
              " Database = desquinela_sqlserver ; uid = desqu_douglas ; password = motoka33 ;";
            
            MySqlConnection Conexao = new MySqlConnection(configuracao);

            if (radioButton10.Checked)
            {

                textBox2.Enabled = false;
                radioButton13.Enabled = false;
                radioButton1.Enabled = false;
                radioButton11.Enabled = false;
                radioButton14.Enabled = false;
                radioButton12.Enabled = false;
                radioButton6.Enabled = false;
                radioButton2.Enabled = false;
                radioButton8.Enabled = false;
                radioButton7.Enabled = false;

                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    Conexao.Open();
                    string sql_query = "SELECT * FROM curso WHERE tipo like '%" + radioButton10.Text + "%'";


                    MySqlDataAdapter data = new MySqlDataAdapter(sql_query, Conexao);
                    DataSet tabela = new DataSet();
                    MySqlCommandBuilder cmd = new MySqlCommandBuilder(data);
                    data.Fill(tabela);
                    dataGridView1.DataSource = tabela.Tables[0];

                    this.Cursor = Cursors.Default;

                }

                catch (MySqlException)
                {
                    MessageBox.Show("Problema com o Banco de dados", "mensagem do sistema");
                    return;
                }

            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            string configuracao = "server= opmy0013.servidorwebfacil.com ; Port = 3306 ;" +
               " Database = desquinela_sqlserver ; uid = desqu_douglas ; password = motoka33 ;";
            MySqlConnection Conexao = new MySqlConnection(configuracao);


            if (radioButton1.Checked)

            {


                textBox2.Enabled = true;
                radioButton13.Enabled = false;
                radioButton10.Enabled = false;
                radioButton11.Enabled = false;
                radioButton14.Enabled = false;
                radioButton12.Enabled = false;
                radioButton6.Enabled = false;
                radioButton2.Enabled = false;
                radioButton8.Enabled = false;
                radioButton7.Enabled = false;

                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    string sql_query = "SELECT * FROM curso WHERE nome like '%" + textBox2.Text + "%'";

                    MySqlDataAdapter data = new MySqlDataAdapter(sql_query, Conexao);
                    DataSet tabela = new DataSet();
                    MySqlCommandBuilder cmd = new MySqlCommandBuilder(data);
                    data.Fill(tabela);
                    dataGridView1.DataSource = tabela.Tables[0];

                    this.Cursor = Cursors.Default;

                }

                catch (MySqlException)
                {
                    MessageBox.Show("Problema com o Banco de dados", "mensagem do sistema");
                    return;
                }
            }
        }

        private void radioButton13_CheckedChanged(object sender, EventArgs e)
        {
            string configuracao = "server= opmy0013.servidorwebfacil.com ; Port = 3306 ;" +
             " Database = desquinela_sqlserver ; uid = desqu_douglas ; password = motoka33 ;";
            MySqlConnection Conexao = new MySqlConnection(configuracao);


            if (radioButton13.Checked)

            {

                textBox2.Enabled = false;
                radioButton1.Enabled = false;
                radioButton10.Enabled = false;
                radioButton11.Enabled = false;
                radioButton14.Enabled = false;
                radioButton12.Enabled = false;
                radioButton6.Enabled = false;
                radioButton2.Enabled = false;
                radioButton8.Enabled = false;
                radioButton7.Enabled = false;

                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    string sql_query = "SELECT * FROM curso WHERE periodo like '%" + radioButton13.Text + "%'";

                    MySqlDataAdapter data = new MySqlDataAdapter(sql_query, Conexao);
                    DataSet tabela = new DataSet();
                    MySqlCommandBuilder cmd = new MySqlCommandBuilder(data);
                    data.Fill(tabela);
                    dataGridView1.DataSource = tabela.Tables[0];

                    this.Cursor = Cursors.Default;

                }

                catch (MySqlException)
                {
                    MessageBox.Show("Problema com o Banco de dados", "mensagem do sistema");
                    return;
                }
            }
        }

        private void radioButton12_CheckedChanged(object sender, EventArgs e)
        {

            string configuracao = "server= opmy0013.servidorwebfacil.com ; Port = 3306 ;" +
             " Database = desquinela_sqlserver ; uid = desqu_douglas ; password = motoka33 ;";
            MySqlConnection Conexao = new MySqlConnection(configuracao);


            if (radioButton12.Checked)

            {

                textBox2.Enabled = false;
                radioButton1.Enabled = false;
                radioButton10.Enabled = false;
                radioButton11.Enabled = false;
                radioButton14.Enabled = false;
                radioButton13.Enabled = false;
                radioButton6.Enabled = false;
                radioButton2.Enabled = false;
                radioButton8.Enabled = false;
                radioButton7.Enabled = false;

                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    string sql_query = "SELECT * FROM curso WHERE periodo like '%" + radioButton12.Text + "%'";

                    MySqlDataAdapter data = new MySqlDataAdapter(sql_query, Conexao);
                    DataSet tabela = new DataSet();
                    MySqlCommandBuilder cmd = new MySqlCommandBuilder(data);
                    data.Fill(tabela);
                    dataGridView1.DataSource = tabela.Tables[0];

                    this.Cursor = Cursors.Default;

                }

                catch (MySqlException)
                {
                    MessageBox.Show("Problema com o Banco de dados", "mensagem do sistema");
                }
            }
        }

        private void radioButton14_CheckedChanged(object sender, EventArgs e)
        {

            string configuracao = "server= opmy0013.servidorwebfacil.com ; Port = 3306 ;" +
             " Database = desquinela_sqlserver ; uid = desqu_douglas ; password = motoka33 ;";
            MySqlConnection Conexao = new MySqlConnection(configuracao);


            if (radioButton14.Checked)

            {

                textBox2.Enabled = false;
                radioButton1.Enabled = false;
                radioButton10.Enabled = false;
                radioButton11.Enabled = false;
                radioButton12.Enabled = false;
                radioButton13.Enabled = false;
                radioButton6.Enabled = false;
                radioButton2.Enabled = false;
                radioButton8.Enabled = false;
                radioButton7.Enabled = false;

                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    string sql_query = "SELECT * FROM curso WHERE periodo like '%" + radioButton14.Text + "%'";

                    MySqlDataAdapter data = new MySqlDataAdapter(sql_query, Conexao);
                    DataSet tabela = new DataSet();
                    MySqlCommandBuilder cmd = new MySqlCommandBuilder(data);
                    data.Fill(tabela);
                    dataGridView1.DataSource = tabela.Tables[0];

                    this.Cursor = Cursors.Default;

                }

                catch (MySqlException)
                {
                    MessageBox.Show("Problema com o Banco de dados", "mensagem do sistema");
                    return;
                }
            }
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {

            string configuracao = "server= opmy0013.servidorwebfacil.com ; Port = 3306 ;" +
             " Database = desquinela_sqlserver ; uid = desqu_douglas ; password = motoka33 ;";
            MySqlConnection Conexao = new MySqlConnection(configuracao);


            if (radioButton6.Checked)

            {
                textBox2.Enabled = false;
                radioButton1.Enabled = false;
                radioButton10.Enabled = false;
                radioButton11.Enabled = false;
                radioButton12.Enabled = false;
                radioButton13.Enabled = false;
                radioButton14.Enabled = false;
                radioButton2.Enabled = false;
                radioButton8.Enabled = false;
                radioButton7.Enabled = false;

                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    string sql_query = "SELECT * FROM curso WHERE turma like '%" + radioButton6.Text + "%'";

                    MySqlDataAdapter data = new MySqlDataAdapter(sql_query, Conexao);
                    DataSet tabela = new DataSet();
                    MySqlCommandBuilder cmd = new MySqlCommandBuilder(data);
                    data.Fill(tabela);
                    dataGridView1.DataSource = tabela.Tables[0];

                    this.Cursor = Cursors.Default;

                }

                catch (MySqlException)
                {
                    MessageBox.Show("Problema com o Banco de dados", "mensagem do sistema");
                    return;
                }
            }
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {

            string configuracao = "server= opmy0013.servidorwebfacil.com ; Port = 3306 ;" +
             " Database = desquinela_sqlserver ; uid = desqu_douglas ; password = motoka33 ;";
            MySqlConnection Conexao = new MySqlConnection(configuracao);


            if (radioButton7.Checked)

            {
                textBox2.Enabled = false;
                radioButton1.Enabled = false;
                radioButton10.Enabled = false;
                radioButton11.Enabled = false;
                radioButton12.Enabled = false;
                radioButton13.Enabled = false;
                radioButton14.Enabled = false;
                radioButton2.Enabled = false;
                radioButton8.Enabled = false;
                radioButton6.Enabled = false;
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    string sql_query = "SELECT * FROM curso WHERE turma like '%" + radioButton7.Text + "%'";

                    MySqlDataAdapter data = new MySqlDataAdapter(sql_query, Conexao);
                    DataSet tabela = new DataSet();
                    MySqlCommandBuilder cmd = new MySqlCommandBuilder(data);
                    data.Fill(tabela);
                    dataGridView1.DataSource = tabela.Tables[0];

                    this.Cursor = Cursors.Default;

                }

                catch (MySqlException)
                {
                    MessageBox.Show("Problema com o Banco de dados", "mensagem do sistema");
                    return;
                }
            }
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {

            string configuracao = "server= opmy0013.servidorwebfacil.com ; Port = 3306 ;" +
             " Database = desquinela_sqlserver ; uid = desqu_douglas ; password = motoka33 ;";
            MySqlConnection Conexao = new MySqlConnection(configuracao);


            if (radioButton8.Checked)

            {
                textBox2.Enabled = false;
                radioButton1.Enabled = false;
                radioButton10.Enabled = false;
                radioButton11.Enabled = false;
                radioButton12.Enabled = false;
                radioButton13.Enabled = false;
                radioButton14.Enabled = false;
                radioButton2.Enabled = false;
                radioButton7.Enabled = false;
                radioButton6.Enabled = false;

                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    string sql_query = "SELECT * FROM curso WHERE turma like '%" + radioButton8.Text + "%'";

                    MySqlDataAdapter data = new MySqlDataAdapter(sql_query, Conexao);
                    DataSet tabela = new DataSet();
                    MySqlCommandBuilder cmd = new MySqlCommandBuilder(data);
                    data.Fill(tabela);
                    dataGridView1.DataSource = tabela.Tables[0];

                    this.Cursor = Cursors.Default;

                }

                catch (MySqlException)
                {
                    MessageBox.Show("Problema com o Banco de dados", "mensagem do sistema");
                    return;
                }
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

            string configuracao = "server= opmy0013.servidorwebfacil.com ; Port = 3306 ;" +
             " Database = desquinela_sqlserver ; uid = desqu_douglas ; password = motoka33 ;";
            MySqlConnection Conexao = new MySqlConnection(configuracao);


            if (radioButton2.Checked)

            {
                textBox2.Enabled = true;
                radioButton1.Enabled = false;
                radioButton10.Enabled = false;
                radioButton11.Enabled = false;
                radioButton12.Enabled = false;
                radioButton13.Enabled = false;
                radioButton14.Enabled = false;
                radioButton8.Enabled = false;
                radioButton7.Enabled = false;
                radioButton6.Enabled = false;
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    string sql_query = "SELECT * FROM curso WHERE professor like '%" + textBox2.Text + "%'";

                    MySqlDataAdapter data = new MySqlDataAdapter(sql_query, Conexao);
                    DataSet tabela = new DataSet();
                    MySqlCommandBuilder cmd = new MySqlCommandBuilder(data);
                    data.Fill(tabela);
                    dataGridView1.DataSource = tabela.Tables[0];

                    this.Cursor = Cursors.Default;

                }

                catch (MySqlException)
                {
                    MessageBox.Show("Problema com o Banco de dados", "mensagem do sistema");
                    return;
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
            limparTextBoxes(this);
            textBox2.Enabled = true;
            radioButton1.Enabled = true;
            radioButton2.Enabled = true;
            radioButton6.Enabled = true;
            radioButton7.Enabled = true;
            radioButton8.Enabled = true;
            radioButton10.Enabled = true;
            radioButton11.Enabled = true;
            radioButton12.Enabled = true;
            radioButton13.Enabled = true;
            radioButton14.Enabled = true;
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            limparTextBoxes(this);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "") {
                MessageBox.Show("Favor digite o id_cod a ser excluido", "mensagem do sistema");
                return;
                //limparTextBoxes(this);
            }          
            
            
            string configuracao = "server= opmy0013.servidorwebfacil.com ; Port = 3306 ;" +
                  " Database = desquinela_sqlserver ; uid = desqu_douglas ; password = motoka33 ;";

            MySqlConnection Conexao = new MySqlConnection(configuracao);

            this.Cursor = Cursors.WaitCursor;
            string sql = "DELETE FROM `curso` WHERE `id_cod` like '%" + textBox3.Text + "%'";

            MySqlCommand comando = new MySqlCommand(sql, Conexao);
            comando.CommandType = CommandType.Text;
            Conexao.Open();

            try
            {

                int i = comando.ExecuteNonQuery();
                if (i > 0)
                    this.Cursor = Cursors.Default;
                MessageBox.Show("Registro excluído com sucesso");
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO: " + ex.ToString());
            }
            finally
            {
                Conexao.Close();
            }
            
            }

        private void button6_Click(object sender, EventArgs e)
        {
            

            if (radioButton5.Checked == false)
            {
                MessageBox.Show("Favor verifique se a opção ALTERAR está ativada", "mensagem do sistema");
                return;
            }
            else  if (Nome.Text == "" || Professor.Text == "" || Telefone.Text == "" || Ordem.Text == "" ||
                Celular.Text == "" || Ficha.Text == "" || Contador.Text == "" || Periodo.Text == "" || Observação.Text == "" || Turma.Text == "" ||
                maskedTextBox1.Text == "" || radioButton3.Text == "" || radioButton4.Text == "" || textBox1.Text == "")
            {
                MessageBox.Show("Favor preencher todos os campos", "mensagem do sistema");
                return;
            }

            else if (radioButton5.Checked == true)
            {
               string configuracao = "server= opmy0013.servidorwebfacil.com ; Port = 3306 ;" +
                      " Database = desquinela_sqlserver ; uid = desqu_douglas ; password = motoka33 ;";

                MySqlConnection Conexao = new MySqlConnection(configuracao);
                
                this.Cursor = Cursors.WaitCursor;
                string sql = "UPDATE `curso` SET `nome`='" + Nome.Text + "', `professor`='" + Professor.Text + "',`telefone`='" + Telefone.Text + "',`celular`='" + Celular.Text + "', `periodo`='" + Periodo.Text + "', `ficha`='" + Ficha.Text + "' ,`turma`='" + Turma.Text + "', `tipo`='" + radioButton3.Text + "', `contador`='" + Contador.Text + "',`ordem`='" + Ordem.Text + "' , `obs`='" + Observação.Text + "', `data`='" + maskedTextBox1.Text + "' WHERE id_cod ='"+textBox1.Text+"'";

                MySqlCommand comando = new MySqlCommand(sql, Conexao);
                comando.CommandType = CommandType.Text;
                Conexao.Open();

                try
                {

                    int i = comando.ExecuteNonQuery();
                    if (i > 0)
                        this.Cursor = Cursors.Default;
                    MessageBox.Show("ALTERAÇÃO feita com sucesso");
                    limparTextBoxes(this);
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERRO: " + ex.ToString());
                    limparTextBoxes(this);
                    return;
                }
                finally
                {
                    Conexao.Close();

                }

            }
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            Form5 tela2 = new Form5();
            tela2.ShowDialog();
            
        }

       
        private void pictureBox4_Click(object sender, EventArgs e)
        {
          
            this.Cursor = Cursors.WaitCursor;
            Form5 tela2 = new Form5();
            tela2.ShowDialog();
           
            this.Cursor = Cursors.Default;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
       
        }

        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
            
            this.Cursor = Cursors.Hand;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked) {
                textBox1.Enabled = true;
                textBox1.Text = String.Empty;
            }
        }

        private void MainForm_KeyUP(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);

            }



        }

        private void teste(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button4_Click(sender, e);

            }





        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

    }
}


  
 