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
    public partial class Proveedores : Form
    {
        public Proveedores()
        {
            InitializeComponent();
            oBLLProveedor = new BLLProveedor();
        }

        BLLProveedor oBLLProveedor;

        private void Proveedores_Load(object sender, EventArgs e)
        {
            CargarGrillaProveedores();
        }

        void CargarGrillaProveedores()
        {
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = oBLLProveedor.ListarTodo();
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            BEProveedor oBEProveedor = new BEProveedor();   
            oBEProveedor.RazonSocial = textBoxRazonSocial.Text;
            oBEProveedor.CUIT = Convert.ToInt32(textBoxCUIT.Text);

            if(oBEProveedor.RazonSocial != "" && oBEProveedor.CUIT != 0)
            {
                if(oBLLProveedor.ListarTodo().Exists(x => x.CUIT == oBEProveedor.CUIT) == false)
                {
                    oBLLProveedor.Guardar(oBEProveedor);
                    CargarGrillaProveedores();
                    MessageBox.Show("Proveedor ingresado correctamente");
                }
                else
                {
                    MessageBox.Show("El CUIT ingresa ya existe");
                }
            }
            else
            {
                MessageBox.Show("No se pueden ingresar campos vacios!");
            }
        }
    }
}
