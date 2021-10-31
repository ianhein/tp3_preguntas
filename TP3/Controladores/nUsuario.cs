using System;
using System.Collections.Generic;
using TP3.Persistencia;
using MenuPrincipal;

namespace TP3.Controladores
{
    class nUsuario
    {
        public static void Menu()
        {
            Console.Clear();
            string[] opciones = new string[5] { "Ingresar", "Registrarse", "Ranking General", "Ranking por Tema", "Salir" };
            string titulo = "Juego de preguntas";
            Herramientas.DibujoMenu(titulo, opciones);
            int op = Herramientas.LeerEntero(1, 5);

            switch (op)
            {
                case 1:
                    Ingresar();
                    Console.ReadKey();
                    nPartida.GenerarPreguntas();
                    Menu();
                    break;

                case 2:
                    Registrarse();
                    Menu();
                    break;

                case 3:
                    nPartida.ListarPorPuntos();
                    Console.ReadKey();
                    Menu();
                    break;
                case 4:
                    nPartida.ImprimirUsuariosxTema();
                    Console.ReadKey();
                    Menu();
                    break;
                default:
                    break;
            }


        }

        public static void Ingresar()
        {
            Console.Clear();
            Usuario u = new Usuario();
            Console.WriteLine("Ingrese su nombre de usuario: ");
            u.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese su contraseña: ");
            u.Password = Console.ReadLine();
            List<Usuario> usuarios = pUsuario.GetByUser(u.Nombre, u.Password);
            u.Puntos = Program.puntos;
            u.Id = Program.idusuario;
            pUsuario.Update(u);

            if (usuarios.Count == 1)
            {
                Console.WriteLine("Usuario valido");
                Program.idusuario = usuarios[0].Id;
                nPartida.GenerarPreguntas();
            }
            else
            {
                Console.WriteLine("Usuario incorrecto");
                Console.ReadKey(true);
                Menu();
            }
        }
        public static void Registrarse()//revisar para que se guarde directamente en la BD
        {
            Console.Clear();
            Usuario u = new Usuario();
            Console.WriteLine("Ingrese un nombre de usuario: ");
            u.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese una contraseña: ");
            u.Password = Console.ReadLine();
            foreach(Usuario a in pUsuario.GetAll())
            {
                if (u.Nombre == a.Nombre)
                {
                    Console.WriteLine("Este nombre de Usuario ya esta en uso!");
                    Console.WriteLine("");
                    Registrarse();
                }
            }
            pUsuario.Save(u);//listo
        }
    }
}
