using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP3.Entidades;

namespace TP3.Entidades
{
    class Respuesta
    {
        int id;
        string respuesta;
        int correcto; //1 es correcto 0 es incorrecto
        Pregunta pregunta;


        public Respuesta()
        { }

        public Respuesta(int id, string respuesta, int correcto, Pregunta pregunta)
        {
            this.id = id;
            this.respuesta = respuesta;
            this.correcto = correcto;
            this.pregunta = pregunta;
        }

        public int Id { get => id; set => id = value; }
        public string Respuestaa { get => respuesta; set => respuesta = value; }
        public int Correcto { get => correcto; set => correcto = value; }
        public Pregunta Preguntaa { get => pregunta; set => pregunta = value; }
    }
}

