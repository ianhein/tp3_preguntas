using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3.Entidades  
{
    class Pregunta  //falta una lista que guarde las respuestas de la pregunta.
    {
        int id;
        string pregunta;
        Tema tema;

        public Pregunta()
        { }

        public Pregunta(int id, string pregunta, Tema tema, bool validar)
        {
            this.id = id;
            this.pregunta = pregunta;
            this.tema = tema;
        }

        public int Id { get => id; set => id = value; }
        public string Preguntaa { get => pregunta; set => pregunta = value; }
        public Tema Tema { get => tema; set => tema = value; }
    }
}