using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3
{
    class Respuestas
    {
        int id;
        string respuesta;
        Boolean clave;

        public Respuestas(int id, string respuesta, bool clave)
        {
            this.id = id;
            this.respuesta = respuesta;
            this.clave = clave;
        }

        public int Id { get => id; set => id = value; }
        public string Respuesta { get => respuesta; set => respuesta = value; }
        public bool Clave { get => clave; set => clave = value; }
    }
}
