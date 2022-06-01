using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema
{
    class Usuarios
    {
        int id_usuario, estado, saldo;
        string user, password, cuenta;
        
        
        public string Cuenta { get => cuenta; set => cuenta = value; }
        public int State { get => estado; set => estado = value; }
        public int saldoM { get => saldo; set => saldo = value; }
        public string Usuario { get => user; set => user = value; }
        public string Password { get => password; set => password = value; }
        public int Id { get => id_usuario; set => id_usuario = value; }
    }
}
