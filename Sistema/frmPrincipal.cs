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
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
            jLabelUser.Text = Session.usuario;
            //labelCaj.Text = Session.i.ToString();
        }

        private void btnRetirar_Click(object sender, EventArgs e)
        {
            frmRetirar op = new frmRetirar();
            op.Visible = true;
            this.Visible = false;
        }

        private void btnDepositar_Click(object sender, EventArgs e)
        {
            frmDepositar op = new frmDepositar();
            op.Visible = true;
            this.Visible = false;
        }

        private void btnTransferir_Click(object sender, EventArgs e)
        {
            frmTransferir op = new frmTransferir();
            op.Visible = true;
            this.Visible = false;
        }

        private void btnSaldo_Click(object sender, EventArgs e)
        {
            frmSaldo op = new frmSaldo();
            op.Visible = true;
            this.Visible = false;
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            Frmh op = new Frmh();
            op.Visible = true;
            this.Visible = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            salir();
        }
        public void salir()
        {
                if (MessageBox.Show("Seguro que deseas salir?", "Banco",
                      MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                      == DialogResult.Yes)
                {
                    MessageBox.Show("!!!... Gracias vuelva pronto ...!!!");
                    Application.Exit();
                }
        }
    }
}
