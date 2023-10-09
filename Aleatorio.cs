using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_palabras_lista
{
    public class Aleatorio
    {
        private Random random = new Random();
        private int numAleatorio;

        public void generar_palabra_aleatoria(List<Palabra> palabras)
        {
            numAleatorio = aleatorio(palabras.Count);

            if (palabras[numAleatorio] != null)
            {
                Console.WriteLine("ID: " + palabras[numAleatorio].Id + ", palabra: " + palabras[numAleatorio].PalabrA);
            }
            else
            {
                Console.WriteLine("No hay ningun dato");
            }

        }

        public int aleatorio(int numAleatorio)
        {
            return random.Next(numAleatorio);
        }

    }
}
