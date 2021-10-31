using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP3.Entidades;
using TP3.Controladores;
using System.Data.SQLite;

namespace TP3.Persistencia
{
    class pRespuesta
    {
        public static List<Respuesta> GetRespuestaByIdPregunta(int id)
        {

            List<Respuesta> respuestas = new List<Respuesta>();

            SQLiteCommand cmd = new SQLiteCommand("SELECT * from Respuesta where IdPregunta=@idPregunta");
            cmd.Parameters.Add(new SQLiteParameter("@idPregunta", id));

            cmd.Connection = Conexion.Connection;
            SQLiteDataReader obdr = cmd.ExecuteReader();

            while (obdr.Read())
            {
                Respuesta r = new Respuesta(obdr.GetInt32(0), obdr.GetString(1), obdr.GetInt32(2), pPregunta.GetPreguntaById(obdr.GetInt32(3)));
                respuestas.Add(r);

            }
            return respuestas;

        }

        public static Respuesta GetRespuestaById(int id)
        {
            Respuesta r = new Respuesta();
            SQLiteCommand cmd = new SQLiteCommand("SELECT * from Respuesta where Id=@id");
            cmd.Parameters.Add(new SQLiteParameter("@id", id));
            cmd.Connection = Conexion.Connection;
            SQLiteDataReader obdr = cmd.ExecuteReader();
            while (obdr.Read())
            {
                r.Id = obdr.GetInt32(0);
                r.Respuestaa = obdr.GetString(1);
                r.Correcto = obdr.GetInt32(2);
                r.Preguntaa = pPregunta.GetPreguntaById(obdr.GetInt32(3));

            }
            return r;


        }
    }
}
