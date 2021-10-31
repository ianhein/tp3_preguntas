using System;
using System.Collections.Generic;
using TP3.Entidades;
using TP3.Persistencia;
using MenuPrincipal;
using System.Threading;


namespace TP3.Controladores
{
    class nPartida
    {
        public static List<Partida> actual = new List<Partida>();

        public static void GenerarPreguntas()//porque se repite?
        {
            List<Pregunta> tempPreg = pPregunta.GetAll();
            Random random = new Random();
            int i = 0;
            int a = 4;//agregar aqui el maximo de preguntas

            while (i < 3)
            {
                Console.Clear();
                
                Pregunta preg = new Pregunta();
                int ranInt = (Int32)random.Next(1, a);
                preg = tempPreg[ranInt];
                List<Respuesta> tempResp = pRespuesta.GetRespuestaByIdPregunta(preg.Id);

                Console.WriteLine("{0}- {1}?", preg.Id, preg.Preguntaa); //falta imprimir las respuestas

                foreach (Respuesta resp in tempResp)
                {
                    Console.WriteLine("-{0} Respuesta: {1}", resp.Id, resp.Respuestaa);
                }

                Console.WriteLine("Seleccione una respuesta");
                int responder = Herramientas.LeerEntero(11, 55);
                Respuesta r = pRespuesta.GetRespuestaById(responder);
                ValidarRespuesta(r);
                tempPreg.RemoveAt(ranInt);
                a = a - 1;
                i = i + 1;
            }Puntaje();
        }

        public static void Puntaje()
        {
            int puntos = 0;
            Usuario u = pUsuario.GetUsuarioById(Program.idusuario);

            foreach (Partida p in actual)
            {
                Console.WriteLine("Pregunta: {0}, {1}", p.Preguntas.Preguntaa, p.Correcto == 0 ? "Incorrecto" : "Correcto");
            if (p.Correcto == 1)
                {
                    puntos += 10;
                }
            }
            Console.WriteLine("Total de puntos: {0}", puntos);
            actual.RemoveRange(0, actual.Count);
            Console.ReadKey();
            nUsuario.Menu();
        }

        public static void ValidarRespuesta(Respuesta r)
        {
            int id = 10000;
            Usuario u = pUsuario.GetUsuarioById(Program.idusuario);
            if (r.Correcto == 1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("La respuesta es correcta");
                Thread.Sleep(500);
                Console.WriteLine(".");
                Thread.Sleep(250);
                Console.WriteLine(".");
                Thread.Sleep(150);
                Console.WriteLine(".");
                Thread.Sleep(50);
                Console.ForegroundColor = ConsoleColor.Gray;
                u.Puntos += 10;
                pPartida.Save(r.Preguntaa, r);
                Partida p = new Partida(id, u, r.Preguntaa, 1, r.Preguntaa.Tema.Id);
                actual.Add(p);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("La respuesta es incorrecta");
                Thread.Sleep(500);
                Console.WriteLine(".");
                Thread.Sleep(250);
                Console.WriteLine(".");
                Thread.Sleep(150);
                Console.WriteLine(".");
                Thread.Sleep(50);
                Console.ForegroundColor = ConsoleColor.Gray;
                Partida p = new Partida(id, u, r.Preguntaa, 0, r.Preguntaa.Tema.Id);
                actual.Add(p);
            }
            pUsuario.Update(u);
        }

        public static List<Usuario> ListarPorPuntos()
        {
            List<Usuario> usuarios = pUsuario.GetAll();
            foreach (Usuario u in usuarios)
            {
                Console.WriteLine("Nombre: {0}  Puntos: {1}", u.Nombre, u.Puntos);
            }
            return usuarios;
        }

        public static List<string> RankingXTema(int idtema)
        {
            List<string> u = new List<string>();

            for(int i = 0; i < pPartida.GetUsuariosPorTema(idtema).Count; i++)
            {
                String s = pPartida.GetUsuariosPorTema(idtema)[i].Usuario.Nombre;
                u.Add(s);
            }
            return u;
        }
        public static void ImprimirUsuariosxTema()
        {
            Console.WriteLine("Ingrese un id tema: ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < RankingXTema(n).Count; i++)
            {
                Console.WriteLine("Nombre: " + RankingXTema(n)[i]);
            }
        }
    }
}