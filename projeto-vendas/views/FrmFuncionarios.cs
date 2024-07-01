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
    public partial class FrmFuncionarios : Form
    {
        public FrmFuncionarios()
        {
            InitializeComponent();
        }

        private void btnsalvar_Click(object sender, EventArgs e)
        {
            //botao salvar
            Funcionario obj = new Funcionario();

            //receber os dados dos campos
            obj.Nome = txtnome.Text;
            obj.Rg = txtrg.Text;
            obj.Cpf = txtcpf.Text; 
            obj.Email = txtemail.Text;
            obj.senha = txtsenha.Text;
            obj.nivel_acesso = cbnivel.SelectedItem.ToString();
            obj.Telefone = txttelefone.Text;
            obj.Celular = txtcelular.Text;
            obj.Cep = txtcep.Text;
            obj.Endereco = txtendereco.Text;
            obj.Numero = int.Parse(txtnumero.Text);
            obj.Bairro = txtbairro.Text;
            obj.Cidade = txtcidade.Text;
            obj.Estado = cbuf.SelectedItem.ToString();
            obj.cargo = cbcargo.SelectedItem.ToString();


            //criar o objeto funcionario DAO
            FuncionarioDAO dao = new FuncionarioDAO();
            dao.cadastrarFuncionario(obj);

            dtgfuncionario.DataSource = dao.listarFuncionarios();
        }

        private void btnexcluir_Click(object sender, EventArgs e)
        {
            //botão excluir
            Funcionario obj = new Funcionario();
            obj.Id = int.Parse(txtcodigo.Text);

            FuncionarioDAO dao = new FuncionarioDAO();
            dao.DeletarFuncionario(obj);

            dtgfuncionario.DataSource = dao.listarFuncionarios();
        }

        private void btnalterar_Click(object sender, EventArgs e)
        {
            //botao alterar
            Funcionario obj = new Funcionario();

            obj.Nome = txtnome.Text;
            obj.Rg = txtrg.Text;
            obj.Cpf = txtcpf.Text;
            obj.Email = txtemail.Text;
            obj.senha = txtsenha.Text;
            obj.nivel_acesso = cbnivel.SelectedItem.ToString();
            obj.Telefone = txttelefone.Text;
            obj.Celular = txtcelular.Text;
            obj.Cep = txtcep.Text;
            obj.Endereco = txtendereco.Text;
            obj.Numero = int.Parse(txtnumero.Text);
            obj.Bairro = txtbairro.Text;
            obj.Cidade = txtcidade.Text;
            obj.Estado = cbuf.SelectedItem.ToString();
            obj.cargo = cbcargo.SelectedItem.ToString();

            obj.Id = int.Parse(txtcodigo.Text);

            FuncionarioDAO dao = new FuncionarioDAO();
            dao.AlterarFuncionario(obj);

            dtgfuncionario.DataSource = dao.listarFuncionarios();
        }

        private void dtgclientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void FrmFuncionarios_Load(object sender, EventArgs e)
        {
            FuncionarioDAO dao = new FuncionarioDAO();
            dtgfuncionario.DataSource = dao.listarFuncionarios();
        }

        private void dtgfuncionario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtcodigo.Text = dtgfuncionario.CurrentRow.Cells[0].Value.ToString();
            txtnome.Text = dtgfuncionario.CurrentRow.Cells[1].Value.ToString();
            txtrg.Text = dtgfuncionario.CurrentRow.Cells[2].Value.ToString();
            txtcpf.Text = dtgfuncionario.CurrentRow.Cells[3].Value.ToString();
            txtemail.Text = dtgfuncionario.CurrentRow.Cells[4].Value.ToString();
            txtsenha.Text = dtgfuncionario.CurrentRow.Cells[5].Value.ToString();
            cbcargo.Text = dtgfuncionario.CurrentRow.Cells[6].Value.ToString();
            cbnivel.Text = dtgfuncionario.CurrentRow.Cells[7].Value.ToString();
            txttelefone.Text = dtgfuncionario.CurrentRow.Cells[8].Value.ToString();
            txtcelular.Text = dtgfuncionario.CurrentRow.Cells[9].Value.ToString();
            txtcep.Text = dtgfuncionario.CurrentRow.Cells[10].Value.ToString();
            txtendereco.Text = dtgfuncionario.CurrentRow.Cells[11].Value.ToString();
            txtnumero.Text = dtgfuncionario.CurrentRow.Cells[12].Value.ToString();
            txtbairro.Text = dtgfuncionario.CurrentRow.Cells[14].Value.ToString();
            txtcidade.Text = dtgfuncionario.CurrentRow.Cells[15].Value.ToString();
            cbuf.Text = dtgfuncionario.CurrentRow.Cells[16].Value.ToString();

            tabFuncionario.SelectedTab = tabcontrol1;




        }

        private void btnpesquisar_Click(object sender, EventArgs e)
        {
            //botao pesquisar 
            string nome = txtpesquisa.Text;

            FuncionarioDAO dAO = new FuncionarioDAO();
            dtgfuncionario.DataSource = dAO.BuscaFuncionariosPorNome(nome);

            if(dtgfuncionario.Rows.Count == 1 || txtpesquisa.Text == string.Empty)
            {
                MessageBox.Show("Funcionário não encontrado!");
                dtgfuncionario.DataSource = dAO.listarFuncionarios();
            }

        }

        private void txtpesquisa_TextChanged(object sender, EventArgs e)
        {
            string nome = "%" + txtpesquisa.Text + "%";

            FuncionarioDAO dao = new FuncionarioDAO();
            dtgfuncionario.DataSource = dao.listarFuncionariosPorNome(nome);

        }

        private void btnnovo_Click(object sender, EventArgs e)
        {
            new Helpers().LimparTela(this);
        }

        private void btnpesquisarcep_Click(object sender, EventArgs e)
        {
            //botao pesquisar cep 
            try
            {
                string cep = txtcep.Text;
                string xml = "https://viacep.com.br/ws/"+cep+"/xml/";

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

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
    }
}
