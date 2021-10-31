using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3
{
    class Usuario
    {
        int id;
        string nombre;
        int puntos;
        string password;

        public Usuario()
        {
        }

        public Usuario(int id, string nombre, string password, int puntos)
        {
            this.id = id;
            this.nombre = nombre;
            this.password = password;
            this.puntos = puntos;
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int Puntos { get => puntos; set => puntos = value; }
        public string Password { get => password; set => password = value; }
    }
}