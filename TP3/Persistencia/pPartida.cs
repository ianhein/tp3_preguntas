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
    class pPartida
    {
        public static void Save(Pregunta p, Respuesta r)
        {
            SQLiteCommand cmd = new SQLiteCommand("INSERT INTO Partida (IdUsuario, IdPregunta, Correcta, idTema) VALUES (@idUsuario, @idPregunta, @Correcta, @idTema)");
            cmd.Parameters.Add(new SQLiteParameter("@idUsuario", Program.idusuario));//porque globales?
            cmd.Parameters.Add(new SQLiteParameter("@idPregunta", p.Id));
            cmd.Parameters.Add(new SQLiteParameter("@Correcta", r.Correcto));
            cmd.Parameters.Add(new SQLiteParameter("@idTema", p.Tema.Id));
            cmd.Connection = Conexion.Connection;
            cmd.ExecuteNonQuery();
        }
        public static List<Partida> GetAllPartidaByUsuario(int id)
        {
            List<Partida> preguntasPartida = new List<Partida>();
            SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM Partida WHERE IdUsuario=@id ");
            cmd.Parameters.Add(new SQLiteParameter("@id", id));
            cmd.Connection = Conexion.Connection;
            SQLiteDataReader obdr = cmd.ExecuteReader();
            while (obdr.Read())
            {
                Partida p = new Partida();
                p.Id = obdr.GetInt32(0);
                p.Usuario = pUsuario.GetUsuarioById(obdr.GetInt32(1));
                p.Preguntas = pPregunta.GetPreguntaById(obdr.GetInt32(2));
                p.IdTema = obdr.GetInt32(3);
                p.Correcto = obdr.GetInt32(4);
                preguntasPartida.Add(p);
            }
            return preguntasPartida;
        }

        public static List<Partida> GetAll()
        {
            List<Partida> partida = new List<Partida>();
            SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM Partida");
            cmd.Connection = Conexion.Connection;
            SQLiteDataReader obdr = cmd.ExecuteReader();
            while (obdr.Read())
            {
                Partida p = new Partida();
                p.Id = obdr.GetInt32(0);
                p.Usuario = pUsuario.GetUsuarioById(obdr.GetInt32(1));
                p.Preguntas = pPregunta.GetPreguntaById(obdr.GetInt32(2));
                p.Correcto = obdr.GetInt32(3);
                p.IdTema = obdr.GetInt32(4);
                partida.Add(p);
            } return partida;
        }

        public static List<Partida> GetUsuariosPorTema(int idtema)
        {
            List<Partida> listas = new List<Partida>();
            SQLiteCommand cmd = new SQLiteCommand("SELECT id, idUsuario, COUNT(idusuario) AS cnt FROM Partida WHERE idTema = @idtema GROUP BY idusuario ORDER BY cnt DESC");
            cmd.Parameters.Add(new SQLiteParameter("@idtema", idtema));
            cmd.Connection = Conexion.Connection;
            SQLiteDataReader obdr = cmd.ExecuteReader();

            while (obdr.Read())
            {
                Partida p = new Partida();
                p.Id = obdr.GetInt32(0);
                p.Usuario = pUsuario.GetUsuarioById(obdr.GetInt32(1));
                p.Preguntas = pPregunta.GetPreguntaById(obdr.GetInt32(2));
                listas.Add(p);
            }
            return listas;
        }
    }
}