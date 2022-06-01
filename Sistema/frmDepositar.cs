using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Sistema
{
    public partial class frmDepositar : Form
    {
        int cantidad=0, id=0, i=0;
         
        public frmDepositar()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            frmPrincipal op = new frmPrincipal();
            op.Visible = true;
            this.Visible = false;
        }

        private void btnDep_Click(object sender, EventArgs e)
        {
            depositar();
        }
        public void depositar()
        {
            cantidad = Convert.ToInt32(txtMontoT.Text);
            id = Session.id_usuario;
            if (string.IsNullOrEmpty(cantidad.ToString()))
            {
                MessageBox.Show("Debe ingresar la cantidad de depositar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MySqlConnection conexion = Conexion.getConexion();
                conexion.Open();
                String query = "UPDATE usuarios SET saldo = (saldo + @cantidad) WHERE id_usuario LIKE @id ";
                MySqlCommand comando = new MySqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@cantidad", cantidad);
                comando.Parameters.AddWithValue("@id", id);
                int resultado = comando.ExecuteNonQuery();
                try
                {
                    if (resultado == 1)
                    {
                        MessageBox.Show("Deposito Exitoso");
                        Random ob = new Random();
                        i = ob.Next(1, 10);
                        string Date = DateTime.Now.ToString("G");
                        string op = "Deposito";
                        string sql = "INSERT INTO historial (id_usuario, id_cajero, fecha, cantidadH, movimiento) VALUES(@id_usuario, @id_cajero, @fecha, @cantidad, @movimiento)";
                        MySqlCommand comand = new MySqlCommand(sql, conexion);
                        comand.Parameters.AddWithValue("@id_usuario", id);
                        comand.Parameters.AddWithValue("@id_cajero", i);
                        comand.Parameters.AddWithValue("@fecha", Date);
                        comand.Parameters.AddWithValue("@cantidad", cantidad);
                        comand.Parameters.AddWithValue("@movimiento", op);

                        int res = comand.ExecuteNonQuery();

                    }
                    else
                    {
                        MessageBox.Show("ERROR, NO se pudo depositar");
                    }

                    txtMontoT.Text = "";

                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
