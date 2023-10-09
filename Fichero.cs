using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_palabras_lista
{
    public class Fichero
    {
        private string ruta_archivo;
        //se almacenan los datos para cargarlos posteriormente        
        private List<Palabra> almacenar_palabras;
        //variables empleadas para almacenar lo que contiene el fichero para separarlos con un split
        private List<string> contenido_archivo, separador_datos;

        public void generar_fichero(string nombre_fichero, List<Palabra> palabras)
        {
            ruta_archivo = @"C:\Users\ricardsanchez\Desktop\" + nombre_fichero;
            if (!File.Exists(ruta_archivo))
            {
                contenido_fichero(palabras);
            }
            else
            {
                File.Delete(ruta_archivo);
                contenido_fichero(palabras);
            }
        }

        private void contenido_fichero(List<Palabra> palabras)
        {

            using (StreamWriter sw = File.CreateText(ruta_archivo))
            {
                for (int i = 0; i < palabras.Count; i++)
                {
                    if (palabras[i] != null)
                    {
                        sw.WriteLine("ID: " + palabras[i].Id
                        + " ,Palabra: " + palabras[i].PalabrA
                        + " ,Nivel: " + palabras[i].Nivel);
                    }
                }
                Console.WriteLine("Fichero creado");

            }

        }

        public void mostrar_archivo(string nombre_fichero)
        {
            int posicion = 0;
            ruta_archivo = @"C:\Users\ricardsanchez\Desktop\" + nombre_fichero;

            if (File.Exists(ruta_archivo))
            {
                using (StreamReader sr = File.OpenText(ruta_archivo))
                {
                    string leer;
                    while ((leer = sr.ReadLine()) != null)
                    {
                        posicion++;
                        Console.WriteLine(leer);
                    }
                    almacenar_palabras = new List<Palabra>();
                    contenido_archivo = new List<string>();
                }
            }
            else
            {
                Console.WriteLine("¡NO EXISTE ARCHIVO PARA LEER!");
            }

        }

        private void guardar_palabras()
        {
            using (StreamReader sr = File.OpenText(ruta_archivo))
            {
                string leer, palabra = "";
                //cont se usa para incrementar individualmente el array donde se almacenan los coches
                int posicion = 0, id = 0, nivel = 0, cont = 0;

                while ((leer = sr.ReadLine()) != null)
                {
                    contenido_archivo.Add(leer);
                    separador_datos = contenido_archivo.ElementAt(posicion).Split(" ").ToList();
                    //como se usa un split se prepara el for para que solo se almacenen en variables
                    //los datos buscados
                    for (int i = 1; i < separador_datos.Count; i += 8)
                    {
                        id = Convert.ToInt32(separador_datos.ElementAt(i));
                        palabra = separador_datos.ElementAt(i+2);
                        nivel = Convert.ToInt32(separador_datos.ElementAt(i + 4));

                        almacenar_palabras.Add(new Palabra(palabra, id, nivel));
                        cont++;
                    }
                    posicion++;
                }

            }
        }

        public List<Palabra> cargar_archivo(string nombreFichero)
        {
            mostrar_archivo(nombreFichero);
            guardar_palabras();


            return almacenar_palabras;
        }

        public void borrar_fichero(string nombreFichero, List<Palabra> palabras)
        {
            ruta_archivo = @"C:\Users\ricardsanchez\Desktop\" + nombreFichero;

            if (File.Exists(ruta_archivo))
            {
                File.Delete(ruta_archivo);
                Console.WriteLine("Introduce el nombre del nuevo fichero");
                nombreFichero = Console.ReadLine();
                generar_fichero(nombreFichero, palabras);
            }
            else
            {
                Console.WriteLine("¡NO EXISTE ARCHIVO PARA BORRAR!");
            }


        }


    }
}
