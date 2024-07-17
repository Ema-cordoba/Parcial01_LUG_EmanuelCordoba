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
    public partial class Calefactores : Form
    {
        public Calefactores()
        {
            InitializeComponent();
            oBLLCalElectrico = new BLLCalefactorElectrico();
            oBLLCalGas = new BLLCalefactorGas();
            oBLLProveedor = new BLLProveedor();
        }


        BLLCalefactorElectrico oBLLCalElectrico;
        BLLCalefactorGas oBLLCalGas;
        BLLProveedor oBLLProveedor;


        void CargarComboBoxProveedores()
        {
            this.comboBoxPro.DataSource = null;
            this.comboBoxPro.DataSource = oBLLProveedor.ListarTodo();
            this.comboBoxPro.DisplayMember = "RazonSocial";
            this.comboBoxPro.ValueMember = "Codigo";
            this.comboBoxPro.Refresh();
        }

        void CargarGrillaCalElectricos()
        {
            this.dataGridView2.DataSource = null;
            this.dataGridView2.DataSource = oBLLCalElectrico.ListarTodo();
            this.dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        void CargarGrillaCalGas()
        {
            this.dataGridView2.DataSource = null;
            this.dataGridView2.DataSource = oBLLCalGas.ListarTodo();
            this.dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       

        private void Calefactores_Load_1(object sender, EventArgs e)
        {
            CargarComboBoxProveedores();
         
            CargarGrillaCalElectricos();
            this.radioButtonElectrico.Checked = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(textNombre.Text != "" && textCalorias.Text != "" && textModelo.Text != "" && textCantidad.Text != "" && textBoxAmbiguo.Text != "")
                {
                    if(radioButtonElectrico.Checked == true)
                    {
                        BECalefactorElectrico oBECalElectrico = new BECalefactorElectrico();
                        oBECalElectrico.Nombre = textNombre.Text;
                        oBECalElectrico.Modelo = textModelo.Text;
                        oBECalElectrico.Cantidad = Convert.ToInt32(textCantidad.Text);
                        oBECalElectrico.Eficiencia = textBoxAmbiguo.Text;
                        oBECalElectrico.Proveedor = (BEProveedor)comboBox1.SelectedItem;
                        oBLLCalElectrico.Guardar(oBECalElectrico);
                        MessageBox.Show("Cargado calefactor electrico correctamente");
                        CargarGrillaCalElectricos();
                    }
                    else if(radioButtonCalGas.Checked == true)
                    {
                        BECalefactorGas oBECalGas = new BECalefactorGas();
                        oBECalGas.Nombre = textNombre.Text;
                        oBECalGas.Modelo = textModelo.Text;
                        oBECalGas.Cantidad = Convert.ToInt32(textCantidad.Text);
                        oBECalGas.TiroBalanceado = Convert.ToByte(textBoxAmbiguo.Text);
                        oBECalGas.Proveedor = (BEProveedor)comboBox1.SelectedItem;
                        oBLLCalGas.Guardar(oBECalGas);
                        MessageBox.Show("Cargado calefactor a gas correctamente");
                        CargarGrillaCalGas();
                    }
                    else
                    {
                        MessageBox.Show("Para agregar Calefactor debe estar los campos completos");
                    }
                }
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
            finally { VaciarTxt(); }
        }



        void VaciarTxt()
        {
            this.textNombre.Text = string.Empty;
            this.textModelo.Text = string.Empty;
            this.textCalorias .Text = string.Empty;
            this.textCantidad.Text = string.Empty;
            this.textBoxAmbiguo.Text = string.Empty;
            
        }

        private void textCantidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resultado;
                if(radioButtonElectrico.Checked == true)
                {
                    BECalefactorElectrico oBECalElectrico = (BECalefactorElectrico)this.dataGridView2.CurrentRow.DataBoundItem;
                    resultado = (MessageBox.Show("Desea elminiar el calefactor electrico?", "INFORMACION", MessageBoxButtons.YesNo));

                    if (resultado == DialogResult.Yes) 
                    {
                        oBLLCalElectrico.Borrar(oBECalElectrico);
                        CargarGrillaCalElectricos();
                    }
                }
                else
                {
                    BECalefactorGas oBECalGas = (BECalefactorGas)this.dataGridView2.CurrentRow.DataBoundItem;
                    resultado = (MessageBox.Show("Desea elminiar el calefactor a gas?", "INFORMACION", MessageBoxButtons.YesNo));

                    if (resultado == DialogResult.Yes) 
                    {
                        oBLLCalGas.Borrar(oBECalGas);
                        CargarGrillaCalGas();
                    }
                }

            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
            finally { VaciarTxt(); }
        }
    }
}
