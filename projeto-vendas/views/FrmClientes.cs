using projeto_vendas.dao;
using projeto_vendas.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projeto_vendas.views
{
    public partial class FrmClientes : Form
    {
        public FrmClientes()
        {
            InitializeComponent();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            //1 passo - Criar um objeto da classe ClienteDAO
            ClienteDAO dao = new ClienteDAO();
            dtgclientes.DataSource = dao.ListarCliente();   
        }

        private void dtgclientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnsalvar_Click(object sender, EventArgs e)
        {
            // 1 passo - receber os dados dentro do objeto modelo de cliente
            Cliente obj = new Cliente();

            obj.Nome = txtnome.Text;
            obj.Rg = txtrg.Text;
            obj.Cpf = txtcpf.Text;
            obj.Email = txtemail.Text;
            obj.Telefone = txttelefone.Text;
            obj.Celular = txtcelular.Text;
            obj.Cep = txtcep.Text;
            obj.Endereco = txtendereco.Text;
            obj.Numero = int.Parse(txtnumero.Text);
            obj.Bairro = txtbairro.Text;
            obj.Cidade = txtcidade.Text;
            obj.Estado = cbuf.SelectedItem.ToString();

            ClienteDAO dao = new ClienteDAO();
            dao.cadastrarCliente(obj);

            dtgclientes.DataSource = dao.ListarCliente();

        }

        private void btnexcluir_Click(object sender, EventArgs e)
        {
            Cliente obj = new Cliente();
            obj.Id = int.Parse(txtcodigo.Text);

            ClienteDAO dao = new ClienteDAO();
            dao.excluirCliente(obj);

            dtgclientes.DataSource = dao.ListarCliente();
        }

        private void btnalterar_Click(object sender, EventArgs e)
        {
            Cliente obj = new Cliente();

            obj.Nome = txtnome.Text;
            obj.Rg = txtrg.Text;
            obj.Cpf = txtcpf.Text;
            obj.Email = txtemail.Text;
            obj.Telefone = txttelefone.Text;
            obj.Celular = txtcelular.Text;
            obj.Cep = txtcep.Text;
            obj.Endereco = txtendereco.Text;
            obj.Numero = int.Parse(txtnumero.Text);
            obj.Bairro = txtbairro.Text;
            obj.Cidade = txtcidade.Text;
            obj.Estado = cbuf.SelectedItem.ToString();

            obj.Id = int.Parse(txtcodigo.Text);

            ClienteDAO dao = new ClienteDAO();
            dao.alterarCliente(obj);

            dtgclientes.DataSource = dao.ListarCliente();
        }

        private void dtgclientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtcodigo.Text = dtgclientes.CurrentRow.Cells[0].Value.ToString();
            txtnome.Text = dtgclientes.CurrentRow.Cells[1].Value.ToString();
            txtrg.Text = dtgclientes.CurrentRow.Cells[2].Value.ToString();
            txtcpf.Text = dtgclientes.CurrentRow.Cells[3].Value.ToString();
            txtemail.Text = dtgclientes.CurrentRow.Cells[4].Value.ToString();
            txttelefone.Text = dtgclientes.CurrentRow.Cells[5].Value.ToString();
            txtcelular.Text = dtgclientes.CurrentRow.Cells[6].Value.ToString();
            txtcep.Text = dtgclientes.CurrentRow.Cells[7].Value.ToString();
            txtendereco.Text = dtgclientes.CurrentRow.Cells[8].Value.ToString();
            txtnumero.Text = dtgclientes.CurrentRow.Cells[9].Value.ToString();
            txtbairro.Text = dtgclientes.CurrentRow.Cells[11].Value.ToString();
            txtcidade.Text = dtgclientes.CurrentRow.Cells[12].Value.ToString();
            cbuf.Text = dtgclientes.CurrentRow.Cells[13].Value.ToString();

            tabControl1.SelectedTab = tabPage1;

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            new Helpers().LimparTela(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string cep = txtcep.Text;
                string xml = "https://viacep.com.br/ws/" + cep + "/xml/";

                DataSet dados = new DataSet();

                dados.ReadXml(xml);

                txtendereco.Text = dados.Tables[0].Rows[0]["logradouro"].ToString();
                txtbairro.Text = dados.Tables[0].Rows[0]["bairro"].ToString();
                txtcidade.Text = dados.Tables[0].Rows[0]["localidade"].ToString();
                cbuf.Text = dados.Tables[0].Rows[0]["uf"].ToString();




            }
            catch (Exception)
            {

                MessageBox.Show("endereço não encontrado, por favor digite manualmente.");
            }
        }

        private void btnpesquisar_Click(object sender, EventArgs e)
        {

        }
    }
}

