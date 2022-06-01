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
    public partial class frmTransferir : Form
    {
        int cantidad = 0, id = 0, i = 0;
        string cuenta = "";
        Modelo modelo = new Modelo();
        public frmTransferir()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            frmPrincipal op = new frmPrincipal();
            op.Visible = true;
            this.Visible = false;
        }

        private void btnTrans_Click(object sender, EventArgs e)
        {
            transferir();
        }
        public void transferir()
        {
            cuenta = txtCuenta.Text;
            cantidad = int.Parse(txtMontoT.Text);
            id = Session.id_usuario;
            if (string.IsNullOrEmpty(cantidad.ToString()) || string.IsNullOrEmpty(cuenta))
            {
                MessageBox.Show("Debe ingresar la cuenta receptora y el monto de envio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (modelo.existeCuenta(cuenta))
                {
                    MySqlConnection conexion = Conexion.getConexion();
                    conexion.Open();

                    String query = "UPDATE usuarios SET saldo = (saldo + @cantidad) WHERE cuenta LIKE @cuenta";
                    MySqlCommand comando = new MySqlCommand(query, conexion);
                    comando.Parameters.AddWithValue("@cantidad", cantidad);
                    comando.Parameters.AddWithValue("@cuenta", cuenta);
                    int resultado = comando.ExecuteNonQuery();

                    String query1 = "UPDATE usuarios SET saldo = (saldo - @cantidad) WHERE id_usuario LIKE @id";
                    MySqlCommand comando1 = new MySqlCommand(query1, conexion);
                    comando1.Parameters.AddWithValue("@cantidad", cantidad);
                    comando1.Parameters.AddWithValue("@id", id);
                    int resultado1 = comando1.ExecuteNonQuery();

                    try
                    {
                        if ((resultado == 1) && (resultado1 == 1))
                        {
                            MessageBox.Show("Transferencia exitosa");

                            i = Session.i;
                            string Date = DateTime.Now.ToString("G");
                            string op = "Transferencia";
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
                else
                {
                    MessageBox.Show("El número de cuenta no existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }
        public void date()
        {
            string Date = DateTime.Now.ToString("G");
            string op = "";

        }
    }
}
