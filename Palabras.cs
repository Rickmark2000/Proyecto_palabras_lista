using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_palabras_lista
{
    public class Palabras
    {
            private List<Palabra> palabras_lista;
            private Palabra palabra;
            private int cantidad;
            private int limite;
            private Aleatorio random;
            private Fichero fichero;


            public Palabras(int limite)
            {
                this.limite = limite;
                palabras_lista = new List<Palabra>();
                cantidad = 0;
                random = new Aleatorio();
                fichero = new Fichero();
            }
            //se usan los region para que secciones del código ocupen menos espacio
            #region "---------------PEDIR DATOS USUARIO---------------"
            private string pedir_dato()
            {
                return Console.ReadLine();
            }

            private string pedir_palabra()
            {
                string palabra = "";
                Console.WriteLine("Introduce la palabra");

                try
                {
                    palabra = Console.ReadLine();
                }
                catch (NullReferenceException)
                {
                    Console.WriteLine("No valido");
                }
                return palabra;
            }

            private int pedir_id()
            {
                int id = 0;
                Console.WriteLine("Introduce el id");
                id = Convert.ToInt32(Console.ReadLine());
                return id;
            }

            private int pedir_nivel()
            {
                int nivel = 0;
                Console.WriteLine("Introduce el nivel");
                nivel = Convert.ToInt32(Console.ReadLine());
                return nivel;
            }
            #endregion

            #region "------------CREAR PALABRA-------------------"
            public Palabra crear_palabra()
            {
                bool valido = false;
                Palabra palabra;
                string respuesta = "";

                do
                {
                    palabra = new Palabra(pedir_palabra(),
                        pedir_id(),
                        pedir_nivel()
                    );

                    anadir_palabra(palabra);
                    Console.WriteLine("¿Añadir otro mas?");
                    respuesta = Console.ReadLine();
                if (palabras_lista.Count<limite)
                {
                    valido = respuesta == "si" ? true : false;
                }
                else
                {
                    valido = false;
                }


            } while (valido);

                return palabra;
            }

            private void anadir_palabra(Palabra p)
            {
                bool continuar = true;
                string respuesta = "";

                if (p != null)
                {
                    palabras_lista.Add(p);
                    Console.WriteLine(cantidad);
                    cantidad++;
                }
            }
            #endregion

            public void eliminar_palabra(int idPalabra)
            {
                if (cantidad != 0)
                {
                    bool encontrado = false;
                    int posicion = 0;
                    
                    while (posicion < limite && !encontrado)
                    {
                        if (idPalabra == palabras_lista[posicion].Id)
                        {
                            encontrado = true;
                        }
                        else
                        {
                            posicion++;
                        }

                    }

                    if (!encontrado)
                    {
                        Console.WriteLine("No existe");
                    }
                    else
                    {

                        palabras_lista.RemoveAt(posicion);
                        cantidad--;
                        Console.WriteLine("Borrado completo");
                    }
                }
            }

            public void vaciar_palabras()
            {
                palabras_lista.Clear();
                cantidad = 0;
            }


            public void mostrar_palabras()
            {

                foreach(Palabra palabra in palabras_lista)
                {
                  Console.WriteLine("palabra: " + palabra.PalabrA);
                }

            }

            public void buscar_palabra()
            {
                int buscar = 0;

                Console.WriteLine("Capacidad actual de " + palabras_lista.Count
                + "\n ¿que palabra desea buscar?");
                buscar = Convert.ToInt32(Console.ReadLine());
                //se reduce buscar para que al introducir 1 se busque la posición cero
                buscar -= 1;

                if (buscar < palabras_lista.Count)
                {
                        Console.WriteLine("Palabra: " + palabras_lista.ElementAt(buscar).PalabrA +
                            "\n ID: " + palabras_lista.ElementAt(buscar).Id);
                }
                else
                {
                    Console.WriteLine("EL TAMAÑO MÁXIMO ERA DE " + limite);
                }

            }

        public void mostrar_palabra_aleatoria()
        {
            int num = 0;
            Aleatorio aleatorio = new Aleatorio();
            num = aleatorio.aleatorio(palabras_lista.Count);
            if (num < palabras_lista.Count)
            {
                if (palabras_lista.Contains(palabras_lista.ElementAt(num)))
                {
                    Console.WriteLine("La palabra es: " + palabras_lista.ElementAt(num).PalabrA);
                    determinar_nivel(palabras_lista.ElementAt(num));
                }
                else
                {
                    Console.WriteLine("Es un numero demasiado grande");
                }

            }
        }

            private void determinar_nivel(Palabra palabra)
            {
                Console.WriteLine("El nivel actual es: " + palabra.Nivel);

            }

            public void gestionar_fichero()
            {
                string nombreFichero = "";
                int op = 0;
                List<Palabra> palabras2;

                Console.WriteLine("introduce el nombre del archivo");
                nombreFichero = pedir_dato();

                Console.WriteLine("1- Crear fichero" +
                    "\n2- leer fichero" +
                    "\n3- cargar archivo" +
                    "\n4- borrar archivo");
                op = Convert.ToInt32(pedir_dato());

                switch (op)
                {
                    case 1:
                        fichero.generar_fichero(nombreFichero, palabras_lista);
                        break;
                    case 2:
                        fichero.mostrar_archivo(nombreFichero);
                        break;
                    case 3:
                        palabras_lista = fichero.cargar_archivo(nombreFichero);
                        break;
                    case 4:
                        fichero.borrar_fichero(nombreFichero, palabras_lista);
                        break;
                    default:
                        Console.WriteLine("!NO ES UNA OPCION VALIDA!");
                        break;

                }
            }
            public void guardado_salida()
            {
                /*como al salir se tiene que 
                 * "machar" el archivo, se pregunta al usuario si desea guarddar
                 * 
                 */
                string nombreFichero = "", respuesta = "";
                bool respuesta_salida;

                Console.WriteLine("¿Desea guardar los datos?");
                respuesta = pedir_dato();

                respuesta_salida = respuesta == ("si") ? true : false;

                if (respuesta_salida)
                {
                    Console.WriteLine("introduce el archivo para guardar datos");
                    nombreFichero = pedir_dato();
                    fichero.generar_fichero(nombreFichero, palabras_lista);
                }
            }
        }
}
