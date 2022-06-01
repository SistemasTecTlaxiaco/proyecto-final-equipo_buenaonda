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
            
        }
    }
}
