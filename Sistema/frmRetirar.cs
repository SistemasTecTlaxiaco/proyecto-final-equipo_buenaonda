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
    public partial class frmRetirar : Form
    {
        int cantidad = 0, id = 0, saldo=0, cant=0, dato=0, i=0;
        int b1000 = 0, b500 = 0, b200 = 0, b100 = 0, b50 = 0, b20 = 0;
        int m10 = 0, m5 = 0, m2 = 0, m1 = 0;
        string caa = "";
        public frmRetirar()
        {
            InitializeComponent();
            cargarSaldo();
            vacio();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            frmPrincipal op = new frmPrincipal();
            op.Visible = true;
            this.Visible = false;
            vacio();
        }

        private void btnRet_Click(object sender, EventArgs e)
        {
            retirar();
        }
        public void retirar()
        {
            cantidad = int.Parse(txtMontoT.Text);
            // cantidad = txtMontoT.Text.Value
            caa = txtMontoT.Text;
            // cantidad = Convert.ToInt32(txtMontoT.Text);

            id = Session.id_usuario;
            saldo = Convert.ToInt32(labelSaldo.Text);
            if (cantidad < 0)
            {
                MessageBox.Show("Debe ingresar la cantidad a retirar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (cantidad >= saldo)
                {
                    MessageBox.Show("Ingrese una cantidad menor a su saldo actual", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MySqlConnection conexion = Conexion.getConexion();
                    conexion.Open();
                    String query = "UPDATE usuarios SET saldo = (saldo - @cantidadd) WHERE id_usuario LIKE @id_usuario ";
                    MySqlCommand comando = new MySqlCommand(query, conexion);
                    comando.Parameters.AddWithValue("@cantidadd", cantidad);
                    comando.Parameters.AddWithValue("@id_usuario", id);
                    int resultado = comando.ExecuteNonQuery();
                    try
                    {
                        if (resultado == 1)
                        {
                            cant += cantidad;
                            b1000 = (cantidad / 1000);
                            cantidad -= b1000 * 1000;
                            b500 = (cantidad / 500);
                            cantidad -= b500 * 500;
                            b200 = (cantidad / 200);
                            cantidad -= b200 * 200;
                            b100 = (cantidad / 100);
                            cantidad -= b100 * 100;
                            b50 = (cantidad / 50);
                            cantidad -= b50 * 50;
                            b20 = (cantidad / 20);
                            cantidad -= b20 * 20;
                            m10 = (cantidad / 10);
                            cantidad -= m10 * 10;
                            m5 = (cantidad / 5);
                            cantidad -= m5 * 5;
                            m2 = (cantidad / 2);
                            cantidad -= m2 * 2;
                            m1 = (cantidad / 1);
                            cantidad -= m1 * 1;

                            MessageBox.Show("Retiro exitoso, Usted recibirá la siguiente cantidad: ");
                            labelR.Text = "Retiraste:";
                            labelRC.Text = caa.ToString();
                            i = Session.i;
                            string Date = DateTime.Now.ToString("G");
                            string op = "Retiro";
                            string sql = "INSERT INTO historial (id_usuario, id_cajero, fecha, cantidadH, movimiento) VALUES(@id_usuario, @id_cajero, @fecha, @cantidad, @movimiento)";
                            MySqlCommand comand = new MySqlCommand(sql, conexion);
                            comand.Parameters.AddWithValue("@id_usuario", id);
                            comand.Parameters.AddWithValue("@id_cajero", i);
                            comand.Parameters.AddWithValue("@fecha", Date);
                            comand.Parameters.AddWithValue("@cantidad", caa);
                            comand.Parameters.AddWithValue("@movimiento", op);

                            int res = comand.ExecuteNonQuery();

                            if (b1000 > 0)
                            {
                                cargarSaldo();
                                labelB1000.Text = "Billete(s) de 1000:";
                                label1000B.Text = b1000.ToString();
                                dato = 1;
                                String query1 = "UPDATE cajero SET cantidad = (cantidad - @cant) WHERE id_cajero LIKE @id_cajero";
                                MySqlCommand comando1 = new MySqlCommand(query1, conexion);
                                comando1.Parameters.AddWithValue("@cant", b1000);
                                comando1.Parameters.AddWithValue("@id_cajero", dato);
                                int resultado1 = comando1.ExecuteNonQuery();
                            }
                            if (b500 > 0)
                            {
                                cargarSaldo();
                                labelB500.Text = "Billete(s) de 500:";
                                label500B.Text = b500.ToString();
                                dato = 2;
                                String query2 = "UPDATE cajero SET cantidad = (cantidad - @cant) WHERE id_cajero LIKE @id_cajero";
                                MySqlCommand comando2 = new MySqlCommand(query2, conexion);
                                comando2.Parameters.AddWithValue("@cant", b500);
                                comando2.Parameters.AddWithValue("@id_cajero", dato);
                                int resultado2 = comando2.ExecuteNonQuery();
                            }
                            if (b200 > 0)
                            {
                                cargarSaldo();
                                labelB200.Text = "Billete(s) de 200:";
                                label200B.Text = b200.ToString();
                                dato = 3;
                                String query3 = "UPDATE cajero SET cantidad = (cantidad - @cant) WHERE id_cajero LIKE @id_cajero";
                                MySqlCommand comando3 = new MySqlCommand(query3, conexion);
                                comando3.Parameters.AddWithValue("@cant", b200);
                                comando3.Parameters.AddWithValue("@id_cajero", dato);
                                int resultado3 = comando3.ExecuteNonQuery();
                            }
                            if (b100 > 0)
                            {
                                cargarSaldo();
                                labelB100.Text = "Billete(s) de 100:";
                                label100B.Text = b100.ToString();
                                dato = 4;
                                String query4 = "UPDATE cajero SET cantidad = (cantidad - @cant) WHERE id_cajero LIKE @id_cajero";
                                MySqlCommand comando4 = new MySqlCommand(query4, conexion);
                                comando4.Parameters.AddWithValue("@cant", b100);
                                comando4.Parameters.AddWithValue("@id_cajero", dato);
                                int resultado4 = comando4.ExecuteNonQuery();
                            }
                            if (b50 > 0)
                            {
                                cargarSaldo();
                                labelB50.Text = "Billete(s) de 50:";
                                label50B.Text = b50.ToString();
                                dato = 5;
                                String query5 = "UPDATE cajero SET cantidad = (cantidad - @cant) WHERE id_cajero LIKE @id_cajero";
                                MySqlCommand comando5 = new MySqlCommand(query5, conexion);
                                comando5.Parameters.AddWithValue("@cant", b50);
                                comando5.Parameters.AddWithValue("@id_cajero", dato);
                                int resultado5 = comando5.ExecuteNonQuery();
                            }
                            if (b20 > 0)
                            {
                                cargarSaldo();
                                labelB20.Text = "Billete(s) de 20:";
                                label20B.Text = b20.ToString();
                                dato = 6;
                                String query6 = "UPDATE cajero SET cantidad = (cantidad - @cant) WHERE id_cajero LIKE @id_cajero";
                                MySqlCommand comando6 = new MySqlCommand(query6, conexion);
                                comando6.Parameters.AddWithValue("@cant", b20);
                                comando6.Parameters.AddWithValue("@id_cajero", dato);
                                int resultado6 = comando6.ExecuteNonQuery();
                            }
                            if (m10 > 0)
                            {
                                cargarSaldo();
                                labelM10.Text = "Moneda(s) de 10:";
                                label10M.Text = m10.ToString();
                                dato = 7;
                                String query7 = "UPDATE cajero SET cantidad = (cantidad - @cant) WHERE id_cajero LIKE @id_cajero";
                                MySqlCommand comando7 = new MySqlCommand(query7, conexion);
                                comando7.Parameters.AddWithValue("@cant", m10);
                                comando7.Parameters.AddWithValue("@id_cajero", dato);
                                int resultado7 = comando7.ExecuteNonQuery();
                            }
                            if (m5 > 0)
                            {
                                cargarSaldo();
                                labelM5.Text = "Moneda(s) de 5:";
                                label5M.Text = m5.ToString();
                                dato = 8;
                                String query8 = "UPDATE cajero SET cantidad = (cantidad - @cant) WHERE id_cajero LIKE @id_cajero";
                                MySqlCommand comando8 = new MySqlCommand(query8, conexion);
                                comando8.Parameters.AddWithValue("@cant", m5);
                                comando8.Parameters.AddWithValue("@id_cajero", dato);
                                int resultado8 = comando8.ExecuteNonQuery();
                            }
                            if (m2 > 0)
                            {
                                cargarSaldo();
                                labelM2.Text = "Moneda(s) de 2:";
                                label2M.Text = m2.ToString();
                                dato = 9;
                                String query9 = "UPDATE cajero SET cantidad = (cantidad - @cant) WHERE id_cajero LIKE @id_cajero";
                                MySqlCommand comando9 = new MySqlCommand(query9, conexion);
                                comando9.Parameters.AddWithValue("@cant", m2);
                                comando9.Parameters.AddWithValue("@id_cajero", dato);
                                int resultado9 = comando9.ExecuteNonQuery();
                            }
                            if (m1 > 0)
                            {
                                cargarSaldo();
                                labelM1.Text = "Moneda(s) de 1:";
                                label1M.Text = m1.ToString();
                                dato = 10;
                                String query10 = "UPDATE cajero SET cantidad = (cantidad - @cant) WHERE id_cajero LIKE @id_cajero";
                                MySqlCommand comando10 = new MySqlCommand(query10, conexion);
                                comando10.Parameters.AddWithValue("@cant", m1);
                                comando10.Parameters.AddWithValue("@id_cajero", dato);
                                int resultado7 = comando10.ExecuteNonQuery();
                            }

                        }
                        else
                        {
                            MessageBox.Show("ERROR, NO se pudo retirar");
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
        public void cargarSaldo()
        {
            id = Session.id_usuario;
            MySqlDataReader reader;
            MySqlConnection conexion = Conexion.getConexion();

            conexion.Open();
            string query = "SELECT saldo FROM usuarios WHERE id_usuario LIKE @id";
            MySqlCommand comando = new MySqlCommand(query, conexion);
            comando.Parameters.AddWithValue("@id", id);
            reader = comando.ExecuteReader();

            Usuarios usr = null;

            while (reader.Read())
            {
                usr = new Usuarios();
                usr.saldoM = int.Parse(reader["saldo"].ToString());

            }
            labelSaldo.Text = usr.saldoM.ToString();
        }
        public void vacio()
        {
            label1000B.Text = "";
            label500B.Text = "";
            label200B.Text = "";
            label100B.Text = "";
            label50B.Text = "";
            label20B.Text = "";
            label10M.Text = "";
            label5M.Text = "";
            label2M.Text = "";
            label1M.Text = "";
            labelB1000.Text = "";
            labelB500.Text = "";
            labelB200.Text = "";
            labelB100.Text = "";
            labelB50.Text = "";
            labelB20.Text = "";
            labelM10.Text = "";
            labelM5.Text = "";
            labelM2.Text = "";
            labelM1.Text = "";
            labelR.Text = "";
            labelRC.Text = "";

        }
    }
}
