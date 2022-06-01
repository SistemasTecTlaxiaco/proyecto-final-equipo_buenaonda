using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema
{
    public partial class frmHistorial : Form
    {
        Modelo modelo = new Modelo();
        int id = 0;
        DataRow lstNombre = null;
        public frmHistorial()
        {
            InitializeComponent();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            frmPrincipal op = new frmPrincipal();
            op.Visible = true;
            this.Visible = false;
        }
        private void Inventario_Load(object sender, EventArgs e)
        {
            // Create an unbound DataGridView by declaring a column count.
            dataGridView1.ColumnCount = 6;
            dataGridView1.ColumnHeadersVisible = true;


            // Set the column header style.
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();

            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Verdana", 8, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

            // Set the column header names.
            dataGridView1.Columns[0].Name = "Id_Op";
            dataGridView1.Columns[1].Name = "Usuario";
            dataGridView1.Columns[2].Name = "Fecha";
            dataGridView1.Columns[3].Name = "Cantidad";
            dataGridView1.Columns[4].Name = "Movimiento";
            dataGridView1.Columns[5].Name = "Ubicación";
         


            // Set the column header width.
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 120;
            dataGridView1.Columns[2].Width = 120;
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[4].Width = 100;
            dataGridView1.Columns[5].Width = 100;
          

            
        }
        public void addProducto()
        {
            id = Session.id_usuario;
            String sql2 = "SELECT user FROM usuarios WHERE id_usuario=" + id;
            DataRow fila = modelo.getRow(sql2);

            String sql3 = (@"select cantidad as can_Vendidas from factura_detalle inner join productos on factura_detalle.producto_id=productos.id where productos.id=" + id);
            DataRow cant_vendidas = modelo.getRow(sql3);

            if (sql3 == null)
            {
                MessageBox.Show("No hay ventas de este producto");
            }
            else
            {
                int canVen = (int)cant_vendidas[0];
                var canIni = (int)fila[2];
                int canFinal = canIni - canVen;
               // dataGridView1.Rows.Add(comboBox1.SelectedValue, fila[0], comboBox1.Text, fila[1], fila[2], cant_vendidas[0], canFinal);
            }
        }
    }
}
