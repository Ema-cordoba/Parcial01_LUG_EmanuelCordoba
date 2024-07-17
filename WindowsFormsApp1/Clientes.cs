using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;

namespace WindowsFormsApp1
{
    public partial class Clientes : Form
    {
        public Clientes()
        {
            InitializeComponent();
            oBLLCliente = new BLLCliente();
        }

        BLLCliente oBLLCliente;

        private void Clientes_Load(object sender, EventArgs e)
        {
            CargarGrillaClientes();
        }

        void CargarGrillaClientes()
        {
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = oBLLCliente.ListarTodo();
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                BECliente objBECliente = (BECliente)this.dataGridView1.CurrentRow.DataBoundItem;
                int DescuentoElec = oBLLCliente.ObtenerDescuentosCalElectrico(objBECliente,Convert.ToDecimal(textBox1));
                int DescuentoGas = oBLLCliente.ObtenerDescuentosCalGas(objBECliente, Convert.ToDecimal(textBox1));
                if (DescuentoElec != 0 && DescuentoGas != 0)
                {
                    MessageBox.Show("Descuentos otorgados: " + Environment.NewLine + $"{DescuentoElec}% en productos de electricidad" + Environment.NewLine + $"{DescuentoGas}% en productos de pintureria");
                }
                else
                {
                    MessageBox.Show("El cliente todavia no tiene descuentos");
                }
            }
            catch (Exception) { }
        }
    }
}
