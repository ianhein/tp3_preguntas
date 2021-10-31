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
        int password;
        List<Respuestas> respuestasc;

        public Usuario(int id, string nombre, int puntos, List<Respuestas> respuestasc)
        {
            this.id = id;
            this.nombre = nombre;
            this.puntos = puntos;
            this.Respuestasc = respuestasc;
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int Puntos { get => puntos; set => puntos = value; }
        public int Password { get => password; set => password = value; }
        public List<Respuestas> Respuestasc { get => respuestasc; set => respuestasc = value; }
    }
}
