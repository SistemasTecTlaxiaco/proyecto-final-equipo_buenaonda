using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema
{
    public class Session
    {
        public static int id_usuario, saldo;
        public static string usuario;
        public static Random ob = new Random();
        public static int i = ob.Next(1, 10);
    }
}
