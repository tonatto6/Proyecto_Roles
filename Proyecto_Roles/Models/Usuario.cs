﻿namespace Proyecto_Roles.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public string[] Roles { get; set; }
    }
}
