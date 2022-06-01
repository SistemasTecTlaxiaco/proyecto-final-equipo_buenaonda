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
            
                
            
        }
        public void cargarSaldo()
        {
            
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
