using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Sistema
{
    class Control
    {
        public string ctrlRegistro(Usuarios usuario)
        {
            Modelo modelo = new Modelo();
            string respuesta = "";

            if(string.IsNullOrEmpty(usuario.Usuario) || string.IsNullOrEmpty(usuario.Password)||string.IsNullOrEmpty(usuario.Cuenta)||string.IsNullOrEmpty(usuario.saldoM.ToString()) )
            {
                respuesta = "Debe ingresar todos los datos";
            } else
            {
                    if (modelo.existeUsuario(usuario.Usuario))
                    {
                        respuesta = "El usuario ya existe";
                    } else
                    {
                        usuario.Password = generarSHA1(usuario.Password);
                        modelo.registro(usuario);
                    }
            }
            return respuesta;
        }
        public string ctrlRegistro2(Cuentas cuenta) ////
        {
            Modelo modelo = new Modelo();
            string respuesta = "";
            

            if (string.IsNullOrEmpty(cuenta.Cuenta) || string.IsNullOrEmpty(cuenta.saldoM.ToString()))
            {
                respuesta = "Debe ingresar todos los datos";
            }
            else
            {
                modelo.registro2(cuenta);
            }
            return respuesta;
        } //

        public string ctrlLogin(string usuario, string password)
        {
            Modelo modelo = new Modelo();
            string respuesta = "";
            Usuarios datosUsuario = null;

            if(string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(password))
            {
                respuesta = "Debe llenar todos los campos";
            } else
            {
                datosUsuario = modelo.porUsuario(usuario);

                if(datosUsuario == null)
                {
                    respuesta = "El usuario no existe";
                } else
                {
                    if(datosUsuario.Password != generarSHA1(password))
                    {
                        respuesta = "El usuario y/o contraseña no coinciden";
                    } else
                    {
                        Session.id_usuario = datosUsuario.Id;
                        Session.usuario = usuario;
                        Session.saldo = datosUsuario.saldoM;
                        
                    }
                }
            }
            return respuesta;
        }


        private string generarSHA1(string cadena)
        {
            UTF8Encoding enc = new UTF8Encoding();
            byte[] data = enc.GetBytes(cadena);
            byte[] result;

            SHA1CryptoServiceProvider sha = new SHA1CryptoServiceProvider();

            result = sha.ComputeHash(data);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {

                if (result[i] < 16)
                {
                    sb.Append("0");
                }
                sb.Append(result[i].ToString("x"));
            }

            return sb.ToString();
        }

    }
}
