using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP3.Entidades;
using TP3.Controladores;
using System.Data.SQLite;
using TP3.Persistencia;

namespace TP3.Persistencia
{
    class pPregunta
    {

        public static List<Pregunta> GetAll()
        {
            List<Pregunta> preguntas = new List<Pregunta>();
            SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM Pregunta");
            cmd.Connection = Conexion.Connection;
            SQLiteDataReader obdr = cmd.ExecuteReader();
            while (obdr.Read())
            {
                Pregunta p = new Pregunta();
                p.Id = obdr.GetInt32(0);
                p.Preguntaa = obdr.GetString(1);
                p.Tema = pTema.GetTemaById(obdr.GetInt32(2));
                preguntas.Add(p);
            }
            return preguntas;
        }

        public static Pregunta GetPreguntaById(int id)
        {
            Pregunta p = new Pregunta();
            SQLiteCommand cmd = new SQLiteCommand("SELECT * from Pregunta where Id=@id");
            cmd.Parameters.Add(new SQLiteParameter("@id", id));
            cmd.Connection = Conexion.Connection;
            SQLiteDataReader obdr = cmd.ExecuteReader();
            while (obdr.Read())
            {
                p.Id = obdr.GetInt32(0);
                p.Preguntaa = obdr.GetString(1);
                p.Tema = pTema.GetTemaById(obdr.GetInt32(2));
            }
            return p;
        }
    }
}
