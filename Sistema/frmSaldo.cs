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
    public partial class frmSaldo : Form
    {
        int id = 0, i=0, cantidad=0;
        public frmSaldo()
        {
            InitializeComponent();
            cargarSaldo();
            h();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            frmPrincipal op = new frmPrincipal();
            op.Visible = true;
            this.Visible = false;
        }

        private void frmSaldo_Load(object sender, EventArgs e)
        {

        }

        public void cargarSaldo()
        {
            id = Session.id_usuario;
            MySqlDataReader reader;
            MySqlConnection conexion = Conexion.getConexion();
            
            conexion.Open();
            string query = "SELECT user, saldo FROM usuarios WHERE id_usuario LIKE @id";
            MySqlCommand comando = new MySqlCommand(query, conexion);
            comando.Parameters.AddWithValue("@id", id);
            reader = comando.ExecuteReader();

            Usuarios usr = null;

            while (reader.Read())
            {
                usr = new Usuarios();
                usr.Usuario = reader["user"].ToString();
                usr.saldoM = int.Parse(reader["saldo"].ToString());

                               
            }
            labelUser.Text = usr.Usuario;
            labelSaldo.Text = usr.saldoM.ToString();
            //cantidad = int.Parse(labelSaldo.ToString());

           
        }
        public void h()
        {
            cantidad = int.Parse(labelSaldo.Text);
            MySqlConnection conexion = Conexion.getConexion();
            conexion.Open();
            i = Session.i;
            string Date = DateTime.Now.ToString("G");
            string op = "Consulta de saldo";
            string sql = "INSERT INTO historial (id_usuario, id_cajero, fecha, cantidadH, movimiento) VALUES(@id_usuario, @id_cajero, @fecha, @cantidad, @movimiento)";
            MySqlCommand comand = new MySqlCommand(sql, conexion);
            comand.Parameters.AddWithValue("@id_usuario", id);
            comand.Parameters.AddWithValue("@id_cajero", i);
            comand.Parameters.AddWithValue("@fecha", Date);
            comand.Parameters.AddWithValue("@cantidad", cantidad);
            comand.Parameters.AddWithValue("@movimiento", op);

            int res = comand.ExecuteNonQuery();
        }
    }
}
