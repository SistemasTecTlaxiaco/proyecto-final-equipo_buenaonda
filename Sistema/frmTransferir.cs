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
            
        }
        public void date()///
        {
            string Date = DateTime.Now.ToString("G");
            string op = "";

        }
    }
}
