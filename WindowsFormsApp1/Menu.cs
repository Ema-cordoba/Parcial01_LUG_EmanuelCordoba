using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clientes formClientes = new Clientes();
            formClientes.MdiParent = this;
            formClientes.Show();
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Proveedores formProveedores = new Proveedores();
            formProveedores.MdiParent = this;
            formProveedores.Show();
        }

        private void calefactoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Calefactores formCalefactores = new Calefactores();
            formCalefactores.MdiParent = this;
            formCalefactores.Show();
        }

        private void comprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Compras formCompras = new Compras();
            formCompras.MdiParent = this;
            formCompras.Show();
        }
    }
}
