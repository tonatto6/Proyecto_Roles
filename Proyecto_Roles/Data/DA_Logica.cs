using Proyecto_Roles.Models;

namespace Proyecto_Roles.Data
{
    public class DA_Logica
    {
        public List<Usuario> Listar_Usuario()
        {
            //En esta clase la conectamos con la base de datos para leer los usuarios, validarlos, etc.

            return new List<Usuario>
            {
                new Usuario{Correo="administrador@gmail.com", Clave = "123", Roles = new string[]{"Administrador"}},
                new Usuario{Correo="supervisor@gmail.com", Clave = "123", Roles = new string[]{"Supervisor"}},
                new Usuario{Correo="empleado1@gmail.com", Clave = "123", Roles = new string[]{"Empleado"}},
                new Usuario{Correo="empleado2@gmail.com", Clave = "123", Roles = new string[]{"Empleado"}}
            };
        }
    
        public Usuario Validar_Usuario(string correo, string clave)
        {
            return Listar_Usuario().Where(item => item.Correo == correo && item.Clave == clave).FirstOrDefault();
        }
    }
}
