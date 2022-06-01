using MySql.Data.MySqlClient;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema
{
    class Modelo
    {
        public int registro(Usuarios usuario)
        {
            MySqlConnection conexion = Conexion.getConexion();
            conexion.Open();

            string sql = "INSERT INTO usuarios (user, password, cuenta, saldo, estado) VALUES(@user, @password, @cuenta, @saldo, @estado)";
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@user", usuario.Usuario);
            comando.Parameters.AddWithValue("@password", usuario.Password);
            comando.Parameters.AddWithValue("@cuenta", usuario.Cuenta);
            comando.Parameters.AddWithValue("@saldo", usuario.saldoM);
            comando.Parameters.AddWithValue("@estado", 2);

            int resultado = comando.ExecuteNonQuery();

            return resultado;
        }
        public int Query(string sql)
        {
            MySqlConnection conexion = Conexion.getConexion();
            conexion.Open();
            MySqlCommand command = new MySqlCommand(sql, conexion);
            return command.ExecuteNonQuery();
        }
        public DataTable getData(string sql) ///
        {
            MySqlConnection conexion = Conexion.getConexion();
            conexion.Open();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conexion);
            adapter.Fill(table);
   
            return table;
        }//

        //Obtener una fila de la tabla retornada por getData
        public DataRow getRow(string sql)//
        {
            DataRow row = null;
            if (this.getData(sql).Rows.Count == 0)
            {
                return null;
            }
            row = this.getData(sql).Rows[0];
            return row;
        }//
        public int registro2(Cuentas cuenta)//
        {
            MySqlConnection conexion = Conexion.getConexion();
            conexion.Open();
            Modelo modelo = new Modelo();
            Usuarios usuarios = new Usuarios();
            Usuarios datosUsuario = null;
            datosUsuario = modelo.actualUsuario(usuarios.Usuario);
            
            string sql = "INSERT INTO cuentas (id_usuario, cuenta, saldo, estado) VALUES(@id_usuario, @cuenta, @saldo, @estado)";
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@id_usuario", datosUsuario.Id);
            comando.Parameters.AddWithValue("@cuenta", cuenta.Cuenta);
            comando.Parameters.AddWithValue("@saldo", cuenta.saldoM);
            comando.Parameters.AddWithValue("@estado", 1);

            int resultado = comando.ExecuteNonQuery();

            return resultado;
        }//

        public bool existeUsuario(string usuario)
        {
            return false;
        }
        public bool existeCuenta(string cuenta)
        {
            return false;
        }

        public Usuarios porUsuario(string usuario)
        {
            MySqlDataReader reader;
            MySqlConnection conexion = Conexion.getConexion();
            conexion.Open();

            string sql = "SELECT id_usuario, password, saldo FROM usuarios WHERE user LIKE @usuario";
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@usuario", usuario);

            reader = comando.ExecuteReader();

            Usuarios usr = null;

            while (reader.Read())
            {
                usr = new Usuarios();
                usr.Id = int.Parse(reader["id_usuario"].ToString());
                usr.Password = reader["password"].ToString();
                usr.saldoM = int.Parse(reader["saldo"].ToString());
                
            }
            return usr;
        }
        public Usuarios actualUsuario(string usuario)
        {
            MySqlDataReader reader;
            MySqlConnection conexion = Conexion.getConexion();
            conexion.Open();

            string sql = "SELECT id_usuario FROM usuarios WHERE user LIKE @usuario";
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@usuario", usuario);

            reader = comando.ExecuteReader();

            Usuarios usr = null;

            while (reader.Read())
            {
                usr = new Usuarios();
                usr.Id = int.Parse(reader["id_usuario"].ToString());
            }
            return usr;
        }
    }
}
