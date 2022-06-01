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
    public partial class frmCuentas : Form
    {
        public frmCuentas()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            Cuentas cuenta = new Cuentas();
            
            cuenta.Cuenta = txtNCuenta.Text;
            //cuenta.saldoM = txtSaldo.Text.ToString();

            try
            {

                Control control = new Control();
                string respuesta = control.ctrlRegistro2(cuenta);

                if (respuesta.Length > 0)
                {
                    MessageBox.Show(respuesta, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Cuenta guardada y dada de alta", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmLogin login = new frmLogin();
                    login.Visible = true;
                    this.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
