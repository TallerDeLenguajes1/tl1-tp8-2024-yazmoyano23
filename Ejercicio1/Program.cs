// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System;
using System.Collections.Generic;
using espacioTarea;
class Program {
        static void Main(string[] args)
        {   
            List<Tarea> tareasPendientes = CrearLista(3); //Modificar a N

            mostrarLista(tareasPendientes,"LISTA INICIAL");

            List<Tarea> tareasRealizadas = MoverPendientesARealizadas(tareasPendientes);

            mostrarLista(tareasPendientes,"LISTA TAREAS PENDIENTES");
            mostrarLista(tareasRealizadas,"LISTA TAREAS REALIZADAS");

            Console.WriteLine("\nBuscar tarea pendiente... (SI:S NO:N) ");
            string resp = Console.ReadLine();
            if (resp == "S")
            {
                Console.WriteLine("Ingrese la descripcion de la tarea a buscar:");
                string tareaBuscar = Console.ReadLine();
                foreach (var Tarea in tareasPendientes)
                {
                    if (tareaBuscar == Tarea.Descripcion) {
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine("Informacion de tarea:");
                        Console.WriteLine("ID: " + Tarea.TareaID);
                        Console.WriteLine("Descripción: " + Tarea.Descripcion);
                        Console.WriteLine("Duración: " + Tarea.Duracion);
                    } 
                }

            } else {
                Console.WriteLine("FIN");
            }
        }

        // Método estático que crea una lista de tareas
        static List<Tarea> CrearLista(int cantidad)
        {
            Random random = new Random();
            string[] descripciones = { "Preparar informes", "Preparar Documentación", "Programar tareas" };

            List<Tarea> lista = new List<Tarea>();

            for (int i = 0; i < cantidad; i++)
            {
                int id = i + 1;
                int duracion = random.Next(1, 61);
                string descripcion = descripciones[random.Next(descripciones.Length)];
                Tarea tarea = new Tarea(id, descripcion, duracion);
                lista.Add(tarea);
            }

            return lista;
        }

    static List<Tarea> MoverPendientesARealizadas(List<Tarea> lista1)
    {
        List<Tarea> lista2 = new List<Tarea>();
        List<Tarea> tareasAEliminar = new List<Tarea>();

        foreach (var tarea in lista1)
        {
            Console.WriteLine($"\n¿Se realizó la tarea {tarea.TareaID}: {tarea.Descripcion}? S = SI");
            string resp = Console.ReadLine();

            if (resp == "S")
            {
                lista2.Add(tarea);           // Agregar la tarea a la nueva lista
                tareasAEliminar.Add(tarea);  // Marcar la tarea para eliminarla más tarde
            }
        }

        // Eliminar las tareas después de iterar
        foreach (var tarea in tareasAEliminar)
        {
            lista1.Remove(tarea);
        }

        return lista2;
    }

    static void mostrarLista(List<Tarea> lista, string nombrelista){
        Console.WriteLine("\n" + nombrelista);
        foreach (var tarea in lista)
        {
            Console.WriteLine($"ID: {tarea.TareaID} - DESCRIPCION: {tarea.Descripcion} - DURACION: {tarea.Duracion} minutos");
        }
    } 

}