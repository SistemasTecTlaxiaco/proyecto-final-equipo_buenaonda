﻿using System;
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
    public partial class Frmh : Form
    {
        Modelo modelo = new Modelo();
        int id = 0, id_cajero=0;
        DataRow lstHistorial = null;
        public Frmh()
        {
            InitializeComponent();
            labelUser.Text = Session.usuario;
            h();
            cargar();
           // addListView();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Menu_Click(object sender, EventArgs e)
        {
            frmPrincipal op = new frmPrincipal();
            op.Visible = true;
            this.Visible = false;
        }
        public void addListView()//
        {
            id = Session.id_usuario;

            lstHistorial = modelo.getRow("SELECT fecha, cantidad, movimiento FROM historial WHERE id_usuario='" + id + "'");
            ListViewItem lvItem = new ListViewItem();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            

            lvItem.SubItems[0].Text = lstHistorial[0].ToString();
            lvItem.SubItems.Add(lstHistorial[1].ToString());
            lvItem.SubItems.Add(lstHistorial[2].ToString());
           // lvItem.SubItems.Add(lstHistorial[2].ToString());
           // lvItem.SubItems.Add(lstHistorial[3].ToString());
            //lvItem.SubItems.Add(lstHistorial[5].ToString());

            listView1.Items.Add(lvItem);

        }//
        public void cargar()
        {
            id = Session.id_usuario;
            id_cajero = Session.i;
            MySqlConnection conexion = Conexion.getConexion();
            conexion.Open();
            DataSet ds = new DataSet();
            DataTable table = new DataTable();


            string sql = ("SELECT fecha, cantidadH, movimiento, ubicacion FROM historial INNER JOIN cajero ON historial.id_cajero=cajero.id_cajero WHERE id_usuario LIKE '" + id + "'");

            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conexion);
            adapter.Fill(ds);
            table = ds.Tables[0];
            this.listView1.Items.Clear();
            for (int i = 0; i < table.Rows.Count; i++)
            {

                DataRow filas = table.Rows[i];

                ListViewItem lvItem = new ListViewItem(filas[0].ToString());
                lvItem.SubItems.Add(filas[1].ToString());
                lvItem.SubItems.Add(filas[2].ToString());
                lvItem.SubItems.Add(filas[3].ToString());

                listView1.Items.Add(lvItem);


            }


        }

        public void ex()
        {
            MySqlDataReader reader;
            MySqlConnection conexion = Conexion.getConexion();
            conexion.Open();

            string sql = "SELECT id_cajero FROM historial WHERE user LIKE @usuario";
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            //   comando.Parameters.AddWithValue("@usuario", usuario);

            reader = comando.ExecuteReader();

            Usuarios usr = null;

            while (reader.Read())
            {
                usr = new Usuarios();
                usr.Id = int.Parse(reader["id_usuario"].ToString());
            }

        }
        public void h()
        {
            // Propiedades del ListView
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;

            //Columnas
            
            listView1.Columns.Add("Fecha", 150, HorizontalAlignment.Left);
            listView1.Columns.Add("Cantidad", 80, HorizontalAlignment.Left);
            listView1.Columns.Add("Movimiento", 110, HorizontalAlignment.Left);
            listView1.Columns.Add("Ubicación", 150, HorizontalAlignment.Left);

        }
    }
}
