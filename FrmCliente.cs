using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD
{
    public partial class FrmCliente : Form
    {
        public FrmCliente()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            List<Cliente> cli = cliente.listacliente();
            dgvCliente.DataSource = cli;
            btnExcluir.Enabled = false;
            btnEditar.Enabled = false;
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            if (cliente.RegistroRepetido(txtNome.Text, txtEmail.Text) == true)
            {
                MessageBox.Show("Cliente já existe em nossa base de dados!");
                txtNome.Text = string.Empty;
                txtCelular.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtCidade.Text = string.Empty;
                return;
            }
            else
            {
                cliente.Inserir(txtNome.Text, txtCelular.Text, txtEmail.Text, txtCidade.Text);
                MessageBox.Show("Cliente cadastrado com sucesso!");
                List<Cliente> cli = cliente.listacliente();
                dgvCliente.DataSource = cli;
                txtNome.Text = string.Empty;
                txtCelular.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtCidade.Text = string.Empty;
            }
        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            if(txtId.Text == string.Empty)
            {
                MessageBox.Show("Por favor, digite um ID.");
                return;
            }
            int Id = Convert.ToInt32(txtId.Text.Trim());
            Cliente cliente = new Cliente();
            cliente.Localiza(Id);
            txtNome.Text = cliente.nome;
            txtCelular.Text = cliente.celular;
            txtEmail.Text = cliente.email;
            txtCidade.Text = cliente.cidade;
            if (txtNome.Text != null)
            {
                btnExcluir.Enabled = true;
                btnEditar.Enabled = true;
            }
            


        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(txtId.Text.Trim());
            Cliente cliente = new Cliente();
            cliente.Atualizar(Id, txtNome.Text, txtCelular.Text, txtEmail.Text, txtCidade.Text);
            MessageBox.Show("Cliente atualizado com sucesso !");
            List<Cliente> cli = cliente.listacliente();
            dgvCliente.DataSource = cli;
            txtId.Text = string.Empty;
            txtNome.Text = string.Empty;
            txtCelular.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtCidade.Text = string.Empty;
            btnEditar.Enabled=false;
            btnExcluir.Enabled=false;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(txtId.Text.Trim());
            Cliente cliente = new Cliente();
            cliente.Excluir(Id);
            MessageBox.Show("Cliente excluido com sucesso !");
            List<Cliente> cli = cliente.listacliente();
            dgvCliente.DataSource = cli;
            txtId.Text = string.Empty;
            txtNome.Text = string.Empty;
            txtCelular.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtCidade.Text = string.Empty;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
        }

        private void dgvCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvCliente.Rows[e.RowIndex];
                this.dgvCliente.Rows[e.RowIndex].Selected = true;
                txtId.Text = row.Cells[0].Value.ToString();
                txtNome.Text = row.Cells[1].Value.ToString();
                txtCelular.Text = row.Cells[2].Value.ToString();
                txtEmail.Text = row.Cells[3].Value.ToString();
                txtCidade.Text = row.Cells[4].Value.ToString();
            }
            btnEditar.Enabled = true;
            btnExcluir.Enabled = true;
        }
    }
}
