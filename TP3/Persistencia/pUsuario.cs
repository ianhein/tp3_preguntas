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
    class pUsuario
    {
        public static void Save(Usuario u)
        {

            SQLiteCommand cmd = new SQLiteCommand("INSERT INTO Usuario (Nombre, password, Puntos) VALUES (@nombre, @password, @puntos)");
            cmd.Parameters.Add(new SQLiteParameter("@nombre", u.Nombre));
            cmd.Parameters.Add(new SQLiteParameter("@password", u.Password));
            cmd.Parameters.Add(new SQLiteParameter("@puntos", u.Puntos));
            cmd.Connection = Conexion.Connection;
            cmd.ExecuteNonQuery();

        }
        public static List<Usuario> GetByUser(string nombre, string password)
        {
            List<Usuario> usuarios = new List<Usuario>();

            SQLiteCommand cmd = new SQLiteCommand("SELECT * from Usuario where nombre=@Nombre and password=@password;");
            cmd.Parameters.Add(new SQLiteParameter("@Nombre", nombre));
            cmd.Parameters.Add(new SQLiteParameter("@password", password));
            cmd.Connection = Conexion.Connection;
            SQLiteDataReader obdr = cmd.ExecuteReader();

            while (obdr.Read())
            {
                Usuario u = new Usuario(obdr.GetInt32(0), obdr.GetString(1), obdr.GetString(2), obdr.GetInt32(3));
                usuarios.Add(u);

            }
            return usuarios;
        }

        public static List<Usuario> GetAll()
        {
            List<Usuario> usuarios = new List<Usuario>();
            SQLiteCommand cmd = new SQLiteCommand("SELECT Id, Nombre, password, Puntos FROM Usuario GROUP BY puntos ORDER BY puntos DESC");
            cmd.Connection = Conexion.Connection;
            SQLiteDataReader obdr = cmd.ExecuteReader();
            while (obdr.Read())
            {
                Usuario u = new Usuario();
                u.Id = obdr.GetInt32(0);
                u.Nombre = obdr.GetString(1);
                u.Password = obdr.GetString(2);
                u.Puntos = obdr.GetInt32(3);
                usuarios.Add(u);
            }
            return usuarios;
        }

        public static void Update(Usuario u)
        {
            SQLiteCommand cmd = new SQLiteCommand("UPDATE Usuario SET Puntos = @puntos WHERE Id = @id;");
            cmd.Parameters.Add(new SQLiteParameter("@puntos", u.Puntos));
            cmd.Parameters.Add(new SQLiteParameter("@id", u.Id));
            cmd.Connection = Conexion.Connection;
            cmd.ExecuteNonQuery();
        }

        public static Usuario GetUsuarioById(int id)
        {
            Usuario u = new Usuario();
            SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM Usuario WHERE Id=@id");
            cmd.Parameters.Add(new SQLiteParameter("@id", id));
            cmd.Connection = Conexion.Connection;
            SQLiteDataReader obdr = cmd.ExecuteReader();
            while (obdr.Read())
            {
                u.Id = id;
                u.Nombre = obdr.GetString(1);
                u.Password = obdr.GetString(2);
                u.Puntos = obdr.GetInt32(3);
            }
            return u;
        }
    }
}
