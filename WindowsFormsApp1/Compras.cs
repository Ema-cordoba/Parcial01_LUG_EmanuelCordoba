using BE;
using BLL;
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
    public partial class Compras : Form
    {
        public Compras()
        {
            InitializeComponent();
            oBLLCliente = new BLLCliente();
            oBLLCalElectrico = new BLLCalefactorElectrico();
            oBLLCalGas = new BLLCalefactorGas();
        }

        public List<BECalefactor> ListaCalefactores = new List<BECalefactor>(); 

        BLLCliente oBLLCliente;
        BLLCalefactorElectrico oBLLCalElectrico;
        BLLCalefactorGas oBLLCalGas;


        void CargarGrillaClientes()
        {
            this.dataGridViewClientes.DataSource = null;
            this.dataGridViewClientes.DataSource = oBLLCliente.ListarTodo();
            this.dataGridViewClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        void CargarGrillaCalElectrico()
        {
            this.dataGridViewCalefactores.DataSource = null;
            this.dataGridViewCalefactores.DataSource = oBLLCalElectrico.ListarTodo();
            this.dataGridViewCalefactores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        void CargarGrillaCalGas()
        {
            this.dataGridViewCalefactores.DataSource = null;
            this.dataGridViewCalefactores.DataSource = oBLLCalGas.ListarTodo();
            this.dataGridViewCalefactores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }


        private void Compras_Load(object sender, EventArgs e)
        {
            CargarGrillaClientes();
            this.radioButtonElect.Checked = true;
        }

        private void radioButtonElect_CheckedChanged(object sender, EventArgs e)
        {
            CargarGrillaCalElectrico();
        }

        private void radioButtonGas_CheckedChanged(object sender, EventArgs e)
        {
            CargarGrillaCalGas();
        }

        void CargarGrillaCarrito(List<BECalefactor> ListaCalefactores)
        {
            this.dataGridViewCarrito.DataSource = null;
            this.dataGridViewCarrito.DataSource = ListaCalefactores;
            this.dataGridViewCarrito.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                int cant = Convert.ToInt32(textBoxCantidad.Text);
                if(cant > 2)
                {
                    MessageBox.Show("Debe selecionar 1 o 2 calefactores");
                }
                else if(radioButtonElect.Checked == true)
                {
                    BECalefactorElectrico oBECalElectrico = (BECalefactorElectrico)this.dataGridViewCalefactores.CurrentRow.DataBoundItem;
                    if(oBECalElectrico.Cantidad - cant > 0)
                    {
                        if(ListaCalefactores.Exists(x=>x.Codigo == oBECalElectrico.Codigo) == false)
                        {
                            BECalefactorElectrico oBECalElectrico2 = new BECalefactorElectrico();
                            oBECalElectrico2.Codigo = oBECalElectrico.Codigo;
                            oBECalElectrico2.Nombre = oBECalElectrico.Nombre;
                            oBECalElectrico2.Calorias = oBECalElectrico.Calorias;
                            oBECalElectrico2.Modelo = oBECalElectrico.Modelo;
                            oBECalElectrico2.Eficiencia = oBECalElectrico.Eficiencia;
                            oBECalElectrico2.Cantidad = cant;
                            ListaCalefactores.Add(oBECalElectrico2);

                            oBECalElectrico.Cantidad = oBECalElectrico.Cantidad - cant;
                            oBLLCalElectrico.Guardar(oBECalElectrico);
                            CargarGrillaCarrito(ListaCalefactores);
                            CargarGrillaCalElectrico();


                        }
                        else
                        {
                            MessageBox.Show("No puede agregar al carrito dos veces el mismo producto");
                        }
                    }
                    else
                    {
                        MessageBox.Show("El producto se encuentra sin stock disponible");
                    }

                }
                else
                {
                    BECalefactorGas oBECalGas = (BECalefactorGas)this.dataGridViewCalefactores.CurrentRow.DataBoundItem;
                    if (oBECalGas.Cantidad - cant > 0)
                    {
                        if (ListaCalefactores.Exists(x => x.Codigo == oBECalGas.Codigo) == false)
                        {
                            BECalefactorGas oBECalGas2 = new BECalefactorGas();
                            oBECalGas2.Codigo = oBECalGas.Codigo;
                            oBECalGas2.Nombre = oBECalGas.Nombre;
                            oBECalGas2.Calorias = oBECalGas.Calorias;
                            oBECalGas2.Modelo = oBECalGas.Modelo;
                            oBECalGas2.TiroBalanceado = oBECalGas.TiroBalanceado;
                            oBECalGas2.Cantidad = cant;
                            ListaCalefactores.Add(oBECalGas2);

                            oBECalGas.Cantidad = oBECalGas.Cantidad - cant;
                            oBLLCalGas.Guardar(oBECalGas);
                            CargarGrillaCarrito(ListaCalefactores);
                            CargarGrillaCalGas();


                        }
                        else
                        {
                            MessageBox.Show("No puede agregar al carrito dos veces el mismo producto");
                        }
                    }
                    else
                    {
                        MessageBox.Show("El producto se encuentra sin stock disponible");
                    }
                }
            }
            catch { }
        }

        private void buttonConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                BECliente oBECliente = (BECliente)this.dataGridViewClientes.CurrentRow.DataBoundItem;
                DialogResult resultado = MessageBox.Show($"Desea confirmar la compra {oBECliente.Nombre} , {oBECliente.Apellido}?", "INFORMACION", MessageBoxButtons.YesNo);

                if (resultado == DialogResult.Yes) 
                {
                    foreach(BECalefactor obj in ListaCalefactores)
                    {
                        if(obj is BECalefactorElectrico)
                        {
                            oBLLCalElectrico.GuardarCalefactor_Cliente(oBECliente, obj as BECalefactorElectrico);
                        }
                        else
                        {
                            oBLLCalGas.GuardarCalefactor_Cliente(oBECliente, obj as BECalefactorGas);
                        }
                    }
                }
                ListaCalefactores.Clear();
                CargarGrillaCarrito(ListaCalefactores);
                CargarGrillaComprasCliente(oBLLCliente.ListarTodo().Find(x=> x.Codigo == oBECliente.Codigo));


            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        void CargarGrillaComprasCliente(BECliente oBECliente)
        {
            this.dataGridViewCompradoClientes.DataSource = null;
            this.dataGridViewCompradoClientes.DataSource = oBECliente.ListaCalefactores;
            this.dataGridViewCompradoClientes.Columns.Remove("Proveedor");
            this.dataGridViewCompradoClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }
    }
}
