using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema
{
    class Cuentas
    {
        int id_usuario, id_cuenta, estado, saldo;
        string cuenta;
        public string Cuenta { get => cuenta; set => cuenta = value; }
        public int Id_User { get => id_usuario; set => id_usuario = value; }
        public int Id_Cuenta { get => id_cuenta; set => id_cuenta = value; }
        public int State { get => estado; set => estado = value; }
        public int saldoM { get => saldo; set => saldo = value; }

    }
}
