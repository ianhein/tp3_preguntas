using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3
{
    class Preguntas
    {
        int id;
        string pregunta;
        List<Respuestas> respuestasp;

        public Preguntas(int id, string pregunta, List<Respuestas> respuestasp)
        {
            this.Id = id;
            this.Pregunta = pregunta;
            this.Respuestasp = respuestasp;
        }

        public int Id { get => id; set => id = value; }
        public string Pregunta { get => pregunta; set => pregunta = value; }
        public List<Respuestas> Respuestasp { get => respuestasp; set => respuestasp = value; }
    }
}
