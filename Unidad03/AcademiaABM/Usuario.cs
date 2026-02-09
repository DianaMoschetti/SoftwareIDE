using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaABM
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string User { get; set; }
        public string Email { get; set; }
        public bool Habilitado { get; set; }


        public Usuario() { }

        public List<Usuario> Listar()
        {            
            List<Usuario> usuarios = new()
            {
                new Usuario
                {
                    Id = 1,
                    Nombre = "Juan",
                    Apellido = "Perez",
                    User = "jperez",
                    Email = "jperez@email.com",
                    Habilitado = true
                },
                new Usuario
                {
                    Id = 2,
                    Nombre = "Maria",
                    Apellido = "Gomez",
                    User = "mgomez",
                    Email = "mgomez@email.com",
                    Habilitado = false
                },
                new Usuario
                {
                    Id = 3,
                    Nombre = "Carlos",
                    Apellido = "Lopez",
                    User = "clopez",
                    Email= "clopez@email.com",
                    Habilitado = true
                }
            };

            return usuarios;

        }
    }
}