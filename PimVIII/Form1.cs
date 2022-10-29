using MySql.Data.MySqlClient;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace PimVIII

{
    public partial class Form1 : Form
    {
        MySqlConnection conexao;
        MySqlCommand comando;
        MySqlDataReader dr;
        string strSql;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                conexao = new MySqlConnection("Server = localhost; Database = pim8; Uid = root; Pwd = #Tecnologia1988;");

                conexao.Open();

                strSql = "INSERT INTO endereco (logradouro, numero, cep, bairro, cidade, estado) " +
                    "VALUES (@logradouro, @numero, @cep, @bairro, @cidade, @estado)";

                comando = new MySqlCommand(strSql, conexao);
                comando.Parameters.AddWithValue("@logradouro", txtLogradouro.Text);
                comando.Parameters.AddWithValue("@numero", txtNumero.Text);
                comando.Parameters.AddWithValue("@cep", txtCEP.Text);
                comando.Parameters.AddWithValue("@bairro", txtBairro.Text);
                comando.Parameters.AddWithValue("@cidade", txtCidade.Text);
                comando.Parameters.AddWithValue("@estado", txtEstado.Text);

                comando.ExecuteNonQuery();

                strSql = "INSERT INTO pessoa (nome, cpf, ENDERECO_id) " +
                    "VALUES (@nome, @cpf, @ENDERECO_id)";
                comando = new MySqlCommand(strSql, conexao);
                comando.Parameters.AddWithValue("@nome", txtNome.Text);
                comando.Parameters.AddWithValue("@cpf", txtCPF.Text);
                comando.Parameters.AddWithValue("@ENDERECO_id", txtID.Text);

                comando.ExecuteNonQuery();

                strSql = "INSERT INTO telefone_tipo (tipo) " +
                    "VALUES (@tipo)";
                comando = new MySqlCommand(strSql, conexao);
                comando.Parameters.AddWithValue("@tipo", txtTipo.Text);               

                comando.ExecuteNonQuery();

                strSql = "INSERT INTO telefone (numeroTelefone, ddd, TELEFONE_TIPO_id) " +
                    "VALUES (@numeroTelefone, @ddd, @TELEFONE_TIPO_id)";
                comando = new MySqlCommand(strSql, conexao);
                comando.Parameters.AddWithValue("@numeroTelefone", txtTelefone.Text);
                comando.Parameters.AddWithValue("@ddd", txtDDD.Text);
                comando.Parameters.AddWithValue("@TELEFONE_TIPO_id", txtID.Text);

                comando.ExecuteNonQuery();

                strSql = "INSERT INTO pessoa_telefone (PESSOA_id, TELEFONE_id) " +
                    "VALUES (@PESSOA_id, @TELEFONE_id)";
                comando = new MySqlCommand(strSql, conexao);
                comando.Parameters.AddWithValue("@PESSOA_id", txtID.Text);
                comando.Parameters.AddWithValue("@TELEFONE_id", txtID.Text);

                comando.ExecuteNonQuery();

                MessageBox.Show("DADOS ADICIONADO COM SUCESSO!");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
                conexao = null;
                comando = null;
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                conexao = new MySqlConnection("Server = localhost; Database = pim8; Uid = root; Pwd = #Tecnologia1988;");
                conexao.Open();

                strSql = "SELECT id, nome, cpf, logradouro, numero, cep, bairro, cidade, estado, PESSOA_id, TELEFONE_id " +
                    "FROM pessoa" +
                    "INNER JOIN endereco" +
                    "ON id = @p.ENDERECO_id" +
                    "INNER JOIN pessoa_telefone" +
                    "ON id = @fk.PESSOA_id" +
                    "WHERE cpf = @cpf;";

                comando = new MySqlCommand(strSql, conexao);
                comando.Parameters.AddWithValue("@cpf", txtCPF.Text);

                comando.ExecuteNonQuery();

                MessageBox.Show("DADOS ADICIONADO COM SUCESSO!");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
                conexao = null;
                comando = null;
            }
        }
    }
}