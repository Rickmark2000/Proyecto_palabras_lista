using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_palabras_lista
{
    public class Program
    {
        static void Main(string[] args)
        {
            int limite = 0, opcion = 0, idBuscar = 0;
            Palabras palabras;

            Console.WriteLine("¿Cual es el limite de palabras?");
            limite = Convert.ToInt32(Console.ReadLine());
            palabras = new Palabras(limite);

            Console.Clear();
            do
            {

                Console.WriteLine("Menu:" +
                    "\n0)Salir" +
                    "\n1)Añadir palabra" +
                    "\n2)Buscar palabra" +
                    "\n3) Eliminar palabra" +
                    "\n4)vaciar palabras" +
                    "\n5)mostrar palabras" +
                    "\n6)Palabra aleatoria" +
                    "\n7)Acceder fichero");

                opcion = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                switch (opcion)
                {
                    case 0:
                        Console.WriteLine("Fin de programa");
                        palabras.guardado_salida();
                        break;
                    case 1:
                        palabras.crear_palabra();
                        break;
                    case 2:
                        palabras.buscar_palabra();
                        break;
                    case 3:
                        Console.WriteLine("¿Cual es el id de la palabra para borrar?");
                        idBuscar = Convert.ToInt32(Console.ReadLine());
                        palabras.eliminar_palabra(idBuscar);
                        break;
                    case 4:
                        palabras.vaciar_palabras();
                        break;
                    case 5:
                        palabras.mostrar_palabras();
                        break;
                    case 6:
                        palabras.mostrar_palabra_aleatoria();
                        break;
                    case 7:
                        palabras.gestionar_fichero();
                        break;
                }
            } while (opcion != 0);
        }
    }
}
