using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3.Entidades
{
    class Partida
    {
        int id;
        Usuario usuario;
        Pregunta preguntas;
        int correcto;
        int idTema;
        
        public Partida()
        {

        }

        public Partida(int id, Usuario usuario, Pregunta preguntas, int correcto, int idTema)
        {
            this.id = id;
            this.usuario = usuario;
            this.preguntas = preguntas;
            this.correcto = correcto;
            this.idTema = idTema;
        }

        public int Id { get => id; set => id = value; }
        public int Correcto { get => correcto; set => correcto = value; }
        public Usuario Usuario { get => usuario; set => usuario = value; }
        public Pregunta Preguntas { get => preguntas; set => preguntas = value; }
        public int IdTema { get => idTema; set => idTema = value; }
    }
}
