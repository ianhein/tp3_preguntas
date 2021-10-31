using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3
{
    class Tema
    {
        int id;
        string nombre;

        public Tema(int id, string tema)
        {
            this.id = id;
            this.nombre = tema;
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
    }
}
